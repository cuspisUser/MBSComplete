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

    public class DDKOLONAIDDDataAdapter : IDataAdapter, IDDKOLONAIDDDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmDDKOLONAIDDSelect1;
        private ReadWriteCommand cmDDKOLONAIDDSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DDKOLONAIDDSelect1;
        private IDataReader DDKOLONAIDDSelect4;
        private DDKOLONAIDDDataSet DDKOLONAIDDSet;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVKOLONAIDDOriginal;
        private readonly string m_SelectString164 = "TM1.[IDKOLONAIDD], TM1.[NAZIVKOLONAIDD]";
        private string m_WhereString;
        private short RcdFound164;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private DDKOLONAIDDDataSet.DDKOLONAIDDRow rowDDKOLONAIDD;
        private string scmdbuf;
        private StatementType sMode164;

        public event DDKOLONAIDDUpdateEventHandler DDKOLONAIDDUpdated;

        public event DDKOLONAIDDUpdateEventHandler DDKOLONAIDDUpdating;

        private void AddRowDdkolonaidd()
        {
            this.DDKOLONAIDDSet.DDKOLONAIDD.AddDDKOLONAIDDRow(this.rowDDKOLONAIDD);
        }

        private void AfterConfirmDdkolonaidd()
        {
            this.OnDDKOLONAIDDUpdating(new DDKOLONAIDDEventArgs(this.rowDDKOLONAIDD, this.Gx_mode));
        }

        private void CheckDeleteErrorsDdkolonaidd()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDKATEGORIJA] FROM [DDKATEGORIJA] WITH (NOLOCK) WHERE [IDKOLONAIDD] = @IDKOLONAIDD ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKOLONAIDD["IDKOLONAIDD"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new DDKATEGORIJAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "DDKATEGORIJA" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyDdkolonaidd()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKOLONAIDD], [NAZIVKOLONAIDD] FROM [DDKOLONAIDD] WITH (UPDLOCK) WHERE [IDKOLONAIDD] = @IDKOLONAIDD ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKOLONAIDD["IDKOLONAIDD"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DDKOLONAIDDDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DDKOLONAIDD") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVKOLONAIDDOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new DDKOLONAIDDDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DDKOLONAIDD") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowDdkolonaidd()
        {
            this.rowDDKOLONAIDD = this.DDKOLONAIDDSet.DDKOLONAIDD.NewDDKOLONAIDDRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDdkolonaidd();
            this.AfterConfirmDdkolonaidd();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DDKOLONAIDD]  WHERE [IDKOLONAIDD] = @IDKOLONAIDD", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKOLONAIDD["IDKOLONAIDD"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsDdkolonaidd();
            }
            this.OnDDKOLONAIDDUpdated(new DDKOLONAIDDEventArgs(this.rowDDKOLONAIDD, StatementType.Delete));
            this.rowDDKOLONAIDD.Delete();
            this.sMode164 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode164;
        }

        public virtual int Fill(DDKOLONAIDDDataSet dataSet)
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
                    this.DDKOLONAIDDSet = dataSet;
                    this.LoadChildDdkolonaidd(0, -1);
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
            this.DDKOLONAIDDSet = (DDKOLONAIDDDataSet) dataSet;
            if (this.DDKOLONAIDDSet != null)
            {
                return this.Fill(this.DDKOLONAIDDSet);
            }
            this.DDKOLONAIDDSet = new DDKOLONAIDDDataSet();
            this.Fill(this.DDKOLONAIDDSet);
            dataSet.Merge(this.DDKOLONAIDDSet);
            return 0;
        }

        public virtual int Fill(DDKOLONAIDDDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDKOLONAIDD"]));
        }

        public virtual int Fill(DDKOLONAIDDDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDKOLONAIDD"]));
        }

        public virtual int Fill(DDKOLONAIDDDataSet dataSet, int iDKOLONAIDD)
        {
            if (!this.FillByIDKOLONAIDD(dataSet, iDKOLONAIDD))
            {
                throw new DDKOLONAIDDNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DDKOLONAIDD") }));
            }
            return 0;
        }

        public virtual bool FillByIDKOLONAIDD(DDKOLONAIDDDataSet dataSet, int iDKOLONAIDD)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDKOLONAIDDSet = dataSet;
            this.rowDDKOLONAIDD = this.DDKOLONAIDDSet.DDKOLONAIDD.NewDDKOLONAIDDRow();
            this.rowDDKOLONAIDD.IDKOLONAIDD = iDKOLONAIDD;
            try
            {
                this.LoadByIDKOLONAIDD(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound164 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(DDKOLONAIDDDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDKOLONAIDDSet = dataSet;
            try
            {
                this.LoadChildDdkolonaidd(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKOLONAIDD], [NAZIVKOLONAIDD] FROM [DDKOLONAIDD] WITH (NOLOCK) WHERE [IDKOLONAIDD] = @IDKOLONAIDD ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKOLONAIDD["IDKOLONAIDD"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound164 = 1;
                this.rowDDKOLONAIDD["IDKOLONAIDD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowDDKOLONAIDD["NAZIVKOLONAIDD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode164 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode164;
            }
            else
            {
                this.RcdFound164 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDKOLONAIDD";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDKOLONAIDDSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [DDKOLONAIDD] WITH (NOLOCK) ", false);
            this.DDKOLONAIDDSelect1 = this.cmDDKOLONAIDDSelect1.FetchData();
            if (this.DDKOLONAIDDSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.DDKOLONAIDDSelect1.GetInt32(0);
            }
            this.DDKOLONAIDDSelect1.Close();
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
            this.RcdFound164 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVKOLONAIDDOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.DDKOLONAIDDSet = new DDKOLONAIDDDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertDdkolonaidd()
        {
            this.CheckOptimisticConcurrencyDdkolonaidd();
            this.AfterConfirmDdkolonaidd();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DDKOLONAIDD] ([IDKOLONAIDD], [NAZIVKOLONAIDD]) VALUES (@IDKOLONAIDD, @NAZIVKOLONAIDD)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVKOLONAIDD", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKOLONAIDD["IDKOLONAIDD"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDKOLONAIDD["NAZIVKOLONAIDD"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DDKOLONAIDDDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDDKOLONAIDDUpdated(new DDKOLONAIDDEventArgs(this.rowDDKOLONAIDD, StatementType.Insert));
        }

        private void LoadByIDKOLONAIDD(int startRow, int maxRows)
        {
            bool enforceConstraints = this.DDKOLONAIDDSet.EnforceConstraints;
            this.DDKOLONAIDDSet.DDKOLONAIDD.BeginLoadData();
            this.ScanByIDKOLONAIDD(startRow, maxRows);
            this.DDKOLONAIDDSet.DDKOLONAIDD.EndLoadData();
            this.DDKOLONAIDDSet.EnforceConstraints = enforceConstraints;
            if (this.DDKOLONAIDDSet.DDKOLONAIDD.Count > 0)
            {
                this.rowDDKOLONAIDD = this.DDKOLONAIDDSet.DDKOLONAIDD[this.DDKOLONAIDDSet.DDKOLONAIDD.Count - 1];
            }
        }

        private void LoadChildDdkolonaidd(int startRow, int maxRows)
        {
            this.CreateNewRowDdkolonaidd();
            bool enforceConstraints = this.DDKOLONAIDDSet.EnforceConstraints;
            this.DDKOLONAIDDSet.DDKOLONAIDD.BeginLoadData();
            this.ScanStartDdkolonaidd(startRow, maxRows);
            this.DDKOLONAIDDSet.DDKOLONAIDD.EndLoadData();
            this.DDKOLONAIDDSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataDdkolonaidd(int maxRows)
        {
            int num = 0;
            if (this.RcdFound164 != 0)
            {
                this.ScanLoadDdkolonaidd();
                while ((this.RcdFound164 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowDdkolonaidd();
                    this.CreateNewRowDdkolonaidd();
                    this.ScanNextDdkolonaidd();
                }
            }
            if (num > 0)
            {
                this.RcdFound164 = 1;
            }
            this.ScanEndDdkolonaidd();
            if (this.DDKOLONAIDDSet.DDKOLONAIDD.Count > 0)
            {
                this.rowDDKOLONAIDD = this.DDKOLONAIDDSet.DDKOLONAIDD[this.DDKOLONAIDDSet.DDKOLONAIDD.Count - 1];
            }
        }

        private void LoadRowDdkolonaidd()
        {
            this.AddRowDdkolonaidd();
        }

        private void OnDDKOLONAIDDUpdated(DDKOLONAIDDEventArgs e)
        {
            if (this.DDKOLONAIDDUpdated != null)
            {
                DDKOLONAIDDUpdateEventHandler dDKOLONAIDDUpdatedEvent = this.DDKOLONAIDDUpdated;
                if (dDKOLONAIDDUpdatedEvent != null)
                {
                    dDKOLONAIDDUpdatedEvent(this, e);
                }
            }
        }

        private void OnDDKOLONAIDDUpdating(DDKOLONAIDDEventArgs e)
        {
            if (this.DDKOLONAIDDUpdating != null)
            {
                DDKOLONAIDDUpdateEventHandler dDKOLONAIDDUpdatingEvent = this.DDKOLONAIDDUpdating;
                if (dDKOLONAIDDUpdatingEvent != null)
                {
                    dDKOLONAIDDUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowDdkolonaidd()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDDKOLONAIDD.RowState);
            if (this.rowDDKOLONAIDD.RowState != DataRowState.Added)
            {
                this.m__NAZIVKOLONAIDDOriginal = RuntimeHelpers.GetObjectValue(this.rowDDKOLONAIDD["NAZIVKOLONAIDD", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVKOLONAIDDOriginal = RuntimeHelpers.GetObjectValue(this.rowDDKOLONAIDD["NAZIVKOLONAIDD"]);
            }
            this._Gxremove = this.rowDDKOLONAIDD.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowDDKOLONAIDD = (DDKOLONAIDDDataSet.DDKOLONAIDDRow) DataSetUtil.CloneOriginalDataRow(this.rowDDKOLONAIDD);
            }
        }

        private void ScanByIDKOLONAIDD(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDKOLONAIDD] = @IDKOLONAIDD";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString164 + "  FROM [DDKOLONAIDD] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDKOLONAIDD]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString164, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDKOLONAIDD] ) AS DK_PAGENUM   FROM [DDKOLONAIDD] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString164 + " FROM [DDKOLONAIDD] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDKOLONAIDD] ";
            }
            this.cmDDKOLONAIDDSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmDDKOLONAIDDSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDKOLONAIDDSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
            }
            this.cmDDKOLONAIDDSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKOLONAIDD["IDKOLONAIDD"]));
            this.DDKOLONAIDDSelect4 = this.cmDDKOLONAIDDSelect4.FetchData();
            this.RcdFound164 = 0;
            this.ScanLoadDdkolonaidd();
            this.LoadDataDdkolonaidd(maxRows);
        }

        private void ScanEndDdkolonaidd()
        {
            this.DDKOLONAIDDSelect4.Close();
        }

        private void ScanLoadDdkolonaidd()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDDKOLONAIDDSelect4.HasMoreRows)
            {
                this.RcdFound164 = 1;
                this.rowDDKOLONAIDD["IDKOLONAIDD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDKOLONAIDDSelect4, 0));
                this.rowDDKOLONAIDD["NAZIVKOLONAIDD"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDKOLONAIDDSelect4, 1));
            }
        }

        private void ScanNextDdkolonaidd()
        {
            this.cmDDKOLONAIDDSelect4.HasMoreRows = this.DDKOLONAIDDSelect4.Read();
            this.RcdFound164 = 0;
            this.ScanLoadDdkolonaidd();
        }

        private void ScanStartDdkolonaidd(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString164 + "  FROM [DDKOLONAIDD] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDKOLONAIDD]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString164, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDKOLONAIDD] ) AS DK_PAGENUM   FROM [DDKOLONAIDD] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString164 + " FROM [DDKOLONAIDD] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDKOLONAIDD] ";
            }
            this.cmDDKOLONAIDDSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.DDKOLONAIDDSelect4 = this.cmDDKOLONAIDDSelect4.FetchData();
            this.RcdFound164 = 0;
            this.ScanLoadDdkolonaidd();
            this.LoadDataDdkolonaidd(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.DDKOLONAIDDSet = (DDKOLONAIDDDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.DDKOLONAIDDSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.DDKOLONAIDDSet.DDKOLONAIDD.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DDKOLONAIDDDataSet.DDKOLONAIDDRow current = (DDKOLONAIDDDataSet.DDKOLONAIDDRow) enumerator.Current;
                        this.rowDDKOLONAIDD = current;
                        if (Helpers.IsRowChanged(this.rowDDKOLONAIDD))
                        {
                            this.ReadRowDdkolonaidd();
                            if (this.rowDDKOLONAIDD.RowState == DataRowState.Added)
                            {
                                this.InsertDdkolonaidd();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateDdkolonaidd();
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

        private void UpdateDdkolonaidd()
        {
            this.CheckOptimisticConcurrencyDdkolonaidd();
            this.AfterConfirmDdkolonaidd();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DDKOLONAIDD] SET [NAZIVKOLONAIDD]=@NAZIVKOLONAIDD  WHERE [IDKOLONAIDD] = @IDKOLONAIDD", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVKOLONAIDD", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDKOLONAIDD["NAZIVKOLONAIDD"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDKOLONAIDD["IDKOLONAIDD"]));
            command.ExecuteStmt();
            this.OnDDKOLONAIDDUpdated(new DDKOLONAIDDEventArgs(this.rowDDKOLONAIDD, StatementType.Update));
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
        public class DDKATEGORIJAInvalidDeleteException : InvalidDeleteException
        {
            public DDKATEGORIJAInvalidDeleteException()
            {
            }

            public DDKATEGORIJAInvalidDeleteException(string message) : base(message)
            {
            }

            protected DDKATEGORIJAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKATEGORIJAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDKOLONAIDDDataChangedException : DataChangedException
        {
            public DDKOLONAIDDDataChangedException()
            {
            }

            public DDKOLONAIDDDataChangedException(string message) : base(message)
            {
            }

            protected DDKOLONAIDDDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKOLONAIDDDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDKOLONAIDDDataLockedException : DataLockedException
        {
            public DDKOLONAIDDDataLockedException()
            {
            }

            public DDKOLONAIDDDataLockedException(string message) : base(message)
            {
            }

            protected DDKOLONAIDDDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKOLONAIDDDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDKOLONAIDDDuplicateKeyException : DuplicateKeyException
        {
            public DDKOLONAIDDDuplicateKeyException()
            {
            }

            public DDKOLONAIDDDuplicateKeyException(string message) : base(message)
            {
            }

            protected DDKOLONAIDDDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKOLONAIDDDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DDKOLONAIDDEventArgs : EventArgs
        {
            private DDKOLONAIDDDataSet.DDKOLONAIDDRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public DDKOLONAIDDEventArgs(DDKOLONAIDDDataSet.DDKOLONAIDDRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DDKOLONAIDDDataSet.DDKOLONAIDDRow Row
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
        public class DDKOLONAIDDNotFoundException : DataNotFoundException
        {
            public DDKOLONAIDDNotFoundException()
            {
            }

            public DDKOLONAIDDNotFoundException(string message) : base(message)
            {
            }

            protected DDKOLONAIDDNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDKOLONAIDDNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void DDKOLONAIDDUpdateEventHandler(object sender, DDKOLONAIDDDataAdapter.DDKOLONAIDDEventArgs e);
    }
}

