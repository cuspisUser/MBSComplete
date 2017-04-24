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

    public class TIPPARTNERADataAdapter : IDataAdapter, ITIPPARTNERADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmTIPPARTNERASelect1;
        private ReadWriteCommand cmTIPPARTNERASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVTIPPARTNERAOriginal;
        private readonly string m_SelectString160 = "TM1.[IDTIPPARTNERA], TM1.[NAZIVTIPPARTNERA]";
        private string m_WhereString;
        private short RcdFound160;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private TIPPARTNERADataSet.TIPPARTNERARow rowTIPPARTNERA;
        private string scmdbuf;
        private StatementType sMode160;
        private IDataReader TIPPARTNERASelect1;
        private IDataReader TIPPARTNERASelect4;
        private TIPPARTNERADataSet TIPPARTNERASet;

        public event TIPPARTNERAUpdateEventHandler TIPPARTNERAUpdated;

        public event TIPPARTNERAUpdateEventHandler TIPPARTNERAUpdating;

        private void AddRowTippartnera()
        {
            this.TIPPARTNERASet.TIPPARTNERA.AddTIPPARTNERARow(this.rowTIPPARTNERA);
        }

        private void AfterConfirmTippartnera()
        {
            this.OnTIPPARTNERAUpdating(new TIPPARTNERAEventArgs(this.rowTIPPARTNERA, this.Gx_mode));
        }

        private void CheckDeleteErrorsTippartnera()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDPARTNER] FROM [PARTNER] WITH (NOLOCK) WHERE [IDTIPPARTNERA] = @IDTIPPARTNERA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPPARTNERA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPPARTNERA["IDTIPPARTNERA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new PARTNERInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "PARTNER" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyTippartnera()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDTIPPARTNERA], [NAZIVTIPPARTNERA] FROM [TIPPARTNERA] WITH (UPDLOCK) WHERE [IDTIPPARTNERA] = @IDTIPPARTNERA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPPARTNERA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPPARTNERA["IDTIPPARTNERA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new TIPPARTNERADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("TIPPARTNERA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVTIPPARTNERAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new TIPPARTNERADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("TIPPARTNERA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowTippartnera()
        {
            this.rowTIPPARTNERA = this.TIPPARTNERASet.TIPPARTNERA.NewTIPPARTNERARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyTippartnera();
            this.AfterConfirmTippartnera();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [TIPPARTNERA]  WHERE [IDTIPPARTNERA] = @IDTIPPARTNERA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPPARTNERA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPPARTNERA["IDTIPPARTNERA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsTippartnera();
            }
            this.OnTIPPARTNERAUpdated(new TIPPARTNERAEventArgs(this.rowTIPPARTNERA, StatementType.Delete));
            this.rowTIPPARTNERA.Delete();
            this.sMode160 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode160;
        }

        public virtual int Fill(TIPPARTNERADataSet dataSet)
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
                    this.TIPPARTNERASet = dataSet;
                    this.LoadChildTippartnera(0, -1);
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
            this.TIPPARTNERASet = (TIPPARTNERADataSet) dataSet;
            if (this.TIPPARTNERASet != null)
            {
                return this.Fill(this.TIPPARTNERASet);
            }
            this.TIPPARTNERASet = new TIPPARTNERADataSet();
            this.Fill(this.TIPPARTNERASet);
            dataSet.Merge(this.TIPPARTNERASet);
            return 0;
        }

        public virtual int Fill(TIPPARTNERADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDTIPPARTNERA"]));
        }

        public virtual int Fill(TIPPARTNERADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDTIPPARTNERA"]));
        }

        public virtual int Fill(TIPPARTNERADataSet dataSet, int iDTIPPARTNERA)
        {
            if (!this.FillByIDTIPPARTNERA(dataSet, iDTIPPARTNERA))
            {
                throw new TIPPARTNERANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("TIPPARTNERA") }));
            }
            return 0;
        }

        public virtual bool FillByIDTIPPARTNERA(TIPPARTNERADataSet dataSet, int iDTIPPARTNERA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.TIPPARTNERASet = dataSet;
            this.rowTIPPARTNERA = this.TIPPARTNERASet.TIPPARTNERA.NewTIPPARTNERARow();
            this.rowTIPPARTNERA.IDTIPPARTNERA = iDTIPPARTNERA;
            try
            {
                this.LoadByIDTIPPARTNERA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound160 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(TIPPARTNERADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.TIPPARTNERASet = dataSet;
            try
            {
                this.LoadChildTippartnera(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDTIPPARTNERA], [NAZIVTIPPARTNERA] FROM [TIPPARTNERA] WITH (NOLOCK) WHERE [IDTIPPARTNERA] = @IDTIPPARTNERA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPPARTNERA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPPARTNERA["IDTIPPARTNERA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound160 = 1;
                this.rowTIPPARTNERA["IDTIPPARTNERA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowTIPPARTNERA["NAZIVTIPPARTNERA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode160 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode160;
            }
            else
            {
                this.RcdFound160 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDTIPPARTNERA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmTIPPARTNERASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [TIPPARTNERA] WITH (NOLOCK) ", false);
            this.TIPPARTNERASelect1 = this.cmTIPPARTNERASelect1.FetchData();
            if (this.TIPPARTNERASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.TIPPARTNERASelect1.GetInt32(0);
            }
            this.TIPPARTNERASelect1.Close();
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
            this.RcdFound160 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVTIPPARTNERAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.TIPPARTNERASet = new TIPPARTNERADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertTippartnera()
        {
            this.CheckOptimisticConcurrencyTippartnera();
            this.AfterConfirmTippartnera();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [TIPPARTNERA] ([IDTIPPARTNERA], [NAZIVTIPPARTNERA]) VALUES (@IDTIPPARTNERA, @NAZIVTIPPARTNERA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPPARTNERA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVTIPPARTNERA", DbType.String, 100));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPPARTNERA["IDTIPPARTNERA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowTIPPARTNERA["NAZIVTIPPARTNERA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new TIPPARTNERADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnTIPPARTNERAUpdated(new TIPPARTNERAEventArgs(this.rowTIPPARTNERA, StatementType.Insert));
        }

        private void LoadByIDTIPPARTNERA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.TIPPARTNERASet.EnforceConstraints;
            this.TIPPARTNERASet.TIPPARTNERA.BeginLoadData();
            this.ScanByIDTIPPARTNERA(startRow, maxRows);
            this.TIPPARTNERASet.TIPPARTNERA.EndLoadData();
            this.TIPPARTNERASet.EnforceConstraints = enforceConstraints;
            if (this.TIPPARTNERASet.TIPPARTNERA.Count > 0)
            {
                this.rowTIPPARTNERA = this.TIPPARTNERASet.TIPPARTNERA[this.TIPPARTNERASet.TIPPARTNERA.Count - 1];
            }
        }

        private void LoadChildTippartnera(int startRow, int maxRows)
        {
            this.CreateNewRowTippartnera();
            bool enforceConstraints = this.TIPPARTNERASet.EnforceConstraints;
            this.TIPPARTNERASet.TIPPARTNERA.BeginLoadData();
            this.ScanStartTippartnera(startRow, maxRows);
            this.TIPPARTNERASet.TIPPARTNERA.EndLoadData();
            this.TIPPARTNERASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataTippartnera(int maxRows)
        {
            int num = 0;
            if (this.RcdFound160 != 0)
            {
                this.ScanLoadTippartnera();
                while ((this.RcdFound160 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowTippartnera();
                    this.CreateNewRowTippartnera();
                    this.ScanNextTippartnera();
                }
            }
            if (num > 0)
            {
                this.RcdFound160 = 1;
            }
            this.ScanEndTippartnera();
            if (this.TIPPARTNERASet.TIPPARTNERA.Count > 0)
            {
                this.rowTIPPARTNERA = this.TIPPARTNERASet.TIPPARTNERA[this.TIPPARTNERASet.TIPPARTNERA.Count - 1];
            }
        }

        private void LoadRowTippartnera()
        {
            this.AddRowTippartnera();
        }

        private void OnTIPPARTNERAUpdated(TIPPARTNERAEventArgs e)
        {
            if (this.TIPPARTNERAUpdated != null)
            {
                TIPPARTNERAUpdateEventHandler tIPPARTNERAUpdatedEvent = this.TIPPARTNERAUpdated;
                if (tIPPARTNERAUpdatedEvent != null)
                {
                    tIPPARTNERAUpdatedEvent(this, e);
                }
            }
        }

        private void OnTIPPARTNERAUpdating(TIPPARTNERAEventArgs e)
        {
            if (this.TIPPARTNERAUpdating != null)
            {
                TIPPARTNERAUpdateEventHandler tIPPARTNERAUpdatingEvent = this.TIPPARTNERAUpdating;
                if (tIPPARTNERAUpdatingEvent != null)
                {
                    tIPPARTNERAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowTippartnera()
        {
            this.Gx_mode = Mode.FromRowState(this.rowTIPPARTNERA.RowState);
            if (this.rowTIPPARTNERA.RowState != DataRowState.Added)
            {
                this.m__NAZIVTIPPARTNERAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPPARTNERA["NAZIVTIPPARTNERA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVTIPPARTNERAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPPARTNERA["NAZIVTIPPARTNERA"]);
            }
            this._Gxremove = this.rowTIPPARTNERA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowTIPPARTNERA = (TIPPARTNERADataSet.TIPPARTNERARow) DataSetUtil.CloneOriginalDataRow(this.rowTIPPARTNERA);
            }
        }

        private void ScanByIDTIPPARTNERA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDTIPPARTNERA] = @IDTIPPARTNERA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString160 + "  FROM [TIPPARTNERA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPPARTNERA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString160, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDTIPPARTNERA] ) AS DK_PAGENUM   FROM [TIPPARTNERA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString160 + " FROM [TIPPARTNERA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPPARTNERA] ";
            }
            this.cmTIPPARTNERASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmTIPPARTNERASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmTIPPARTNERASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPPARTNERA", DbType.Int32));
            }
            this.cmTIPPARTNERASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPPARTNERA["IDTIPPARTNERA"]));
            this.TIPPARTNERASelect4 = this.cmTIPPARTNERASelect4.FetchData();
            this.RcdFound160 = 0;
            this.ScanLoadTippartnera();
            this.LoadDataTippartnera(maxRows);
        }

        private void ScanEndTippartnera()
        {
            this.TIPPARTNERASelect4.Close();
        }

        private void ScanLoadTippartnera()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmTIPPARTNERASelect4.HasMoreRows)
            {
                this.RcdFound160 = 1;
                this.rowTIPPARTNERA["IDTIPPARTNERA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.TIPPARTNERASelect4, 0));
                this.rowTIPPARTNERA["NAZIVTIPPARTNERA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.TIPPARTNERASelect4, 1));
            }
        }

        private void ScanNextTippartnera()
        {
            this.cmTIPPARTNERASelect4.HasMoreRows = this.TIPPARTNERASelect4.Read();
            this.RcdFound160 = 0;
            this.ScanLoadTippartnera();
        }

        private void ScanStartTippartnera(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString160 + "  FROM [TIPPARTNERA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPPARTNERA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString160, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDTIPPARTNERA] ) AS DK_PAGENUM   FROM [TIPPARTNERA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString160 + " FROM [TIPPARTNERA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPPARTNERA] ";
            }
            this.cmTIPPARTNERASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.TIPPARTNERASelect4 = this.cmTIPPARTNERASelect4.FetchData();
            this.RcdFound160 = 0;
            this.ScanLoadTippartnera();
            this.LoadDataTippartnera(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.TIPPARTNERASet = (TIPPARTNERADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.TIPPARTNERASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.TIPPARTNERASet.TIPPARTNERA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        TIPPARTNERADataSet.TIPPARTNERARow current = (TIPPARTNERADataSet.TIPPARTNERARow) enumerator.Current;
                        this.rowTIPPARTNERA = current;
                        if (Helpers.IsRowChanged(this.rowTIPPARTNERA))
                        {
                            this.ReadRowTippartnera();
                            if (this.rowTIPPARTNERA.RowState == DataRowState.Added)
                            {
                                this.InsertTippartnera();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateTippartnera();
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

        private void UpdateTippartnera()
        {
            this.CheckOptimisticConcurrencyTippartnera();
            this.AfterConfirmTippartnera();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [TIPPARTNERA] SET [NAZIVTIPPARTNERA]=@NAZIVTIPPARTNERA  WHERE [IDTIPPARTNERA] = @IDTIPPARTNERA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVTIPPARTNERA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPPARTNERA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPPARTNERA["NAZIVTIPPARTNERA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowTIPPARTNERA["IDTIPPARTNERA"]));
            command.ExecuteStmt();
            this.OnTIPPARTNERAUpdated(new TIPPARTNERAEventArgs(this.rowTIPPARTNERA, StatementType.Update));
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
        public class PARTNERInvalidDeleteException : InvalidDeleteException
        {
            public PARTNERInvalidDeleteException()
            {
            }

            public PARTNERInvalidDeleteException(string message) : base(message)
            {
            }

            protected PARTNERInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PARTNERInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPPARTNERADataChangedException : DataChangedException
        {
            public TIPPARTNERADataChangedException()
            {
            }

            public TIPPARTNERADataChangedException(string message) : base(message)
            {
            }

            protected TIPPARTNERADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPPARTNERADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPPARTNERADataLockedException : DataLockedException
        {
            public TIPPARTNERADataLockedException()
            {
            }

            public TIPPARTNERADataLockedException(string message) : base(message)
            {
            }

            protected TIPPARTNERADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPPARTNERADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPPARTNERADuplicateKeyException : DuplicateKeyException
        {
            public TIPPARTNERADuplicateKeyException()
            {
            }

            public TIPPARTNERADuplicateKeyException(string message) : base(message)
            {
            }

            protected TIPPARTNERADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPPARTNERADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class TIPPARTNERAEventArgs : EventArgs
        {
            private TIPPARTNERADataSet.TIPPARTNERARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public TIPPARTNERAEventArgs(TIPPARTNERADataSet.TIPPARTNERARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public TIPPARTNERADataSet.TIPPARTNERARow Row
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
        public class TIPPARTNERANotFoundException : DataNotFoundException
        {
            public TIPPARTNERANotFoundException()
            {
            }

            public TIPPARTNERANotFoundException(string message) : base(message)
            {
            }

            protected TIPPARTNERANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPPARTNERANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void TIPPARTNERAUpdateEventHandler(object sender, TIPPARTNERADataAdapter.TIPPARTNERAEventArgs e);
    }
}

