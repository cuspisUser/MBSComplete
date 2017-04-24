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

    public class RADNOMJESTODataAdapter : IDataAdapter, IRADNOMJESTODataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmRADNOMJESTOSelect1;
        private ReadWriteCommand cmRADNOMJESTOSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVRADNOMJESTOOriginal;
        private readonly string m_SelectString26 = "TM1.[IDRADNOMJESTO], TM1.[NAZIVRADNOMJESTO]";
        private string m_WhereString;
        private IDataReader RADNOMJESTOSelect1;
        private IDataReader RADNOMJESTOSelect4;
        private RADNOMJESTODataSet RADNOMJESTOSet;
        private short RcdFound26;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private RADNOMJESTODataSet.RADNOMJESTORow rowRADNOMJESTO;
        private string scmdbuf;
        private StatementType sMode26;

        public event RADNOMJESTOUpdateEventHandler RADNOMJESTOUpdated;

        public event RADNOMJESTOUpdateEventHandler RADNOMJESTOUpdating;

        private void AddRowRadnomjesto()
        {
            this.RADNOMJESTOSet.RADNOMJESTO.AddRADNOMJESTORow(this.rowRADNOMJESTO);
        }

        private void AfterConfirmRadnomjesto()
        {
            this.OnRADNOMJESTOUpdating(new RADNOMJESTOEventArgs(this.rowRADNOMJESTO, this.Gx_mode));
        }

        private void CheckDeleteErrorsRadnomjesto()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK] FROM [RADNIK] WITH (NOLOCK) WHERE [IDRADNOMJESTO] = @IDRADNOMJESTO ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNOMJESTO["IDRADNOMJESTO"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIK" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyRadnomjesto()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRADNOMJESTO], [NAZIVRADNOMJESTO] FROM [RADNOMJESTO] WITH (UPDLOCK) WHERE [IDRADNOMJESTO] = @IDRADNOMJESTO ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNOMJESTO["IDRADNOMJESTO"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RADNOMJESTODataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RADNOMJESTO") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVRADNOMJESTOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new RADNOMJESTODataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RADNOMJESTO") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowRadnomjesto()
        {
            this.rowRADNOMJESTO = this.RADNOMJESTOSet.RADNOMJESTO.NewRADNOMJESTORow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRadnomjesto();
            this.AfterConfirmRadnomjesto();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RADNOMJESTO]  WHERE [IDRADNOMJESTO] = @IDRADNOMJESTO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNOMJESTO["IDRADNOMJESTO"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsRadnomjesto();
            }
            this.OnRADNOMJESTOUpdated(new RADNOMJESTOEventArgs(this.rowRADNOMJESTO, StatementType.Delete));
            this.rowRADNOMJESTO.Delete();
            this.sMode26 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode26;
        }

        public virtual int Fill(RADNOMJESTODataSet dataSet)
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
                    this.RADNOMJESTOSet = dataSet;
                    this.LoadChildRadnomjesto(0, -1);
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
            this.RADNOMJESTOSet = (RADNOMJESTODataSet) dataSet;
            if (this.RADNOMJESTOSet != null)
            {
                return this.Fill(this.RADNOMJESTOSet);
            }
            this.RADNOMJESTOSet = new RADNOMJESTODataSet();
            this.Fill(this.RADNOMJESTOSet);
            dataSet.Merge(this.RADNOMJESTOSet);
            return 0;
        }

        public virtual int Fill(RADNOMJESTODataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDRADNOMJESTO"]));
        }

        public virtual int Fill(RADNOMJESTODataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDRADNOMJESTO"]));
        }

        public virtual int Fill(RADNOMJESTODataSet dataSet, int iDRADNOMJESTO)
        {
            if (!this.FillByIDRADNOMJESTO(dataSet, iDRADNOMJESTO))
            {
                throw new RADNOMJESTONotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RADNOMJESTO") }));
            }
            return 0;
        }

        public virtual bool FillByIDRADNOMJESTO(RADNOMJESTODataSet dataSet, int iDRADNOMJESTO)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNOMJESTOSet = dataSet;
            this.rowRADNOMJESTO = this.RADNOMJESTOSet.RADNOMJESTO.NewRADNOMJESTORow();
            this.rowRADNOMJESTO.IDRADNOMJESTO = iDRADNOMJESTO;
            try
            {
                this.LoadByIDRADNOMJESTO(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound26 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(RADNOMJESTODataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNOMJESTOSet = dataSet;
            try
            {
                this.LoadChildRadnomjesto(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRADNOMJESTO], [NAZIVRADNOMJESTO] FROM [RADNOMJESTO] WITH (NOLOCK) WHERE [IDRADNOMJESTO] = @IDRADNOMJESTO ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNOMJESTO["IDRADNOMJESTO"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound26 = 1;
                this.rowRADNOMJESTO["IDRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowRADNOMJESTO["NAZIVRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode26 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode26;
            }
            else
            {
                this.RcdFound26 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDRADNOMJESTO";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNOMJESTOSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNOMJESTO] WITH (NOLOCK) ", false);
            this.RADNOMJESTOSelect1 = this.cmRADNOMJESTOSelect1.FetchData();
            if (this.RADNOMJESTOSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNOMJESTOSelect1.GetInt32(0);
            }
            this.RADNOMJESTOSelect1.Close();
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
            this.RcdFound26 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVRADNOMJESTOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.RADNOMJESTOSet = new RADNOMJESTODataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertRadnomjesto()
        {
            this.CheckOptimisticConcurrencyRadnomjesto();
            this.AfterConfirmRadnomjesto();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RADNOMJESTO] ([IDRADNOMJESTO], [NAZIVRADNOMJESTO]) VALUES (@IDRADNOMJESTO, @NAZIVRADNOMJESTO)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVRADNOMJESTO", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNOMJESTO["IDRADNOMJESTO"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNOMJESTO["NAZIVRADNOMJESTO"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RADNOMJESTODuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnRADNOMJESTOUpdated(new RADNOMJESTOEventArgs(this.rowRADNOMJESTO, StatementType.Insert));
        }

        private void LoadByIDRADNOMJESTO(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNOMJESTOSet.EnforceConstraints;
            this.RADNOMJESTOSet.RADNOMJESTO.BeginLoadData();
            this.ScanByIDRADNOMJESTO(startRow, maxRows);
            this.RADNOMJESTOSet.RADNOMJESTO.EndLoadData();
            this.RADNOMJESTOSet.EnforceConstraints = enforceConstraints;
            if (this.RADNOMJESTOSet.RADNOMJESTO.Count > 0)
            {
                this.rowRADNOMJESTO = this.RADNOMJESTOSet.RADNOMJESTO[this.RADNOMJESTOSet.RADNOMJESTO.Count - 1];
            }
        }

        private void LoadChildRadnomjesto(int startRow, int maxRows)
        {
            this.CreateNewRowRadnomjesto();
            bool enforceConstraints = this.RADNOMJESTOSet.EnforceConstraints;
            this.RADNOMJESTOSet.RADNOMJESTO.BeginLoadData();
            this.ScanStartRadnomjesto(startRow, maxRows);
            this.RADNOMJESTOSet.RADNOMJESTO.EndLoadData();
            this.RADNOMJESTOSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataRadnomjesto(int maxRows)
        {
            int num = 0;
            if (this.RcdFound26 != 0)
            {
                this.ScanLoadRadnomjesto();
                while ((this.RcdFound26 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowRadnomjesto();
                    this.CreateNewRowRadnomjesto();
                    this.ScanNextRadnomjesto();
                }
            }
            if (num > 0)
            {
                this.RcdFound26 = 1;
            }
            this.ScanEndRadnomjesto();
            if (this.RADNOMJESTOSet.RADNOMJESTO.Count > 0)
            {
                this.rowRADNOMJESTO = this.RADNOMJESTOSet.RADNOMJESTO[this.RADNOMJESTOSet.RADNOMJESTO.Count - 1];
            }
        }

        private void LoadRowRadnomjesto()
        {
            this.AddRowRadnomjesto();
        }

        private void OnRADNOMJESTOUpdated(RADNOMJESTOEventArgs e)
        {
            if (this.RADNOMJESTOUpdated != null)
            {
                RADNOMJESTOUpdateEventHandler rADNOMJESTOUpdatedEvent = this.RADNOMJESTOUpdated;
                if (rADNOMJESTOUpdatedEvent != null)
                {
                    rADNOMJESTOUpdatedEvent(this, e);
                }
            }
        }

        private void OnRADNOMJESTOUpdating(RADNOMJESTOEventArgs e)
        {
            if (this.RADNOMJESTOUpdating != null)
            {
                RADNOMJESTOUpdateEventHandler rADNOMJESTOUpdatingEvent = this.RADNOMJESTOUpdating;
                if (rADNOMJESTOUpdatingEvent != null)
                {
                    rADNOMJESTOUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowRadnomjesto()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRADNOMJESTO.RowState);
            if (this.rowRADNOMJESTO.RowState != DataRowState.Added)
            {
                this.m__NAZIVRADNOMJESTOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNOMJESTO["NAZIVRADNOMJESTO", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVRADNOMJESTOOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNOMJESTO["NAZIVRADNOMJESTO"]);
            }
            this._Gxremove = this.rowRADNOMJESTO.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowRADNOMJESTO = (RADNOMJESTODataSet.RADNOMJESTORow) DataSetUtil.CloneOriginalDataRow(this.rowRADNOMJESTO);
            }
        }

        private void ScanByIDRADNOMJESTO(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDRADNOMJESTO] = @IDRADNOMJESTO";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString26 + "  FROM [RADNOMJESTO] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNOMJESTO]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString26, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNOMJESTO] ) AS DK_PAGENUM   FROM [RADNOMJESTO] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString26 + " FROM [RADNOMJESTO] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNOMJESTO] ";
            }
            this.cmRADNOMJESTOSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNOMJESTOSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNOMJESTOSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
            }
            this.cmRADNOMJESTOSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNOMJESTO["IDRADNOMJESTO"]));
            this.RADNOMJESTOSelect4 = this.cmRADNOMJESTOSelect4.FetchData();
            this.RcdFound26 = 0;
            this.ScanLoadRadnomjesto();
            this.LoadDataRadnomjesto(maxRows);
        }

        private void ScanEndRadnomjesto()
        {
            this.RADNOMJESTOSelect4.Close();
        }

        private void ScanLoadRadnomjesto()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRADNOMJESTOSelect4.HasMoreRows)
            {
                this.RcdFound26 = 1;
                this.rowRADNOMJESTO["IDRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNOMJESTOSelect4, 0));
                this.rowRADNOMJESTO["NAZIVRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNOMJESTOSelect4, 1));
            }
        }

        private void ScanNextRadnomjesto()
        {
            this.cmRADNOMJESTOSelect4.HasMoreRows = this.RADNOMJESTOSelect4.Read();
            this.RcdFound26 = 0;
            this.ScanLoadRadnomjesto();
        }

        private void ScanStartRadnomjesto(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString26 + "  FROM [RADNOMJESTO] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNOMJESTO]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString26, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNOMJESTO] ) AS DK_PAGENUM   FROM [RADNOMJESTO] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString26 + " FROM [RADNOMJESTO] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNOMJESTO] ";
            }
            this.cmRADNOMJESTOSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.RADNOMJESTOSelect4 = this.cmRADNOMJESTOSelect4.FetchData();
            this.RcdFound26 = 0;
            this.ScanLoadRadnomjesto();
            this.LoadDataRadnomjesto(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.RADNOMJESTOSet = (RADNOMJESTODataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.RADNOMJESTOSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.RADNOMJESTOSet.RADNOMJESTO.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        RADNOMJESTODataSet.RADNOMJESTORow current = (RADNOMJESTODataSet.RADNOMJESTORow) enumerator.Current;
                        this.rowRADNOMJESTO = current;
                        if (Helpers.IsRowChanged(this.rowRADNOMJESTO))
                        {
                            this.ReadRowRadnomjesto();
                            if (this.rowRADNOMJESTO.RowState == DataRowState.Added)
                            {
                                this.InsertRadnomjesto();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateRadnomjesto();
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

        private void UpdateRadnomjesto()
        {
            this.CheckOptimisticConcurrencyRadnomjesto();
            this.AfterConfirmRadnomjesto();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [RADNOMJESTO] SET [NAZIVRADNOMJESTO]=@NAZIVRADNOMJESTO  WHERE [IDRADNOMJESTO] = @IDRADNOMJESTO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVRADNOMJESTO", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOMJESTO", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNOMJESTO["NAZIVRADNOMJESTO"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNOMJESTO["IDRADNOMJESTO"]));
            command.ExecuteStmt();
            this.OnRADNOMJESTOUpdated(new RADNOMJESTOEventArgs(this.rowRADNOMJESTO, StatementType.Update));
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

        [Serializable]
        public class RADNOMJESTODataChangedException : DataChangedException
        {
            public RADNOMJESTODataChangedException()
            {
            }

            public RADNOMJESTODataChangedException(string message) : base(message)
            {
            }

            protected RADNOMJESTODataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNOMJESTODataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNOMJESTODataLockedException : DataLockedException
        {
            public RADNOMJESTODataLockedException()
            {
            }

            public RADNOMJESTODataLockedException(string message) : base(message)
            {
            }

            protected RADNOMJESTODataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNOMJESTODataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNOMJESTODuplicateKeyException : DuplicateKeyException
        {
            public RADNOMJESTODuplicateKeyException()
            {
            }

            public RADNOMJESTODuplicateKeyException(string message) : base(message)
            {
            }

            protected RADNOMJESTODuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNOMJESTODuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RADNOMJESTOEventArgs : EventArgs
        {
            private RADNOMJESTODataSet.RADNOMJESTORow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RADNOMJESTOEventArgs(RADNOMJESTODataSet.RADNOMJESTORow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RADNOMJESTODataSet.RADNOMJESTORow Row
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
        public class RADNOMJESTONotFoundException : DataNotFoundException
        {
            public RADNOMJESTONotFoundException()
            {
            }

            public RADNOMJESTONotFoundException(string message) : base(message)
            {
            }

            protected RADNOMJESTONotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNOMJESTONotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void RADNOMJESTOUpdateEventHandler(object sender, RADNOMJESTODataAdapter.RADNOMJESTOEventArgs e);
    }
}

