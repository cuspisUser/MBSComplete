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

    public class BENEFICIRANIDataAdapter : IDataAdapter, IBENEFICIRANIDataAdapter
    {
        private bool _Gxremove;
        private IDataReader BENEFICIRANISelect1;
        private IDataReader BENEFICIRANISelect4;
        private BENEFICIRANIDataSet BENEFICIRANISet;
        private ReadWriteCommand cmBENEFICIRANISelect1;
        private ReadWriteCommand cmBENEFICIRANISelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__BROJPRIZNATIHMJESECIOriginal;
        private object m__NAZIVBENEFICIRANIOriginal;
        private readonly string m_SelectString3 = "TM1.[IDBENEFICIRANI], TM1.[NAZIVBENEFICIRANI], TM1.[BROJPRIZNATIHMJESECI]";
        private string m_WhereString;
        private short RcdFound3;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private BENEFICIRANIDataSet.BENEFICIRANIRow rowBENEFICIRANI;
        private string scmdbuf;
        private StatementType sMode3;

        public event BENEFICIRANIUpdateEventHandler BENEFICIRANIUpdated;

        public event BENEFICIRANIUpdateEventHandler BENEFICIRANIUpdating;

        private void AddRowBeneficirani()
        {
            this.BENEFICIRANISet.BENEFICIRANI.AddBENEFICIRANIRow(this.rowBENEFICIRANI);
        }

        private void AfterConfirmBeneficirani()
        {
            this.OnBENEFICIRANIUpdating(new BENEFICIRANIEventArgs(this.rowBENEFICIRANI, this.Gx_mode));
        }

        private void CheckDeleteErrorsBeneficirani()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK] FROM [RADNIK] WITH (NOLOCK) WHERE [IDBENEFICIRANI] = @IDBENEFICIRANI ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBENEFICIRANI["IDBENEFICIRANI"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIK" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyBeneficirani()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDBENEFICIRANI], [NAZIVBENEFICIRANI], [BROJPRIZNATIHMJESECI] FROM [BENEFICIRANI] WITH (UPDLOCK) WHERE [IDBENEFICIRANI] = @IDBENEFICIRANI ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBENEFICIRANI["IDBENEFICIRANI"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new BENEFICIRANIDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("BENEFICIRANI") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVBENEFICIRANIOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || !this.m__BROJPRIZNATIHMJESECIOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 2))))
                {
                    reader.Close();
                    throw new BENEFICIRANIDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("BENEFICIRANI") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowBeneficirani()
        {
            this.rowBENEFICIRANI = this.BENEFICIRANISet.BENEFICIRANI.NewBENEFICIRANIRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyBeneficirani();
            this.AfterConfirmBeneficirani();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [BENEFICIRANI]  WHERE [IDBENEFICIRANI] = @IDBENEFICIRANI", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBENEFICIRANI["IDBENEFICIRANI"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsBeneficirani();
            }
            this.OnBENEFICIRANIUpdated(new BENEFICIRANIEventArgs(this.rowBENEFICIRANI, StatementType.Delete));
            this.rowBENEFICIRANI.Delete();
            this.sMode3 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode3;
        }

        public virtual int Fill(BENEFICIRANIDataSet dataSet)
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
                    this.BENEFICIRANISet = dataSet;
                    this.LoadChildBeneficirani(0, -1);
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
            this.BENEFICIRANISet = (BENEFICIRANIDataSet) dataSet;
            if (this.BENEFICIRANISet != null)
            {
                return this.Fill(this.BENEFICIRANISet);
            }
            this.BENEFICIRANISet = new BENEFICIRANIDataSet();
            this.Fill(this.BENEFICIRANISet);
            dataSet.Merge(this.BENEFICIRANISet);
            return 0;
        }

        public virtual int Fill(BENEFICIRANIDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["IDBENEFICIRANI"]));
        }

        public virtual int Fill(BENEFICIRANIDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["IDBENEFICIRANI"]));
        }

        public virtual int Fill(BENEFICIRANIDataSet dataSet, string iDBENEFICIRANI)
        {
            if (!this.FillByIDBENEFICIRANI(dataSet, iDBENEFICIRANI))
            {
                throw new BENEFICIRANINotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("BENEFICIRANI") }));
            }
            return 0;
        }

        public virtual bool FillByIDBENEFICIRANI(BENEFICIRANIDataSet dataSet, string iDBENEFICIRANI)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.BENEFICIRANISet = dataSet;
            this.rowBENEFICIRANI = this.BENEFICIRANISet.BENEFICIRANI.NewBENEFICIRANIRow();
            this.rowBENEFICIRANI.IDBENEFICIRANI = iDBENEFICIRANI;
            try
            {
                this.LoadByIDBENEFICIRANI(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound3 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(BENEFICIRANIDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.BENEFICIRANISet = dataSet;
            try
            {
                this.LoadChildBeneficirani(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDBENEFICIRANI], [NAZIVBENEFICIRANI], [BROJPRIZNATIHMJESECI] FROM [BENEFICIRANI] WITH (NOLOCK) WHERE [IDBENEFICIRANI] = @IDBENEFICIRANI ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBENEFICIRANI["IDBENEFICIRANI"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound3 = 1;
                this.rowBENEFICIRANI["IDBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowBENEFICIRANI["NAZIVBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowBENEFICIRANI["BROJPRIZNATIHMJESECI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 2));
                this.sMode3 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode3;
            }
            else
            {
                this.RcdFound3 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDBENEFICIRANI";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmBENEFICIRANISelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [BENEFICIRANI] WITH (NOLOCK) ", false);
            this.BENEFICIRANISelect1 = this.cmBENEFICIRANISelect1.FetchData();
            if (this.BENEFICIRANISelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.BENEFICIRANISelect1.GetInt32(0);
            }
            this.BENEFICIRANISelect1.Close();
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
            this.RcdFound3 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVBENEFICIRANIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__BROJPRIZNATIHMJESECIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.BENEFICIRANISet = new BENEFICIRANIDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertBeneficirani()
        {
            this.CheckOptimisticConcurrencyBeneficirani();
            this.AfterConfirmBeneficirani();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [BENEFICIRANI] ([IDBENEFICIRANI], [NAZIVBENEFICIRANI], [BROJPRIZNATIHMJESECI]) VALUES (@IDBENEFICIRANI, @NAZIVBENEFICIRANI, @BROJPRIZNATIHMJESECI)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVBENEFICIRANI", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJPRIZNATIHMJESECI", DbType.Int16));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBENEFICIRANI["IDBENEFICIRANI"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBENEFICIRANI["NAZIVBENEFICIRANI"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowBENEFICIRANI["BROJPRIZNATIHMJESECI"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new BENEFICIRANIDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnBENEFICIRANIUpdated(new BENEFICIRANIEventArgs(this.rowBENEFICIRANI, StatementType.Insert));
        }

        private void LoadByIDBENEFICIRANI(int startRow, int maxRows)
        {
            bool enforceConstraints = this.BENEFICIRANISet.EnforceConstraints;
            this.BENEFICIRANISet.BENEFICIRANI.BeginLoadData();
            this.ScanByIDBENEFICIRANI(startRow, maxRows);
            this.BENEFICIRANISet.BENEFICIRANI.EndLoadData();
            this.BENEFICIRANISet.EnforceConstraints = enforceConstraints;
            if (this.BENEFICIRANISet.BENEFICIRANI.Count > 0)
            {
                this.rowBENEFICIRANI = this.BENEFICIRANISet.BENEFICIRANI[this.BENEFICIRANISet.BENEFICIRANI.Count - 1];
            }
        }

        private void LoadChildBeneficirani(int startRow, int maxRows)
        {
            this.CreateNewRowBeneficirani();
            bool enforceConstraints = this.BENEFICIRANISet.EnforceConstraints;
            this.BENEFICIRANISet.BENEFICIRANI.BeginLoadData();
            this.ScanStartBeneficirani(startRow, maxRows);
            this.BENEFICIRANISet.BENEFICIRANI.EndLoadData();
            this.BENEFICIRANISet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataBeneficirani(int maxRows)
        {
            int num = 0;
            if (this.RcdFound3 != 0)
            {
                this.ScanLoadBeneficirani();
                while ((this.RcdFound3 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowBeneficirani();
                    this.CreateNewRowBeneficirani();
                    this.ScanNextBeneficirani();
                }
            }
            if (num > 0)
            {
                this.RcdFound3 = 1;
            }
            this.ScanEndBeneficirani();
            if (this.BENEFICIRANISet.BENEFICIRANI.Count > 0)
            {
                this.rowBENEFICIRANI = this.BENEFICIRANISet.BENEFICIRANI[this.BENEFICIRANISet.BENEFICIRANI.Count - 1];
            }
        }

        private void LoadRowBeneficirani()
        {
            this.AddRowBeneficirani();
        }

        private void OnBENEFICIRANIUpdated(BENEFICIRANIEventArgs e)
        {
            if (this.BENEFICIRANIUpdated != null)
            {
                BENEFICIRANIUpdateEventHandler bENEFICIRANIUpdatedEvent = this.BENEFICIRANIUpdated;
                if (bENEFICIRANIUpdatedEvent != null)
                {
                    bENEFICIRANIUpdatedEvent(this, e);
                }
            }
        }

        private void OnBENEFICIRANIUpdating(BENEFICIRANIEventArgs e)
        {
            if (this.BENEFICIRANIUpdating != null)
            {
                BENEFICIRANIUpdateEventHandler bENEFICIRANIUpdatingEvent = this.BENEFICIRANIUpdating;
                if (bENEFICIRANIUpdatingEvent != null)
                {
                    bENEFICIRANIUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowBeneficirani()
        {
            this.Gx_mode = Mode.FromRowState(this.rowBENEFICIRANI.RowState);
            if (this.rowBENEFICIRANI.RowState != DataRowState.Added)
            {
                this.m__NAZIVBENEFICIRANIOriginal = RuntimeHelpers.GetObjectValue(this.rowBENEFICIRANI["NAZIVBENEFICIRANI", DataRowVersion.Original]);
                this.m__BROJPRIZNATIHMJESECIOriginal = RuntimeHelpers.GetObjectValue(this.rowBENEFICIRANI["BROJPRIZNATIHMJESECI", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVBENEFICIRANIOriginal = RuntimeHelpers.GetObjectValue(this.rowBENEFICIRANI["NAZIVBENEFICIRANI"]);
                this.m__BROJPRIZNATIHMJESECIOriginal = RuntimeHelpers.GetObjectValue(this.rowBENEFICIRANI["BROJPRIZNATIHMJESECI"]);
            }
            this._Gxremove = this.rowBENEFICIRANI.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowBENEFICIRANI = (BENEFICIRANIDataSet.BENEFICIRANIRow) DataSetUtil.CloneOriginalDataRow(this.rowBENEFICIRANI);
            }
        }

        private void ScanByIDBENEFICIRANI(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDBENEFICIRANI] = @IDBENEFICIRANI";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString3 + "  FROM [BENEFICIRANI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDBENEFICIRANI]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString3, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDBENEFICIRANI] ) AS DK_PAGENUM   FROM [BENEFICIRANI] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString3 + " FROM [BENEFICIRANI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDBENEFICIRANI] ";
            }
            this.cmBENEFICIRANISelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmBENEFICIRANISelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmBENEFICIRANISelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
            }
            this.cmBENEFICIRANISelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBENEFICIRANI["IDBENEFICIRANI"]));
            this.BENEFICIRANISelect4 = this.cmBENEFICIRANISelect4.FetchData();
            this.RcdFound3 = 0;
            this.ScanLoadBeneficirani();
            this.LoadDataBeneficirani(maxRows);
        }

        private void ScanEndBeneficirani()
        {
            this.BENEFICIRANISelect4.Close();
        }

        private void ScanLoadBeneficirani()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmBENEFICIRANISelect4.HasMoreRows)
            {
                this.RcdFound3 = 1;
                this.rowBENEFICIRANI["IDBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BENEFICIRANISelect4, 0));
                this.rowBENEFICIRANI["NAZIVBENEFICIRANI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BENEFICIRANISelect4, 1));
                this.rowBENEFICIRANI["BROJPRIZNATIHMJESECI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.BENEFICIRANISelect4, 2));
            }
        }

        private void ScanNextBeneficirani()
        {
            this.cmBENEFICIRANISelect4.HasMoreRows = this.BENEFICIRANISelect4.Read();
            this.RcdFound3 = 0;
            this.ScanLoadBeneficirani();
        }

        private void ScanStartBeneficirani(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString3 + "  FROM [BENEFICIRANI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDBENEFICIRANI]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString3, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDBENEFICIRANI] ) AS DK_PAGENUM   FROM [BENEFICIRANI] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString3 + " FROM [BENEFICIRANI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDBENEFICIRANI] ";
            }
            this.cmBENEFICIRANISelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.BENEFICIRANISelect4 = this.cmBENEFICIRANISelect4.FetchData();
            this.RcdFound3 = 0;
            this.ScanLoadBeneficirani();
            this.LoadDataBeneficirani(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.BENEFICIRANISet = (BENEFICIRANIDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.BENEFICIRANISet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.BENEFICIRANISet.BENEFICIRANI.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        BENEFICIRANIDataSet.BENEFICIRANIRow current = (BENEFICIRANIDataSet.BENEFICIRANIRow) enumerator.Current;
                        this.rowBENEFICIRANI = current;
                        if (Helpers.IsRowChanged(this.rowBENEFICIRANI))
                        {
                            this.ReadRowBeneficirani();
                            if (this.rowBENEFICIRANI.RowState == DataRowState.Added)
                            {
                                this.InsertBeneficirani();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateBeneficirani();
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

        private void UpdateBeneficirani()
        {
            this.CheckOptimisticConcurrencyBeneficirani();
            this.AfterConfirmBeneficirani();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [BENEFICIRANI] SET [NAZIVBENEFICIRANI]=@NAZIVBENEFICIRANI, [BROJPRIZNATIHMJESECI]=@BROJPRIZNATIHMJESECI  WHERE [IDBENEFICIRANI] = @IDBENEFICIRANI", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVBENEFICIRANI", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJPRIZNATIHMJESECI", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBENEFICIRANI["NAZIVBENEFICIRANI"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBENEFICIRANI["BROJPRIZNATIHMJESECI"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowBENEFICIRANI["IDBENEFICIRANI"]));
            command.ExecuteStmt();
            this.OnBENEFICIRANIUpdated(new BENEFICIRANIEventArgs(this.rowBENEFICIRANI, StatementType.Update));
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
        public class BENEFICIRANIDataChangedException : DataChangedException
        {
            public BENEFICIRANIDataChangedException()
            {
            }

            public BENEFICIRANIDataChangedException(string message) : base(message)
            {
            }

            protected BENEFICIRANIDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BENEFICIRANIDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BENEFICIRANIDataLockedException : DataLockedException
        {
            public BENEFICIRANIDataLockedException()
            {
            }

            public BENEFICIRANIDataLockedException(string message) : base(message)
            {
            }

            protected BENEFICIRANIDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BENEFICIRANIDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BENEFICIRANIDuplicateKeyException : DuplicateKeyException
        {
            public BENEFICIRANIDuplicateKeyException()
            {
            }

            public BENEFICIRANIDuplicateKeyException(string message) : base(message)
            {
            }

            protected BENEFICIRANIDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BENEFICIRANIDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class BENEFICIRANIEventArgs : EventArgs
        {
            private BENEFICIRANIDataSet.BENEFICIRANIRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public BENEFICIRANIEventArgs(BENEFICIRANIDataSet.BENEFICIRANIRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public BENEFICIRANIDataSet.BENEFICIRANIRow Row
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
        public class BENEFICIRANINotFoundException : DataNotFoundException
        {
            public BENEFICIRANINotFoundException()
            {
            }

            public BENEFICIRANINotFoundException(string message) : base(message)
            {
            }

            protected BENEFICIRANINotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BENEFICIRANINotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void BENEFICIRANIUpdateEventHandler(object sender, BENEFICIRANIDataAdapter.BENEFICIRANIEventArgs e);

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

