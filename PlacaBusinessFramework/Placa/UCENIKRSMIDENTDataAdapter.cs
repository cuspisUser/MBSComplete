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

    public class UCENIKRSMIDENTDataAdapter : IDataAdapter, IUCENIKRSMIDENTDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmUCENIKRSMIDENTSelect1;
        private ReadWriteCommand cmUCENIKRSMIDENTSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private readonly string m_SelectString296 = "TM1.[UCENIKRSMIDENT]";
        private string m_WhereString;
        private short RcdFound296;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow rowUCENIKRSMIDENT;
        private string scmdbuf;
        private StatementType sMode296;
        private IDataReader UCENIKRSMIDENTSelect1;
        private IDataReader UCENIKRSMIDENTSelect4;
        private UCENIKRSMIDENTDataSet UCENIKRSMIDENTSet;

        public event UCENIKRSMIDENTUpdateEventHandler UCENIKRSMIDENTUpdated;

        public event UCENIKRSMIDENTUpdateEventHandler UCENIKRSMIDENTUpdating;

        private void AddRowUcenikrsmident()
        {
            this.UCENIKRSMIDENTSet.UCENIKRSMIDENT.AddUCENIKRSMIDENTRow(this.rowUCENIKRSMIDENT);
        }

        private void AfterConfirmUcenikrsmident()
        {
            this.OnUCENIKRSMIDENTUpdating(new UCENIKRSMIDENTEventArgs(this.rowUCENIKRSMIDENT, this.Gx_mode));
        }

        private void CheckOptimisticConcurrencyUcenikrsmident()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [UCENIKRSMIDENT] FROM [UCENIKRSMIDENT] WITH (UPDLOCK) WHERE [UCENIKRSMIDENT] = @UCENIKRSMIDENT ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCENIKRSMIDENT", DbType.String, 4));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKRSMIDENT["UCENIKRSMIDENT"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new UCENIKRSMIDENTDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("UCENIKRSMIDENT") }));
                }
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new UCENIKRSMIDENTDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("UCENIKRSMIDENT") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowUcenikrsmident()
        {
            this.rowUCENIKRSMIDENT = this.UCENIKRSMIDENTSet.UCENIKRSMIDENT.NewUCENIKRSMIDENTRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyUcenikrsmident();
            this.AfterConfirmUcenikrsmident();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [UCENIKRSMIDENT]  WHERE [UCENIKRSMIDENT] = @UCENIKRSMIDENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCENIKRSMIDENT", DbType.String, 4));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKRSMIDENT["UCENIKRSMIDENT"]));
            command.ExecuteStmt();
            this.OnUCENIKRSMIDENTUpdated(new UCENIKRSMIDENTEventArgs(this.rowUCENIKRSMIDENT, StatementType.Delete));
            this.rowUCENIKRSMIDENT.Delete();
            this.sMode296 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode296;
        }

        public virtual int Fill(UCENIKRSMIDENTDataSet dataSet)
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
                    this.UCENIKRSMIDENTSet = dataSet;
                    this.LoadChildUcenikrsmident(0, -1);
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
            this.UCENIKRSMIDENTSet = (UCENIKRSMIDENTDataSet) dataSet;
            if (this.UCENIKRSMIDENTSet != null)
            {
                return this.Fill(this.UCENIKRSMIDENTSet);
            }
            this.UCENIKRSMIDENTSet = new UCENIKRSMIDENTDataSet();
            this.Fill(this.UCENIKRSMIDENTSet);
            dataSet.Merge(this.UCENIKRSMIDENTSet);
            return 0;
        }

        public virtual int Fill(UCENIKRSMIDENTDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["UCENIKRSMIDENT"]));
        }

        public virtual int Fill(UCENIKRSMIDENTDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["UCENIKRSMIDENT"]));
        }

        public virtual int Fill(UCENIKRSMIDENTDataSet dataSet, string uCENIKRSMIDENT)
        {
            if (!this.FillByUCENIKRSMIDENT(dataSet, uCENIKRSMIDENT))
            {
                throw new UCENIKRSMIDENTNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("UCENIKRSMIDENT") }));
            }
            return 0;
        }

        public virtual bool FillByUCENIKRSMIDENT(UCENIKRSMIDENTDataSet dataSet, string uCENIKRSMIDENT)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.UCENIKRSMIDENTSet = dataSet;
            this.rowUCENIKRSMIDENT = this.UCENIKRSMIDENTSet.UCENIKRSMIDENT.NewUCENIKRSMIDENTRow();
            this.rowUCENIKRSMIDENT.UCENIKRSMIDENT = uCENIKRSMIDENT;
            try
            {
                this.LoadByUCENIKRSMIDENT(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound296 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(UCENIKRSMIDENTDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.UCENIKRSMIDENTSet = dataSet;
            try
            {
                this.LoadChildUcenikrsmident(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [UCENIKRSMIDENT] FROM [UCENIKRSMIDENT] WITH (NOLOCK) WHERE [UCENIKRSMIDENT] = @UCENIKRSMIDENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCENIKRSMIDENT", DbType.String, 4));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKRSMIDENT["UCENIKRSMIDENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound296 = 1;
                this.rowUCENIKRSMIDENT["UCENIKRSMIDENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.sMode296 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode296;
            }
            else
            {
                this.RcdFound296 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "UCENIKRSMIDENT";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmUCENIKRSMIDENTSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [UCENIKRSMIDENT] WITH (NOLOCK) ", false);
            this.UCENIKRSMIDENTSelect1 = this.cmUCENIKRSMIDENTSelect1.FetchData();
            if (this.UCENIKRSMIDENTSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.UCENIKRSMIDENTSelect1.GetInt32(0);
            }
            this.UCENIKRSMIDENTSelect1.Close();
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
            this.RcdFound296 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.UCENIKRSMIDENTSet = new UCENIKRSMIDENTDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertUcenikrsmident()
        {
            this.CheckOptimisticConcurrencyUcenikrsmident();
            this.AfterConfirmUcenikrsmident();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [UCENIKRSMIDENT] ([UCENIKRSMIDENT]) VALUES (@UCENIKRSMIDENT)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCENIKRSMIDENT", DbType.String, 4));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKRSMIDENT["UCENIKRSMIDENT"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new UCENIKRSMIDENTDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnUCENIKRSMIDENTUpdated(new UCENIKRSMIDENTEventArgs(this.rowUCENIKRSMIDENT, StatementType.Insert));
        }

        private void LoadByUCENIKRSMIDENT(int startRow, int maxRows)
        {
            bool enforceConstraints = this.UCENIKRSMIDENTSet.EnforceConstraints;
            this.UCENIKRSMIDENTSet.UCENIKRSMIDENT.BeginLoadData();
            this.ScanByUCENIKRSMIDENT(startRow, maxRows);
            this.UCENIKRSMIDENTSet.UCENIKRSMIDENT.EndLoadData();
            this.UCENIKRSMIDENTSet.EnforceConstraints = enforceConstraints;
            if (this.UCENIKRSMIDENTSet.UCENIKRSMIDENT.Count > 0)
            {
                this.rowUCENIKRSMIDENT = this.UCENIKRSMIDENTSet.UCENIKRSMIDENT[this.UCENIKRSMIDENTSet.UCENIKRSMIDENT.Count - 1];
            }
        }

        private void LoadChildUcenikrsmident(int startRow, int maxRows)
        {
            this.CreateNewRowUcenikrsmident();
            bool enforceConstraints = this.UCENIKRSMIDENTSet.EnforceConstraints;
            this.UCENIKRSMIDENTSet.UCENIKRSMIDENT.BeginLoadData();
            this.ScanStartUcenikrsmident(startRow, maxRows);
            this.UCENIKRSMIDENTSet.UCENIKRSMIDENT.EndLoadData();
            this.UCENIKRSMIDENTSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataUcenikrsmident(int maxRows)
        {
            int num = 0;
            if (this.RcdFound296 != 0)
            {
                this.ScanLoadUcenikrsmident();
                while ((this.RcdFound296 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowUcenikrsmident();
                    this.CreateNewRowUcenikrsmident();
                    this.ScanNextUcenikrsmident();
                }
            }
            if (num > 0)
            {
                this.RcdFound296 = 1;
            }
            this.ScanEndUcenikrsmident();
            if (this.UCENIKRSMIDENTSet.UCENIKRSMIDENT.Count > 0)
            {
                this.rowUCENIKRSMIDENT = this.UCENIKRSMIDENTSet.UCENIKRSMIDENT[this.UCENIKRSMIDENTSet.UCENIKRSMIDENT.Count - 1];
            }
        }

        private void LoadRowUcenikrsmident()
        {
            this.AddRowUcenikrsmident();
        }

        private void OnUCENIKRSMIDENTUpdated(UCENIKRSMIDENTEventArgs e)
        {
            if (this.UCENIKRSMIDENTUpdated != null)
            {
                UCENIKRSMIDENTUpdateEventHandler uCENIKRSMIDENTUpdatedEvent = this.UCENIKRSMIDENTUpdated;
                if (uCENIKRSMIDENTUpdatedEvent != null)
                {
                    uCENIKRSMIDENTUpdatedEvent(this, e);
                }
            }
        }

        private void OnUCENIKRSMIDENTUpdating(UCENIKRSMIDENTEventArgs e)
        {
            if (this.UCENIKRSMIDENTUpdating != null)
            {
                UCENIKRSMIDENTUpdateEventHandler uCENIKRSMIDENTUpdatingEvent = this.UCENIKRSMIDENTUpdating;
                if (uCENIKRSMIDENTUpdatingEvent != null)
                {
                    uCENIKRSMIDENTUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowUcenikrsmident()
        {
            this.Gx_mode = Mode.FromRowState(this.rowUCENIKRSMIDENT.RowState);
            if (this.rowUCENIKRSMIDENT.RowState == DataRowState.Added)
            {
            }
            this._Gxremove = this.rowUCENIKRSMIDENT.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowUCENIKRSMIDENT = (UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow) DataSetUtil.CloneOriginalDataRow(this.rowUCENIKRSMIDENT);
            }
        }

        private void ScanByUCENIKRSMIDENT(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[UCENIKRSMIDENT] = @UCENIKRSMIDENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString296 + "  FROM [UCENIKRSMIDENT] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[UCENIKRSMIDENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString296, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[UCENIKRSMIDENT] ) AS DK_PAGENUM   FROM [UCENIKRSMIDENT] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString296 + " FROM [UCENIKRSMIDENT] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[UCENIKRSMIDENT] ";
            }
            this.cmUCENIKRSMIDENTSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmUCENIKRSMIDENTSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmUCENIKRSMIDENTSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@UCENIKRSMIDENT", DbType.String, 4));
            }
            this.cmUCENIKRSMIDENTSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIKRSMIDENT["UCENIKRSMIDENT"]));
            this.UCENIKRSMIDENTSelect4 = this.cmUCENIKRSMIDENTSelect4.FetchData();
            this.RcdFound296 = 0;
            this.ScanLoadUcenikrsmident();
            this.LoadDataUcenikrsmident(maxRows);
        }

        private void ScanEndUcenikrsmident()
        {
            this.UCENIKRSMIDENTSelect4.Close();
        }

        private void ScanLoadUcenikrsmident()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmUCENIKRSMIDENTSelect4.HasMoreRows)
            {
                this.RcdFound296 = 1;
                this.rowUCENIKRSMIDENT["UCENIKRSMIDENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKRSMIDENTSelect4, 0));
            }
        }

        private void ScanNextUcenikrsmident()
        {
            this.cmUCENIKRSMIDENTSelect4.HasMoreRows = this.UCENIKRSMIDENTSelect4.Read();
            this.RcdFound296 = 0;
            this.ScanLoadUcenikrsmident();
        }

        private void ScanStartUcenikrsmident(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString296 + "  FROM [UCENIKRSMIDENT] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[UCENIKRSMIDENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString296, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[UCENIKRSMIDENT] ) AS DK_PAGENUM   FROM [UCENIKRSMIDENT] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString296 + " FROM [UCENIKRSMIDENT] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[UCENIKRSMIDENT] ";
            }
            this.cmUCENIKRSMIDENTSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.UCENIKRSMIDENTSelect4 = this.cmUCENIKRSMIDENTSelect4.FetchData();
            this.RcdFound296 = 0;
            this.ScanLoadUcenikrsmident();
            this.LoadDataUcenikrsmident(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.UCENIKRSMIDENTSet = (UCENIKRSMIDENTDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.UCENIKRSMIDENTSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.UCENIKRSMIDENTSet.UCENIKRSMIDENT.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow current = (UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow) enumerator.Current;
                        this.rowUCENIKRSMIDENT = current;
                        if (Helpers.IsRowChanged(this.rowUCENIKRSMIDENT))
                        {
                            this.ReadRowUcenikrsmident();
                            if (this.rowUCENIKRSMIDENT.RowState == DataRowState.Added)
                            {
                                this.InsertUcenikrsmident();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateUcenikrsmident();
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

        private void UpdateUcenikrsmident()
        {
            this.CheckOptimisticConcurrencyUcenikrsmident();
            this.AfterConfirmUcenikrsmident();
            this.OnUCENIKRSMIDENTUpdated(new UCENIKRSMIDENTEventArgs(this.rowUCENIKRSMIDENT, StatementType.Update));
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
        public class UCENIKRSMIDENTDataChangedException : DataChangedException
        {
            public UCENIKRSMIDENTDataChangedException()
            {
            }

            public UCENIKRSMIDENTDataChangedException(string message) : base(message)
            {
            }

            protected UCENIKRSMIDENTDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UCENIKRSMIDENTDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class UCENIKRSMIDENTDataLockedException : DataLockedException
        {
            public UCENIKRSMIDENTDataLockedException()
            {
            }

            public UCENIKRSMIDENTDataLockedException(string message) : base(message)
            {
            }

            protected UCENIKRSMIDENTDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UCENIKRSMIDENTDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class UCENIKRSMIDENTDuplicateKeyException : DuplicateKeyException
        {
            public UCENIKRSMIDENTDuplicateKeyException()
            {
            }

            public UCENIKRSMIDENTDuplicateKeyException(string message) : base(message)
            {
            }

            protected UCENIKRSMIDENTDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UCENIKRSMIDENTDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class UCENIKRSMIDENTEventArgs : EventArgs
        {
            private UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public UCENIKRSMIDENTEventArgs(UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public UCENIKRSMIDENTDataSet.UCENIKRSMIDENTRow Row
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
        public class UCENIKRSMIDENTNotFoundException : DataNotFoundException
        {
            public UCENIKRSMIDENTNotFoundException()
            {
            }

            public UCENIKRSMIDENTNotFoundException(string message) : base(message)
            {
            }

            protected UCENIKRSMIDENTNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UCENIKRSMIDENTNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void UCENIKRSMIDENTUpdateEventHandler(object sender, UCENIKRSMIDENTDataAdapter.UCENIKRSMIDENTEventArgs e);
    }
}

