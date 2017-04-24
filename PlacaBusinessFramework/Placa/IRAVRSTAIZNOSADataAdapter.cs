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

    public class IRAVRSTAIZNOSADataAdapter : IDataAdapter, IIRAVRSTAIZNOSADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmIRAVRSTAIZNOSASelect1;
        private ReadWriteCommand cmIRAVRSTAIZNOSASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private IDataReader IRAVRSTAIZNOSASelect1;
        private IDataReader IRAVRSTAIZNOSASelect4;
        private IRAVRSTAIZNOSADataSet IRAVRSTAIZNOSASet;
        private object m__IRAVRSTAIZNOSANAZIVOriginal;
        private readonly string m_SelectString219 = "TM1.[IDIRAVRSTAIZNOSA], TM1.[IRAVRSTAIZNOSANAZIV]";
        private string m_WhereString;
        private short RcdFound219;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow rowIRAVRSTAIZNOSA;
        private string scmdbuf;
        private StatementType sMode219;

        public event IRAVRSTAIZNOSAUpdateEventHandler IRAVRSTAIZNOSAUpdated;

        public event IRAVRSTAIZNOSAUpdateEventHandler IRAVRSTAIZNOSAUpdating;

        private void AddRowIravrstaiznosa()
        {
            this.IRAVRSTAIZNOSASet.IRAVRSTAIZNOSA.AddIRAVRSTAIZNOSARow(this.rowIRAVRSTAIZNOSA);
        }

        private void AfterConfirmIravrstaiznosa()
        {
            this.OnIRAVRSTAIZNOSAUpdating(new IRAVRSTAIZNOSAEventArgs(this.rowIRAVRSTAIZNOSA, this.Gx_mode));
        }

        private void CheckDeleteErrorsIravrstaiznosa()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAIRA], [SHEMAIRAKONTOIDKONTO], [SHEMAIRASTRANEIDSTRANEKNJIZENJA] FROM [SHEMAIRASHEMAIRAKONTIRANJE] WITH (NOLOCK) WHERE [IDIRAVRSTAIZNOSA] = @IDIRAVRSTAIZNOSA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIRAVRSTAIZNOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRAVRSTAIZNOSA["IDIRAVRSTAIZNOSA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAIRAKONTIRANJE" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyIravrstaiznosa()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDIRAVRSTAIZNOSA], [IRAVRSTAIZNOSANAZIV] FROM [IRAVRSTAIZNOSA] WITH (UPDLOCK) WHERE [IDIRAVRSTAIZNOSA] = @IDIRAVRSTAIZNOSA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIRAVRSTAIZNOSA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRAVRSTAIZNOSA["IDIRAVRSTAIZNOSA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new IRAVRSTAIZNOSADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("IRAVRSTAIZNOSA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__IRAVRSTAIZNOSANAZIVOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new IRAVRSTAIZNOSADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("IRAVRSTAIZNOSA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowIravrstaiznosa()
        {
            this.rowIRAVRSTAIZNOSA = this.IRAVRSTAIZNOSASet.IRAVRSTAIZNOSA.NewIRAVRSTAIZNOSARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyIravrstaiznosa();
            this.AfterConfirmIravrstaiznosa();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [IRAVRSTAIZNOSA]  WHERE [IDIRAVRSTAIZNOSA] = @IDIRAVRSTAIZNOSA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIRAVRSTAIZNOSA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRAVRSTAIZNOSA["IDIRAVRSTAIZNOSA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsIravrstaiznosa();
            }
            this.OnIRAVRSTAIZNOSAUpdated(new IRAVRSTAIZNOSAEventArgs(this.rowIRAVRSTAIZNOSA, StatementType.Delete));
            this.rowIRAVRSTAIZNOSA.Delete();
            this.sMode219 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode219;
        }

        public virtual int Fill(IRAVRSTAIZNOSADataSet dataSet)
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
                    this.IRAVRSTAIZNOSASet = dataSet;
                    this.LoadChildIravrstaiznosa(0, -1);
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
            this.IRAVRSTAIZNOSASet = (IRAVRSTAIZNOSADataSet) dataSet;
            if (this.IRAVRSTAIZNOSASet != null)
            {
                return this.Fill(this.IRAVRSTAIZNOSASet);
            }
            this.IRAVRSTAIZNOSASet = new IRAVRSTAIZNOSADataSet();
            this.Fill(this.IRAVRSTAIZNOSASet);
            dataSet.Merge(this.IRAVRSTAIZNOSASet);
            return 0;
        }

        public virtual int Fill(IRAVRSTAIZNOSADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDIRAVRSTAIZNOSA"]));
        }

        public virtual int Fill(IRAVRSTAIZNOSADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDIRAVRSTAIZNOSA"]));
        }

        public virtual int Fill(IRAVRSTAIZNOSADataSet dataSet, int iDIRAVRSTAIZNOSA)
        {
            if (!this.FillByIDIRAVRSTAIZNOSA(dataSet, iDIRAVRSTAIZNOSA))
            {
                throw new IRAVRSTAIZNOSANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("IRAVRSTAIZNOSA") }));
            }
            return 0;
        }

        public virtual bool FillByIDIRAVRSTAIZNOSA(IRAVRSTAIZNOSADataSet dataSet, int iDIRAVRSTAIZNOSA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.IRAVRSTAIZNOSASet = dataSet;
            this.rowIRAVRSTAIZNOSA = this.IRAVRSTAIZNOSASet.IRAVRSTAIZNOSA.NewIRAVRSTAIZNOSARow();
            this.rowIRAVRSTAIZNOSA.IDIRAVRSTAIZNOSA = iDIRAVRSTAIZNOSA;
            try
            {
                this.LoadByIDIRAVRSTAIZNOSA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound219 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(IRAVRSTAIZNOSADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.IRAVRSTAIZNOSASet = dataSet;
            try
            {
                this.LoadChildIravrstaiznosa(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDIRAVRSTAIZNOSA], [IRAVRSTAIZNOSANAZIV] FROM [IRAVRSTAIZNOSA] WITH (NOLOCK) WHERE [IDIRAVRSTAIZNOSA] = @IDIRAVRSTAIZNOSA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIRAVRSTAIZNOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRAVRSTAIZNOSA["IDIRAVRSTAIZNOSA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound219 = 1;
                this.rowIRAVRSTAIZNOSA["IDIRAVRSTAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowIRAVRSTAIZNOSA["IRAVRSTAIZNOSANAZIV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode219 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode219;
            }
            else
            {
                this.RcdFound219 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDIRAVRSTAIZNOSA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIRAVRSTAIZNOSASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [IRAVRSTAIZNOSA] WITH (NOLOCK) ", false);
            this.IRAVRSTAIZNOSASelect1 = this.cmIRAVRSTAIZNOSASelect1.FetchData();
            if (this.IRAVRSTAIZNOSASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.IRAVRSTAIZNOSASelect1.GetInt32(0);
            }
            this.IRAVRSTAIZNOSASelect1.Close();
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
            this.RcdFound219 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__IRAVRSTAIZNOSANAZIVOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.IRAVRSTAIZNOSASet = new IRAVRSTAIZNOSADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertIravrstaiznosa()
        {
            this.CheckOptimisticConcurrencyIravrstaiznosa();
            this.AfterConfirmIravrstaiznosa();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [IRAVRSTAIZNOSA] ([IDIRAVRSTAIZNOSA], [IRAVRSTAIZNOSANAZIV]) VALUES (@IDIRAVRSTAIZNOSA, @IRAVRSTAIZNOSANAZIV)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIRAVRSTAIZNOSA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAVRSTAIZNOSANAZIV", DbType.String, 30));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRAVRSTAIZNOSA["IDIRAVRSTAIZNOSA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowIRAVRSTAIZNOSA["IRAVRSTAIZNOSANAZIV"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new IRAVRSTAIZNOSADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnIRAVRSTAIZNOSAUpdated(new IRAVRSTAIZNOSAEventArgs(this.rowIRAVRSTAIZNOSA, StatementType.Insert));
        }

        private void LoadByIDIRAVRSTAIZNOSA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.IRAVRSTAIZNOSASet.EnforceConstraints;
            this.IRAVRSTAIZNOSASet.IRAVRSTAIZNOSA.BeginLoadData();
            this.ScanByIDIRAVRSTAIZNOSA(startRow, maxRows);
            this.IRAVRSTAIZNOSASet.IRAVRSTAIZNOSA.EndLoadData();
            this.IRAVRSTAIZNOSASet.EnforceConstraints = enforceConstraints;
            if (this.IRAVRSTAIZNOSASet.IRAVRSTAIZNOSA.Count > 0)
            {
                this.rowIRAVRSTAIZNOSA = this.IRAVRSTAIZNOSASet.IRAVRSTAIZNOSA[this.IRAVRSTAIZNOSASet.IRAVRSTAIZNOSA.Count - 1];
            }
        }

        private void LoadChildIravrstaiznosa(int startRow, int maxRows)
        {
            this.CreateNewRowIravrstaiznosa();
            bool enforceConstraints = this.IRAVRSTAIZNOSASet.EnforceConstraints;
            this.IRAVRSTAIZNOSASet.IRAVRSTAIZNOSA.BeginLoadData();
            this.ScanStartIravrstaiznosa(startRow, maxRows);
            this.IRAVRSTAIZNOSASet.IRAVRSTAIZNOSA.EndLoadData();
            this.IRAVRSTAIZNOSASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataIravrstaiznosa(int maxRows)
        {
            int num = 0;
            if (this.RcdFound219 != 0)
            {
                this.ScanLoadIravrstaiznosa();
                while ((this.RcdFound219 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowIravrstaiznosa();
                    this.CreateNewRowIravrstaiznosa();
                    this.ScanNextIravrstaiznosa();
                }
            }
            if (num > 0)
            {
                this.RcdFound219 = 1;
            }
            this.ScanEndIravrstaiznosa();
            if (this.IRAVRSTAIZNOSASet.IRAVRSTAIZNOSA.Count > 0)
            {
                this.rowIRAVRSTAIZNOSA = this.IRAVRSTAIZNOSASet.IRAVRSTAIZNOSA[this.IRAVRSTAIZNOSASet.IRAVRSTAIZNOSA.Count - 1];
            }
        }

        private void LoadRowIravrstaiznosa()
        {
            this.AddRowIravrstaiznosa();
        }

        private void OnIRAVRSTAIZNOSAUpdated(IRAVRSTAIZNOSAEventArgs e)
        {
            if (this.IRAVRSTAIZNOSAUpdated != null)
            {
                IRAVRSTAIZNOSAUpdateEventHandler iRAVRSTAIZNOSAUpdatedEvent = this.IRAVRSTAIZNOSAUpdated;
                if (iRAVRSTAIZNOSAUpdatedEvent != null)
                {
                    iRAVRSTAIZNOSAUpdatedEvent(this, e);
                }
            }
        }

        private void OnIRAVRSTAIZNOSAUpdating(IRAVRSTAIZNOSAEventArgs e)
        {
            if (this.IRAVRSTAIZNOSAUpdating != null)
            {
                IRAVRSTAIZNOSAUpdateEventHandler iRAVRSTAIZNOSAUpdatingEvent = this.IRAVRSTAIZNOSAUpdating;
                if (iRAVRSTAIZNOSAUpdatingEvent != null)
                {
                    iRAVRSTAIZNOSAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowIravrstaiznosa()
        {
            this.Gx_mode = Mode.FromRowState(this.rowIRAVRSTAIZNOSA.RowState);
            if (this.rowIRAVRSTAIZNOSA.RowState != DataRowState.Added)
            {
                this.m__IRAVRSTAIZNOSANAZIVOriginal = RuntimeHelpers.GetObjectValue(this.rowIRAVRSTAIZNOSA["IRAVRSTAIZNOSANAZIV", DataRowVersion.Original]);
            }
            else
            {
                this.m__IRAVRSTAIZNOSANAZIVOriginal = RuntimeHelpers.GetObjectValue(this.rowIRAVRSTAIZNOSA["IRAVRSTAIZNOSANAZIV"]);
            }
            this._Gxremove = this.rowIRAVRSTAIZNOSA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowIRAVRSTAIZNOSA = (IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow) DataSetUtil.CloneOriginalDataRow(this.rowIRAVRSTAIZNOSA);
            }
        }

        private void ScanByIDIRAVRSTAIZNOSA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDIRAVRSTAIZNOSA] = @IDIRAVRSTAIZNOSA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString219 + "  FROM [IRAVRSTAIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDIRAVRSTAIZNOSA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString219, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDIRAVRSTAIZNOSA] ) AS DK_PAGENUM   FROM [IRAVRSTAIZNOSA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString219 + " FROM [IRAVRSTAIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDIRAVRSTAIZNOSA] ";
            }
            this.cmIRAVRSTAIZNOSASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmIRAVRSTAIZNOSASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmIRAVRSTAIZNOSASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIRAVRSTAIZNOSA", DbType.Int32));
            }
            this.cmIRAVRSTAIZNOSASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRAVRSTAIZNOSA["IDIRAVRSTAIZNOSA"]));
            this.IRAVRSTAIZNOSASelect4 = this.cmIRAVRSTAIZNOSASelect4.FetchData();
            this.RcdFound219 = 0;
            this.ScanLoadIravrstaiznosa();
            this.LoadDataIravrstaiznosa(maxRows);
        }

        private void ScanEndIravrstaiznosa()
        {
            this.IRAVRSTAIZNOSASelect4.Close();
        }

        private void ScanLoadIravrstaiznosa()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmIRAVRSTAIZNOSASelect4.HasMoreRows)
            {
                this.RcdFound219 = 1;
                this.rowIRAVRSTAIZNOSA["IDIRAVRSTAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.IRAVRSTAIZNOSASelect4, 0));
                this.rowIRAVRSTAIZNOSA["IRAVRSTAIZNOSANAZIV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.IRAVRSTAIZNOSASelect4, 1));
            }
        }

        private void ScanNextIravrstaiznosa()
        {
            this.cmIRAVRSTAIZNOSASelect4.HasMoreRows = this.IRAVRSTAIZNOSASelect4.Read();
            this.RcdFound219 = 0;
            this.ScanLoadIravrstaiznosa();
        }

        private void ScanStartIravrstaiznosa(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString219 + "  FROM [IRAVRSTAIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDIRAVRSTAIZNOSA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString219, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDIRAVRSTAIZNOSA] ) AS DK_PAGENUM   FROM [IRAVRSTAIZNOSA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString219 + " FROM [IRAVRSTAIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDIRAVRSTAIZNOSA] ";
            }
            this.cmIRAVRSTAIZNOSASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.IRAVRSTAIZNOSASelect4 = this.cmIRAVRSTAIZNOSASelect4.FetchData();
            this.RcdFound219 = 0;
            this.ScanLoadIravrstaiznosa();
            this.LoadDataIravrstaiznosa(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.IRAVRSTAIZNOSASet = (IRAVRSTAIZNOSADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.IRAVRSTAIZNOSASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.IRAVRSTAIZNOSASet.IRAVRSTAIZNOSA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow current = (IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow) enumerator.Current;
                        this.rowIRAVRSTAIZNOSA = current;
                        if (Helpers.IsRowChanged(this.rowIRAVRSTAIZNOSA))
                        {
                            this.ReadRowIravrstaiznosa();
                            if (this.rowIRAVRSTAIZNOSA.RowState == DataRowState.Added)
                            {
                                this.InsertIravrstaiznosa();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateIravrstaiznosa();
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

        private void UpdateIravrstaiznosa()
        {
            this.CheckOptimisticConcurrencyIravrstaiznosa();
            this.AfterConfirmIravrstaiznosa();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [IRAVRSTAIZNOSA] SET [IRAVRSTAIZNOSANAZIV]=@IRAVRSTAIZNOSANAZIV  WHERE [IDIRAVRSTAIZNOSA] = @IDIRAVRSTAIZNOSA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IRAVRSTAIZNOSANAZIV", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIRAVRSTAIZNOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIRAVRSTAIZNOSA["IRAVRSTAIZNOSANAZIV"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowIRAVRSTAIZNOSA["IDIRAVRSTAIZNOSA"]));
            command.ExecuteStmt();
            this.OnIRAVRSTAIZNOSAUpdated(new IRAVRSTAIZNOSAEventArgs(this.rowIRAVRSTAIZNOSA, StatementType.Update));
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
        public class IRAVRSTAIZNOSADataChangedException : DataChangedException
        {
            public IRAVRSTAIZNOSADataChangedException()
            {
            }

            public IRAVRSTAIZNOSADataChangedException(string message) : base(message)
            {
            }

            protected IRAVRSTAIZNOSADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IRAVRSTAIZNOSADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class IRAVRSTAIZNOSADataLockedException : DataLockedException
        {
            public IRAVRSTAIZNOSADataLockedException()
            {
            }

            public IRAVRSTAIZNOSADataLockedException(string message) : base(message)
            {
            }

            protected IRAVRSTAIZNOSADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IRAVRSTAIZNOSADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class IRAVRSTAIZNOSADuplicateKeyException : DuplicateKeyException
        {
            public IRAVRSTAIZNOSADuplicateKeyException()
            {
            }

            public IRAVRSTAIZNOSADuplicateKeyException(string message) : base(message)
            {
            }

            protected IRAVRSTAIZNOSADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IRAVRSTAIZNOSADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class IRAVRSTAIZNOSAEventArgs : EventArgs
        {
            private IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public IRAVRSTAIZNOSAEventArgs(IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow Row
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
        public class IRAVRSTAIZNOSANotFoundException : DataNotFoundException
        {
            public IRAVRSTAIZNOSANotFoundException()
            {
            }

            public IRAVRSTAIZNOSANotFoundException(string message) : base(message)
            {
            }

            protected IRAVRSTAIZNOSANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IRAVRSTAIZNOSANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void IRAVRSTAIZNOSAUpdateEventHandler(object sender, IRAVRSTAIZNOSADataAdapter.IRAVRSTAIZNOSAEventArgs e);

        [Serializable]
        public class SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException : InvalidDeleteException
        {
            public SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException()
            {
            }

            public SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

