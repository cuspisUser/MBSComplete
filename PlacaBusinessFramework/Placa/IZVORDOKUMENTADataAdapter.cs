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

    public class IZVORDOKUMENTADataAdapter : IDataAdapter, IIZVORDOKUMENTADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmIZVORDOKUMENTASelect1;
        private ReadWriteCommand cmIZVORDOKUMENTASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private IDataReader IZVORDOKUMENTASelect1;
        private IDataReader IZVORDOKUMENTASelect4;
        private IZVORDOKUMENTADataSet IZVORDOKUMENTASet;
        private object m__NAZIVIZVORAOriginal;
        private readonly string m_SelectString76 = "TM1.[SIFRAIZVORA], TM1.[NAZIVIZVORA]";
        private string m_WhereString;
        private short RcdFound76;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private IZVORDOKUMENTADataSet.IZVORDOKUMENTARow rowIZVORDOKUMENTA;
        private string scmdbuf;
        private StatementType sMode76;

        public event IZVORDOKUMENTAUpdateEventHandler IZVORDOKUMENTAUpdated;

        public event IZVORDOKUMENTAUpdateEventHandler IZVORDOKUMENTAUpdating;

        private void AddRowIzvordokumenta()
        {
            this.IZVORDOKUMENTASet.IZVORDOKUMENTA.AddIZVORDOKUMENTARow(this.rowIZVORDOKUMENTA);
        }

        private void AfterConfirmIzvordokumenta()
        {
            this.OnIZVORDOKUMENTAUpdating(new IZVORDOKUMENTAEventArgs(this.rowIZVORDOKUMENTA, this.Gx_mode));
        }

        private void CheckDeleteErrorsIzvordokumenta()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDKORISNIK], [IDZIRO] FROM [KORISNIKLevel1] WITH (NOLOCK) WHERE [SIFRAIZVORA] = @SIFRAIZVORA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAIZVORA", DbType.String, 3));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIZVORDOKUMENTA["SIFRAIZVORA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new KORISNIKLevel1InvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Level1" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyIzvordokumenta()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [SIFRAIZVORA], [NAZIVIZVORA] FROM [IZVORDOKUMENTA] WITH (UPDLOCK) WHERE [SIFRAIZVORA] = @SIFRAIZVORA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAIZVORA", DbType.String, 3));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIZVORDOKUMENTA["SIFRAIZVORA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new IZVORDOKUMENTADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("IZVORDOKUMENTA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVIZVORAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new IZVORDOKUMENTADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("IZVORDOKUMENTA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowIzvordokumenta()
        {
            this.rowIZVORDOKUMENTA = this.IZVORDOKUMENTASet.IZVORDOKUMENTA.NewIZVORDOKUMENTARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyIzvordokumenta();
            this.AfterConfirmIzvordokumenta();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [IZVORDOKUMENTA]  WHERE [SIFRAIZVORA] = @SIFRAIZVORA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAIZVORA", DbType.String, 3));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIZVORDOKUMENTA["SIFRAIZVORA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsIzvordokumenta();
            }
            this.OnIZVORDOKUMENTAUpdated(new IZVORDOKUMENTAEventArgs(this.rowIZVORDOKUMENTA, StatementType.Delete));
            this.rowIZVORDOKUMENTA.Delete();
            this.sMode76 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode76;
        }

        public virtual int Fill(IZVORDOKUMENTADataSet dataSet)
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
                    this.IZVORDOKUMENTASet = dataSet;
                    this.LoadChildIzvordokumenta(0, -1);
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
            this.IZVORDOKUMENTASet = (IZVORDOKUMENTADataSet) dataSet;
            if (this.IZVORDOKUMENTASet != null)
            {
                return this.Fill(this.IZVORDOKUMENTASet);
            }
            this.IZVORDOKUMENTASet = new IZVORDOKUMENTADataSet();
            this.Fill(this.IZVORDOKUMENTASet);
            dataSet.Merge(this.IZVORDOKUMENTASet);
            return 0;
        }

        public virtual int Fill(IZVORDOKUMENTADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["SIFRAIZVORA"]));
        }

        public virtual int Fill(IZVORDOKUMENTADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["SIFRAIZVORA"]));
        }

        public virtual int Fill(IZVORDOKUMENTADataSet dataSet, string sIFRAIZVORA)
        {
            if (!this.FillBySIFRAIZVORA(dataSet, sIFRAIZVORA))
            {
                throw new IZVORDOKUMENTANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("IZVORDOKUMENTA") }));
            }
            return 0;
        }

        public virtual bool FillBySIFRAIZVORA(IZVORDOKUMENTADataSet dataSet, string sIFRAIZVORA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.IZVORDOKUMENTASet = dataSet;
            this.rowIZVORDOKUMENTA = this.IZVORDOKUMENTASet.IZVORDOKUMENTA.NewIZVORDOKUMENTARow();
            this.rowIZVORDOKUMENTA.SIFRAIZVORA = sIFRAIZVORA;
            try
            {
                this.LoadBySIFRAIZVORA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound76 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(IZVORDOKUMENTADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.IZVORDOKUMENTASet = dataSet;
            try
            {
                this.LoadChildIzvordokumenta(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [SIFRAIZVORA], [NAZIVIZVORA] FROM [IZVORDOKUMENTA] WITH (NOLOCK) WHERE [SIFRAIZVORA] = @SIFRAIZVORA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAIZVORA", DbType.String, 3));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIZVORDOKUMENTA["SIFRAIZVORA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound76 = 1;
                this.rowIZVORDOKUMENTA["SIFRAIZVORA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowIZVORDOKUMENTA["NAZIVIZVORA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode76 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode76;
            }
            else
            {
                this.RcdFound76 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "SIFRAIZVORA";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIZVORDOKUMENTASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [IZVORDOKUMENTA] WITH (NOLOCK) ", false);
            this.IZVORDOKUMENTASelect1 = this.cmIZVORDOKUMENTASelect1.FetchData();
            if (this.IZVORDOKUMENTASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.IZVORDOKUMENTASelect1.GetInt32(0);
            }
            this.IZVORDOKUMENTASelect1.Close();
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
            this.RcdFound76 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVIZVORAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.IZVORDOKUMENTASet = new IZVORDOKUMENTADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertIzvordokumenta()
        {
            this.CheckOptimisticConcurrencyIzvordokumenta();
            this.AfterConfirmIzvordokumenta();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [IZVORDOKUMENTA] ([SIFRAIZVORA], [NAZIVIZVORA]) VALUES (@SIFRAIZVORA, @NAZIVIZVORA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAIZVORA", DbType.String, 3));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVIZVORA", DbType.String, 20));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIZVORDOKUMENTA["SIFRAIZVORA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowIZVORDOKUMENTA["NAZIVIZVORA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new IZVORDOKUMENTADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnIZVORDOKUMENTAUpdated(new IZVORDOKUMENTAEventArgs(this.rowIZVORDOKUMENTA, StatementType.Insert));
        }

        private void LoadBySIFRAIZVORA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.IZVORDOKUMENTASet.EnforceConstraints;
            this.IZVORDOKUMENTASet.IZVORDOKUMENTA.BeginLoadData();
            this.ScanBySIFRAIZVORA(startRow, maxRows);
            this.IZVORDOKUMENTASet.IZVORDOKUMENTA.EndLoadData();
            this.IZVORDOKUMENTASet.EnforceConstraints = enforceConstraints;
            if (this.IZVORDOKUMENTASet.IZVORDOKUMENTA.Count > 0)
            {
                this.rowIZVORDOKUMENTA = this.IZVORDOKUMENTASet.IZVORDOKUMENTA[this.IZVORDOKUMENTASet.IZVORDOKUMENTA.Count - 1];
            }
        }

        private void LoadChildIzvordokumenta(int startRow, int maxRows)
        {
            this.CreateNewRowIzvordokumenta();
            bool enforceConstraints = this.IZVORDOKUMENTASet.EnforceConstraints;
            this.IZVORDOKUMENTASet.IZVORDOKUMENTA.BeginLoadData();
            this.ScanStartIzvordokumenta(startRow, maxRows);
            this.IZVORDOKUMENTASet.IZVORDOKUMENTA.EndLoadData();
            this.IZVORDOKUMENTASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataIzvordokumenta(int maxRows)
        {
            int num = 0;
            if (this.RcdFound76 != 0)
            {
                this.ScanLoadIzvordokumenta();
                while ((this.RcdFound76 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowIzvordokumenta();
                    this.CreateNewRowIzvordokumenta();
                    this.ScanNextIzvordokumenta();
                }
            }
            if (num > 0)
            {
                this.RcdFound76 = 1;
            }
            this.ScanEndIzvordokumenta();
            if (this.IZVORDOKUMENTASet.IZVORDOKUMENTA.Count > 0)
            {
                this.rowIZVORDOKUMENTA = this.IZVORDOKUMENTASet.IZVORDOKUMENTA[this.IZVORDOKUMENTASet.IZVORDOKUMENTA.Count - 1];
            }
        }

        private void LoadRowIzvordokumenta()
        {
            this.AddRowIzvordokumenta();
        }

        private void OnIZVORDOKUMENTAUpdated(IZVORDOKUMENTAEventArgs e)
        {
            if (this.IZVORDOKUMENTAUpdated != null)
            {
                IZVORDOKUMENTAUpdateEventHandler iZVORDOKUMENTAUpdatedEvent = this.IZVORDOKUMENTAUpdated;
                if (iZVORDOKUMENTAUpdatedEvent != null)
                {
                    iZVORDOKUMENTAUpdatedEvent(this, e);
                }
            }
        }

        private void OnIZVORDOKUMENTAUpdating(IZVORDOKUMENTAEventArgs e)
        {
            if (this.IZVORDOKUMENTAUpdating != null)
            {
                IZVORDOKUMENTAUpdateEventHandler iZVORDOKUMENTAUpdatingEvent = this.IZVORDOKUMENTAUpdating;
                if (iZVORDOKUMENTAUpdatingEvent != null)
                {
                    iZVORDOKUMENTAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowIzvordokumenta()
        {
            this.Gx_mode = Mode.FromRowState(this.rowIZVORDOKUMENTA.RowState);
            if (this.rowIZVORDOKUMENTA.RowState != DataRowState.Added)
            {
                this.m__NAZIVIZVORAOriginal = RuntimeHelpers.GetObjectValue(this.rowIZVORDOKUMENTA["NAZIVIZVORA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVIZVORAOriginal = RuntimeHelpers.GetObjectValue(this.rowIZVORDOKUMENTA["NAZIVIZVORA"]);
            }
            this._Gxremove = this.rowIZVORDOKUMENTA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowIZVORDOKUMENTA = (IZVORDOKUMENTADataSet.IZVORDOKUMENTARow) DataSetUtil.CloneOriginalDataRow(this.rowIZVORDOKUMENTA);
            }
        }

        private void ScanBySIFRAIZVORA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[SIFRAIZVORA] = @SIFRAIZVORA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString76 + "  FROM [IZVORDOKUMENTA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[SIFRAIZVORA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString76, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[SIFRAIZVORA] ) AS DK_PAGENUM   FROM [IZVORDOKUMENTA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString76 + " FROM [IZVORDOKUMENTA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[SIFRAIZVORA] ";
            }
            this.cmIZVORDOKUMENTASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmIZVORDOKUMENTASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmIZVORDOKUMENTASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAIZVORA", DbType.String, 3));
            }
            this.cmIZVORDOKUMENTASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIZVORDOKUMENTA["SIFRAIZVORA"]));
            this.IZVORDOKUMENTASelect4 = this.cmIZVORDOKUMENTASelect4.FetchData();
            this.RcdFound76 = 0;
            this.ScanLoadIzvordokumenta();
            this.LoadDataIzvordokumenta(maxRows);
        }

        private void ScanEndIzvordokumenta()
        {
            this.IZVORDOKUMENTASelect4.Close();
        }

        private void ScanLoadIzvordokumenta()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmIZVORDOKUMENTASelect4.HasMoreRows)
            {
                this.RcdFound76 = 1;
                this.rowIZVORDOKUMENTA["SIFRAIZVORA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.IZVORDOKUMENTASelect4, 0));
                this.rowIZVORDOKUMENTA["NAZIVIZVORA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.IZVORDOKUMENTASelect4, 1));
            }
        }

        private void ScanNextIzvordokumenta()
        {
            this.cmIZVORDOKUMENTASelect4.HasMoreRows = this.IZVORDOKUMENTASelect4.Read();
            this.RcdFound76 = 0;
            this.ScanLoadIzvordokumenta();
        }

        private void ScanStartIzvordokumenta(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString76 + "  FROM [IZVORDOKUMENTA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[SIFRAIZVORA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString76, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[SIFRAIZVORA] ) AS DK_PAGENUM   FROM [IZVORDOKUMENTA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString76 + " FROM [IZVORDOKUMENTA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[SIFRAIZVORA] ";
            }
            this.cmIZVORDOKUMENTASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.IZVORDOKUMENTASelect4 = this.cmIZVORDOKUMENTASelect4.FetchData();
            this.RcdFound76 = 0;
            this.ScanLoadIzvordokumenta();
            this.LoadDataIzvordokumenta(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.IZVORDOKUMENTASet = (IZVORDOKUMENTADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.IZVORDOKUMENTASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.IZVORDOKUMENTASet.IZVORDOKUMENTA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        IZVORDOKUMENTADataSet.IZVORDOKUMENTARow current = (IZVORDOKUMENTADataSet.IZVORDOKUMENTARow) enumerator.Current;
                        this.rowIZVORDOKUMENTA = current;
                        if (Helpers.IsRowChanged(this.rowIZVORDOKUMENTA))
                        {
                            this.ReadRowIzvordokumenta();
                            if (this.rowIZVORDOKUMENTA.RowState == DataRowState.Added)
                            {
                                this.InsertIzvordokumenta();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateIzvordokumenta();
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

        private void UpdateIzvordokumenta()
        {
            this.CheckOptimisticConcurrencyIzvordokumenta();
            this.AfterConfirmIzvordokumenta();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [IZVORDOKUMENTA] SET [NAZIVIZVORA]=@NAZIVIZVORA  WHERE [SIFRAIZVORA] = @SIFRAIZVORA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVIZVORA", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAIZVORA", DbType.String, 3));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIZVORDOKUMENTA["NAZIVIZVORA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowIZVORDOKUMENTA["SIFRAIZVORA"]));
            command.ExecuteStmt();
            this.OnIZVORDOKUMENTAUpdated(new IZVORDOKUMENTAEventArgs(this.rowIZVORDOKUMENTA, StatementType.Update));
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
        public class IZVORDOKUMENTADataChangedException : DataChangedException
        {
            public IZVORDOKUMENTADataChangedException()
            {
            }

            public IZVORDOKUMENTADataChangedException(string message) : base(message)
            {
            }

            protected IZVORDOKUMENTADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IZVORDOKUMENTADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class IZVORDOKUMENTADataLockedException : DataLockedException
        {
            public IZVORDOKUMENTADataLockedException()
            {
            }

            public IZVORDOKUMENTADataLockedException(string message) : base(message)
            {
            }

            protected IZVORDOKUMENTADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IZVORDOKUMENTADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class IZVORDOKUMENTADuplicateKeyException : DuplicateKeyException
        {
            public IZVORDOKUMENTADuplicateKeyException()
            {
            }

            public IZVORDOKUMENTADuplicateKeyException(string message) : base(message)
            {
            }

            protected IZVORDOKUMENTADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IZVORDOKUMENTADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class IZVORDOKUMENTAEventArgs : EventArgs
        {
            private IZVORDOKUMENTADataSet.IZVORDOKUMENTARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public IZVORDOKUMENTAEventArgs(IZVORDOKUMENTADataSet.IZVORDOKUMENTARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public IZVORDOKUMENTADataSet.IZVORDOKUMENTARow Row
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
        public class IZVORDOKUMENTANotFoundException : DataNotFoundException
        {
            public IZVORDOKUMENTANotFoundException()
            {
            }

            public IZVORDOKUMENTANotFoundException(string message) : base(message)
            {
            }

            protected IZVORDOKUMENTANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IZVORDOKUMENTANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void IZVORDOKUMENTAUpdateEventHandler(object sender, IZVORDOKUMENTADataAdapter.IZVORDOKUMENTAEventArgs e);

        [Serializable]
        public class KORISNIKLevel1InvalidDeleteException : InvalidDeleteException
        {
            public KORISNIKLevel1InvalidDeleteException()
            {
            }

            public KORISNIKLevel1InvalidDeleteException(string message) : base(message)
            {
            }

            protected KORISNIKLevel1InvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KORISNIKLevel1InvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

