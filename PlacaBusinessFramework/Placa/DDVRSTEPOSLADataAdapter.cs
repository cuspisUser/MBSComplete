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

    public class DDVRSTEPOSLADataAdapter : IDataAdapter, IDDVRSTEPOSLADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmDDVRSTEPOSLASelect1;
        private ReadWriteCommand cmDDVRSTEPOSLASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DDVRSTEPOSLASelect1;
        private IDataReader DDVRSTEPOSLASelect4;
        private DDVRSTEPOSLADataSet DDVRSTEPOSLASet;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__DDNAZIVVRSTAPOSLAOriginal;
        private readonly string m_SelectString168 = "TM1.[DDIDVRSTAPOSLA], TM1.[DDNAZIVVRSTAPOSLA]";
        private string m_WhereString;
        private short RcdFound168;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private DDVRSTEPOSLADataSet.DDVRSTEPOSLARow rowDDVRSTEPOSLA;
        private string scmdbuf;
        private StatementType sMode168;

        public event DDVRSTEPOSLAUpdateEventHandler DDVRSTEPOSLAUpdated;

        public event DDVRSTEPOSLAUpdateEventHandler DDVRSTEPOSLAUpdating;

        private void AddRowDdvrsteposla()
        {
            this.DDVRSTEPOSLASet.DDVRSTEPOSLA.AddDDVRSTEPOSLARow(this.rowDDVRSTEPOSLA);
        }

        private void AfterConfirmDdvrsteposla()
        {
            this.OnDDVRSTEPOSLAUpdating(new DDVRSTEPOSLAEventArgs(this.rowDDVRSTEPOSLA, this.Gx_mode));
        }

        private void CheckDeleteErrorsDdvrsteposla()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [DDOBRACUNIDOBRACUN], [DDIDRADNIK], [DDIDVRSTAPOSLA] FROM [DDOBRACUNRadniciVrstePosla] WITH (NOLOCK) WHERE [DDIDVRSTAPOSLA] = @DDIDVRSTAPOSLA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDVRSTAPOSLA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDVRSTEPOSLA["DDIDVRSTAPOSLA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new DDOBRACUNRadniciVrstePoslaInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "VrstePosla" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyDdvrsteposla()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDIDVRSTAPOSLA], [DDNAZIVVRSTAPOSLA] FROM [DDVRSTEPOSLA] WITH (UPDLOCK) WHERE [DDIDVRSTAPOSLA] = @DDIDVRSTAPOSLA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDVRSTAPOSLA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDVRSTEPOSLA["DDIDVRSTAPOSLA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DDVRSTEPOSLADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DDVRSTEPOSLA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__DDNAZIVVRSTAPOSLAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new DDVRSTEPOSLADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DDVRSTEPOSLA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowDdvrsteposla()
        {
            this.rowDDVRSTEPOSLA = this.DDVRSTEPOSLASet.DDVRSTEPOSLA.NewDDVRSTEPOSLARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDdvrsteposla();
            this.AfterConfirmDdvrsteposla();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DDVRSTEPOSLA]  WHERE [DDIDVRSTAPOSLA] = @DDIDVRSTAPOSLA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDVRSTAPOSLA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDVRSTEPOSLA["DDIDVRSTAPOSLA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsDdvrsteposla();
            }
            this.OnDDVRSTEPOSLAUpdated(new DDVRSTEPOSLAEventArgs(this.rowDDVRSTEPOSLA, StatementType.Delete));
            this.rowDDVRSTEPOSLA.Delete();
            this.sMode168 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode168;
        }

        public virtual int Fill(DDVRSTEPOSLADataSet dataSet)
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
                    this.DDVRSTEPOSLASet = dataSet;
                    this.LoadChildDdvrsteposla(0, -1);
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
            this.DDVRSTEPOSLASet = (DDVRSTEPOSLADataSet) dataSet;
            if (this.DDVRSTEPOSLASet != null)
            {
                return this.Fill(this.DDVRSTEPOSLASet);
            }
            this.DDVRSTEPOSLASet = new DDVRSTEPOSLADataSet();
            this.Fill(this.DDVRSTEPOSLASet);
            dataSet.Merge(this.DDVRSTEPOSLASet);
            return 0;
        }

        public virtual int Fill(DDVRSTEPOSLADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["DDIDVRSTAPOSLA"]));
        }

        public virtual int Fill(DDVRSTEPOSLADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["DDIDVRSTAPOSLA"]));
        }

        public virtual int Fill(DDVRSTEPOSLADataSet dataSet, int dDIDVRSTAPOSLA)
        {
            if (!this.FillByDDIDVRSTAPOSLA(dataSet, dDIDVRSTAPOSLA))
            {
                throw new DDVRSTEPOSLANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DDVRSTEPOSLA") }));
            }
            return 0;
        }

        public virtual bool FillByDDIDVRSTAPOSLA(DDVRSTEPOSLADataSet dataSet, int dDIDVRSTAPOSLA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDVRSTEPOSLASet = dataSet;
            this.rowDDVRSTEPOSLA = this.DDVRSTEPOSLASet.DDVRSTEPOSLA.NewDDVRSTEPOSLARow();
            this.rowDDVRSTEPOSLA.DDIDVRSTAPOSLA = dDIDVRSTAPOSLA;
            try
            {
                this.LoadByDDIDVRSTAPOSLA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound168 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(DDVRSTEPOSLADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDVRSTEPOSLASet = dataSet;
            try
            {
                this.LoadChildDdvrsteposla(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [DDIDVRSTAPOSLA], [DDNAZIVVRSTAPOSLA] FROM [DDVRSTEPOSLA] WITH (NOLOCK) WHERE [DDIDVRSTAPOSLA] = @DDIDVRSTAPOSLA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDVRSTAPOSLA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDVRSTEPOSLA["DDIDVRSTAPOSLA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound168 = 1;
                this.rowDDVRSTEPOSLA["DDIDVRSTAPOSLA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowDDVRSTEPOSLA["DDNAZIVVRSTAPOSLA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode168 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode168;
            }
            else
            {
                this.RcdFound168 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "DDIDVRSTAPOSLA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDVRSTEPOSLASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [DDVRSTEPOSLA] WITH (NOLOCK) ", false);
            this.DDVRSTEPOSLASelect1 = this.cmDDVRSTEPOSLASelect1.FetchData();
            if (this.DDVRSTEPOSLASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.DDVRSTEPOSLASelect1.GetInt32(0);
            }
            this.DDVRSTEPOSLASelect1.Close();
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
            this.RcdFound168 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__DDNAZIVVRSTAPOSLAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.DDVRSTEPOSLASet = new DDVRSTEPOSLADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertDdvrsteposla()
        {
            this.CheckOptimisticConcurrencyDdvrsteposla();
            this.AfterConfirmDdvrsteposla();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DDVRSTEPOSLA] ([DDIDVRSTAPOSLA], [DDNAZIVVRSTAPOSLA]) VALUES (@DDIDVRSTAPOSLA, @DDNAZIVVRSTAPOSLA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDVRSTAPOSLA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDNAZIVVRSTAPOSLA", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDVRSTEPOSLA["DDIDVRSTAPOSLA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDVRSTEPOSLA["DDNAZIVVRSTAPOSLA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DDVRSTEPOSLADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDDVRSTEPOSLAUpdated(new DDVRSTEPOSLAEventArgs(this.rowDDVRSTEPOSLA, StatementType.Insert));
        }

        private void LoadByDDIDVRSTAPOSLA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.DDVRSTEPOSLASet.EnforceConstraints;
            this.DDVRSTEPOSLASet.DDVRSTEPOSLA.BeginLoadData();
            this.ScanByDDIDVRSTAPOSLA(startRow, maxRows);
            this.DDVRSTEPOSLASet.DDVRSTEPOSLA.EndLoadData();
            this.DDVRSTEPOSLASet.EnforceConstraints = enforceConstraints;
            if (this.DDVRSTEPOSLASet.DDVRSTEPOSLA.Count > 0)
            {
                this.rowDDVRSTEPOSLA = this.DDVRSTEPOSLASet.DDVRSTEPOSLA[this.DDVRSTEPOSLASet.DDVRSTEPOSLA.Count - 1];
            }
        }

        private void LoadChildDdvrsteposla(int startRow, int maxRows)
        {
            this.CreateNewRowDdvrsteposla();
            bool enforceConstraints = this.DDVRSTEPOSLASet.EnforceConstraints;
            this.DDVRSTEPOSLASet.DDVRSTEPOSLA.BeginLoadData();
            this.ScanStartDdvrsteposla(startRow, maxRows);
            this.DDVRSTEPOSLASet.DDVRSTEPOSLA.EndLoadData();
            this.DDVRSTEPOSLASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataDdvrsteposla(int maxRows)
        {
            int num = 0;
            if (this.RcdFound168 != 0)
            {
                this.ScanLoadDdvrsteposla();
                while ((this.RcdFound168 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowDdvrsteposla();
                    this.CreateNewRowDdvrsteposla();
                    this.ScanNextDdvrsteposla();
                }
            }
            if (num > 0)
            {
                this.RcdFound168 = 1;
            }
            this.ScanEndDdvrsteposla();
            if (this.DDVRSTEPOSLASet.DDVRSTEPOSLA.Count > 0)
            {
                this.rowDDVRSTEPOSLA = this.DDVRSTEPOSLASet.DDVRSTEPOSLA[this.DDVRSTEPOSLASet.DDVRSTEPOSLA.Count - 1];
            }
        }

        private void LoadRowDdvrsteposla()
        {
            this.AddRowDdvrsteposla();
        }

        private void OnDDVRSTEPOSLAUpdated(DDVRSTEPOSLAEventArgs e)
        {
            if (this.DDVRSTEPOSLAUpdated != null)
            {
                DDVRSTEPOSLAUpdateEventHandler dDVRSTEPOSLAUpdatedEvent = this.DDVRSTEPOSLAUpdated;
                if (dDVRSTEPOSLAUpdatedEvent != null)
                {
                    dDVRSTEPOSLAUpdatedEvent(this, e);
                }
            }
        }

        private void OnDDVRSTEPOSLAUpdating(DDVRSTEPOSLAEventArgs e)
        {
            if (this.DDVRSTEPOSLAUpdating != null)
            {
                DDVRSTEPOSLAUpdateEventHandler dDVRSTEPOSLAUpdatingEvent = this.DDVRSTEPOSLAUpdating;
                if (dDVRSTEPOSLAUpdatingEvent != null)
                {
                    dDVRSTEPOSLAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowDdvrsteposla()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDDVRSTEPOSLA.RowState);
            if (this.rowDDVRSTEPOSLA.RowState != DataRowState.Added)
            {
                this.m__DDNAZIVVRSTAPOSLAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDVRSTEPOSLA["DDNAZIVVRSTAPOSLA", DataRowVersion.Original]);
            }
            else
            {
                this.m__DDNAZIVVRSTAPOSLAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDVRSTEPOSLA["DDNAZIVVRSTAPOSLA"]);
            }
            this._Gxremove = this.rowDDVRSTEPOSLA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowDDVRSTEPOSLA = (DDVRSTEPOSLADataSet.DDVRSTEPOSLARow) DataSetUtil.CloneOriginalDataRow(this.rowDDVRSTEPOSLA);
            }
        }

        private void ScanByDDIDVRSTAPOSLA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[DDIDVRSTAPOSLA] = @DDIDVRSTAPOSLA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString168 + "  FROM [DDVRSTEPOSLA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[DDIDVRSTAPOSLA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString168, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[DDIDVRSTAPOSLA] ) AS DK_PAGENUM   FROM [DDVRSTEPOSLA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString168 + " FROM [DDVRSTEPOSLA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[DDIDVRSTAPOSLA] ";
            }
            this.cmDDVRSTEPOSLASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmDDVRSTEPOSLASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDVRSTEPOSLASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDVRSTAPOSLA", DbType.Int32));
            }
            this.cmDDVRSTEPOSLASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDVRSTEPOSLA["DDIDVRSTAPOSLA"]));
            this.DDVRSTEPOSLASelect4 = this.cmDDVRSTEPOSLASelect4.FetchData();
            this.RcdFound168 = 0;
            this.ScanLoadDdvrsteposla();
            this.LoadDataDdvrsteposla(maxRows);
        }

        private void ScanEndDdvrsteposla()
        {
            this.DDVRSTEPOSLASelect4.Close();
        }

        private void ScanLoadDdvrsteposla()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDDVRSTEPOSLASelect4.HasMoreRows)
            {
                this.RcdFound168 = 1;
                this.rowDDVRSTEPOSLA["DDIDVRSTAPOSLA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDVRSTEPOSLASelect4, 0));
                this.rowDDVRSTEPOSLA["DDNAZIVVRSTAPOSLA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDVRSTEPOSLASelect4, 1));
            }
        }

        private void ScanNextDdvrsteposla()
        {
            this.cmDDVRSTEPOSLASelect4.HasMoreRows = this.DDVRSTEPOSLASelect4.Read();
            this.RcdFound168 = 0;
            this.ScanLoadDdvrsteposla();
        }

        private void ScanStartDdvrsteposla(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString168 + "  FROM [DDVRSTEPOSLA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[DDIDVRSTAPOSLA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString168, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[DDIDVRSTAPOSLA] ) AS DK_PAGENUM   FROM [DDVRSTEPOSLA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString168 + " FROM [DDVRSTEPOSLA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[DDIDVRSTAPOSLA] ";
            }
            this.cmDDVRSTEPOSLASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.DDVRSTEPOSLASelect4 = this.cmDDVRSTEPOSLASelect4.FetchData();
            this.RcdFound168 = 0;
            this.ScanLoadDdvrsteposla();
            this.LoadDataDdvrsteposla(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.DDVRSTEPOSLASet = (DDVRSTEPOSLADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.DDVRSTEPOSLASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.DDVRSTEPOSLASet.DDVRSTEPOSLA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DDVRSTEPOSLADataSet.DDVRSTEPOSLARow current = (DDVRSTEPOSLADataSet.DDVRSTEPOSLARow) enumerator.Current;
                        this.rowDDVRSTEPOSLA = current;
                        if (Helpers.IsRowChanged(this.rowDDVRSTEPOSLA))
                        {
                            this.ReadRowDdvrsteposla();
                            if (this.rowDDVRSTEPOSLA.RowState == DataRowState.Added)
                            {
                                this.InsertDdvrsteposla();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateDdvrsteposla();
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

        private void UpdateDdvrsteposla()
        {
            this.CheckOptimisticConcurrencyDdvrsteposla();
            this.AfterConfirmDdvrsteposla();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DDVRSTEPOSLA] SET [DDNAZIVVRSTAPOSLA]=@DDNAZIVVRSTAPOSLA  WHERE [DDIDVRSTAPOSLA] = @DDIDVRSTAPOSLA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDNAZIVVRSTAPOSLA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDVRSTAPOSLA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDVRSTEPOSLA["DDNAZIVVRSTAPOSLA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDVRSTEPOSLA["DDIDVRSTAPOSLA"]));
            command.ExecuteStmt();
            new ddvrsteposlaupdateredundancy(ref this.dsDefault).execute(this.rowDDVRSTEPOSLA.DDIDVRSTAPOSLA);
            this.OnDDVRSTEPOSLAUpdated(new DDVRSTEPOSLAEventArgs(this.rowDDVRSTEPOSLA, StatementType.Update));
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
        public class DDOBRACUNRadniciVrstePoslaInvalidDeleteException : InvalidDeleteException
        {
            public DDOBRACUNRadniciVrstePoslaInvalidDeleteException()
            {
            }

            public DDOBRACUNRadniciVrstePoslaInvalidDeleteException(string message) : base(message)
            {
            }

            protected DDOBRACUNRadniciVrstePoslaInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDOBRACUNRadniciVrstePoslaInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDVRSTEPOSLADataChangedException : DataChangedException
        {
            public DDVRSTEPOSLADataChangedException()
            {
            }

            public DDVRSTEPOSLADataChangedException(string message) : base(message)
            {
            }

            protected DDVRSTEPOSLADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDVRSTEPOSLADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDVRSTEPOSLADataLockedException : DataLockedException
        {
            public DDVRSTEPOSLADataLockedException()
            {
            }

            public DDVRSTEPOSLADataLockedException(string message) : base(message)
            {
            }

            protected DDVRSTEPOSLADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDVRSTEPOSLADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDVRSTEPOSLADuplicateKeyException : DuplicateKeyException
        {
            public DDVRSTEPOSLADuplicateKeyException()
            {
            }

            public DDVRSTEPOSLADuplicateKeyException(string message) : base(message)
            {
            }

            protected DDVRSTEPOSLADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDVRSTEPOSLADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DDVRSTEPOSLAEventArgs : EventArgs
        {
            private DDVRSTEPOSLADataSet.DDVRSTEPOSLARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public DDVRSTEPOSLAEventArgs(DDVRSTEPOSLADataSet.DDVRSTEPOSLARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DDVRSTEPOSLADataSet.DDVRSTEPOSLARow Row
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
        public class DDVRSTEPOSLANotFoundException : DataNotFoundException
        {
            public DDVRSTEPOSLANotFoundException()
            {
            }

            public DDVRSTEPOSLANotFoundException(string message) : base(message)
            {
            }

            protected DDVRSTEPOSLANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDVRSTEPOSLANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void DDVRSTEPOSLAUpdateEventHandler(object sender, DDVRSTEPOSLADataAdapter.DDVRSTEPOSLAEventArgs e);
    }
}

