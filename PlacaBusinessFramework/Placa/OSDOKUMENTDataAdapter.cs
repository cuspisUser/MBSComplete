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

    public class OSDOKUMENTDataAdapter : IDataAdapter, IOSDOKUMENTDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmOSDOKUMENTSelect1;
        private ReadWriteCommand cmOSDOKUMENTSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVOSDOKUMENTOriginal;
        private readonly string m_SelectString273 = "TM1.[IDOSDOKUMENT], TM1.[NAZIVOSDOKUMENT]";
        private string m_WhereString;
        private IDataReader OSDOKUMENTSelect1;
        private IDataReader OSDOKUMENTSelect4;
        private OSDOKUMENTDataSet OSDOKUMENTSet;
        private short RcdFound273;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private OSDOKUMENTDataSet.OSDOKUMENTRow rowOSDOKUMENT;
        private string scmdbuf;
        private StatementType sMode273;

        public event OSDOKUMENTUpdateEventHandler OSDOKUMENTUpdated;

        public event OSDOKUMENTUpdateEventHandler OSDOKUMENTUpdating;

        private void AddRowOsdokument()
        {
            this.OSDOKUMENTSet.OSDOKUMENT.AddOSDOKUMENTRow(this.rowOSDOKUMENT);
        }

        private void AfterConfirmOsdokument()
        {
            this.OnOSDOKUMENTUpdating(new OSDOKUMENTEventArgs(this.rowOSDOKUMENT, this.Gx_mode));
        }

        private void CheckDeleteErrorsOsdokument()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [INVBROJ], [IDOSDOKUMENT], [OSBROJDOKUMENTA] FROM [OSTEMELJNICA] WITH (NOLOCK) WHERE [IDOSDOKUMENT] = @IDOSDOKUMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSDOKUMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSDOKUMENT["IDOSDOKUMENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new OSTEMELJNICAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "TEMELJNICA" }));
            }
            reader.Close();
        }

        private void CheckExtendedTableOsdokument()
        {
            this.rowOSDOKUMENT.OSDK = NumberUtil.ToString((long) this.rowOSDOKUMENT.IDOSDOKUMENT, "") + " | " + this.rowOSDOKUMENT.NAZIVOSDOKUMENT;
        }

        private void CheckOptimisticConcurrencyOsdokument()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOSDOKUMENT], [NAZIVOSDOKUMENT] FROM [OSDOKUMENT] WITH (UPDLOCK) WHERE [IDOSDOKUMENT] = @IDOSDOKUMENT ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSDOKUMENT", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSDOKUMENT["IDOSDOKUMENT"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new OSDOKUMENTDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("OSDOKUMENT") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVOSDOKUMENTOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new OSDOKUMENTDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("OSDOKUMENT") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowOsdokument()
        {
            this.rowOSDOKUMENT = this.OSDOKUMENTSet.OSDOKUMENT.NewOSDOKUMENTRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyOsdokument();
            this.OnDeleteControlsOsdokument();
            this.AfterConfirmOsdokument();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [OSDOKUMENT]  WHERE [IDOSDOKUMENT] = @IDOSDOKUMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSDOKUMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSDOKUMENT["IDOSDOKUMENT"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsOsdokument();
            }
            this.OnOSDOKUMENTUpdated(new OSDOKUMENTEventArgs(this.rowOSDOKUMENT, StatementType.Delete));
            this.rowOSDOKUMENT.Delete();
            this.sMode273 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode273;
        }

        public virtual int Fill(OSDOKUMENTDataSet dataSet)
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
                    this.OSDOKUMENTSet = dataSet;
                    this.LoadChildOsdokument(0, -1);
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
            this.OSDOKUMENTSet = (OSDOKUMENTDataSet) dataSet;
            if (this.OSDOKUMENTSet != null)
            {
                return this.Fill(this.OSDOKUMENTSet);
            }
            this.OSDOKUMENTSet = new OSDOKUMENTDataSet();
            this.Fill(this.OSDOKUMENTSet);
            dataSet.Merge(this.OSDOKUMENTSet);
            return 0;
        }

        public virtual int Fill(OSDOKUMENTDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDOSDOKUMENT"]));
        }

        public virtual int Fill(OSDOKUMENTDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDOSDOKUMENT"]));
        }

        public virtual int Fill(OSDOKUMENTDataSet dataSet, int iDOSDOKUMENT)
        {
            if (!this.FillByIDOSDOKUMENT(dataSet, iDOSDOKUMENT))
            {
                throw new OSDOKUMENTNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OSDOKUMENT") }));
            }
            return 0;
        }

        public virtual bool FillByIDOSDOKUMENT(OSDOKUMENTDataSet dataSet, int iDOSDOKUMENT)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSDOKUMENTSet = dataSet;
            this.rowOSDOKUMENT = this.OSDOKUMENTSet.OSDOKUMENT.NewOSDOKUMENTRow();
            this.rowOSDOKUMENT.IDOSDOKUMENT = iDOSDOKUMENT;
            try
            {
                this.LoadByIDOSDOKUMENT(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound273 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(OSDOKUMENTDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSDOKUMENTSet = dataSet;
            try
            {
                this.LoadChildOsdokument(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOSDOKUMENT], [NAZIVOSDOKUMENT] FROM [OSDOKUMENT] WITH (NOLOCK) WHERE [IDOSDOKUMENT] = @IDOSDOKUMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSDOKUMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSDOKUMENT["IDOSDOKUMENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound273 = 1;
                this.rowOSDOKUMENT["IDOSDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowOSDOKUMENT["NAZIVOSDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode273 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadOsdokument();
                this.Gx_mode = this.sMode273;
            }
            else
            {
                this.RcdFound273 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDOSDOKUMENT";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSDOKUMENTSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OSDOKUMENT] WITH (NOLOCK) ", false);
            this.OSDOKUMENTSelect1 = this.cmOSDOKUMENTSelect1.FetchData();
            if (this.OSDOKUMENTSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OSDOKUMENTSelect1.GetInt32(0);
            }
            this.OSDOKUMENTSelect1.Close();
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
            this.RcdFound273 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVOSDOKUMENTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.OSDOKUMENTSet = new OSDOKUMENTDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertOsdokument()
        {
            this.CheckOptimisticConcurrencyOsdokument();
            this.CheckExtendedTableOsdokument();
            this.AfterConfirmOsdokument();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [OSDOKUMENT] ([IDOSDOKUMENT], [NAZIVOSDOKUMENT]) VALUES (@IDOSDOKUMENT, @NAZIVOSDOKUMENT)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOSDOKUMENT", DbType.String, 30));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSDOKUMENT["IDOSDOKUMENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOSDOKUMENT["NAZIVOSDOKUMENT"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new OSDOKUMENTDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnOSDOKUMENTUpdated(new OSDOKUMENTEventArgs(this.rowOSDOKUMENT, StatementType.Insert));
        }

        private void LoadByIDOSDOKUMENT(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OSDOKUMENTSet.EnforceConstraints;
            this.OSDOKUMENTSet.OSDOKUMENT.BeginLoadData();
            this.ScanByIDOSDOKUMENT(startRow, maxRows);
            this.OSDOKUMENTSet.OSDOKUMENT.EndLoadData();
            this.OSDOKUMENTSet.EnforceConstraints = enforceConstraints;
            if (this.OSDOKUMENTSet.OSDOKUMENT.Count > 0)
            {
                this.rowOSDOKUMENT = this.OSDOKUMENTSet.OSDOKUMENT[this.OSDOKUMENTSet.OSDOKUMENT.Count - 1];
            }
        }

        private void LoadChildOsdokument(int startRow, int maxRows)
        {
            this.CreateNewRowOsdokument();
            bool enforceConstraints = this.OSDOKUMENTSet.EnforceConstraints;
            this.OSDOKUMENTSet.OSDOKUMENT.BeginLoadData();
            this.ScanStartOsdokument(startRow, maxRows);
            this.OSDOKUMENTSet.OSDOKUMENT.EndLoadData();
            this.OSDOKUMENTSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataOsdokument(int maxRows)
        {
            int num = 0;
            if (this.RcdFound273 != 0)
            {
                this.ScanLoadOsdokument();
                while ((this.RcdFound273 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowOsdokument();
                    this.CreateNewRowOsdokument();
                    this.ScanNextOsdokument();
                }
            }
            if (num > 0)
            {
                this.RcdFound273 = 1;
            }
            this.ScanEndOsdokument();
            if (this.OSDOKUMENTSet.OSDOKUMENT.Count > 0)
            {
                this.rowOSDOKUMENT = this.OSDOKUMENTSet.OSDOKUMENT[this.OSDOKUMENTSet.OSDOKUMENT.Count - 1];
            }
        }

        private void LoadOsdokument()
        {
            this.rowOSDOKUMENT.OSDK = NumberUtil.ToString((long) this.rowOSDOKUMENT.IDOSDOKUMENT, "") + " | " + this.rowOSDOKUMENT.NAZIVOSDOKUMENT;
        }

        private void LoadRowOsdokument()
        {
            this.OnLoadActionsOsdokument();
            this.AddRowOsdokument();
        }

        private void OnDeleteControlsOsdokument()
        {
            this.rowOSDOKUMENT.OSDK = NumberUtil.ToString((long) this.rowOSDOKUMENT.IDOSDOKUMENT, "") + " | " + this.rowOSDOKUMENT.NAZIVOSDOKUMENT;
        }

        private void OnLoadActionsOsdokument()
        {
            this.rowOSDOKUMENT.OSDK = NumberUtil.ToString((long) this.rowOSDOKUMENT.IDOSDOKUMENT, "") + " | " + this.rowOSDOKUMENT.NAZIVOSDOKUMENT;
        }

        private void OnOSDOKUMENTUpdated(OSDOKUMENTEventArgs e)
        {
            if (this.OSDOKUMENTUpdated != null)
            {
                OSDOKUMENTUpdateEventHandler oSDOKUMENTUpdatedEvent = this.OSDOKUMENTUpdated;
                if (oSDOKUMENTUpdatedEvent != null)
                {
                    oSDOKUMENTUpdatedEvent(this, e);
                }
            }
        }

        private void OnOSDOKUMENTUpdating(OSDOKUMENTEventArgs e)
        {
            if (this.OSDOKUMENTUpdating != null)
            {
                OSDOKUMENTUpdateEventHandler oSDOKUMENTUpdatingEvent = this.OSDOKUMENTUpdating;
                if (oSDOKUMENTUpdatingEvent != null)
                {
                    oSDOKUMENTUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowOsdokument()
        {
            this.Gx_mode = Mode.FromRowState(this.rowOSDOKUMENT.RowState);
            if (this.rowOSDOKUMENT.RowState != DataRowState.Added)
            {
                this.m__NAZIVOSDOKUMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowOSDOKUMENT["NAZIVOSDOKUMENT", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVOSDOKUMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowOSDOKUMENT["NAZIVOSDOKUMENT"]);
            }
            this._Gxremove = this.rowOSDOKUMENT.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowOSDOKUMENT = (OSDOKUMENTDataSet.OSDOKUMENTRow) DataSetUtil.CloneOriginalDataRow(this.rowOSDOKUMENT);
            }
        }

        private void ScanByIDOSDOKUMENT(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDOSDOKUMENT] = @IDOSDOKUMENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString273 + "  FROM [OSDOKUMENT] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSDOKUMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString273, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOSDOKUMENT] ) AS DK_PAGENUM   FROM [OSDOKUMENT] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString273 + " FROM [OSDOKUMENT] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSDOKUMENT] ";
            }
            this.cmOSDOKUMENTSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOSDOKUMENTSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSDOKUMENTSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSDOKUMENT", DbType.Int32));
            }
            this.cmOSDOKUMENTSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSDOKUMENT["IDOSDOKUMENT"]));
            this.OSDOKUMENTSelect4 = this.cmOSDOKUMENTSelect4.FetchData();
            this.RcdFound273 = 0;
            this.ScanLoadOsdokument();
            this.LoadDataOsdokument(maxRows);
        }

        private void ScanEndOsdokument()
        {
            this.OSDOKUMENTSelect4.Close();
        }

        private void ScanLoadOsdokument()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmOSDOKUMENTSelect4.HasMoreRows)
            {
                this.RcdFound273 = 1;
                this.rowOSDOKUMENT["IDOSDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OSDOKUMENTSelect4, 0));
                this.rowOSDOKUMENT["NAZIVOSDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OSDOKUMENTSelect4, 1));
            }
        }

        private void ScanNextOsdokument()
        {
            this.cmOSDOKUMENTSelect4.HasMoreRows = this.OSDOKUMENTSelect4.Read();
            this.RcdFound273 = 0;
            this.ScanLoadOsdokument();
        }

        private void ScanStartOsdokument(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString273 + "  FROM [OSDOKUMENT] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSDOKUMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString273, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOSDOKUMENT] ) AS DK_PAGENUM   FROM [OSDOKUMENT] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString273 + " FROM [OSDOKUMENT] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSDOKUMENT] ";
            }
            this.cmOSDOKUMENTSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.OSDOKUMENTSelect4 = this.cmOSDOKUMENTSelect4.FetchData();
            this.RcdFound273 = 0;
            this.ScanLoadOsdokument();
            this.LoadDataOsdokument(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.OSDOKUMENTSet = (OSDOKUMENTDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.OSDOKUMENTSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.OSDOKUMENTSet.OSDOKUMENT.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        OSDOKUMENTDataSet.OSDOKUMENTRow current = (OSDOKUMENTDataSet.OSDOKUMENTRow) enumerator.Current;
                        this.rowOSDOKUMENT = current;
                        if (Helpers.IsRowChanged(this.rowOSDOKUMENT))
                        {
                            this.ReadRowOsdokument();
                            if (this.rowOSDOKUMENT.RowState == DataRowState.Added)
                            {
                                this.InsertOsdokument();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateOsdokument();
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

        private void UpdateOsdokument()
        {
            this.CheckOptimisticConcurrencyOsdokument();
            this.CheckExtendedTableOsdokument();
            this.AfterConfirmOsdokument();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [OSDOKUMENT] SET [NAZIVOSDOKUMENT]=@NAZIVOSDOKUMENT  WHERE [IDOSDOKUMENT] = @IDOSDOKUMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOSDOKUMENT", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSDOKUMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSDOKUMENT["NAZIVOSDOKUMENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOSDOKUMENT["IDOSDOKUMENT"]));
            command.ExecuteStmt();
            this.OnOSDOKUMENTUpdated(new OSDOKUMENTEventArgs(this.rowOSDOKUMENT, StatementType.Update));
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
        public class OSDOKUMENTDataChangedException : DataChangedException
        {
            public OSDOKUMENTDataChangedException()
            {
            }

            public OSDOKUMENTDataChangedException(string message) : base(message)
            {
            }

            protected OSDOKUMENTDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSDOKUMENTDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSDOKUMENTDataLockedException : DataLockedException
        {
            public OSDOKUMENTDataLockedException()
            {
            }

            public OSDOKUMENTDataLockedException(string message) : base(message)
            {
            }

            protected OSDOKUMENTDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSDOKUMENTDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSDOKUMENTDuplicateKeyException : DuplicateKeyException
        {
            public OSDOKUMENTDuplicateKeyException()
            {
            }

            public OSDOKUMENTDuplicateKeyException(string message) : base(message)
            {
            }

            protected OSDOKUMENTDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSDOKUMENTDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class OSDOKUMENTEventArgs : EventArgs
        {
            private OSDOKUMENTDataSet.OSDOKUMENTRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public OSDOKUMENTEventArgs(OSDOKUMENTDataSet.OSDOKUMENTRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OSDOKUMENTDataSet.OSDOKUMENTRow Row
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
        public class OSDOKUMENTNotFoundException : DataNotFoundException
        {
            public OSDOKUMENTNotFoundException()
            {
            }

            public OSDOKUMENTNotFoundException(string message) : base(message)
            {
            }

            protected OSDOKUMENTNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSDOKUMENTNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void OSDOKUMENTUpdateEventHandler(object sender, OSDOKUMENTDataAdapter.OSDOKUMENTEventArgs e);

        [Serializable]
        public class OSTEMELJNICAInvalidDeleteException : InvalidDeleteException
        {
            public OSTEMELJNICAInvalidDeleteException()
            {
            }

            public OSTEMELJNICAInvalidDeleteException(string message) : base(message)
            {
            }

            protected OSTEMELJNICAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSTEMELJNICAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

