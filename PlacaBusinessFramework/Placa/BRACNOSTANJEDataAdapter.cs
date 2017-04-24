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

    public class BRACNOSTANJEDataAdapter : IDataAdapter, IBRACNOSTANJEDataAdapter
    {
        private bool _Gxremove;
        private IDataReader BRACNOSTANJESelect1;
        private IDataReader BRACNOSTANJESelect4;
        private BRACNOSTANJEDataSet BRACNOSTANJESet;
        private ReadWriteCommand cmBRACNOSTANJESelect1;
        private ReadWriteCommand cmBRACNOSTANJESelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVBRACNOSTANJEOriginal;
        private readonly string m_SelectString4 = "TM1.[IDBRACNOSTANJE], TM1.[NAZIVBRACNOSTANJE]";
        private string m_WhereString;
        private short RcdFound4;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private BRACNOSTANJEDataSet.BRACNOSTANJERow rowBRACNOSTANJE;
        private string scmdbuf;
        private StatementType sMode4;

        public event BRACNOSTANJEUpdateEventHandler BRACNOSTANJEUpdated;

        public event BRACNOSTANJEUpdateEventHandler BRACNOSTANJEUpdating;

        private void AddRowBracnostanje()
        {
            this.BRACNOSTANJESet.BRACNOSTANJE.AddBRACNOSTANJERow(this.rowBRACNOSTANJE);
        }

        private void AfterConfirmBracnostanje()
        {
            this.OnBRACNOSTANJEUpdating(new BRACNOSTANJEEventArgs(this.rowBRACNOSTANJE, this.Gx_mode));
        }

        private void CheckDeleteErrorsBracnostanje()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK] FROM [RADNIK] WITH (NOLOCK) WHERE [IDBRACNOSTANJE] = @IDBRACNOSTANJE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBRACNOSTANJE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBRACNOSTANJE["IDBRACNOSTANJE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIK" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyBracnostanje()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDBRACNOSTANJE], [NAZIVBRACNOSTANJE] FROM [BRACNOSTANJE] WITH (UPDLOCK) WHERE [IDBRACNOSTANJE] = @IDBRACNOSTANJE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBRACNOSTANJE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBRACNOSTANJE["IDBRACNOSTANJE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new BRACNOSTANJEDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("BRACNOSTANJE") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVBRACNOSTANJEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new BRACNOSTANJEDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("BRACNOSTANJE") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowBracnostanje()
        {
            this.rowBRACNOSTANJE = this.BRACNOSTANJESet.BRACNOSTANJE.NewBRACNOSTANJERow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyBracnostanje();
            this.AfterConfirmBracnostanje();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [BRACNOSTANJE]  WHERE [IDBRACNOSTANJE] = @IDBRACNOSTANJE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBRACNOSTANJE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBRACNOSTANJE["IDBRACNOSTANJE"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsBracnostanje();
            }
            this.OnBRACNOSTANJEUpdated(new BRACNOSTANJEEventArgs(this.rowBRACNOSTANJE, StatementType.Delete));
            this.rowBRACNOSTANJE.Delete();
            this.sMode4 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode4;
        }


        public virtual int Fill(BRACNOSTANJEDataSet dataSet)
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
                    this.BRACNOSTANJESet = dataSet;
                    this.LoadChildBracnostanje(0, -1);
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
            this.BRACNOSTANJESet = (BRACNOSTANJEDataSet) dataSet;
            if (this.BRACNOSTANJESet != null)
            {
                return this.Fill(this.BRACNOSTANJESet);
            }
            this.BRACNOSTANJESet = new BRACNOSTANJEDataSet();
            this.Fill(this.BRACNOSTANJESet);
            dataSet.Merge(this.BRACNOSTANJESet);
            return 0;
        }

        public virtual int Fill(BRACNOSTANJEDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDBRACNOSTANJE"]));
        }

        public virtual int Fill(BRACNOSTANJEDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDBRACNOSTANJE"]));
        }

        public virtual int Fill(BRACNOSTANJEDataSet dataSet, int iDBRACNOSTANJE)
        {
            if (!this.FillByIDBRACNOSTANJE(dataSet, iDBRACNOSTANJE))
            {
                throw new BRACNOSTANJENotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("BRACNOSTANJE") }));
            }
            return 0;
        }

        public virtual bool FillByIDBRACNOSTANJE(BRACNOSTANJEDataSet dataSet, int iDBRACNOSTANJE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.BRACNOSTANJESet = dataSet;
            this.rowBRACNOSTANJE = this.BRACNOSTANJESet.BRACNOSTANJE.NewBRACNOSTANJERow();
            this.rowBRACNOSTANJE.IDBRACNOSTANJE = iDBRACNOSTANJE;
            try
            {
                this.LoadByIDBRACNOSTANJE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound4 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(BRACNOSTANJEDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.BRACNOSTANJESet = dataSet;
            try
            {
                this.LoadChildBracnostanje(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDBRACNOSTANJE], [NAZIVBRACNOSTANJE] FROM [BRACNOSTANJE] WITH (NOLOCK) WHERE [IDBRACNOSTANJE] = @IDBRACNOSTANJE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBRACNOSTANJE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBRACNOSTANJE["IDBRACNOSTANJE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound4 = 1;
                this.rowBRACNOSTANJE["IDBRACNOSTANJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowBRACNOSTANJE["NAZIVBRACNOSTANJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode4 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode4;
            }
            else
            {
                this.RcdFound4 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDBRACNOSTANJE";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmBRACNOSTANJESelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [BRACNOSTANJE] WITH (NOLOCK) ", false);
            this.BRACNOSTANJESelect1 = this.cmBRACNOSTANJESelect1.FetchData();
            if (this.BRACNOSTANJESelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.BRACNOSTANJESelect1.GetInt32(0);
            }
            this.BRACNOSTANJESelect1.Close();
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
            this.RcdFound4 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVBRACNOSTANJEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.BRACNOSTANJESet = new BRACNOSTANJEDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertBracnostanje()
        {
            this.CheckOptimisticConcurrencyBracnostanje();
            this.AfterConfirmBracnostanje();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [BRACNOSTANJE] ([IDBRACNOSTANJE], [NAZIVBRACNOSTANJE]) VALUES (@IDBRACNOSTANJE, @NAZIVBRACNOSTANJE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBRACNOSTANJE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVBRACNOSTANJE", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBRACNOSTANJE["IDBRACNOSTANJE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBRACNOSTANJE["NAZIVBRACNOSTANJE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new BRACNOSTANJEDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnBRACNOSTANJEUpdated(new BRACNOSTANJEEventArgs(this.rowBRACNOSTANJE, StatementType.Insert));
        }

        private void LoadByIDBRACNOSTANJE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.BRACNOSTANJESet.EnforceConstraints;
            this.BRACNOSTANJESet.BRACNOSTANJE.BeginLoadData();
            this.ScanByIDBRACNOSTANJE(startRow, maxRows);
            this.BRACNOSTANJESet.BRACNOSTANJE.EndLoadData();
            this.BRACNOSTANJESet.EnforceConstraints = enforceConstraints;
            if (this.BRACNOSTANJESet.BRACNOSTANJE.Count > 0)
            {
                this.rowBRACNOSTANJE = this.BRACNOSTANJESet.BRACNOSTANJE[this.BRACNOSTANJESet.BRACNOSTANJE.Count - 1];
            }
        }

        private void LoadChildBracnostanje(int startRow, int maxRows)
        {
            this.CreateNewRowBracnostanje();
            bool enforceConstraints = this.BRACNOSTANJESet.EnforceConstraints;
            this.BRACNOSTANJESet.BRACNOSTANJE.BeginLoadData();
            this.ScanStartBracnostanje(startRow, maxRows);
            this.BRACNOSTANJESet.BRACNOSTANJE.EndLoadData();
            this.BRACNOSTANJESet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataBracnostanje(int maxRows)
        {
            int num = 0;
            if (this.RcdFound4 != 0)
            {
                this.ScanLoadBracnostanje();
                while ((this.RcdFound4 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowBracnostanje();
                    this.CreateNewRowBracnostanje();
                    this.ScanNextBracnostanje();
                }
            }
            if (num > 0)
            {
                this.RcdFound4 = 1;
            }
            this.ScanEndBracnostanje();
            if (this.BRACNOSTANJESet.BRACNOSTANJE.Count > 0)
            {
                this.rowBRACNOSTANJE = this.BRACNOSTANJESet.BRACNOSTANJE[this.BRACNOSTANJESet.BRACNOSTANJE.Count - 1];
            }
        }

        private void LoadRowBracnostanje()
        {
            this.AddRowBracnostanje();
        }

        private void OnBRACNOSTANJEUpdated(BRACNOSTANJEEventArgs e)
        {
            if (this.BRACNOSTANJEUpdated != null)
            {
                BRACNOSTANJEUpdateEventHandler bRACNOSTANJEUpdatedEvent = this.BRACNOSTANJEUpdated;
                if (bRACNOSTANJEUpdatedEvent != null)
                {
                    bRACNOSTANJEUpdatedEvent(this, e);
                }
            }
        }

        private void OnBRACNOSTANJEUpdating(BRACNOSTANJEEventArgs e)
        {
            if (this.BRACNOSTANJEUpdating != null)
            {
                BRACNOSTANJEUpdateEventHandler bRACNOSTANJEUpdatingEvent = this.BRACNOSTANJEUpdating;
                if (bRACNOSTANJEUpdatingEvent != null)
                {
                    bRACNOSTANJEUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowBracnostanje()
        {
            this.Gx_mode = Mode.FromRowState(this.rowBRACNOSTANJE.RowState);
            if (this.rowBRACNOSTANJE.RowState != DataRowState.Added)
            {
                this.m__NAZIVBRACNOSTANJEOriginal = RuntimeHelpers.GetObjectValue(this.rowBRACNOSTANJE["NAZIVBRACNOSTANJE", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVBRACNOSTANJEOriginal = RuntimeHelpers.GetObjectValue(this.rowBRACNOSTANJE["NAZIVBRACNOSTANJE"]);
            }
            this._Gxremove = this.rowBRACNOSTANJE.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowBRACNOSTANJE = (BRACNOSTANJEDataSet.BRACNOSTANJERow) DataSetUtil.CloneOriginalDataRow(this.rowBRACNOSTANJE);
            }
        }

        private void ScanByIDBRACNOSTANJE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDBRACNOSTANJE] = @IDBRACNOSTANJE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString4 + "  FROM [BRACNOSTANJE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDBRACNOSTANJE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString4, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDBRACNOSTANJE] ) AS DK_PAGENUM   FROM [BRACNOSTANJE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString4 + " FROM [BRACNOSTANJE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDBRACNOSTANJE] ";
            }
            this.cmBRACNOSTANJESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmBRACNOSTANJESelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmBRACNOSTANJESelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBRACNOSTANJE", DbType.Int32));
            }
            this.cmBRACNOSTANJESelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBRACNOSTANJE["IDBRACNOSTANJE"]));
            this.BRACNOSTANJESelect4 = this.cmBRACNOSTANJESelect4.FetchData();
            this.RcdFound4 = 0;
            this.ScanLoadBracnostanje();
            this.LoadDataBracnostanje(maxRows);
        }

        private void ScanEndBracnostanje()
        {
            this.BRACNOSTANJESelect4.Close();
        }

        private void ScanLoadBracnostanje()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmBRACNOSTANJESelect4.HasMoreRows)
            {
                this.RcdFound4 = 1;
                this.rowBRACNOSTANJE["IDBRACNOSTANJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.BRACNOSTANJESelect4, 0));
                this.rowBRACNOSTANJE["NAZIVBRACNOSTANJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BRACNOSTANJESelect4, 1));
            }
        }

        private void ScanNextBracnostanje()
        {
            this.cmBRACNOSTANJESelect4.HasMoreRows = this.BRACNOSTANJESelect4.Read();
            this.RcdFound4 = 0;
            this.ScanLoadBracnostanje();
        }

        private void ScanStartBracnostanje(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString4 + "  FROM [BRACNOSTANJE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDBRACNOSTANJE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString4, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDBRACNOSTANJE] ) AS DK_PAGENUM   FROM [BRACNOSTANJE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString4 + " FROM [BRACNOSTANJE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDBRACNOSTANJE] ";
            }
            this.cmBRACNOSTANJESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.BRACNOSTANJESelect4 = this.cmBRACNOSTANJESelect4.FetchData();
            this.RcdFound4 = 0;
            this.ScanLoadBracnostanje();
            this.LoadDataBracnostanje(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.BRACNOSTANJESet = (BRACNOSTANJEDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.BRACNOSTANJESet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.BRACNOSTANJESet.BRACNOSTANJE.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        BRACNOSTANJEDataSet.BRACNOSTANJERow current = (BRACNOSTANJEDataSet.BRACNOSTANJERow) enumerator.Current;
                        this.rowBRACNOSTANJE = current;
                        if (Helpers.IsRowChanged(this.rowBRACNOSTANJE))
                        {
                            this.ReadRowBracnostanje();
                            if (this.rowBRACNOSTANJE.RowState == DataRowState.Added)
                            {
                                this.InsertBracnostanje();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateBracnostanje();
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

        private void UpdateBracnostanje()
        {
            this.CheckOptimisticConcurrencyBracnostanje();
            this.AfterConfirmBracnostanje();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [BRACNOSTANJE] SET [NAZIVBRACNOSTANJE]=@NAZIVBRACNOSTANJE  WHERE [IDBRACNOSTANJE] = @IDBRACNOSTANJE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVBRACNOSTANJE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBRACNOSTANJE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBRACNOSTANJE["NAZIVBRACNOSTANJE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBRACNOSTANJE["IDBRACNOSTANJE"]));
            command.ExecuteStmt();
            this.OnBRACNOSTANJEUpdated(new BRACNOSTANJEEventArgs(this.rowBRACNOSTANJE, StatementType.Update));
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
        public class BRACNOSTANJEDataChangedException : DataChangedException
        {
            public BRACNOSTANJEDataChangedException()
            {
            }

            public BRACNOSTANJEDataChangedException(string message) : base(message)
            {
            }

            protected BRACNOSTANJEDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BRACNOSTANJEDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BRACNOSTANJEDataLockedException : DataLockedException
        {
            public BRACNOSTANJEDataLockedException()
            {
            }

            public BRACNOSTANJEDataLockedException(string message) : base(message)
            {
            }

            protected BRACNOSTANJEDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BRACNOSTANJEDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BRACNOSTANJEDuplicateKeyException : DuplicateKeyException
        {
            public BRACNOSTANJEDuplicateKeyException()
            {
            }

            public BRACNOSTANJEDuplicateKeyException(string message) : base(message)
            {
            }

            protected BRACNOSTANJEDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BRACNOSTANJEDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class BRACNOSTANJEEventArgs : EventArgs
        {
            private BRACNOSTANJEDataSet.BRACNOSTANJERow m_dataRow;
            private System.Data.StatementType m_statementType;

            public BRACNOSTANJEEventArgs(BRACNOSTANJEDataSet.BRACNOSTANJERow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public BRACNOSTANJEDataSet.BRACNOSTANJERow Row
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
        public class BRACNOSTANJENotFoundException : DataNotFoundException
        {
            public BRACNOSTANJENotFoundException()
            {
            }

            public BRACNOSTANJENotFoundException(string message) : base(message)
            {
            }

            protected BRACNOSTANJENotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BRACNOSTANJENotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void BRACNOSTANJEUpdateEventHandler(object sender, BRACNOSTANJEDataAdapter.BRACNOSTANJEEventArgs e);

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

