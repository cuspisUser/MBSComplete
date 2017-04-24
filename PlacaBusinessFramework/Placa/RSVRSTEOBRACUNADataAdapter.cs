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

    public class RSVRSTEOBRACUNADataAdapter : IDataAdapter, IRSVRSTEOBRACUNADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmRSVRSTEOBRACUNASelect1;
        private ReadWriteCommand cmRSVRSTEOBRACUNASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVRSVRSTEOBRACUNAOriginal;
        private readonly string m_SelectString29 = "TM1.[IDRSVRSTEOBRACUNA], TM1.[NAZIVRSVRSTEOBRACUNA]";
        private string m_WhereString;
        private short RcdFound29;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow rowRSVRSTEOBRACUNA;
        private IDataReader RSVRSTEOBRACUNASelect1;
        private IDataReader RSVRSTEOBRACUNASelect4;
        private RSVRSTEOBRACUNADataSet RSVRSTEOBRACUNASet;
        private string scmdbuf;
        private StatementType sMode29;

        public event RSVRSTEOBRACUNAUpdateEventHandler RSVRSTEOBRACUNAUpdated;

        public event RSVRSTEOBRACUNAUpdateEventHandler RSVRSTEOBRACUNAUpdating;

        private void AddRowRsvrsteobracuna()
        {
            this.RSVRSTEOBRACUNASet.RSVRSTEOBRACUNA.AddRSVRSTEOBRACUNARow(this.rowRSVRSTEOBRACUNA);
        }

        private void AfterConfirmRsvrsteobracuna()
        {
            this.OnRSVRSTEOBRACUNAUpdating(new RSVRSTEOBRACUNAEventArgs(this.rowRSVRSTEOBRACUNA, this.Gx_mode));
        }

        private void CheckDeleteErrorsRsvrsteobracuna()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDENTIFIKATOROBRASCA] FROM [RSMA] WITH (NOLOCK) WHERE [IDRSVRSTEOBRACUNA] = @IDRSVRSTEOBRACUNA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBRACUNA", DbType.String, 2));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBRACUNA["IDRSVRSTEOBRACUNA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RSMAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RSMA" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyRsvrsteobracuna()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRSVRSTEOBRACUNA], [NAZIVRSVRSTEOBRACUNA] FROM [RSVRSTEOBRACUNA] WITH (UPDLOCK) WHERE [IDRSVRSTEOBRACUNA] = @IDRSVRSTEOBRACUNA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBRACUNA", DbType.String, 2));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBRACUNA["IDRSVRSTEOBRACUNA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RSVRSTEOBRACUNADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RSVRSTEOBRACUNA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVRSVRSTEOBRACUNAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new RSVRSTEOBRACUNADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RSVRSTEOBRACUNA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowRsvrsteobracuna()
        {
            this.rowRSVRSTEOBRACUNA = this.RSVRSTEOBRACUNASet.RSVRSTEOBRACUNA.NewRSVRSTEOBRACUNARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRsvrsteobracuna();
            this.AfterConfirmRsvrsteobracuna();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RSVRSTEOBRACUNA]  WHERE [IDRSVRSTEOBRACUNA] = @IDRSVRSTEOBRACUNA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBRACUNA", DbType.String, 2));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBRACUNA["IDRSVRSTEOBRACUNA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsRsvrsteobracuna();
            }
            this.OnRSVRSTEOBRACUNAUpdated(new RSVRSTEOBRACUNAEventArgs(this.rowRSVRSTEOBRACUNA, StatementType.Delete));
            this.rowRSVRSTEOBRACUNA.Delete();
            this.sMode29 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode29;
        }


        public virtual int Fill(RSVRSTEOBRACUNADataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, this.fillDataParameters[0].Value.ToString());
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.RSVRSTEOBRACUNASet = dataSet;
                    this.LoadChildRsvrsteobracuna(0, -1);
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
            this.RSVRSTEOBRACUNASet = (RSVRSTEOBRACUNADataSet) dataSet;
            if (this.RSVRSTEOBRACUNASet != null)
            {
                return this.Fill(this.RSVRSTEOBRACUNASet);
            }
            this.RSVRSTEOBRACUNASet = new RSVRSTEOBRACUNADataSet();
            this.Fill(this.RSVRSTEOBRACUNASet);
            dataSet.Merge(this.RSVRSTEOBRACUNASet);
            return 0;
        }

        public virtual int Fill(RSVRSTEOBRACUNADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["IDRSVRSTEOBRACUNA"]));
        }

        public virtual int Fill(RSVRSTEOBRACUNADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["IDRSVRSTEOBRACUNA"]));
        }

        public virtual int Fill(RSVRSTEOBRACUNADataSet dataSet, string iDRSVRSTEOBRACUNA)
        {
            if (!this.FillByIDRSVRSTEOBRACUNA(dataSet, iDRSVRSTEOBRACUNA))
            {
                throw new RSVRSTEOBRACUNANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RSVRSTEOBRACUNA") }));
            }
            return 0;
        }

        public virtual bool FillByIDRSVRSTEOBRACUNA(RSVRSTEOBRACUNADataSet dataSet, string iDRSVRSTEOBRACUNA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RSVRSTEOBRACUNASet = dataSet;
            this.rowRSVRSTEOBRACUNA = this.RSVRSTEOBRACUNASet.RSVRSTEOBRACUNA.NewRSVRSTEOBRACUNARow();
            this.rowRSVRSTEOBRACUNA.IDRSVRSTEOBRACUNA = iDRSVRSTEOBRACUNA;
            try
            {
                this.LoadByIDRSVRSTEOBRACUNA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound29 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(RSVRSTEOBRACUNADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RSVRSTEOBRACUNASet = dataSet;
            try
            {
                this.LoadChildRsvrsteobracuna(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRSVRSTEOBRACUNA], [NAZIVRSVRSTEOBRACUNA] FROM [RSVRSTEOBRACUNA] WITH (NOLOCK) WHERE [IDRSVRSTEOBRACUNA] = @IDRSVRSTEOBRACUNA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBRACUNA", DbType.String, 2));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBRACUNA["IDRSVRSTEOBRACUNA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound29 = 1;
                this.rowRSVRSTEOBRACUNA["IDRSVRSTEOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowRSVRSTEOBRACUNA["NAZIVRSVRSTEOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode29 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode29;
            }
            else
            {
                this.RcdFound29 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDRSVRSTEOBRACUNA";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRSVRSTEOBRACUNASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RSVRSTEOBRACUNA] WITH (NOLOCK) ", false);
            this.RSVRSTEOBRACUNASelect1 = this.cmRSVRSTEOBRACUNASelect1.FetchData();
            if (this.RSVRSTEOBRACUNASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RSVRSTEOBRACUNASelect1.GetInt32(0);
            }
            this.RSVRSTEOBRACUNASelect1.Close();
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
            this.RcdFound29 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVRSVRSTEOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.RSVRSTEOBRACUNASet = new RSVRSTEOBRACUNADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertRsvrsteobracuna()
        {
            this.CheckOptimisticConcurrencyRsvrsteobracuna();
            this.AfterConfirmRsvrsteobracuna();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RSVRSTEOBRACUNA] ([IDRSVRSTEOBRACUNA], [NAZIVRSVRSTEOBRACUNA]) VALUES (@IDRSVRSTEOBRACUNA, @NAZIVRSVRSTEOBRACUNA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBRACUNA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVRSVRSTEOBRACUNA", DbType.String, 100));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBRACUNA["IDRSVRSTEOBRACUNA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBRACUNA["NAZIVRSVRSTEOBRACUNA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RSVRSTEOBRACUNADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnRSVRSTEOBRACUNAUpdated(new RSVRSTEOBRACUNAEventArgs(this.rowRSVRSTEOBRACUNA, StatementType.Insert));
        }

        private void LoadByIDRSVRSTEOBRACUNA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RSVRSTEOBRACUNASet.EnforceConstraints;
            this.RSVRSTEOBRACUNASet.RSVRSTEOBRACUNA.BeginLoadData();
            this.ScanByIDRSVRSTEOBRACUNA(startRow, maxRows);
            this.RSVRSTEOBRACUNASet.RSVRSTEOBRACUNA.EndLoadData();
            this.RSVRSTEOBRACUNASet.EnforceConstraints = enforceConstraints;
            if (this.RSVRSTEOBRACUNASet.RSVRSTEOBRACUNA.Count > 0)
            {
                this.rowRSVRSTEOBRACUNA = this.RSVRSTEOBRACUNASet.RSVRSTEOBRACUNA[this.RSVRSTEOBRACUNASet.RSVRSTEOBRACUNA.Count - 1];
            }
        }

        private void LoadChildRsvrsteobracuna(int startRow, int maxRows)
        {
            this.CreateNewRowRsvrsteobracuna();
            bool enforceConstraints = this.RSVRSTEOBRACUNASet.EnforceConstraints;
            this.RSVRSTEOBRACUNASet.RSVRSTEOBRACUNA.BeginLoadData();
            this.ScanStartRsvrsteobracuna(startRow, maxRows);
            this.RSVRSTEOBRACUNASet.RSVRSTEOBRACUNA.EndLoadData();
            this.RSVRSTEOBRACUNASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataRsvrsteobracuna(int maxRows)
        {
            int num = 0;
            if (this.RcdFound29 != 0)
            {
                this.ScanLoadRsvrsteobracuna();
                while ((this.RcdFound29 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowRsvrsteobracuna();
                    this.CreateNewRowRsvrsteobracuna();
                    this.ScanNextRsvrsteobracuna();
                }
            }
            if (num > 0)
            {
                this.RcdFound29 = 1;
            }
            this.ScanEndRsvrsteobracuna();
            if (this.RSVRSTEOBRACUNASet.RSVRSTEOBRACUNA.Count > 0)
            {
                this.rowRSVRSTEOBRACUNA = this.RSVRSTEOBRACUNASet.RSVRSTEOBRACUNA[this.RSVRSTEOBRACUNASet.RSVRSTEOBRACUNA.Count - 1];
            }
        }

        private void LoadRowRsvrsteobracuna()
        {
            this.AddRowRsvrsteobracuna();
        }

        private void OnRSVRSTEOBRACUNAUpdated(RSVRSTEOBRACUNAEventArgs e)
        {
            if (this.RSVRSTEOBRACUNAUpdated != null)
            {
                RSVRSTEOBRACUNAUpdateEventHandler rSVRSTEOBRACUNAUpdatedEvent = this.RSVRSTEOBRACUNAUpdated;
                if (rSVRSTEOBRACUNAUpdatedEvent != null)
                {
                    rSVRSTEOBRACUNAUpdatedEvent(this, e);
                }
            }
        }

        private void OnRSVRSTEOBRACUNAUpdating(RSVRSTEOBRACUNAEventArgs e)
        {
            if (this.RSVRSTEOBRACUNAUpdating != null)
            {
                RSVRSTEOBRACUNAUpdateEventHandler rSVRSTEOBRACUNAUpdatingEvent = this.RSVRSTEOBRACUNAUpdating;
                if (rSVRSTEOBRACUNAUpdatingEvent != null)
                {
                    rSVRSTEOBRACUNAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowRsvrsteobracuna()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRSVRSTEOBRACUNA.RowState);
            if (this.rowRSVRSTEOBRACUNA.RowState != DataRowState.Added)
            {
                this.m__NAZIVRSVRSTEOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBRACUNA["NAZIVRSVRSTEOBRACUNA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVRSVRSTEOBRACUNAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBRACUNA["NAZIVRSVRSTEOBRACUNA"]);
            }
            this._Gxremove = this.rowRSVRSTEOBRACUNA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowRSVRSTEOBRACUNA = (RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow) DataSetUtil.CloneOriginalDataRow(this.rowRSVRSTEOBRACUNA);
            }
        }

        private void ScanByIDRSVRSTEOBRACUNA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDRSVRSTEOBRACUNA] = @IDRSVRSTEOBRACUNA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString29 + "  FROM [RSVRSTEOBRACUNA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRSVRSTEOBRACUNA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString29, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRSVRSTEOBRACUNA] ) AS DK_PAGENUM   FROM [RSVRSTEOBRACUNA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString29 + " FROM [RSVRSTEOBRACUNA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRSVRSTEOBRACUNA] ";
            }
            this.cmRSVRSTEOBRACUNASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRSVRSTEOBRACUNASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmRSVRSTEOBRACUNASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBRACUNA", DbType.String, 2));
            }
            this.cmRSVRSTEOBRACUNASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBRACUNA["IDRSVRSTEOBRACUNA"]));
            this.RSVRSTEOBRACUNASelect4 = this.cmRSVRSTEOBRACUNASelect4.FetchData();
            this.RcdFound29 = 0;
            this.ScanLoadRsvrsteobracuna();
            this.LoadDataRsvrsteobracuna(maxRows);
        }

        private void ScanEndRsvrsteobracuna()
        {
            this.RSVRSTEOBRACUNASelect4.Close();
        }

        private void ScanLoadRsvrsteobracuna()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRSVRSTEOBRACUNASelect4.HasMoreRows)
            {
                this.RcdFound29 = 1;
                this.rowRSVRSTEOBRACUNA["IDRSVRSTEOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSVRSTEOBRACUNASelect4, 0));
                this.rowRSVRSTEOBRACUNA["NAZIVRSVRSTEOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSVRSTEOBRACUNASelect4, 1));
            }
        }

        private void ScanNextRsvrsteobracuna()
        {
            this.cmRSVRSTEOBRACUNASelect4.HasMoreRows = this.RSVRSTEOBRACUNASelect4.Read();
            this.RcdFound29 = 0;
            this.ScanLoadRsvrsteobracuna();
        }

        private void ScanStartRsvrsteobracuna(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString29 + "  FROM [RSVRSTEOBRACUNA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRSVRSTEOBRACUNA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString29, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRSVRSTEOBRACUNA] ) AS DK_PAGENUM   FROM [RSVRSTEOBRACUNA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString29 + " FROM [RSVRSTEOBRACUNA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRSVRSTEOBRACUNA] ";
            }
            this.cmRSVRSTEOBRACUNASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.RSVRSTEOBRACUNASelect4 = this.cmRSVRSTEOBRACUNASelect4.FetchData();
            this.RcdFound29 = 0;
            this.ScanLoadRsvrsteobracuna();
            this.LoadDataRsvrsteobracuna(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.RSVRSTEOBRACUNASet = (RSVRSTEOBRACUNADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.RSVRSTEOBRACUNASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.RSVRSTEOBRACUNASet.RSVRSTEOBRACUNA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow current = (RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow) enumerator.Current;
                        this.rowRSVRSTEOBRACUNA = current;
                        if (Helpers.IsRowChanged(this.rowRSVRSTEOBRACUNA))
                        {
                            this.ReadRowRsvrsteobracuna();
                            if (this.rowRSVRSTEOBRACUNA.RowState == DataRowState.Added)
                            {
                                this.InsertRsvrsteobracuna();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateRsvrsteobracuna();
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

        private void UpdateRsvrsteobracuna()
        {
            this.CheckOptimisticConcurrencyRsvrsteobracuna();
            this.AfterConfirmRsvrsteobracuna();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [RSVRSTEOBRACUNA] SET [NAZIVRSVRSTEOBRACUNA]=@NAZIVRSVRSTEOBRACUNA  WHERE [IDRSVRSTEOBRACUNA] = @IDRSVRSTEOBRACUNA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVRSVRSTEOBRACUNA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBRACUNA", DbType.String, 2));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBRACUNA["NAZIVRSVRSTEOBRACUNA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBRACUNA["IDRSVRSTEOBRACUNA"]));
            command.ExecuteStmt();
            this.OnRSVRSTEOBRACUNAUpdated(new RSVRSTEOBRACUNAEventArgs(this.rowRSVRSTEOBRACUNA, StatementType.Update));
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
        public class RSMAInvalidDeleteException : InvalidDeleteException
        {
            public RSMAInvalidDeleteException()
            {
            }

            public RSMAInvalidDeleteException(string message) : base(message)
            {
            }

            protected RSMAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RSMAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RSVRSTEOBRACUNADataChangedException : DataChangedException
        {
            public RSVRSTEOBRACUNADataChangedException()
            {
            }

            public RSVRSTEOBRACUNADataChangedException(string message) : base(message)
            {
            }

            protected RSVRSTEOBRACUNADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RSVRSTEOBRACUNADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RSVRSTEOBRACUNADataLockedException : DataLockedException
        {
            public RSVRSTEOBRACUNADataLockedException()
            {
            }

            public RSVRSTEOBRACUNADataLockedException(string message) : base(message)
            {
            }

            protected RSVRSTEOBRACUNADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RSVRSTEOBRACUNADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RSVRSTEOBRACUNADuplicateKeyException : DuplicateKeyException
        {
            public RSVRSTEOBRACUNADuplicateKeyException()
            {
            }

            public RSVRSTEOBRACUNADuplicateKeyException(string message) : base(message)
            {
            }

            protected RSVRSTEOBRACUNADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RSVRSTEOBRACUNADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RSVRSTEOBRACUNAEventArgs : EventArgs
        {
            private RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RSVRSTEOBRACUNAEventArgs(RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow Row
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
        public class RSVRSTEOBRACUNANotFoundException : DataNotFoundException
        {
            public RSVRSTEOBRACUNANotFoundException()
            {
            }

            public RSVRSTEOBRACUNANotFoundException(string message) : base(message)
            {
            }

            protected RSVRSTEOBRACUNANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RSVRSTEOBRACUNANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void RSVRSTEOBRACUNAUpdateEventHandler(object sender, RSVRSTEOBRACUNADataAdapter.RSVRSTEOBRACUNAEventArgs e);
    }
}

