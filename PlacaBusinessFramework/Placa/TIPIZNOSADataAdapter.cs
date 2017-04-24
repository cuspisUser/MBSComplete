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

    public class TIPIZNOSADataAdapter : IDataAdapter, ITIPIZNOSADataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private ReadWriteCommand cmTIPIZNOSASelect1;
        private ReadWriteCommand cmTIPIZNOSASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__MOTIPAIZNOSAOriginal;
        private object m__OPISTIPAIZNOSAOriginal;
        private object m__OZNAKATIPAIZNOSAOriginal;
        private object m__POTIPAIZNOSAOriginal;
        private object m__VBDITIPAIZNOSAOriginal;
        private object m__ZIROTIPAIZNOSAOriginal;
        private readonly string m_SelectString36 = "TM1.[IDTIPAIZNOSA], TM1.[OPISTIPAIZNOSA], TM1.[OZNAKATIPAIZNOSA], TM1.[VBDITIPAIZNOSA], TM1.[ZIROTIPAIZNOSA], TM1.[MOTIPAIZNOSA], TM1.[POTIPAIZNOSA]";
        private string m_WhereString;
        private short RcdFound36;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private TIPIZNOSADataSet.TIPIZNOSARow rowTIPIZNOSA;
        private string scmdbuf;
        private StatementType sMode36;
        private IDataReader TIPIZNOSASelect1;
        private IDataReader TIPIZNOSASelect4;
        private TIPIZNOSADataSet TIPIZNOSASet;

        public event TIPIZNOSAUpdateEventHandler TIPIZNOSAUpdated;

        public event TIPIZNOSAUpdateEventHandler TIPIZNOSAUpdating;

        private void AddRowTipiznosa()
        {
            this.TIPIZNOSASet.TIPIZNOSA.AddTIPIZNOSARow(this.rowTIPIZNOSA);
        }

        private void AfterConfirmTipiznosa()
        {
            this.OnTIPIZNOSAUpdating(new TIPIZNOSAEventArgs(this.rowTIPIZNOSA, this.Gx_mode));
        }

        private void CheckOptimisticConcurrencyTipiznosa()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDTIPAIZNOSA], [OPISTIPAIZNOSA], [OZNAKATIPAIZNOSA], [VBDITIPAIZNOSA], [ZIROTIPAIZNOSA], [MOTIPAIZNOSA], [POTIPAIZNOSA] FROM [TIPIZNOSA] WITH (UPDLOCK) WHERE [IDTIPAIZNOSA] = @IDTIPAIZNOSA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPAIZNOSA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["IDTIPAIZNOSA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new TIPIZNOSADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("TIPIZNOSA") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPISTIPAIZNOSAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OZNAKATIPAIZNOSAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__VBDITIPAIZNOSAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZIROTIPAIZNOSAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MOTIPAIZNOSAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))
                {
                    this._Condition = true;
                }
                if (this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__POTIPAIZNOSAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6))))
                {
                    reader.Close();
                    throw new TIPIZNOSADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("TIPIZNOSA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowTipiznosa()
        {
            this.rowTIPIZNOSA = this.TIPIZNOSASet.TIPIZNOSA.NewTIPIZNOSARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyTipiznosa();
            this.AfterConfirmTipiznosa();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [TIPIZNOSA]  WHERE [IDTIPAIZNOSA] = @IDTIPAIZNOSA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPAIZNOSA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["IDTIPAIZNOSA"]));
            command.ExecuteStmt();
            this.OnTIPIZNOSAUpdated(new TIPIZNOSAEventArgs(this.rowTIPIZNOSA, StatementType.Delete));
            this.rowTIPIZNOSA.Delete();
            this.sMode36 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode36;
        }

        public virtual int Fill(TIPIZNOSADataSet dataSet)
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
                    this.TIPIZNOSASet = dataSet;
                    this.LoadChildTipiznosa(0, -1);
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
            this.TIPIZNOSASet = (TIPIZNOSADataSet) dataSet;
            if (this.TIPIZNOSASet != null)
            {
                return this.Fill(this.TIPIZNOSASet);
            }
            this.TIPIZNOSASet = new TIPIZNOSADataSet();
            this.Fill(this.TIPIZNOSASet);
            dataSet.Merge(this.TIPIZNOSASet);
            return 0;
        }

        public virtual int Fill(TIPIZNOSADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDTIPAIZNOSA"]));
        }

        public virtual int Fill(TIPIZNOSADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDTIPAIZNOSA"]));
        }

        public virtual int Fill(TIPIZNOSADataSet dataSet, int iDTIPAIZNOSA)
        {
            if (!this.FillByIDTIPAIZNOSA(dataSet, iDTIPAIZNOSA))
            {
                throw new TIPIZNOSANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("TIPIZNOSA") }));
            }
            return 0;
        }

        public virtual bool FillByIDTIPAIZNOSA(TIPIZNOSADataSet dataSet, int iDTIPAIZNOSA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.TIPIZNOSASet = dataSet;
            this.rowTIPIZNOSA = this.TIPIZNOSASet.TIPIZNOSA.NewTIPIZNOSARow();
            this.rowTIPIZNOSA.IDTIPAIZNOSA = iDTIPAIZNOSA;
            try
            {
                this.LoadByIDTIPAIZNOSA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound36 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(TIPIZNOSADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.TIPIZNOSASet = dataSet;
            try
            {
                this.LoadChildTipiznosa(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDTIPAIZNOSA], [OPISTIPAIZNOSA], [OZNAKATIPAIZNOSA], [VBDITIPAIZNOSA], [ZIROTIPAIZNOSA], [MOTIPAIZNOSA], [POTIPAIZNOSA] FROM [TIPIZNOSA] WITH (NOLOCK) WHERE [IDTIPAIZNOSA] = @IDTIPAIZNOSA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPAIZNOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["IDTIPAIZNOSA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound36 = 1;
                this.rowTIPIZNOSA["IDTIPAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowTIPIZNOSA["OPISTIPAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowTIPIZNOSA["OZNAKATIPAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowTIPIZNOSA["VBDITIPAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowTIPIZNOSA["ZIROTIPAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowTIPIZNOSA["MOTIPAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowTIPIZNOSA["POTIPAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.sMode36 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode36;
            }
            else
            {
                this.RcdFound36 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDTIPAIZNOSA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmTIPIZNOSASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [TIPIZNOSA] WITH (NOLOCK) ", false);
            this.TIPIZNOSASelect1 = this.cmTIPIZNOSASelect1.FetchData();
            if (this.TIPIZNOSASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.TIPIZNOSASelect1.GetInt32(0);
            }
            this.TIPIZNOSASelect1.Close();
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
            this.RcdFound36 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__OPISTIPAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OZNAKATIPAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__VBDITIPAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZIROTIPAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MOTIPAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POTIPAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Condition = false;
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.TIPIZNOSASet = new TIPIZNOSADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertTipiznosa()
        {
            this.CheckOptimisticConcurrencyTipiznosa();
            this.AfterConfirmTipiznosa();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [TIPIZNOSA] ([IDTIPAIZNOSA], [OPISTIPAIZNOSA], [OZNAKATIPAIZNOSA], [VBDITIPAIZNOSA], [ZIROTIPAIZNOSA], [MOTIPAIZNOSA], [POTIPAIZNOSA]) VALUES (@IDTIPAIZNOSA, @OPISTIPAIZNOSA, @OZNAKATIPAIZNOSA, @VBDITIPAIZNOSA, @ZIROTIPAIZNOSA, @MOTIPAIZNOSA, @POTIPAIZNOSA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPAIZNOSA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISTIPAIZNOSA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OZNAKATIPAIZNOSA", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDITIPAIZNOSA", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZIROTIPAIZNOSA", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOTIPAIZNOSA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POTIPAIZNOSA", DbType.String, 0x16));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["IDTIPAIZNOSA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["OPISTIPAIZNOSA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["OZNAKATIPAIZNOSA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["VBDITIPAIZNOSA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["ZIROTIPAIZNOSA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["MOTIPAIZNOSA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["POTIPAIZNOSA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new TIPIZNOSADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnTIPIZNOSAUpdated(new TIPIZNOSAEventArgs(this.rowTIPIZNOSA, StatementType.Insert));
        }

        private void LoadByIDTIPAIZNOSA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.TIPIZNOSASet.EnforceConstraints;
            this.TIPIZNOSASet.TIPIZNOSA.BeginLoadData();
            this.ScanByIDTIPAIZNOSA(startRow, maxRows);
            this.TIPIZNOSASet.TIPIZNOSA.EndLoadData();
            this.TIPIZNOSASet.EnforceConstraints = enforceConstraints;
            if (this.TIPIZNOSASet.TIPIZNOSA.Count > 0)
            {
                this.rowTIPIZNOSA = this.TIPIZNOSASet.TIPIZNOSA[this.TIPIZNOSASet.TIPIZNOSA.Count - 1];
            }
        }

        private void LoadChildTipiznosa(int startRow, int maxRows)
        {
            this.CreateNewRowTipiznosa();
            bool enforceConstraints = this.TIPIZNOSASet.EnforceConstraints;
            this.TIPIZNOSASet.TIPIZNOSA.BeginLoadData();
            this.ScanStartTipiznosa(startRow, maxRows);
            this.TIPIZNOSASet.TIPIZNOSA.EndLoadData();
            this.TIPIZNOSASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataTipiznosa(int maxRows)
        {
            int num = 0;
            if (this.RcdFound36 != 0)
            {
                this.ScanLoadTipiznosa();
                while ((this.RcdFound36 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowTipiznosa();
                    this.CreateNewRowTipiznosa();
                    this.ScanNextTipiznosa();
                }
            }
            if (num > 0)
            {
                this.RcdFound36 = 1;
            }
            this.ScanEndTipiznosa();
            if (this.TIPIZNOSASet.TIPIZNOSA.Count > 0)
            {
                this.rowTIPIZNOSA = this.TIPIZNOSASet.TIPIZNOSA[this.TIPIZNOSASet.TIPIZNOSA.Count - 1];
            }
        }

        private void LoadRowTipiznosa()
        {
            this.AddRowTipiznosa();
        }

        private void OnTIPIZNOSAUpdated(TIPIZNOSAEventArgs e)
        {
            if (this.TIPIZNOSAUpdated != null)
            {
                TIPIZNOSAUpdateEventHandler tIPIZNOSAUpdatedEvent = this.TIPIZNOSAUpdated;
                if (tIPIZNOSAUpdatedEvent != null)
                {
                    tIPIZNOSAUpdatedEvent(this, e);
                }
            }
        }

        private void OnTIPIZNOSAUpdating(TIPIZNOSAEventArgs e)
        {
            if (this.TIPIZNOSAUpdating != null)
            {
                TIPIZNOSAUpdateEventHandler tIPIZNOSAUpdatingEvent = this.TIPIZNOSAUpdating;
                if (tIPIZNOSAUpdatingEvent != null)
                {
                    tIPIZNOSAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowTipiznosa()
        {
            this.Gx_mode = Mode.FromRowState(this.rowTIPIZNOSA.RowState);
            if (this.rowTIPIZNOSA.RowState != DataRowState.Added)
            {
                this.m__OPISTIPAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["OPISTIPAIZNOSA", DataRowVersion.Original]);
                this.m__OZNAKATIPAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["OZNAKATIPAIZNOSA", DataRowVersion.Original]);
                this.m__VBDITIPAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["VBDITIPAIZNOSA", DataRowVersion.Original]);
                this.m__ZIROTIPAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["ZIROTIPAIZNOSA", DataRowVersion.Original]);
                this.m__MOTIPAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["MOTIPAIZNOSA", DataRowVersion.Original]);
                this.m__POTIPAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["POTIPAIZNOSA", DataRowVersion.Original]);
            }
            else
            {
                this.m__OPISTIPAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["OPISTIPAIZNOSA"]);
                this.m__OZNAKATIPAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["OZNAKATIPAIZNOSA"]);
                this.m__VBDITIPAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["VBDITIPAIZNOSA"]);
                this.m__ZIROTIPAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["ZIROTIPAIZNOSA"]);
                this.m__MOTIPAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["MOTIPAIZNOSA"]);
                this.m__POTIPAIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["POTIPAIZNOSA"]);
            }
            this._Gxremove = this.rowTIPIZNOSA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowTIPIZNOSA = (TIPIZNOSADataSet.TIPIZNOSARow) DataSetUtil.CloneOriginalDataRow(this.rowTIPIZNOSA);
            }
        }

        private void ScanByIDTIPAIZNOSA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDTIPAIZNOSA] = @IDTIPAIZNOSA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString36 + "  FROM [TIPIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPAIZNOSA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString36, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDTIPAIZNOSA] ) AS DK_PAGENUM   FROM [TIPIZNOSA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString36 + " FROM [TIPIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPAIZNOSA] ";
            }
            this.cmTIPIZNOSASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmTIPIZNOSASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmTIPIZNOSASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPAIZNOSA", DbType.Int32));
            }
            this.cmTIPIZNOSASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["IDTIPAIZNOSA"]));
            this.TIPIZNOSASelect4 = this.cmTIPIZNOSASelect4.FetchData();
            this.RcdFound36 = 0;
            this.ScanLoadTipiznosa();
            this.LoadDataTipiznosa(maxRows);
        }

        private void ScanEndTipiznosa()
        {
            this.TIPIZNOSASelect4.Close();
        }

        private void ScanLoadTipiznosa()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmTIPIZNOSASelect4.HasMoreRows)
            {
                this.RcdFound36 = 1;
                this.rowTIPIZNOSA["IDTIPAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.TIPIZNOSASelect4, 0));
                this.rowTIPIZNOSA["OPISTIPAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.TIPIZNOSASelect4, 1));
                this.rowTIPIZNOSA["OZNAKATIPAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.TIPIZNOSASelect4, 2));
                this.rowTIPIZNOSA["VBDITIPAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.TIPIZNOSASelect4, 3));
                this.rowTIPIZNOSA["ZIROTIPAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.TIPIZNOSASelect4, 4));
                this.rowTIPIZNOSA["MOTIPAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.TIPIZNOSASelect4, 5));
                this.rowTIPIZNOSA["POTIPAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.TIPIZNOSASelect4, 6));
            }
        }

        private void ScanNextTipiznosa()
        {
            this.cmTIPIZNOSASelect4.HasMoreRows = this.TIPIZNOSASelect4.Read();
            this.RcdFound36 = 0;
            this.ScanLoadTipiznosa();
        }

        private void ScanStartTipiznosa(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString36 + "  FROM [TIPIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPAIZNOSA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString36, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDTIPAIZNOSA] ) AS DK_PAGENUM   FROM [TIPIZNOSA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString36 + " FROM [TIPIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPAIZNOSA] ";
            }
            this.cmTIPIZNOSASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.TIPIZNOSASelect4 = this.cmTIPIZNOSASelect4.FetchData();
            this.RcdFound36 = 0;
            this.ScanLoadTipiznosa();
            this.LoadDataTipiznosa(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.TIPIZNOSASet = (TIPIZNOSADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.TIPIZNOSASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.TIPIZNOSASet.TIPIZNOSA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        TIPIZNOSADataSet.TIPIZNOSARow current = (TIPIZNOSADataSet.TIPIZNOSARow) enumerator.Current;
                        this.rowTIPIZNOSA = current;
                        if (Helpers.IsRowChanged(this.rowTIPIZNOSA))
                        {
                            this.ReadRowTipiznosa();
                            if (this.rowTIPIZNOSA.RowState == DataRowState.Added)
                            {
                                this.InsertTipiznosa();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateTipiznosa();
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

        private void UpdateTipiznosa()
        {
            this.CheckOptimisticConcurrencyTipiznosa();
            this.AfterConfirmTipiznosa();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [TIPIZNOSA] SET [OPISTIPAIZNOSA]=@OPISTIPAIZNOSA, [OZNAKATIPAIZNOSA]=@OZNAKATIPAIZNOSA, [VBDITIPAIZNOSA]=@VBDITIPAIZNOSA, [ZIROTIPAIZNOSA]=@ZIROTIPAIZNOSA, [MOTIPAIZNOSA]=@MOTIPAIZNOSA, [POTIPAIZNOSA]=@POTIPAIZNOSA  WHERE [IDTIPAIZNOSA] = @IDTIPAIZNOSA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISTIPAIZNOSA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OZNAKATIPAIZNOSA", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDITIPAIZNOSA", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZIROTIPAIZNOSA", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOTIPAIZNOSA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POTIPAIZNOSA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPAIZNOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["OPISTIPAIZNOSA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["OZNAKATIPAIZNOSA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["VBDITIPAIZNOSA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["ZIROTIPAIZNOSA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["MOTIPAIZNOSA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["POTIPAIZNOSA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowTIPIZNOSA["IDTIPAIZNOSA"]));
            command.ExecuteStmt();
            this.OnTIPIZNOSAUpdated(new TIPIZNOSAEventArgs(this.rowTIPIZNOSA, StatementType.Update));
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
        public class TIPIZNOSADataChangedException : DataChangedException
        {
            public TIPIZNOSADataChangedException()
            {
            }

            public TIPIZNOSADataChangedException(string message) : base(message)
            {
            }

            protected TIPIZNOSADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPIZNOSADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPIZNOSADataLockedException : DataLockedException
        {
            public TIPIZNOSADataLockedException()
            {
            }

            public TIPIZNOSADataLockedException(string message) : base(message)
            {
            }

            protected TIPIZNOSADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPIZNOSADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPIZNOSADuplicateKeyException : DuplicateKeyException
        {
            public TIPIZNOSADuplicateKeyException()
            {
            }

            public TIPIZNOSADuplicateKeyException(string message) : base(message)
            {
            }

            protected TIPIZNOSADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPIZNOSADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class TIPIZNOSAEventArgs : EventArgs
        {
            private TIPIZNOSADataSet.TIPIZNOSARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public TIPIZNOSAEventArgs(TIPIZNOSADataSet.TIPIZNOSARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public TIPIZNOSADataSet.TIPIZNOSARow Row
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
        public class TIPIZNOSANotFoundException : DataNotFoundException
        {
            public TIPIZNOSANotFoundException()
            {
            }

            public TIPIZNOSANotFoundException(string message) : base(message)
            {
            }

            protected TIPIZNOSANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPIZNOSANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void TIPIZNOSAUpdateEventHandler(object sender, TIPIZNOSADataAdapter.TIPIZNOSAEventArgs e);
    }
}

