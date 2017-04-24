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

    public class POSTANSKIBROJEVIDataAdapter : IDataAdapter, IPOSTANSKIBROJEVIDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmPOSTANSKIBROJEVISelect1;
        private ReadWriteCommand cmPOSTANSKIBROJEVISelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVPOSTEOriginal;
        private readonly string m_SelectString299 = "TM1.[POSTANSKIBROJ], TM1.[NAZIVPOSTE]";
        private string m_WhereString;
        private IDataReader POSTANSKIBROJEVISelect1;
        private IDataReader POSTANSKIBROJEVISelect4;
        private POSTANSKIBROJEVIDataSet POSTANSKIBROJEVISet;
        private short RcdFound299;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow rowPOSTANSKIBROJEVI;
        private string scmdbuf;
        private StatementType sMode299;

        public event POSTANSKIBROJEVIUpdateEventHandler POSTANSKIBROJEVIUpdated;

        public event POSTANSKIBROJEVIUpdateEventHandler POSTANSKIBROJEVIUpdating;

        private void AddRowPostanskibrojevi()
        {
            this.POSTANSKIBROJEVISet.POSTANSKIBROJEVI.AddPOSTANSKIBROJEVIRow(this.rowPOSTANSKIBROJEVI);
        }

        private void AfterConfirmPostanskibrojevi()
        {
            this.OnPOSTANSKIBROJEVIUpdating(new POSTANSKIBROJEVIEventArgs(this.rowPOSTANSKIBROJEVI, this.Gx_mode));
        }

        private void CheckDeleteErrorsPostanskibrojevi()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDUCENIK] FROM [UCENIK] WITH (NOLOCK) WHERE [POSTANSKIBROJ] = @POSTANSKIBROJ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTANSKIBROJ", DbType.String, 5));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPOSTANSKIBROJEVI["POSTANSKIBROJ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new UCENIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "UCENIK" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyPostanskibrojevi()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [POSTANSKIBROJ], [NAZIVPOSTE] FROM [POSTANSKIBROJEVI] WITH (UPDLOCK) WHERE [POSTANSKIBROJ] = @POSTANSKIBROJ ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTANSKIBROJ", DbType.String, 5));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPOSTANSKIBROJEVI["POSTANSKIBROJ"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new POSTANSKIBROJEVIDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("POSTANSKIBROJEVI") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVPOSTEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new POSTANSKIBROJEVIDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("POSTANSKIBROJEVI") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowPostanskibrojevi()
        {
            this.rowPOSTANSKIBROJEVI = this.POSTANSKIBROJEVISet.POSTANSKIBROJEVI.NewPOSTANSKIBROJEVIRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyPostanskibrojevi();
            this.AfterConfirmPostanskibrojevi();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [POSTANSKIBROJEVI]  WHERE [POSTANSKIBROJ] = @POSTANSKIBROJ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTANSKIBROJ", DbType.String, 5));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPOSTANSKIBROJEVI["POSTANSKIBROJ"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsPostanskibrojevi();
            }
            this.OnPOSTANSKIBROJEVIUpdated(new POSTANSKIBROJEVIEventArgs(this.rowPOSTANSKIBROJEVI, StatementType.Delete));
            this.rowPOSTANSKIBROJEVI.Delete();
            this.sMode299 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode299;
        }

        public virtual int Fill(POSTANSKIBROJEVIDataSet dataSet)
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
                    this.POSTANSKIBROJEVISet = dataSet;
                    this.LoadChildPostanskibrojevi(0, -1);
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
            this.POSTANSKIBROJEVISet = (POSTANSKIBROJEVIDataSet) dataSet;
            if (this.POSTANSKIBROJEVISet != null)
            {
                return this.Fill(this.POSTANSKIBROJEVISet);
            }
            this.POSTANSKIBROJEVISet = new POSTANSKIBROJEVIDataSet();
            this.Fill(this.POSTANSKIBROJEVISet);
            dataSet.Merge(this.POSTANSKIBROJEVISet);
            return 0;
        }

        public virtual int Fill(POSTANSKIBROJEVIDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["POSTANSKIBROJ"]));
        }

        public virtual int Fill(POSTANSKIBROJEVIDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["POSTANSKIBROJ"]));
        }

        public virtual int Fill(POSTANSKIBROJEVIDataSet dataSet, string pOSTANSKIBROJ)
        {
            if (!this.FillByPOSTANSKIBROJ(dataSet, pOSTANSKIBROJ))
            {
                throw new POSTANSKIBROJEVINotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("POSTANSKIBROJEVI") }));
            }
            return 0;
        }

        public virtual bool FillByPOSTANSKIBROJ(POSTANSKIBROJEVIDataSet dataSet, string pOSTANSKIBROJ)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.POSTANSKIBROJEVISet = dataSet;
            this.rowPOSTANSKIBROJEVI = this.POSTANSKIBROJEVISet.POSTANSKIBROJEVI.NewPOSTANSKIBROJEVIRow();
            this.rowPOSTANSKIBROJEVI.POSTANSKIBROJ = pOSTANSKIBROJ;
            try
            {
                this.LoadByPOSTANSKIBROJ(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound299 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(POSTANSKIBROJEVIDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.POSTANSKIBROJEVISet = dataSet;
            try
            {
                this.LoadChildPostanskibrojevi(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [POSTANSKIBROJ], [NAZIVPOSTE] FROM [POSTANSKIBROJEVI] WITH (NOLOCK) WHERE [POSTANSKIBROJ] = @POSTANSKIBROJ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTANSKIBROJ", DbType.String, 5));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPOSTANSKIBROJEVI["POSTANSKIBROJ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound299 = 1;
                this.rowPOSTANSKIBROJEVI["POSTANSKIBROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowPOSTANSKIBROJEVI["NAZIVPOSTE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode299 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode299;
            }
            else
            {
                this.RcdFound299 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "POSTANSKIBROJ";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPOSTANSKIBROJEVISelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [POSTANSKIBROJEVI] WITH (NOLOCK) ", false);
            this.POSTANSKIBROJEVISelect1 = this.cmPOSTANSKIBROJEVISelect1.FetchData();
            if (this.POSTANSKIBROJEVISelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.POSTANSKIBROJEVISelect1.GetInt32(0);
            }
            this.POSTANSKIBROJEVISelect1.Close();
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
            this.RcdFound299 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVPOSTEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.POSTANSKIBROJEVISet = new POSTANSKIBROJEVIDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertPostanskibrojevi()
        {
            this.CheckOptimisticConcurrencyPostanskibrojevi();
            this.AfterConfirmPostanskibrojevi();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [POSTANSKIBROJEVI] ([POSTANSKIBROJ], [NAZIVPOSTE]) VALUES (@POSTANSKIBROJ, @NAZIVPOSTE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTANSKIBROJ", DbType.String, 5));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPOSTE", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPOSTANSKIBROJEVI["POSTANSKIBROJ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPOSTANSKIBROJEVI["NAZIVPOSTE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new POSTANSKIBROJEVIDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnPOSTANSKIBROJEVIUpdated(new POSTANSKIBROJEVIEventArgs(this.rowPOSTANSKIBROJEVI, StatementType.Insert));
        }

        private void LoadByPOSTANSKIBROJ(int startRow, int maxRows)
        {
            bool enforceConstraints = this.POSTANSKIBROJEVISet.EnforceConstraints;
            this.POSTANSKIBROJEVISet.POSTANSKIBROJEVI.BeginLoadData();
            this.ScanByPOSTANSKIBROJ(startRow, maxRows);
            this.POSTANSKIBROJEVISet.POSTANSKIBROJEVI.EndLoadData();
            this.POSTANSKIBROJEVISet.EnforceConstraints = enforceConstraints;
            if (this.POSTANSKIBROJEVISet.POSTANSKIBROJEVI.Count > 0)
            {
                this.rowPOSTANSKIBROJEVI = this.POSTANSKIBROJEVISet.POSTANSKIBROJEVI[this.POSTANSKIBROJEVISet.POSTANSKIBROJEVI.Count - 1];
            }
        }

        private void LoadChildPostanskibrojevi(int startRow, int maxRows)
        {
            this.CreateNewRowPostanskibrojevi();
            bool enforceConstraints = this.POSTANSKIBROJEVISet.EnforceConstraints;
            this.POSTANSKIBROJEVISet.POSTANSKIBROJEVI.BeginLoadData();
            this.ScanStartPostanskibrojevi(startRow, maxRows);
            this.POSTANSKIBROJEVISet.POSTANSKIBROJEVI.EndLoadData();
            this.POSTANSKIBROJEVISet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataPostanskibrojevi(int maxRows)
        {
            int num = 0;
            if (this.RcdFound299 != 0)
            {
                this.ScanLoadPostanskibrojevi();
                while ((this.RcdFound299 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowPostanskibrojevi();
                    this.CreateNewRowPostanskibrojevi();
                    this.ScanNextPostanskibrojevi();
                }
            }
            if (num > 0)
            {
                this.RcdFound299 = 1;
            }
            this.ScanEndPostanskibrojevi();
            if (this.POSTANSKIBROJEVISet.POSTANSKIBROJEVI.Count > 0)
            {
                this.rowPOSTANSKIBROJEVI = this.POSTANSKIBROJEVISet.POSTANSKIBROJEVI[this.POSTANSKIBROJEVISet.POSTANSKIBROJEVI.Count - 1];
            }
        }

        private void LoadRowPostanskibrojevi()
        {
            this.AddRowPostanskibrojevi();
        }

        private void OnPOSTANSKIBROJEVIUpdated(POSTANSKIBROJEVIEventArgs e)
        {
            if (this.POSTANSKIBROJEVIUpdated != null)
            {
                POSTANSKIBROJEVIUpdateEventHandler pOSTANSKIBROJEVIUpdatedEvent = this.POSTANSKIBROJEVIUpdated;
                if (pOSTANSKIBROJEVIUpdatedEvent != null)
                {
                    pOSTANSKIBROJEVIUpdatedEvent(this, e);
                }
            }
        }

        private void OnPOSTANSKIBROJEVIUpdating(POSTANSKIBROJEVIEventArgs e)
        {
            if (this.POSTANSKIBROJEVIUpdating != null)
            {
                POSTANSKIBROJEVIUpdateEventHandler pOSTANSKIBROJEVIUpdatingEvent = this.POSTANSKIBROJEVIUpdating;
                if (pOSTANSKIBROJEVIUpdatingEvent != null)
                {
                    pOSTANSKIBROJEVIUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowPostanskibrojevi()
        {
            this.Gx_mode = Mode.FromRowState(this.rowPOSTANSKIBROJEVI.RowState);
            if (this.rowPOSTANSKIBROJEVI.RowState != DataRowState.Added)
            {
                this.m__NAZIVPOSTEOriginal = RuntimeHelpers.GetObjectValue(this.rowPOSTANSKIBROJEVI["NAZIVPOSTE", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVPOSTEOriginal = RuntimeHelpers.GetObjectValue(this.rowPOSTANSKIBROJEVI["NAZIVPOSTE"]);
            }
            this._Gxremove = this.rowPOSTANSKIBROJEVI.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowPOSTANSKIBROJEVI = (POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow) DataSetUtil.CloneOriginalDataRow(this.rowPOSTANSKIBROJEVI);
            }
        }

        private void ScanByPOSTANSKIBROJ(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[POSTANSKIBROJ] = @POSTANSKIBROJ";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString299 + "  FROM [POSTANSKIBROJEVI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[POSTANSKIBROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString299, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[POSTANSKIBROJ] ) AS DK_PAGENUM   FROM [POSTANSKIBROJEVI] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString299 + " FROM [POSTANSKIBROJEVI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[POSTANSKIBROJ] ";
            }
            this.cmPOSTANSKIBROJEVISelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmPOSTANSKIBROJEVISelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmPOSTANSKIBROJEVISelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTANSKIBROJ", DbType.String, 5));
            }
            this.cmPOSTANSKIBROJEVISelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPOSTANSKIBROJEVI["POSTANSKIBROJ"]));
            this.POSTANSKIBROJEVISelect4 = this.cmPOSTANSKIBROJEVISelect4.FetchData();
            this.RcdFound299 = 0;
            this.ScanLoadPostanskibrojevi();
            this.LoadDataPostanskibrojevi(maxRows);
        }

        private void ScanEndPostanskibrojevi()
        {
            this.POSTANSKIBROJEVISelect4.Close();
        }

        private void ScanLoadPostanskibrojevi()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmPOSTANSKIBROJEVISelect4.HasMoreRows)
            {
                this.RcdFound299 = 1;
                this.rowPOSTANSKIBROJEVI["POSTANSKIBROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.POSTANSKIBROJEVISelect4, 0));
                this.rowPOSTANSKIBROJEVI["NAZIVPOSTE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.POSTANSKIBROJEVISelect4, 1));
            }
        }

        private void ScanNextPostanskibrojevi()
        {
            this.cmPOSTANSKIBROJEVISelect4.HasMoreRows = this.POSTANSKIBROJEVISelect4.Read();
            this.RcdFound299 = 0;
            this.ScanLoadPostanskibrojevi();
        }

        private void ScanStartPostanskibrojevi(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString299 + "  FROM [POSTANSKIBROJEVI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[POSTANSKIBROJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString299, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[POSTANSKIBROJ] ) AS DK_PAGENUM   FROM [POSTANSKIBROJEVI] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString299 + " FROM [POSTANSKIBROJEVI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[POSTANSKIBROJ] ";
            }
            this.cmPOSTANSKIBROJEVISelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.POSTANSKIBROJEVISelect4 = this.cmPOSTANSKIBROJEVISelect4.FetchData();
            this.RcdFound299 = 0;
            this.ScanLoadPostanskibrojevi();
            this.LoadDataPostanskibrojevi(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.POSTANSKIBROJEVISet = (POSTANSKIBROJEVIDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.POSTANSKIBROJEVISet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.POSTANSKIBROJEVISet.POSTANSKIBROJEVI.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow current = (POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow) enumerator.Current;
                        this.rowPOSTANSKIBROJEVI = current;
                        if (Helpers.IsRowChanged(this.rowPOSTANSKIBROJEVI))
                        {
                            this.ReadRowPostanskibrojevi();
                            if (this.rowPOSTANSKIBROJEVI.RowState == DataRowState.Added)
                            {
                                this.InsertPostanskibrojevi();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdatePostanskibrojevi();
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

        private void UpdatePostanskibrojevi()
        {
            this.CheckOptimisticConcurrencyPostanskibrojevi();
            this.AfterConfirmPostanskibrojevi();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [POSTANSKIBROJEVI] SET [NAZIVPOSTE]=@NAZIVPOSTE  WHERE [POSTANSKIBROJ] = @POSTANSKIBROJ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVPOSTE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTANSKIBROJ", DbType.String, 5));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowPOSTANSKIBROJEVI["NAZIVPOSTE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowPOSTANSKIBROJEVI["POSTANSKIBROJ"]));
            command.ExecuteStmt();
            this.OnPOSTANSKIBROJEVIUpdated(new POSTANSKIBROJEVIEventArgs(this.rowPOSTANSKIBROJEVI, StatementType.Update));
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
        public class POSTANSKIBROJEVIDataChangedException : DataChangedException
        {
            public POSTANSKIBROJEVIDataChangedException()
            {
            }

            public POSTANSKIBROJEVIDataChangedException(string message) : base(message)
            {
            }

            protected POSTANSKIBROJEVIDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public POSTANSKIBROJEVIDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class POSTANSKIBROJEVIDataLockedException : DataLockedException
        {
            public POSTANSKIBROJEVIDataLockedException()
            {
            }

            public POSTANSKIBROJEVIDataLockedException(string message) : base(message)
            {
            }

            protected POSTANSKIBROJEVIDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public POSTANSKIBROJEVIDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class POSTANSKIBROJEVIDuplicateKeyException : DuplicateKeyException
        {
            public POSTANSKIBROJEVIDuplicateKeyException()
            {
            }

            public POSTANSKIBROJEVIDuplicateKeyException(string message) : base(message)
            {
            }

            protected POSTANSKIBROJEVIDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public POSTANSKIBROJEVIDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class POSTANSKIBROJEVIEventArgs : EventArgs
        {
            private POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public POSTANSKIBROJEVIEventArgs(POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public POSTANSKIBROJEVIDataSet.POSTANSKIBROJEVIRow Row
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
        public class POSTANSKIBROJEVINotFoundException : DataNotFoundException
        {
            public POSTANSKIBROJEVINotFoundException()
            {
            }

            public POSTANSKIBROJEVINotFoundException(string message) : base(message)
            {
            }

            protected POSTANSKIBROJEVINotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public POSTANSKIBROJEVINotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void POSTANSKIBROJEVIUpdateEventHandler(object sender, POSTANSKIBROJEVIDataAdapter.POSTANSKIBROJEVIEventArgs e);

        [Serializable]
        public class UCENIKInvalidDeleteException : InvalidDeleteException
        {
            public UCENIKInvalidDeleteException()
            {
            }

            public UCENIKInvalidDeleteException(string message) : base(message)
            {
            }

            protected UCENIKInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UCENIKInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

