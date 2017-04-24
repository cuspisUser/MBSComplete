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

    public class RAD1SPREMEDataAdapter : IDataAdapter, IRAD1SPREMEDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmRAD1SPREMESelect1;
        private ReadWriteCommand cmRAD1SPREMESelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__RAD1NAZIVSPREMEOriginal;
        private readonly string m_SelectString280 = "TM1.[RAD1IDSPREME], TM1.[RAD1NAZIVSPREME]";
        private string m_WhereString;
        private IDataReader RAD1SPREMESelect1;
        private IDataReader RAD1SPREMESelect4;
        private RAD1SPREMEDataSet RAD1SPREMESet;
        private short RcdFound280;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private RAD1SPREMEDataSet.RAD1SPREMERow rowRAD1SPREME;
        private string scmdbuf;
        private StatementType sMode280;

        public event RAD1SPREMEUpdateEventHandler RAD1SPREMEUpdated;

        public event RAD1SPREMEUpdateEventHandler RAD1SPREMEUpdating;

        private void AddRowRad1spreme()
        {
            this.RAD1SPREMESet.RAD1SPREME.AddRAD1SPREMERow(this.rowRAD1SPREME);
        }

        private void AfterConfirmRad1spreme()
        {
            this.OnRAD1SPREMEUpdating(new RAD1SPREMEEventArgs(this.rowRAD1SPREME, this.Gx_mode));
        }

        private void CheckDeleteErrorsRad1spreme()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [RAD1IDSPREME], [IDSTRUCNASPREMA] FROM [RAD1SPREMEVEZA] WITH (NOLOCK) WHERE [RAD1IDSPREME] = @RAD1IDSPREME ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1IDSPREME", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREME["RAD1IDSPREME"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RAD1SPREMEVEZAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RAD1SPREMEVEZA" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyRad1spreme()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [RAD1IDSPREME], [RAD1NAZIVSPREME] FROM [RAD1SPREME] WITH (UPDLOCK) WHERE [RAD1IDSPREME] = @RAD1IDSPREME ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1IDSPREME", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREME["RAD1IDSPREME"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RAD1SPREMEDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RAD1SPREME") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__RAD1NAZIVSPREMEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new RAD1SPREMEDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RAD1SPREME") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowRad1spreme()
        {
            this.rowRAD1SPREME = this.RAD1SPREMESet.RAD1SPREME.NewRAD1SPREMERow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRad1spreme();
            this.AfterConfirmRad1spreme();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RAD1SPREME]  WHERE [RAD1IDSPREME] = @RAD1IDSPREME", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1IDSPREME", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREME["RAD1IDSPREME"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsRad1spreme();
            }
            this.OnRAD1SPREMEUpdated(new RAD1SPREMEEventArgs(this.rowRAD1SPREME, StatementType.Delete));
            this.rowRAD1SPREME.Delete();
            this.sMode280 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode280;
        }

        public virtual int Fill(RAD1SPREMEDataSet dataSet)
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
                    this.RAD1SPREMESet = dataSet;
                    this.LoadChildRad1spreme(0, -1);
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
            this.RAD1SPREMESet = (RAD1SPREMEDataSet) dataSet;
            if (this.RAD1SPREMESet != null)
            {
                return this.Fill(this.RAD1SPREMESet);
            }
            this.RAD1SPREMESet = new RAD1SPREMEDataSet();
            this.Fill(this.RAD1SPREMESet);
            dataSet.Merge(this.RAD1SPREMESet);
            return 0;
        }

        public virtual int Fill(RAD1SPREMEDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["RAD1IDSPREME"]));
        }

        public virtual int Fill(RAD1SPREMEDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["RAD1IDSPREME"]));
        }

        public virtual int Fill(RAD1SPREMEDataSet dataSet, int rAD1IDSPREME)
        {
            if (!this.FillByRAD1IDSPREME(dataSet, rAD1IDSPREME))
            {
                throw new RAD1SPREMENotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RAD1SPREME") }));
            }
            return 0;
        }

        public virtual bool FillByRAD1IDSPREME(RAD1SPREMEDataSet dataSet, int rAD1IDSPREME)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1SPREMESet = dataSet;
            this.rowRAD1SPREME = this.RAD1SPREMESet.RAD1SPREME.NewRAD1SPREMERow();
            this.rowRAD1SPREME.RAD1IDSPREME = rAD1IDSPREME;
            try
            {
                this.LoadByRAD1IDSPREME(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound280 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(RAD1SPREMEDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1SPREMESet = dataSet;
            try
            {
                this.LoadChildRad1spreme(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [RAD1IDSPREME], [RAD1NAZIVSPREME] FROM [RAD1SPREME] WITH (NOLOCK) WHERE [RAD1IDSPREME] = @RAD1IDSPREME ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1IDSPREME", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREME["RAD1IDSPREME"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound280 = 1;
                this.rowRAD1SPREME["RAD1IDSPREME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowRAD1SPREME["RAD1NAZIVSPREME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode280 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode280;
            }
            else
            {
                this.RcdFound280 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "RAD1IDSPREME";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1SPREMESelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RAD1SPREME] WITH (NOLOCK) ", false);
            this.RAD1SPREMESelect1 = this.cmRAD1SPREMESelect1.FetchData();
            if (this.RAD1SPREMESelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RAD1SPREMESelect1.GetInt32(0);
            }
            this.RAD1SPREMESelect1.Close();
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
            this.RcdFound280 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__RAD1NAZIVSPREMEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.RAD1SPREMESet = new RAD1SPREMEDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertRad1spreme()
        {
            this.CheckOptimisticConcurrencyRad1spreme();
            this.AfterConfirmRad1spreme();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RAD1SPREME] ([RAD1IDSPREME], [RAD1NAZIVSPREME]) VALUES (@RAD1IDSPREME, @RAD1NAZIVSPREME)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1IDSPREME", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1NAZIVSPREME", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREME["RAD1IDSPREME"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREME["RAD1NAZIVSPREME"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RAD1SPREMEDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnRAD1SPREMEUpdated(new RAD1SPREMEEventArgs(this.rowRAD1SPREME, StatementType.Insert));
        }

        private void LoadByRAD1IDSPREME(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RAD1SPREMESet.EnforceConstraints;
            this.RAD1SPREMESet.RAD1SPREME.BeginLoadData();
            this.ScanByRAD1IDSPREME(startRow, maxRows);
            this.RAD1SPREMESet.RAD1SPREME.EndLoadData();
            this.RAD1SPREMESet.EnforceConstraints = enforceConstraints;
            if (this.RAD1SPREMESet.RAD1SPREME.Count > 0)
            {
                this.rowRAD1SPREME = this.RAD1SPREMESet.RAD1SPREME[this.RAD1SPREMESet.RAD1SPREME.Count - 1];
            }
        }

        private void LoadChildRad1spreme(int startRow, int maxRows)
        {
            this.CreateNewRowRad1spreme();
            bool enforceConstraints = this.RAD1SPREMESet.EnforceConstraints;
            this.RAD1SPREMESet.RAD1SPREME.BeginLoadData();
            this.ScanStartRad1spreme(startRow, maxRows);
            this.RAD1SPREMESet.RAD1SPREME.EndLoadData();
            this.RAD1SPREMESet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataRad1spreme(int maxRows)
        {
            int num = 0;
            if (this.RcdFound280 != 0)
            {
                this.ScanLoadRad1spreme();
                while ((this.RcdFound280 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowRad1spreme();
                    this.CreateNewRowRad1spreme();
                    this.ScanNextRad1spreme();
                }
            }
            if (num > 0)
            {
                this.RcdFound280 = 1;
            }
            this.ScanEndRad1spreme();
            if (this.RAD1SPREMESet.RAD1SPREME.Count > 0)
            {
                this.rowRAD1SPREME = this.RAD1SPREMESet.RAD1SPREME[this.RAD1SPREMESet.RAD1SPREME.Count - 1];
            }
        }

        private void LoadRowRad1spreme()
        {
            this.AddRowRad1spreme();
        }

        private void OnRAD1SPREMEUpdated(RAD1SPREMEEventArgs e)
        {
            if (this.RAD1SPREMEUpdated != null)
            {
                RAD1SPREMEUpdateEventHandler handler = this.RAD1SPREMEUpdated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnRAD1SPREMEUpdating(RAD1SPREMEEventArgs e)
        {
            if (this.RAD1SPREMEUpdating != null)
            {
                RAD1SPREMEUpdateEventHandler handler = this.RAD1SPREMEUpdating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void ReadRowRad1spreme()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRAD1SPREME.RowState);
            if (this.rowRAD1SPREME.RowState != DataRowState.Added)
            {
                this.m__RAD1NAZIVSPREMEOriginal = RuntimeHelpers.GetObjectValue(this.rowRAD1SPREME["RAD1NAZIVSPREME", DataRowVersion.Original]);
            }
            else
            {
                this.m__RAD1NAZIVSPREMEOriginal = RuntimeHelpers.GetObjectValue(this.rowRAD1SPREME["RAD1NAZIVSPREME"]);
            }
            this._Gxremove = this.rowRAD1SPREME.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowRAD1SPREME = (RAD1SPREMEDataSet.RAD1SPREMERow) DataSetUtil.CloneOriginalDataRow(this.rowRAD1SPREME);
            }
        }

        private void ScanByRAD1IDSPREME(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[RAD1IDSPREME] = @RAD1IDSPREME";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString280 + "  FROM [RAD1SPREME] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1IDSPREME]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString280, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1IDSPREME] ) AS DK_PAGENUM   FROM [RAD1SPREME] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString280 + " FROM [RAD1SPREME] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1IDSPREME] ";
            }
            this.cmRAD1SPREMESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRAD1SPREMESelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1SPREMESelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1IDSPREME", DbType.Int32));
            }
            this.cmRAD1SPREMESelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREME["RAD1IDSPREME"]));
            this.RAD1SPREMESelect4 = this.cmRAD1SPREMESelect4.FetchData();
            this.RcdFound280 = 0;
            this.ScanLoadRad1spreme();
            this.LoadDataRad1spreme(maxRows);
        }

        private void ScanEndRad1spreme()
        {
            this.RAD1SPREMESelect4.Close();
        }

        private void ScanLoadRad1spreme()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRAD1SPREMESelect4.HasMoreRows)
            {
                this.RcdFound280 = 1;
                this.rowRAD1SPREME["RAD1IDSPREME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RAD1SPREMESelect4, 0));
                this.rowRAD1SPREME["RAD1NAZIVSPREME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RAD1SPREMESelect4, 1));
            }
        }

        private void ScanNextRad1spreme()
        {
            this.cmRAD1SPREMESelect4.HasMoreRows = this.RAD1SPREMESelect4.Read();
            this.RcdFound280 = 0;
            this.ScanLoadRad1spreme();
        }

        private void ScanStartRad1spreme(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString280 + "  FROM [RAD1SPREME] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1IDSPREME]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString280, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1IDSPREME] ) AS DK_PAGENUM   FROM [RAD1SPREME] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString280 + " FROM [RAD1SPREME] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1IDSPREME] ";
            }
            this.cmRAD1SPREMESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.RAD1SPREMESelect4 = this.cmRAD1SPREMESelect4.FetchData();
            this.RcdFound280 = 0;
            this.ScanLoadRad1spreme();
            this.LoadDataRad1spreme(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.RAD1SPREMESet = (RAD1SPREMEDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.RAD1SPREMESet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.RAD1SPREMESet.RAD1SPREME.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        RAD1SPREMEDataSet.RAD1SPREMERow current = (RAD1SPREMEDataSet.RAD1SPREMERow) enumerator.Current;
                        this.rowRAD1SPREME = current;
                        if (Helpers.IsRowChanged(this.rowRAD1SPREME))
                        {
                            this.ReadRowRad1spreme();
                            if (this.rowRAD1SPREME.RowState == DataRowState.Added)
                            {
                                this.InsertRad1spreme();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateRad1spreme();
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

        private void UpdateRad1spreme()
        {
            this.CheckOptimisticConcurrencyRad1spreme();
            this.AfterConfirmRad1spreme();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [RAD1SPREME] SET [RAD1NAZIVSPREME]=@RAD1NAZIVSPREME  WHERE [RAD1IDSPREME] = @RAD1IDSPREME", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1NAZIVSPREME", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1IDSPREME", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREME["RAD1NAZIVSPREME"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREME["RAD1IDSPREME"]));
            command.ExecuteStmt();
            this.OnRAD1SPREMEUpdated(new RAD1SPREMEEventArgs(this.rowRAD1SPREME, StatementType.Update));
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
        public class RAD1SPREMEDataChangedException : DataChangedException
        {
            public RAD1SPREMEDataChangedException()
            {
            }

            public RAD1SPREMEDataChangedException(string message) : base(message)
            {
            }

            protected RAD1SPREMEDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1SPREMEDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1SPREMEDataLockedException : DataLockedException
        {
            public RAD1SPREMEDataLockedException()
            {
            }

            public RAD1SPREMEDataLockedException(string message) : base(message)
            {
            }

            protected RAD1SPREMEDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1SPREMEDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1SPREMEDuplicateKeyException : DuplicateKeyException
        {
            public RAD1SPREMEDuplicateKeyException()
            {
            }

            public RAD1SPREMEDuplicateKeyException(string message) : base(message)
            {
            }

            protected RAD1SPREMEDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1SPREMEDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RAD1SPREMEEventArgs : EventArgs
        {
            private RAD1SPREMEDataSet.RAD1SPREMERow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RAD1SPREMEEventArgs(RAD1SPREMEDataSet.RAD1SPREMERow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RAD1SPREMEDataSet.RAD1SPREMERow Row
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
        public class RAD1SPREMENotFoundException : DataNotFoundException
        {
            public RAD1SPREMENotFoundException()
            {
            }

            public RAD1SPREMENotFoundException(string message) : base(message)
            {
            }

            protected RAD1SPREMENotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1SPREMENotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void RAD1SPREMEUpdateEventHandler(object sender, RAD1SPREMEDataAdapter.RAD1SPREMEEventArgs e);

        [Serializable]
        public class RAD1SPREMEVEZAInvalidDeleteException : InvalidDeleteException
        {
            public RAD1SPREMEVEZAInvalidDeleteException()
            {
            }

            public RAD1SPREMEVEZAInvalidDeleteException(string message) : base(message)
            {
            }

            protected RAD1SPREMEVEZAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1SPREMEVEZAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

