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

    public class URAVRSTAIZNOSADataAdapter : IDataAdapter, IURAVRSTAIZNOSADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmURAVRSTAIZNOSASelect1;
        private ReadWriteCommand cmURAVRSTAIZNOSASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__URAVRSTAIZNOSANAZIVOriginal;
        private readonly string m_SelectString217 = "TM1.[IDURAVRSTAIZNOSA], TM1.[URAVRSTAIZNOSANAZIV]";
        private string m_WhereString;
        private short RcdFound217;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow rowURAVRSTAIZNOSA;
        private string scmdbuf;
        private StatementType sMode217;
        private IDataReader URAVRSTAIZNOSASelect1;
        private IDataReader URAVRSTAIZNOSASelect4;
        private URAVRSTAIZNOSADataSet URAVRSTAIZNOSASet;

        public event URAVRSTAIZNOSAUpdateEventHandler URAVRSTAIZNOSAUpdated;

        public event URAVRSTAIZNOSAUpdateEventHandler URAVRSTAIZNOSAUpdating;

        private void AddRowUravrstaiznosa()
        {
            this.URAVRSTAIZNOSASet.URAVRSTAIZNOSA.AddURAVRSTAIZNOSARow(this.rowURAVRSTAIZNOSA);
        }

        private void AfterConfirmUravrstaiznosa()
        {
            this.OnURAVRSTAIZNOSAUpdating(new URAVRSTAIZNOSAEventArgs(this.rowURAVRSTAIZNOSA, this.Gx_mode));
        }

        private void CheckDeleteErrorsUravrstaiznosa()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAURA], [SHEMAURAKONTOIDKONTO], [SHEMAURASTRANEIDSTRANEKNJIZENJA], [IDURAVRSTAIZNOSA] FROM [SHEMAURASHEMAURAKONTIRANJE] WITH (NOLOCK) WHERE [IDURAVRSTAIZNOSA] = @IDURAVRSTAIZNOSA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDURAVRSTAIZNOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURAVRSTAIZNOSA["IDURAVRSTAIZNOSA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAURAKONTIRANJE" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyUravrstaiznosa()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDURAVRSTAIZNOSA], [URAVRSTAIZNOSANAZIV] FROM [URAVRSTAIZNOSA] WITH (UPDLOCK) WHERE [IDURAVRSTAIZNOSA] = @IDURAVRSTAIZNOSA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDURAVRSTAIZNOSA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURAVRSTAIZNOSA["IDURAVRSTAIZNOSA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new URAVRSTAIZNOSADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("URAVRSTAIZNOSA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__URAVRSTAIZNOSANAZIVOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new URAVRSTAIZNOSADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("URAVRSTAIZNOSA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowUravrstaiznosa()
        {
            this.rowURAVRSTAIZNOSA = this.URAVRSTAIZNOSASet.URAVRSTAIZNOSA.NewURAVRSTAIZNOSARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyUravrstaiznosa();
            this.AfterConfirmUravrstaiznosa();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [URAVRSTAIZNOSA]  WHERE [IDURAVRSTAIZNOSA] = @IDURAVRSTAIZNOSA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDURAVRSTAIZNOSA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURAVRSTAIZNOSA["IDURAVRSTAIZNOSA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsUravrstaiznosa();
            }
            this.OnURAVRSTAIZNOSAUpdated(new URAVRSTAIZNOSAEventArgs(this.rowURAVRSTAIZNOSA, StatementType.Delete));
            this.rowURAVRSTAIZNOSA.Delete();
            this.sMode217 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode217;
        }

        public virtual int Fill(URAVRSTAIZNOSADataSet dataSet)
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
                    this.URAVRSTAIZNOSASet = dataSet;
                    this.LoadChildUravrstaiznosa(0, -1);
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
            this.URAVRSTAIZNOSASet = (URAVRSTAIZNOSADataSet) dataSet;
            if (this.URAVRSTAIZNOSASet != null)
            {
                return this.Fill(this.URAVRSTAIZNOSASet);
            }
            this.URAVRSTAIZNOSASet = new URAVRSTAIZNOSADataSet();
            this.Fill(this.URAVRSTAIZNOSASet);
            dataSet.Merge(this.URAVRSTAIZNOSASet);
            return 0;
        }

        public virtual int Fill(URAVRSTAIZNOSADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDURAVRSTAIZNOSA"]));
        }

        public virtual int Fill(URAVRSTAIZNOSADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDURAVRSTAIZNOSA"]));
        }

        public virtual int Fill(URAVRSTAIZNOSADataSet dataSet, int iDURAVRSTAIZNOSA)
        {
            if (!this.FillByIDURAVRSTAIZNOSA(dataSet, iDURAVRSTAIZNOSA))
            {
                throw new URAVRSTAIZNOSANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("URAVRSTAIZNOSA") }));
            }
            return 0;
        }

        public virtual bool FillByIDURAVRSTAIZNOSA(URAVRSTAIZNOSADataSet dataSet, int iDURAVRSTAIZNOSA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.URAVRSTAIZNOSASet = dataSet;
            this.rowURAVRSTAIZNOSA = this.URAVRSTAIZNOSASet.URAVRSTAIZNOSA.NewURAVRSTAIZNOSARow();
            this.rowURAVRSTAIZNOSA.IDURAVRSTAIZNOSA = iDURAVRSTAIZNOSA;
            try
            {
                this.LoadByIDURAVRSTAIZNOSA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound217 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(URAVRSTAIZNOSADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.URAVRSTAIZNOSASet = dataSet;
            try
            {
                this.LoadChildUravrstaiznosa(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDURAVRSTAIZNOSA], [URAVRSTAIZNOSANAZIV] FROM [URAVRSTAIZNOSA] WITH (NOLOCK) WHERE [IDURAVRSTAIZNOSA] = @IDURAVRSTAIZNOSA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDURAVRSTAIZNOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURAVRSTAIZNOSA["IDURAVRSTAIZNOSA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound217 = 1;
                this.rowURAVRSTAIZNOSA["IDURAVRSTAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowURAVRSTAIZNOSA["URAVRSTAIZNOSANAZIV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode217 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode217;
            }
            else
            {
                this.RcdFound217 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDURAVRSTAIZNOSA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmURAVRSTAIZNOSASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [URAVRSTAIZNOSA] WITH (NOLOCK) ", false);
            this.URAVRSTAIZNOSASelect1 = this.cmURAVRSTAIZNOSASelect1.FetchData();
            if (this.URAVRSTAIZNOSASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.URAVRSTAIZNOSASelect1.GetInt32(0);
            }
            this.URAVRSTAIZNOSASelect1.Close();
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
            this.RcdFound217 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__URAVRSTAIZNOSANAZIVOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.URAVRSTAIZNOSASet = new URAVRSTAIZNOSADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertUravrstaiznosa()
        {
            this.CheckOptimisticConcurrencyUravrstaiznosa();
            this.AfterConfirmUravrstaiznosa();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [URAVRSTAIZNOSA] ([IDURAVRSTAIZNOSA], [URAVRSTAIZNOSANAZIV]) VALUES (@IDURAVRSTAIZNOSA, @URAVRSTAIZNOSANAZIV)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDURAVRSTAIZNOSA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAVRSTAIZNOSANAZIV", DbType.String, 30));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURAVRSTAIZNOSA["IDURAVRSTAIZNOSA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowURAVRSTAIZNOSA["URAVRSTAIZNOSANAZIV"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new URAVRSTAIZNOSADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnURAVRSTAIZNOSAUpdated(new URAVRSTAIZNOSAEventArgs(this.rowURAVRSTAIZNOSA, StatementType.Insert));
        }

        private void LoadByIDURAVRSTAIZNOSA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.URAVRSTAIZNOSASet.EnforceConstraints;
            this.URAVRSTAIZNOSASet.URAVRSTAIZNOSA.BeginLoadData();
            this.ScanByIDURAVRSTAIZNOSA(startRow, maxRows);
            this.URAVRSTAIZNOSASet.URAVRSTAIZNOSA.EndLoadData();
            this.URAVRSTAIZNOSASet.EnforceConstraints = enforceConstraints;
            if (this.URAVRSTAIZNOSASet.URAVRSTAIZNOSA.Count > 0)
            {
                this.rowURAVRSTAIZNOSA = this.URAVRSTAIZNOSASet.URAVRSTAIZNOSA[this.URAVRSTAIZNOSASet.URAVRSTAIZNOSA.Count - 1];
            }
        }

        private void LoadChildUravrstaiznosa(int startRow, int maxRows)
        {
            this.CreateNewRowUravrstaiznosa();
            bool enforceConstraints = this.URAVRSTAIZNOSASet.EnforceConstraints;
            this.URAVRSTAIZNOSASet.URAVRSTAIZNOSA.BeginLoadData();
            this.ScanStartUravrstaiznosa(startRow, maxRows);
            this.URAVRSTAIZNOSASet.URAVRSTAIZNOSA.EndLoadData();
            this.URAVRSTAIZNOSASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataUravrstaiznosa(int maxRows)
        {
            int num = 0;
            if (this.RcdFound217 != 0)
            {
                this.ScanLoadUravrstaiznosa();
                while ((this.RcdFound217 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowUravrstaiznosa();
                    this.CreateNewRowUravrstaiznosa();
                    this.ScanNextUravrstaiznosa();
                }
            }
            if (num > 0)
            {
                this.RcdFound217 = 1;
            }
            this.ScanEndUravrstaiznosa();
            if (this.URAVRSTAIZNOSASet.URAVRSTAIZNOSA.Count > 0)
            {
                this.rowURAVRSTAIZNOSA = this.URAVRSTAIZNOSASet.URAVRSTAIZNOSA[this.URAVRSTAIZNOSASet.URAVRSTAIZNOSA.Count - 1];
            }
        }

        private void LoadRowUravrstaiznosa()
        {
            this.AddRowUravrstaiznosa();
        }

        private void OnURAVRSTAIZNOSAUpdated(URAVRSTAIZNOSAEventArgs e)
        {
            if (this.URAVRSTAIZNOSAUpdated != null)
            {
                URAVRSTAIZNOSAUpdateEventHandler uRAVRSTAIZNOSAUpdatedEvent = this.URAVRSTAIZNOSAUpdated;
                if (uRAVRSTAIZNOSAUpdatedEvent != null)
                {
                    uRAVRSTAIZNOSAUpdatedEvent(this, e);
                }
            }
        }

        private void OnURAVRSTAIZNOSAUpdating(URAVRSTAIZNOSAEventArgs e)
        {
            if (this.URAVRSTAIZNOSAUpdating != null)
            {
                URAVRSTAIZNOSAUpdateEventHandler uRAVRSTAIZNOSAUpdatingEvent = this.URAVRSTAIZNOSAUpdating;
                if (uRAVRSTAIZNOSAUpdatingEvent != null)
                {
                    uRAVRSTAIZNOSAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowUravrstaiznosa()
        {
            this.Gx_mode = Mode.FromRowState(this.rowURAVRSTAIZNOSA.RowState);
            if (this.rowURAVRSTAIZNOSA.RowState != DataRowState.Added)
            {
                this.m__URAVRSTAIZNOSANAZIVOriginal = RuntimeHelpers.GetObjectValue(this.rowURAVRSTAIZNOSA["URAVRSTAIZNOSANAZIV", DataRowVersion.Original]);
            }
            else
            {
                this.m__URAVRSTAIZNOSANAZIVOriginal = RuntimeHelpers.GetObjectValue(this.rowURAVRSTAIZNOSA["URAVRSTAIZNOSANAZIV"]);
            }
            this._Gxremove = this.rowURAVRSTAIZNOSA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowURAVRSTAIZNOSA = (URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow) DataSetUtil.CloneOriginalDataRow(this.rowURAVRSTAIZNOSA);
            }
        }

        private void ScanByIDURAVRSTAIZNOSA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDURAVRSTAIZNOSA] = @IDURAVRSTAIZNOSA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString217 + "  FROM [URAVRSTAIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDURAVRSTAIZNOSA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString217, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDURAVRSTAIZNOSA] ) AS DK_PAGENUM   FROM [URAVRSTAIZNOSA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString217 + " FROM [URAVRSTAIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDURAVRSTAIZNOSA] ";
            }
            this.cmURAVRSTAIZNOSASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmURAVRSTAIZNOSASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmURAVRSTAIZNOSASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDURAVRSTAIZNOSA", DbType.Int32));
            }
            this.cmURAVRSTAIZNOSASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURAVRSTAIZNOSA["IDURAVRSTAIZNOSA"]));
            this.URAVRSTAIZNOSASelect4 = this.cmURAVRSTAIZNOSASelect4.FetchData();
            this.RcdFound217 = 0;
            this.ScanLoadUravrstaiznosa();
            this.LoadDataUravrstaiznosa(maxRows);
        }

        private void ScanEndUravrstaiznosa()
        {
            this.URAVRSTAIZNOSASelect4.Close();
        }

        private void ScanLoadUravrstaiznosa()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmURAVRSTAIZNOSASelect4.HasMoreRows)
            {
                this.RcdFound217 = 1;
                this.rowURAVRSTAIZNOSA["IDURAVRSTAIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.URAVRSTAIZNOSASelect4, 0));
                this.rowURAVRSTAIZNOSA["URAVRSTAIZNOSANAZIV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.URAVRSTAIZNOSASelect4, 1));
            }
        }

        private void ScanNextUravrstaiznosa()
        {
            this.cmURAVRSTAIZNOSASelect4.HasMoreRows = this.URAVRSTAIZNOSASelect4.Read();
            this.RcdFound217 = 0;
            this.ScanLoadUravrstaiznosa();
        }

        private void ScanStartUravrstaiznosa(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString217 + "  FROM [URAVRSTAIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDURAVRSTAIZNOSA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString217, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDURAVRSTAIZNOSA] ) AS DK_PAGENUM   FROM [URAVRSTAIZNOSA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString217 + " FROM [URAVRSTAIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDURAVRSTAIZNOSA] ";
            }
            this.cmURAVRSTAIZNOSASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.URAVRSTAIZNOSASelect4 = this.cmURAVRSTAIZNOSASelect4.FetchData();
            this.RcdFound217 = 0;
            this.ScanLoadUravrstaiznosa();
            this.LoadDataUravrstaiznosa(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.URAVRSTAIZNOSASet = (URAVRSTAIZNOSADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.URAVRSTAIZNOSASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.URAVRSTAIZNOSASet.URAVRSTAIZNOSA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow current = (URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow) enumerator.Current;
                        this.rowURAVRSTAIZNOSA = current;
                        if (Helpers.IsRowChanged(this.rowURAVRSTAIZNOSA))
                        {
                            this.ReadRowUravrstaiznosa();
                            if (this.rowURAVRSTAIZNOSA.RowState == DataRowState.Added)
                            {
                                this.InsertUravrstaiznosa();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateUravrstaiznosa();
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

        private void UpdateUravrstaiznosa()
        {
            this.CheckOptimisticConcurrencyUravrstaiznosa();
            this.AfterConfirmUravrstaiznosa();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [URAVRSTAIZNOSA] SET [URAVRSTAIZNOSANAZIV]=@URAVRSTAIZNOSANAZIV  WHERE [IDURAVRSTAIZNOSA] = @IDURAVRSTAIZNOSA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAVRSTAIZNOSANAZIV", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDURAVRSTAIZNOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowURAVRSTAIZNOSA["URAVRSTAIZNOSANAZIV"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowURAVRSTAIZNOSA["IDURAVRSTAIZNOSA"]));
            command.ExecuteStmt();
            this.OnURAVRSTAIZNOSAUpdated(new URAVRSTAIZNOSAEventArgs(this.rowURAVRSTAIZNOSA, StatementType.Update));
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
        public class SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException : InvalidDeleteException
        {
            public SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException()
            {
            }

            public SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class URAVRSTAIZNOSADataChangedException : DataChangedException
        {
            public URAVRSTAIZNOSADataChangedException()
            {
            }

            public URAVRSTAIZNOSADataChangedException(string message) : base(message)
            {
            }

            protected URAVRSTAIZNOSADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public URAVRSTAIZNOSADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class URAVRSTAIZNOSADataLockedException : DataLockedException
        {
            public URAVRSTAIZNOSADataLockedException()
            {
            }

            public URAVRSTAIZNOSADataLockedException(string message) : base(message)
            {
            }

            protected URAVRSTAIZNOSADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public URAVRSTAIZNOSADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class URAVRSTAIZNOSADuplicateKeyException : DuplicateKeyException
        {
            public URAVRSTAIZNOSADuplicateKeyException()
            {
            }

            public URAVRSTAIZNOSADuplicateKeyException(string message) : base(message)
            {
            }

            protected URAVRSTAIZNOSADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public URAVRSTAIZNOSADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class URAVRSTAIZNOSAEventArgs : EventArgs
        {
            private URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public URAVRSTAIZNOSAEventArgs(URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow Row
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
        public class URAVRSTAIZNOSANotFoundException : DataNotFoundException
        {
            public URAVRSTAIZNOSANotFoundException()
            {
            }

            public URAVRSTAIZNOSANotFoundException(string message) : base(message)
            {
            }

            protected URAVRSTAIZNOSANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public URAVRSTAIZNOSANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void URAVRSTAIZNOSAUpdateEventHandler(object sender, URAVRSTAIZNOSADataAdapter.URAVRSTAIZNOSAEventArgs e);
    }
}

