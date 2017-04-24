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

    public class PLVRSTEIZNOSADataAdapter : IDataAdapter, IPLVRSTEIZNOSADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmPLVRSTEIZNOSASelect1;
        private ReadWriteCommand cmPLVRSTEIZNOSASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVPLVRSTEIZNOSAOriginal;
        private readonly string m_SelectString228 = "TM1.[IDPLVRSTEIZNOSA], TM1.[NAZIVPLVRSTEIZNOSA]";
        private string m_WhereString;
        private IDataReader PLVRSTEIZNOSASelect1;
        private IDataReader PLVRSTEIZNOSASelect4;
        private PLVRSTEIZNOSADataSet PLVRSTEIZNOSASet;
        private short RcdFound228;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow rowPLVRSTEIZNOSA;
        private string scmdbuf;
        private StatementType sMode228;

        public event PLVRSTEIZNOSAUpdateEventHandler PLVRSTEIZNOSAUpdated;

        public event PLVRSTEIZNOSAUpdateEventHandler PLVRSTEIZNOSAUpdating;

        private void AddRowPlvrsteiznosa()
        {
            this.PLVRSTEIZNOSASet.PLVRSTEIZNOSA.AddPLVRSTEIZNOSARow(this.rowPLVRSTEIZNOSA);
        }

        private void AfterConfirmPlvrsteiznosa()
        {
            this.OnPLVRSTEIZNOSAUpdating(new PLVRSTEIZNOSAEventArgs(this.rowPLVRSTEIZNOSA, this.Gx_mode));
        }

        private void CheckDeleteErrorsPlvrsteiznosa()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAPLACA], [SHEMAPLACASTANDARDID] FROM [SHEMAPLACASHEMAPLACASTANDARD] WITH (NOLOCK) WHERE [IDPLVRSTEIZNOSA] = @IDPLVRSTEIZNOSA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLVRSTEIZNOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLVRSTEIZNOSA["IDPLVRSTEIZNOSA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new SHEMAPLACASHEMAPLACASTANDARDInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAPLACASTANDARD" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyPlvrsteiznosa()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDPLVRSTEIZNOSA], [NAZIVPLVRSTEIZNOSA] FROM [PLVRSTEIZNOSA] WITH (UPDLOCK) WHERE [IDPLVRSTEIZNOSA] = @IDPLVRSTEIZNOSA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLVRSTEIZNOSA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLVRSTEIZNOSA["IDPLVRSTEIZNOSA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new PLVRSTEIZNOSADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("PLVRSTEIZNOSA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVPLVRSTEIZNOSAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new PLVRSTEIZNOSADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("PLVRSTEIZNOSA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowPlvrsteiznosa()
        {
            this.rowPLVRSTEIZNOSA = this.PLVRSTEIZNOSASet.PLVRSTEIZNOSA.NewPLVRSTEIZNOSARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyPlvrsteiznosa();
            this.AfterConfirmPlvrsteiznosa();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [PLVRSTEIZNOSA]  WHERE [IDPLVRSTEIZNOSA] = @IDPLVRSTEIZNOSA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLVRSTEIZNOSA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLVRSTEIZNOSA["IDPLVRSTEIZNOSA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsPlvrsteiznosa();
            }
            this.OnPLVRSTEIZNOSAUpdated(new PLVRSTEIZNOSAEventArgs(this.rowPLVRSTEIZNOSA, StatementType.Delete));
            this.rowPLVRSTEIZNOSA.Delete();
            this.sMode228 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode228;
        }

        public virtual int Fill(PLVRSTEIZNOSADataSet dataSet)
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
                    this.PLVRSTEIZNOSASet = dataSet;
                    this.LoadChildPlvrsteiznosa(0, -1);
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
            this.PLVRSTEIZNOSASet = (PLVRSTEIZNOSADataSet) dataSet;
            if (this.PLVRSTEIZNOSASet != null)
            {
                return this.Fill(this.PLVRSTEIZNOSASet);
            }
            this.PLVRSTEIZNOSASet = new PLVRSTEIZNOSADataSet();
            this.Fill(this.PLVRSTEIZNOSASet);
            dataSet.Merge(this.PLVRSTEIZNOSASet);
            return 0;
        }

        public virtual int Fill(PLVRSTEIZNOSADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDPLVRSTEIZNOSA"]));
        }

        public virtual int Fill(PLVRSTEIZNOSADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDPLVRSTEIZNOSA"]));
        }

        public virtual int Fill(PLVRSTEIZNOSADataSet dataSet, int iDPLVRSTEIZNOSA)
        {
            if (!this.FillByIDPLVRSTEIZNOSA(dataSet, iDPLVRSTEIZNOSA))
            {
                throw new PLVRSTEIZNOSANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("PLVRSTEIZNOSA") }));
            }
            return 0;
        }

        public virtual bool FillByIDPLVRSTEIZNOSA(PLVRSTEIZNOSADataSet dataSet, int iDPLVRSTEIZNOSA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PLVRSTEIZNOSASet = dataSet;
            this.rowPLVRSTEIZNOSA = this.PLVRSTEIZNOSASet.PLVRSTEIZNOSA.NewPLVRSTEIZNOSARow();
            this.rowPLVRSTEIZNOSA.IDPLVRSTEIZNOSA = iDPLVRSTEIZNOSA;
            try
            {
                this.LoadByIDPLVRSTEIZNOSA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound228 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(PLVRSTEIZNOSADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.PLVRSTEIZNOSASet = dataSet;
            try
            {
                this.LoadChildPlvrsteiznosa(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDPLVRSTEIZNOSA], [NAZIVPLVRSTEIZNOSA] FROM [PLVRSTEIZNOSA] WITH (NOLOCK) WHERE [IDPLVRSTEIZNOSA] = @IDPLVRSTEIZNOSA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLVRSTEIZNOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLVRSTEIZNOSA["IDPLVRSTEIZNOSA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound228 = 1;
                this.rowPLVRSTEIZNOSA["IDPLVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowPLVRSTEIZNOSA["NAZIVPLVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode228 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode228;
            }
            else
            {
                this.RcdFound228 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDPLVRSTEIZNOSA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPLVRSTEIZNOSASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [PLVRSTEIZNOSA] WITH (NOLOCK) ", false);
            this.PLVRSTEIZNOSASelect1 = this.cmPLVRSTEIZNOSASelect1.FetchData();
            if (this.PLVRSTEIZNOSASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.PLVRSTEIZNOSASelect1.GetInt32(0);
            }
            this.PLVRSTEIZNOSASelect1.Close();
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
            this.RcdFound228 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVPLVRSTEIZNOSAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.PLVRSTEIZNOSASet = new PLVRSTEIZNOSADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertPlvrsteiznosa()
        {
            this.CheckOptimisticConcurrencyPlvrsteiznosa();
            this.AfterConfirmPlvrsteiznosa();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [PLVRSTEIZNOSA] ([IDPLVRSTEIZNOSA], [NAZIVPLVRSTEIZNOSA]) VALUES (@IDPLVRSTEIZNOSA, @NAZIVPLVRSTEIZNOSA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLVRSTEIZNOSA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPLVRSTEIZNOSA", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLVRSTEIZNOSA["IDPLVRSTEIZNOSA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPLVRSTEIZNOSA["NAZIVPLVRSTEIZNOSA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new PLVRSTEIZNOSADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnPLVRSTEIZNOSAUpdated(new PLVRSTEIZNOSAEventArgs(this.rowPLVRSTEIZNOSA, StatementType.Insert));
        }

        private void LoadByIDPLVRSTEIZNOSA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.PLVRSTEIZNOSASet.EnforceConstraints;
            this.PLVRSTEIZNOSASet.PLVRSTEIZNOSA.BeginLoadData();
            this.ScanByIDPLVRSTEIZNOSA(startRow, maxRows);
            this.PLVRSTEIZNOSASet.PLVRSTEIZNOSA.EndLoadData();
            this.PLVRSTEIZNOSASet.EnforceConstraints = enforceConstraints;
            if (this.PLVRSTEIZNOSASet.PLVRSTEIZNOSA.Count > 0)
            {
                this.rowPLVRSTEIZNOSA = this.PLVRSTEIZNOSASet.PLVRSTEIZNOSA[this.PLVRSTEIZNOSASet.PLVRSTEIZNOSA.Count - 1];
            }
        }

        private void LoadChildPlvrsteiznosa(int startRow, int maxRows)
        {
            this.CreateNewRowPlvrsteiznosa();
            bool enforceConstraints = this.PLVRSTEIZNOSASet.EnforceConstraints;
            this.PLVRSTEIZNOSASet.PLVRSTEIZNOSA.BeginLoadData();
            this.ScanStartPlvrsteiznosa(startRow, maxRows);
            this.PLVRSTEIZNOSASet.PLVRSTEIZNOSA.EndLoadData();
            this.PLVRSTEIZNOSASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataPlvrsteiznosa(int maxRows)
        {
            int num = 0;
            if (this.RcdFound228 != 0)
            {
                this.ScanLoadPlvrsteiznosa();
                while ((this.RcdFound228 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowPlvrsteiznosa();
                    this.CreateNewRowPlvrsteiznosa();
                    this.ScanNextPlvrsteiznosa();
                }
            }
            if (num > 0)
            {
                this.RcdFound228 = 1;
            }
            this.ScanEndPlvrsteiznosa();
            if (this.PLVRSTEIZNOSASet.PLVRSTEIZNOSA.Count > 0)
            {
                this.rowPLVRSTEIZNOSA = this.PLVRSTEIZNOSASet.PLVRSTEIZNOSA[this.PLVRSTEIZNOSASet.PLVRSTEIZNOSA.Count - 1];
            }
        }

        private void LoadRowPlvrsteiznosa()
        {
            this.AddRowPlvrsteiznosa();
        }

        private void OnPLVRSTEIZNOSAUpdated(PLVRSTEIZNOSAEventArgs e)
        {
            if (this.PLVRSTEIZNOSAUpdated != null)
            {
                PLVRSTEIZNOSAUpdateEventHandler pLVRSTEIZNOSAUpdatedEvent = this.PLVRSTEIZNOSAUpdated;
                if (pLVRSTEIZNOSAUpdatedEvent != null)
                {
                    pLVRSTEIZNOSAUpdatedEvent(this, e);
                }
            }
        }

        private void OnPLVRSTEIZNOSAUpdating(PLVRSTEIZNOSAEventArgs e)
        {
            if (this.PLVRSTEIZNOSAUpdating != null)
            {
                PLVRSTEIZNOSAUpdateEventHandler pLVRSTEIZNOSAUpdatingEvent = this.PLVRSTEIZNOSAUpdating;
                if (pLVRSTEIZNOSAUpdatingEvent != null)
                {
                    pLVRSTEIZNOSAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowPlvrsteiznosa()
        {
            this.Gx_mode = Mode.FromRowState(this.rowPLVRSTEIZNOSA.RowState);
            if (this.rowPLVRSTEIZNOSA.RowState != DataRowState.Added)
            {
                this.m__NAZIVPLVRSTEIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowPLVRSTEIZNOSA["NAZIVPLVRSTEIZNOSA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVPLVRSTEIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowPLVRSTEIZNOSA["NAZIVPLVRSTEIZNOSA"]);
            }
            this._Gxremove = this.rowPLVRSTEIZNOSA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowPLVRSTEIZNOSA = (PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow) DataSetUtil.CloneOriginalDataRow(this.rowPLVRSTEIZNOSA);
            }
        }

        private void ScanByIDPLVRSTEIZNOSA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDPLVRSTEIZNOSA] = @IDPLVRSTEIZNOSA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString228 + "  FROM [PLVRSTEIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPLVRSTEIZNOSA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString228, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDPLVRSTEIZNOSA] ) AS DK_PAGENUM   FROM [PLVRSTEIZNOSA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString228 + " FROM [PLVRSTEIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPLVRSTEIZNOSA] ";
            }
            this.cmPLVRSTEIZNOSASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmPLVRSTEIZNOSASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmPLVRSTEIZNOSASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLVRSTEIZNOSA", DbType.Int32));
            }
            this.cmPLVRSTEIZNOSASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLVRSTEIZNOSA["IDPLVRSTEIZNOSA"]));
            this.PLVRSTEIZNOSASelect4 = this.cmPLVRSTEIZNOSASelect4.FetchData();
            this.RcdFound228 = 0;
            this.ScanLoadPlvrsteiznosa();
            this.LoadDataPlvrsteiznosa(maxRows);
        }

        private void ScanEndPlvrsteiznosa()
        {
            this.PLVRSTEIZNOSASelect4.Close();
        }

        private void ScanLoadPlvrsteiznosa()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmPLVRSTEIZNOSASelect4.HasMoreRows)
            {
                this.RcdFound228 = 1;
                this.rowPLVRSTEIZNOSA["IDPLVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.PLVRSTEIZNOSASelect4, 0));
                this.rowPLVRSTEIZNOSA["NAZIVPLVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.PLVRSTEIZNOSASelect4, 1));
            }
        }

        private void ScanNextPlvrsteiznosa()
        {
            this.cmPLVRSTEIZNOSASelect4.HasMoreRows = this.PLVRSTEIZNOSASelect4.Read();
            this.RcdFound228 = 0;
            this.ScanLoadPlvrsteiznosa();
        }

        private void ScanStartPlvrsteiznosa(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString228 + "  FROM [PLVRSTEIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPLVRSTEIZNOSA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString228, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDPLVRSTEIZNOSA] ) AS DK_PAGENUM   FROM [PLVRSTEIZNOSA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString228 + " FROM [PLVRSTEIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDPLVRSTEIZNOSA] ";
            }
            this.cmPLVRSTEIZNOSASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.PLVRSTEIZNOSASelect4 = this.cmPLVRSTEIZNOSASelect4.FetchData();
            this.RcdFound228 = 0;
            this.ScanLoadPlvrsteiznosa();
            this.LoadDataPlvrsteiznosa(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.PLVRSTEIZNOSASet = (PLVRSTEIZNOSADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.PLVRSTEIZNOSASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.PLVRSTEIZNOSASet.PLVRSTEIZNOSA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow current = (PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow) enumerator.Current;
                        this.rowPLVRSTEIZNOSA = current;
                        if (Helpers.IsRowChanged(this.rowPLVRSTEIZNOSA))
                        {
                            this.ReadRowPlvrsteiznosa();
                            if (this.rowPLVRSTEIZNOSA.RowState == DataRowState.Added)
                            {
                                this.InsertPlvrsteiznosa();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdatePlvrsteiznosa();
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

        private void UpdatePlvrsteiznosa()
        {
            this.CheckOptimisticConcurrencyPlvrsteiznosa();
            this.AfterConfirmPlvrsteiznosa();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [PLVRSTEIZNOSA] SET [NAZIVPLVRSTEIZNOSA]=@NAZIVPLVRSTEIZNOSA  WHERE [IDPLVRSTEIZNOSA] = @IDPLVRSTEIZNOSA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPLVRSTEIZNOSA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPLVRSTEIZNOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPLVRSTEIZNOSA["NAZIVPLVRSTEIZNOSA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPLVRSTEIZNOSA["IDPLVRSTEIZNOSA"]));
            command.ExecuteStmt();
            this.OnPLVRSTEIZNOSAUpdated(new PLVRSTEIZNOSAEventArgs(this.rowPLVRSTEIZNOSA, StatementType.Update));
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
        public class PLVRSTEIZNOSADataChangedException : DataChangedException
        {
            public PLVRSTEIZNOSADataChangedException()
            {
            }

            public PLVRSTEIZNOSADataChangedException(string message) : base(message)
            {
            }

            protected PLVRSTEIZNOSADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PLVRSTEIZNOSADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PLVRSTEIZNOSADataLockedException : DataLockedException
        {
            public PLVRSTEIZNOSADataLockedException()
            {
            }

            public PLVRSTEIZNOSADataLockedException(string message) : base(message)
            {
            }

            protected PLVRSTEIZNOSADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PLVRSTEIZNOSADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PLVRSTEIZNOSADuplicateKeyException : DuplicateKeyException
        {
            public PLVRSTEIZNOSADuplicateKeyException()
            {
            }

            public PLVRSTEIZNOSADuplicateKeyException(string message) : base(message)
            {
            }

            protected PLVRSTEIZNOSADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PLVRSTEIZNOSADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class PLVRSTEIZNOSAEventArgs : EventArgs
        {
            private PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public PLVRSTEIZNOSAEventArgs(PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow Row
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
        public class PLVRSTEIZNOSANotFoundException : DataNotFoundException
        {
            public PLVRSTEIZNOSANotFoundException()
            {
            }

            public PLVRSTEIZNOSANotFoundException(string message) : base(message)
            {
            }

            protected PLVRSTEIZNOSANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PLVRSTEIZNOSANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void PLVRSTEIZNOSAUpdateEventHandler(object sender, PLVRSTEIZNOSADataAdapter.PLVRSTEIZNOSAEventArgs e);

        [Serializable]
        public class SHEMAPLACASHEMAPLACASTANDARDInvalidDeleteException : InvalidDeleteException
        {
            public SHEMAPLACASHEMAPLACASTANDARDInvalidDeleteException()
            {
            }

            public SHEMAPLACASHEMAPLACASTANDARDInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMAPLACASHEMAPLACASTANDARDInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACASHEMAPLACASTANDARDInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

