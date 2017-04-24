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

    public class RSVRSTEOBVEZNIKADataAdapter : IDataAdapter, IRSVRSTEOBVEZNIKADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmRSVRSTEOBVEZNIKASelect1;
        private ReadWriteCommand cmRSVRSTEOBVEZNIKASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVRSVRSTEOBVEZNIKAOriginal;
        private readonly string m_SelectString30 = "TM1.[IDRSVRSTEOBVEZNIKA], TM1.[NAZIVRSVRSTEOBVEZNIKA]";
        private string m_WhereString;
        private short RcdFound30;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow rowRSVRSTEOBVEZNIKA;
        private IDataReader RSVRSTEOBVEZNIKASelect1;
        private IDataReader RSVRSTEOBVEZNIKASelect4;
        private RSVRSTEOBVEZNIKADataSet RSVRSTEOBVEZNIKASet;
        private string scmdbuf;
        private StatementType sMode30;

        public event RSVRSTEOBVEZNIKAUpdateEventHandler RSVRSTEOBVEZNIKAUpdated;

        public event RSVRSTEOBVEZNIKAUpdateEventHandler RSVRSTEOBVEZNIKAUpdating;

        private void AddRowRsvrsteobveznika()
        {
            this.RSVRSTEOBVEZNIKASet.RSVRSTEOBVEZNIKA.AddRSVRSTEOBVEZNIKARow(this.rowRSVRSTEOBVEZNIKA);
        }

        private void AfterConfirmRsvrsteobveznika()
        {
            this.OnRSVRSTEOBVEZNIKAUpdating(new RSVRSTEOBVEZNIKAEventArgs(this.rowRSVRSTEOBVEZNIKA, this.Gx_mode));
        }

        private void CheckDeleteErrorsRsvrsteobveznika()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDENTIFIKATOROBRASCA] FROM [RSMA] WITH (NOLOCK) WHERE [IDRSVRSTEOBVEZNIKA] = @IDRSVRSTEOBVEZNIKA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBVEZNIKA", DbType.String, 2));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBVEZNIKA["IDRSVRSTEOBVEZNIKA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RSMAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RSMA" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyRsvrsteobveznika()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRSVRSTEOBVEZNIKA], [NAZIVRSVRSTEOBVEZNIKA] FROM [RSVRSTEOBVEZNIKA] WITH (UPDLOCK) WHERE [IDRSVRSTEOBVEZNIKA] = @IDRSVRSTEOBVEZNIKA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBVEZNIKA", DbType.String, 2));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBVEZNIKA["IDRSVRSTEOBVEZNIKA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RSVRSTEOBVEZNIKADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RSVRSTEOBVEZNIKA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVRSVRSTEOBVEZNIKAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new RSVRSTEOBVEZNIKADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RSVRSTEOBVEZNIKA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowRsvrsteobveznika()
        {
            this.rowRSVRSTEOBVEZNIKA = this.RSVRSTEOBVEZNIKASet.RSVRSTEOBVEZNIKA.NewRSVRSTEOBVEZNIKARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRsvrsteobveznika();
            this.AfterConfirmRsvrsteobveznika();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RSVRSTEOBVEZNIKA]  WHERE [IDRSVRSTEOBVEZNIKA] = @IDRSVRSTEOBVEZNIKA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBVEZNIKA", DbType.String, 2));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBVEZNIKA["IDRSVRSTEOBVEZNIKA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsRsvrsteobveznika();
            }
            this.OnRSVRSTEOBVEZNIKAUpdated(new RSVRSTEOBVEZNIKAEventArgs(this.rowRSVRSTEOBVEZNIKA, StatementType.Delete));
            this.rowRSVRSTEOBVEZNIKA.Delete();
            this.sMode30 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode30;
        }

        public virtual int Fill(RSVRSTEOBVEZNIKADataSet dataSet)
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
                    this.RSVRSTEOBVEZNIKASet = dataSet;
                    this.LoadChildRsvrsteobveznika(0, -1);
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
            this.RSVRSTEOBVEZNIKASet = (RSVRSTEOBVEZNIKADataSet) dataSet;
            if (this.RSVRSTEOBVEZNIKASet != null)
            {
                return this.Fill(this.RSVRSTEOBVEZNIKASet);
            }
            this.RSVRSTEOBVEZNIKASet = new RSVRSTEOBVEZNIKADataSet();
            this.Fill(this.RSVRSTEOBVEZNIKASet);
            dataSet.Merge(this.RSVRSTEOBVEZNIKASet);
            return 0;
        }

        public virtual int Fill(RSVRSTEOBVEZNIKADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["IDRSVRSTEOBVEZNIKA"]));
        }

        public virtual int Fill(RSVRSTEOBVEZNIKADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["IDRSVRSTEOBVEZNIKA"]));
        }

        public virtual int Fill(RSVRSTEOBVEZNIKADataSet dataSet, string iDRSVRSTEOBVEZNIKA)
        {
            if (!this.FillByIDRSVRSTEOBVEZNIKA(dataSet, iDRSVRSTEOBVEZNIKA))
            {
                throw new RSVRSTEOBVEZNIKANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RSVRSTEOBVEZNIKA") }));
            }
            return 0;
        }

        public virtual bool FillByIDRSVRSTEOBVEZNIKA(RSVRSTEOBVEZNIKADataSet dataSet, string iDRSVRSTEOBVEZNIKA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RSVRSTEOBVEZNIKASet = dataSet;
            this.rowRSVRSTEOBVEZNIKA = this.RSVRSTEOBVEZNIKASet.RSVRSTEOBVEZNIKA.NewRSVRSTEOBVEZNIKARow();
            this.rowRSVRSTEOBVEZNIKA.IDRSVRSTEOBVEZNIKA = iDRSVRSTEOBVEZNIKA;
            try
            {
                this.LoadByIDRSVRSTEOBVEZNIKA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound30 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(RSVRSTEOBVEZNIKADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RSVRSTEOBVEZNIKASet = dataSet;
            try
            {
                this.LoadChildRsvrsteobveznika(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRSVRSTEOBVEZNIKA], [NAZIVRSVRSTEOBVEZNIKA] FROM [RSVRSTEOBVEZNIKA] WITH (NOLOCK) WHERE [IDRSVRSTEOBVEZNIKA] = @IDRSVRSTEOBVEZNIKA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBVEZNIKA", DbType.String, 2));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBVEZNIKA["IDRSVRSTEOBVEZNIKA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound30 = 1;
                this.rowRSVRSTEOBVEZNIKA["IDRSVRSTEOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowRSVRSTEOBVEZNIKA["NAZIVRSVRSTEOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode30 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode30;
            }
            else
            {
                this.RcdFound30 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDRSVRSTEOBVEZNIKA";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRSVRSTEOBVEZNIKASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RSVRSTEOBVEZNIKA] WITH (NOLOCK) ", false);
            this.RSVRSTEOBVEZNIKASelect1 = this.cmRSVRSTEOBVEZNIKASelect1.FetchData();
            if (this.RSVRSTEOBVEZNIKASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RSVRSTEOBVEZNIKASelect1.GetInt32(0);
            }
            this.RSVRSTEOBVEZNIKASelect1.Close();
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
            this.RcdFound30 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVRSVRSTEOBVEZNIKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.RSVRSTEOBVEZNIKASet = new RSVRSTEOBVEZNIKADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertRsvrsteobveznika()
        {
            this.CheckOptimisticConcurrencyRsvrsteobveznika();
            this.AfterConfirmRsvrsteobveznika();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RSVRSTEOBVEZNIKA] ([IDRSVRSTEOBVEZNIKA], [NAZIVRSVRSTEOBVEZNIKA]) VALUES (@IDRSVRSTEOBVEZNIKA, @NAZIVRSVRSTEOBVEZNIKA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBVEZNIKA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVRSVRSTEOBVEZNIKA", DbType.String, 100));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBVEZNIKA["IDRSVRSTEOBVEZNIKA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBVEZNIKA["NAZIVRSVRSTEOBVEZNIKA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RSVRSTEOBVEZNIKADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnRSVRSTEOBVEZNIKAUpdated(new RSVRSTEOBVEZNIKAEventArgs(this.rowRSVRSTEOBVEZNIKA, StatementType.Insert));
        }

        private void LoadByIDRSVRSTEOBVEZNIKA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RSVRSTEOBVEZNIKASet.EnforceConstraints;
            this.RSVRSTEOBVEZNIKASet.RSVRSTEOBVEZNIKA.BeginLoadData();
            this.ScanByIDRSVRSTEOBVEZNIKA(startRow, maxRows);
            this.RSVRSTEOBVEZNIKASet.RSVRSTEOBVEZNIKA.EndLoadData();
            this.RSVRSTEOBVEZNIKASet.EnforceConstraints = enforceConstraints;
            if (this.RSVRSTEOBVEZNIKASet.RSVRSTEOBVEZNIKA.Count > 0)
            {
                this.rowRSVRSTEOBVEZNIKA = this.RSVRSTEOBVEZNIKASet.RSVRSTEOBVEZNIKA[this.RSVRSTEOBVEZNIKASet.RSVRSTEOBVEZNIKA.Count - 1];
            }
        }

        private void LoadChildRsvrsteobveznika(int startRow, int maxRows)
        {
            this.CreateNewRowRsvrsteobveznika();
            bool enforceConstraints = this.RSVRSTEOBVEZNIKASet.EnforceConstraints;
            this.RSVRSTEOBVEZNIKASet.RSVRSTEOBVEZNIKA.BeginLoadData();
            this.ScanStartRsvrsteobveznika(startRow, maxRows);
            this.RSVRSTEOBVEZNIKASet.RSVRSTEOBVEZNIKA.EndLoadData();
            this.RSVRSTEOBVEZNIKASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataRsvrsteobveznika(int maxRows)
        {
            int num = 0;
            if (this.RcdFound30 != 0)
            {
                this.ScanLoadRsvrsteobveznika();
                while ((this.RcdFound30 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowRsvrsteobveznika();
                    this.CreateNewRowRsvrsteobveznika();
                    this.ScanNextRsvrsteobveznika();
                }
            }
            if (num > 0)
            {
                this.RcdFound30 = 1;
            }
            this.ScanEndRsvrsteobveznika();
            if (this.RSVRSTEOBVEZNIKASet.RSVRSTEOBVEZNIKA.Count > 0)
            {
                this.rowRSVRSTEOBVEZNIKA = this.RSVRSTEOBVEZNIKASet.RSVRSTEOBVEZNIKA[this.RSVRSTEOBVEZNIKASet.RSVRSTEOBVEZNIKA.Count - 1];
            }
        }

        private void LoadRowRsvrsteobveznika()
        {
            this.AddRowRsvrsteobveznika();
        }

        private void OnRSVRSTEOBVEZNIKAUpdated(RSVRSTEOBVEZNIKAEventArgs e)
        {
            if (this.RSVRSTEOBVEZNIKAUpdated != null)
            {
                RSVRSTEOBVEZNIKAUpdateEventHandler rSVRSTEOBVEZNIKAUpdatedEvent = this.RSVRSTEOBVEZNIKAUpdated;
                if (rSVRSTEOBVEZNIKAUpdatedEvent != null)
                {
                    rSVRSTEOBVEZNIKAUpdatedEvent(this, e);
                }
            }
        }

        private void OnRSVRSTEOBVEZNIKAUpdating(RSVRSTEOBVEZNIKAEventArgs e)
        {
            if (this.RSVRSTEOBVEZNIKAUpdating != null)
            {
                RSVRSTEOBVEZNIKAUpdateEventHandler rSVRSTEOBVEZNIKAUpdatingEvent = this.RSVRSTEOBVEZNIKAUpdating;
                if (rSVRSTEOBVEZNIKAUpdatingEvent != null)
                {
                    rSVRSTEOBVEZNIKAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowRsvrsteobveznika()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRSVRSTEOBVEZNIKA.RowState);
            if (this.rowRSVRSTEOBVEZNIKA.RowState != DataRowState.Added)
            {
                this.m__NAZIVRSVRSTEOBVEZNIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBVEZNIKA["NAZIVRSVRSTEOBVEZNIKA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVRSVRSTEOBVEZNIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBVEZNIKA["NAZIVRSVRSTEOBVEZNIKA"]);
            }
            this._Gxremove = this.rowRSVRSTEOBVEZNIKA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowRSVRSTEOBVEZNIKA = (RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow) DataSetUtil.CloneOriginalDataRow(this.rowRSVRSTEOBVEZNIKA);
            }
        }

        private void ScanByIDRSVRSTEOBVEZNIKA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDRSVRSTEOBVEZNIKA] = @IDRSVRSTEOBVEZNIKA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString30 + "  FROM [RSVRSTEOBVEZNIKA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRSVRSTEOBVEZNIKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString30, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRSVRSTEOBVEZNIKA] ) AS DK_PAGENUM   FROM [RSVRSTEOBVEZNIKA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString30 + " FROM [RSVRSTEOBVEZNIKA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRSVRSTEOBVEZNIKA] ";
            }
            this.cmRSVRSTEOBVEZNIKASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRSVRSTEOBVEZNIKASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmRSVRSTEOBVEZNIKASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBVEZNIKA", DbType.String, 2));
            }
            this.cmRSVRSTEOBVEZNIKASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBVEZNIKA["IDRSVRSTEOBVEZNIKA"]));
            this.RSVRSTEOBVEZNIKASelect4 = this.cmRSVRSTEOBVEZNIKASelect4.FetchData();
            this.RcdFound30 = 0;
            this.ScanLoadRsvrsteobveznika();
            this.LoadDataRsvrsteobveznika(maxRows);
        }

        private void ScanEndRsvrsteobveznika()
        {
            this.RSVRSTEOBVEZNIKASelect4.Close();
        }

        private void ScanLoadRsvrsteobveznika()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRSVRSTEOBVEZNIKASelect4.HasMoreRows)
            {
                this.RcdFound30 = 1;
                this.rowRSVRSTEOBVEZNIKA["IDRSVRSTEOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSVRSTEOBVEZNIKASelect4, 0));
                this.rowRSVRSTEOBVEZNIKA["NAZIVRSVRSTEOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RSVRSTEOBVEZNIKASelect4, 1));
            }
        }

        private void ScanNextRsvrsteobveznika()
        {
            this.cmRSVRSTEOBVEZNIKASelect4.HasMoreRows = this.RSVRSTEOBVEZNIKASelect4.Read();
            this.RcdFound30 = 0;
            this.ScanLoadRsvrsteobveznika();
        }

        private void ScanStartRsvrsteobveznika(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString30 + "  FROM [RSVRSTEOBVEZNIKA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRSVRSTEOBVEZNIKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString30, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRSVRSTEOBVEZNIKA] ) AS DK_PAGENUM   FROM [RSVRSTEOBVEZNIKA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString30 + " FROM [RSVRSTEOBVEZNIKA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRSVRSTEOBVEZNIKA] ";
            }
            this.cmRSVRSTEOBVEZNIKASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.RSVRSTEOBVEZNIKASelect4 = this.cmRSVRSTEOBVEZNIKASelect4.FetchData();
            this.RcdFound30 = 0;
            this.ScanLoadRsvrsteobveznika();
            this.LoadDataRsvrsteobveznika(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.RSVRSTEOBVEZNIKASet = (RSVRSTEOBVEZNIKADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.RSVRSTEOBVEZNIKASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.RSVRSTEOBVEZNIKASet.RSVRSTEOBVEZNIKA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow current = (RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow) enumerator.Current;
                        this.rowRSVRSTEOBVEZNIKA = current;
                        if (Helpers.IsRowChanged(this.rowRSVRSTEOBVEZNIKA))
                        {
                            this.ReadRowRsvrsteobveznika();
                            if (this.rowRSVRSTEOBVEZNIKA.RowState == DataRowState.Added)
                            {
                                this.InsertRsvrsteobveznika();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateRsvrsteobveznika();
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

        private void UpdateRsvrsteobveznika()
        {
            this.CheckOptimisticConcurrencyRsvrsteobveznika();
            this.AfterConfirmRsvrsteobveznika();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [RSVRSTEOBVEZNIKA] SET [NAZIVRSVRSTEOBVEZNIKA]=@NAZIVRSVRSTEOBVEZNIKA  WHERE [IDRSVRSTEOBVEZNIKA] = @IDRSVRSTEOBVEZNIKA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVRSVRSTEOBVEZNIKA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRSVRSTEOBVEZNIKA", DbType.String, 2));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBVEZNIKA["NAZIVRSVRSTEOBVEZNIKA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRSVRSTEOBVEZNIKA["IDRSVRSTEOBVEZNIKA"]));
            command.ExecuteStmt();
            this.OnRSVRSTEOBVEZNIKAUpdated(new RSVRSTEOBVEZNIKAEventArgs(this.rowRSVRSTEOBVEZNIKA, StatementType.Update));
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
        public class RSVRSTEOBVEZNIKADataChangedException : DataChangedException
        {
            public RSVRSTEOBVEZNIKADataChangedException()
            {
            }

            public RSVRSTEOBVEZNIKADataChangedException(string message) : base(message)
            {
            }

            protected RSVRSTEOBVEZNIKADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RSVRSTEOBVEZNIKADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RSVRSTEOBVEZNIKADataLockedException : DataLockedException
        {
            public RSVRSTEOBVEZNIKADataLockedException()
            {
            }

            public RSVRSTEOBVEZNIKADataLockedException(string message) : base(message)
            {
            }

            protected RSVRSTEOBVEZNIKADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RSVRSTEOBVEZNIKADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RSVRSTEOBVEZNIKADuplicateKeyException : DuplicateKeyException
        {
            public RSVRSTEOBVEZNIKADuplicateKeyException()
            {
            }

            public RSVRSTEOBVEZNIKADuplicateKeyException(string message) : base(message)
            {
            }

            protected RSVRSTEOBVEZNIKADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RSVRSTEOBVEZNIKADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RSVRSTEOBVEZNIKAEventArgs : EventArgs
        {
            private RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RSVRSTEOBVEZNIKAEventArgs(RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow Row
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
        public class RSVRSTEOBVEZNIKANotFoundException : DataNotFoundException
        {
            public RSVRSTEOBVEZNIKANotFoundException()
            {
            }

            public RSVRSTEOBVEZNIKANotFoundException(string message) : base(message)
            {
            }

            protected RSVRSTEOBVEZNIKANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RSVRSTEOBVEZNIKANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void RSVRSTEOBVEZNIKAUpdateEventHandler(object sender, RSVRSTEOBVEZNIKADataAdapter.RSVRSTEOBVEZNIKAEventArgs e);
    }
}

