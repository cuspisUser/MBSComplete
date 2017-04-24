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

    public class TIPDOKUMENTADataAdapter : IDataAdapter, ITIPDOKUMENTADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmTIPDOKUMENTASelect1;
        private ReadWriteCommand cmTIPDOKUMENTASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVTIPDOKUMENTAOriginal;
        private readonly string m_SelectString197 = "TM1.[IDTIPDOKUMENTA], TM1.[NAZIVTIPDOKUMENTA]";
        private string m_WhereString;
        private short RcdFound197;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private TIPDOKUMENTADataSet.TIPDOKUMENTARow rowTIPDOKUMENTA;
        private string scmdbuf;
        private StatementType sMode197;
        private IDataReader TIPDOKUMENTASelect1;
        private IDataReader TIPDOKUMENTASelect4;
        private TIPDOKUMENTADataSet TIPDOKUMENTASet;

        public event TIPDOKUMENTAUpdateEventHandler TIPDOKUMENTAUpdated;

        public event TIPDOKUMENTAUpdateEventHandler TIPDOKUMENTAUpdating;

        private void AddRowTipdokumenta()
        {
            this.TIPDOKUMENTASet.TIPDOKUMENTA.AddTIPDOKUMENTARow(this.rowTIPDOKUMENTA);
        }

        private void AfterConfirmTipdokumenta()
        {
            this.OnTIPDOKUMENTAUpdating(new TIPDOKUMENTAEventArgs(this.rowTIPDOKUMENTA, this.Gx_mode));
        }

        private void CheckDeleteErrorsTipdokumenta()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDDOKUMENT] FROM [DOKUMENT] WITH (NOLOCK) WHERE [IDTIPDOKUMENTA] = @IDTIPDOKUMENTA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPDOKUMENTA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPDOKUMENTA["IDTIPDOKUMENTA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new DOKUMENTInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "DOKUMENT" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyTipdokumenta()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDTIPDOKUMENTA], [NAZIVTIPDOKUMENTA] FROM [TIPDOKUMENTA] WITH (UPDLOCK) WHERE [IDTIPDOKUMENTA] = @IDTIPDOKUMENTA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPDOKUMENTA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPDOKUMENTA["IDTIPDOKUMENTA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new TIPDOKUMENTADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("TIPDOKUMENTA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVTIPDOKUMENTAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new TIPDOKUMENTADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("TIPDOKUMENTA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowTipdokumenta()
        {
            this.rowTIPDOKUMENTA = this.TIPDOKUMENTASet.TIPDOKUMENTA.NewTIPDOKUMENTARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyTipdokumenta();
            this.AfterConfirmTipdokumenta();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [TIPDOKUMENTA]  WHERE [IDTIPDOKUMENTA] = @IDTIPDOKUMENTA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPDOKUMENTA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPDOKUMENTA["IDTIPDOKUMENTA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsTipdokumenta();
            }
            this.OnTIPDOKUMENTAUpdated(new TIPDOKUMENTAEventArgs(this.rowTIPDOKUMENTA, StatementType.Delete));
            this.rowTIPDOKUMENTA.Delete();
            this.sMode197 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode197;
        }

        public virtual int Fill(TIPDOKUMENTADataSet dataSet)
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
                    this.TIPDOKUMENTASet = dataSet;
                    this.LoadChildTipdokumenta(0, -1);
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
            this.TIPDOKUMENTASet = (TIPDOKUMENTADataSet) dataSet;
            if (this.TIPDOKUMENTASet != null)
            {
                return this.Fill(this.TIPDOKUMENTASet);
            }
            this.TIPDOKUMENTASet = new TIPDOKUMENTADataSet();
            this.Fill(this.TIPDOKUMENTASet);
            dataSet.Merge(this.TIPDOKUMENTASet);
            return 0;
        }

        public virtual int Fill(TIPDOKUMENTADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDTIPDOKUMENTA"]));
        }

        public virtual int Fill(TIPDOKUMENTADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDTIPDOKUMENTA"]));
        }

        public virtual int Fill(TIPDOKUMENTADataSet dataSet, int iDTIPDOKUMENTA)
        {
            if (!this.FillByIDTIPDOKUMENTA(dataSet, iDTIPDOKUMENTA))
            {
                throw new TIPDOKUMENTANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("TIPDOKUMENTA") }));
            }
            return 0;
        }

        public virtual bool FillByIDTIPDOKUMENTA(TIPDOKUMENTADataSet dataSet, int iDTIPDOKUMENTA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.TIPDOKUMENTASet = dataSet;
            this.rowTIPDOKUMENTA = this.TIPDOKUMENTASet.TIPDOKUMENTA.NewTIPDOKUMENTARow();
            this.rowTIPDOKUMENTA.IDTIPDOKUMENTA = iDTIPDOKUMENTA;
            try
            {
                this.LoadByIDTIPDOKUMENTA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound197 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(TIPDOKUMENTADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.TIPDOKUMENTASet = dataSet;
            try
            {
                this.LoadChildTipdokumenta(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDTIPDOKUMENTA], [NAZIVTIPDOKUMENTA] FROM [TIPDOKUMENTA] WITH (NOLOCK) WHERE [IDTIPDOKUMENTA] = @IDTIPDOKUMENTA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPDOKUMENTA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPDOKUMENTA["IDTIPDOKUMENTA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound197 = 1;
                this.rowTIPDOKUMENTA["IDTIPDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowTIPDOKUMENTA["NAZIVTIPDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode197 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode197;
            }
            else
            {
                this.RcdFound197 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDTIPDOKUMENTA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmTIPDOKUMENTASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [TIPDOKUMENTA] WITH (NOLOCK) ", false);
            this.TIPDOKUMENTASelect1 = this.cmTIPDOKUMENTASelect1.FetchData();
            if (this.TIPDOKUMENTASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.TIPDOKUMENTASelect1.GetInt32(0);
            }
            this.TIPDOKUMENTASelect1.Close();
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
            this.RcdFound197 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVTIPDOKUMENTAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.TIPDOKUMENTASet = new TIPDOKUMENTADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertTipdokumenta()
        {
            this.CheckOptimisticConcurrencyTipdokumenta();
            this.AfterConfirmTipdokumenta();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [TIPDOKUMENTA] ([IDTIPDOKUMENTA], [NAZIVTIPDOKUMENTA]) VALUES (@IDTIPDOKUMENTA, @NAZIVTIPDOKUMENTA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPDOKUMENTA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVTIPDOKUMENTA", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPDOKUMENTA["IDTIPDOKUMENTA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowTIPDOKUMENTA["NAZIVTIPDOKUMENTA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new TIPDOKUMENTADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnTIPDOKUMENTAUpdated(new TIPDOKUMENTAEventArgs(this.rowTIPDOKUMENTA, StatementType.Insert));
        }

        private void LoadByIDTIPDOKUMENTA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.TIPDOKUMENTASet.EnforceConstraints;
            this.TIPDOKUMENTASet.TIPDOKUMENTA.BeginLoadData();
            this.ScanByIDTIPDOKUMENTA(startRow, maxRows);
            this.TIPDOKUMENTASet.TIPDOKUMENTA.EndLoadData();
            this.TIPDOKUMENTASet.EnforceConstraints = enforceConstraints;
            if (this.TIPDOKUMENTASet.TIPDOKUMENTA.Count > 0)
            {
                this.rowTIPDOKUMENTA = this.TIPDOKUMENTASet.TIPDOKUMENTA[this.TIPDOKUMENTASet.TIPDOKUMENTA.Count - 1];
            }
        }

        private void LoadChildTipdokumenta(int startRow, int maxRows)
        {
            this.CreateNewRowTipdokumenta();
            bool enforceConstraints = this.TIPDOKUMENTASet.EnforceConstraints;
            this.TIPDOKUMENTASet.TIPDOKUMENTA.BeginLoadData();
            this.ScanStartTipdokumenta(startRow, maxRows);
            this.TIPDOKUMENTASet.TIPDOKUMENTA.EndLoadData();
            this.TIPDOKUMENTASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataTipdokumenta(int maxRows)
        {
            int num = 0;
            if (this.RcdFound197 != 0)
            {
                this.ScanLoadTipdokumenta();
                while ((this.RcdFound197 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowTipdokumenta();
                    this.CreateNewRowTipdokumenta();
                    this.ScanNextTipdokumenta();
                }
            }
            if (num > 0)
            {
                this.RcdFound197 = 1;
            }
            this.ScanEndTipdokumenta();
            if (this.TIPDOKUMENTASet.TIPDOKUMENTA.Count > 0)
            {
                this.rowTIPDOKUMENTA = this.TIPDOKUMENTASet.TIPDOKUMENTA[this.TIPDOKUMENTASet.TIPDOKUMENTA.Count - 1];
            }
        }

        private void LoadRowTipdokumenta()
        {
            this.AddRowTipdokumenta();
        }

        private void OnTIPDOKUMENTAUpdated(TIPDOKUMENTAEventArgs e)
        {
            if (this.TIPDOKUMENTAUpdated != null)
            {
                TIPDOKUMENTAUpdateEventHandler tIPDOKUMENTAUpdatedEvent = this.TIPDOKUMENTAUpdated;
                if (tIPDOKUMENTAUpdatedEvent != null)
                {
                    tIPDOKUMENTAUpdatedEvent(this, e);
                }
            }
        }

        private void OnTIPDOKUMENTAUpdating(TIPDOKUMENTAEventArgs e)
        {
            if (this.TIPDOKUMENTAUpdating != null)
            {
                TIPDOKUMENTAUpdateEventHandler tIPDOKUMENTAUpdatingEvent = this.TIPDOKUMENTAUpdating;
                if (tIPDOKUMENTAUpdatingEvent != null)
                {
                    tIPDOKUMENTAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowTipdokumenta()
        {
            this.Gx_mode = Mode.FromRowState(this.rowTIPDOKUMENTA.RowState);
            if (this.rowTIPDOKUMENTA.RowState != DataRowState.Added)
            {
                this.m__NAZIVTIPDOKUMENTAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPDOKUMENTA["NAZIVTIPDOKUMENTA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVTIPDOKUMENTAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPDOKUMENTA["NAZIVTIPDOKUMENTA"]);
            }
            this._Gxremove = this.rowTIPDOKUMENTA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowTIPDOKUMENTA = (TIPDOKUMENTADataSet.TIPDOKUMENTARow) DataSetUtil.CloneOriginalDataRow(this.rowTIPDOKUMENTA);
            }
        }

        private void ScanByIDTIPDOKUMENTA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDTIPDOKUMENTA] = @IDTIPDOKUMENTA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString197 + "  FROM [TIPDOKUMENTA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPDOKUMENTA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString197, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDTIPDOKUMENTA] ) AS DK_PAGENUM   FROM [TIPDOKUMENTA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString197 + " FROM [TIPDOKUMENTA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPDOKUMENTA] ";
            }
            this.cmTIPDOKUMENTASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmTIPDOKUMENTASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmTIPDOKUMENTASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPDOKUMENTA", DbType.Int32));
            }
            this.cmTIPDOKUMENTASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPDOKUMENTA["IDTIPDOKUMENTA"]));
            this.TIPDOKUMENTASelect4 = this.cmTIPDOKUMENTASelect4.FetchData();
            this.RcdFound197 = 0;
            this.ScanLoadTipdokumenta();
            this.LoadDataTipdokumenta(maxRows);
        }

        private void ScanEndTipdokumenta()
        {
            this.TIPDOKUMENTASelect4.Close();
        }

        private void ScanLoadTipdokumenta()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmTIPDOKUMENTASelect4.HasMoreRows)
            {
                this.RcdFound197 = 1;
                this.rowTIPDOKUMENTA["IDTIPDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.TIPDOKUMENTASelect4, 0));
                this.rowTIPDOKUMENTA["NAZIVTIPDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.TIPDOKUMENTASelect4, 1));
            }
        }

        private void ScanNextTipdokumenta()
        {
            this.cmTIPDOKUMENTASelect4.HasMoreRows = this.TIPDOKUMENTASelect4.Read();
            this.RcdFound197 = 0;
            this.ScanLoadTipdokumenta();
        }

        private void ScanStartTipdokumenta(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString197 + "  FROM [TIPDOKUMENTA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPDOKUMENTA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString197, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDTIPDOKUMENTA] ) AS DK_PAGENUM   FROM [TIPDOKUMENTA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString197 + " FROM [TIPDOKUMENTA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPDOKUMENTA] ";
            }
            this.cmTIPDOKUMENTASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.TIPDOKUMENTASelect4 = this.cmTIPDOKUMENTASelect4.FetchData();
            this.RcdFound197 = 0;
            this.ScanLoadTipdokumenta();
            this.LoadDataTipdokumenta(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.TIPDOKUMENTASet = (TIPDOKUMENTADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.TIPDOKUMENTASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.TIPDOKUMENTASet.TIPDOKUMENTA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        TIPDOKUMENTADataSet.TIPDOKUMENTARow current = (TIPDOKUMENTADataSet.TIPDOKUMENTARow) enumerator.Current;
                        this.rowTIPDOKUMENTA = current;
                        if (Helpers.IsRowChanged(this.rowTIPDOKUMENTA))
                        {
                            this.ReadRowTipdokumenta();
                            if (this.rowTIPDOKUMENTA.RowState == DataRowState.Added)
                            {
                                this.InsertTipdokumenta();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateTipdokumenta();
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

        private void UpdateTipdokumenta()
        {
            this.CheckOptimisticConcurrencyTipdokumenta();
            this.AfterConfirmTipdokumenta();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [TIPDOKUMENTA] SET [NAZIVTIPDOKUMENTA]=@NAZIVTIPDOKUMENTA  WHERE [IDTIPDOKUMENTA] = @IDTIPDOKUMENTA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVTIPDOKUMENTA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPDOKUMENTA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPDOKUMENTA["NAZIVTIPDOKUMENTA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowTIPDOKUMENTA["IDTIPDOKUMENTA"]));
            command.ExecuteStmt();
            this.OnTIPDOKUMENTAUpdated(new TIPDOKUMENTAEventArgs(this.rowTIPDOKUMENTA, StatementType.Update));
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
        public class DOKUMENTInvalidDeleteException : InvalidDeleteException
        {
            public DOKUMENTInvalidDeleteException()
            {
            }

            public DOKUMENTInvalidDeleteException(string message) : base(message)
            {
            }

            protected DOKUMENTInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOKUMENTInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPDOKUMENTADataChangedException : DataChangedException
        {
            public TIPDOKUMENTADataChangedException()
            {
            }

            public TIPDOKUMENTADataChangedException(string message) : base(message)
            {
            }

            protected TIPDOKUMENTADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPDOKUMENTADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPDOKUMENTADataLockedException : DataLockedException
        {
            public TIPDOKUMENTADataLockedException()
            {
            }

            public TIPDOKUMENTADataLockedException(string message) : base(message)
            {
            }

            protected TIPDOKUMENTADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPDOKUMENTADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPDOKUMENTADuplicateKeyException : DuplicateKeyException
        {
            public TIPDOKUMENTADuplicateKeyException()
            {
            }

            public TIPDOKUMENTADuplicateKeyException(string message) : base(message)
            {
            }

            protected TIPDOKUMENTADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPDOKUMENTADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class TIPDOKUMENTAEventArgs : EventArgs
        {
            private TIPDOKUMENTADataSet.TIPDOKUMENTARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public TIPDOKUMENTAEventArgs(TIPDOKUMENTADataSet.TIPDOKUMENTARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public TIPDOKUMENTADataSet.TIPDOKUMENTARow Row
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
        public class TIPDOKUMENTANotFoundException : DataNotFoundException
        {
            public TIPDOKUMENTANotFoundException()
            {
            }

            public TIPDOKUMENTANotFoundException(string message) : base(message)
            {
            }

            protected TIPDOKUMENTANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPDOKUMENTANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void TIPDOKUMENTAUpdateEventHandler(object sender, TIPDOKUMENTADataAdapter.TIPDOKUMENTAEventArgs e);
    }
}

