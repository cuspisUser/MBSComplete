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

    public class KREDITORDataAdapter : IDataAdapter, IKREDITORDataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private ReadWriteCommand cmKREDITORSelect1;
        private ReadWriteCommand cmKREDITORSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private IDataReader KREDITORSelect1;
        private IDataReader KREDITORSelect4;
        private KREDITORDataSet KREDITORSet;
        private object m__NAZIVKREDITOROriginal;
        private object m__PRIMATELJKREDITOR1Original;
        private object m__PRIMATELJKREDITOR2Original;
        private object m__PRIMATELJKREDITOR3Original;
        private object m__VBDIKREDITOROriginal;
        private object m__ZRNKREDITOROriginal;
        private readonly string m_SelectString43 = "TM1.[IDKREDITOR], TM1.[NAZIVKREDITOR], TM1.[VBDIKREDITOR], TM1.[ZRNKREDITOR], TM1.[PRIMATELJKREDITOR1], TM1.[PRIMATELJKREDITOR2], TM1.[PRIMATELJKREDITOR3]";
        private string m_WhereString;
        private short RcdFound43;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private KREDITORDataSet.KREDITORRow rowKREDITOR;
        private string scmdbuf;
        private StatementType sMode43;

        public event KREDITORUpdateEventHandler KREDITORUpdated;

        public event KREDITORUpdateEventHandler KREDITORUpdating;

        private void AddRowKreditor()
        {
            this.KREDITORSet.KREDITOR.AddKREDITORRow(this.rowKREDITOR);
        }

        private void AfterConfirmKreditor()
        {
            this.OnKREDITORUpdating(new KREDITOREventArgs(this.rowKREDITOR, this.Gx_mode));
        }

        private void CheckDeleteErrorsKreditor()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK], [ZADKREDITIIDKREDITOR], [DATUMUGOVORA] FROM [RADNIKKrediti] WITH (NOLOCK) WHERE [ZADKREDITIIDKREDITOR] = @IDKREDITOR ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKREDITOR", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["IDKREDITOR"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new RADNIKKreditiInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Krediti radnika" }));
            }
            reader2.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDOBRACUN], [IDRADNIK], [IDKREDITOR], [DATUMUGOVORA] FROM [OBRACUNKrediti] WITH (NOLOCK) WHERE [IDKREDITOR] = @IDKREDITOR ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKREDITOR", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["IDKREDITOR"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new OBRACUNKreditiInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "ObracunKrediti" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyKreditor()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKREDITOR], [NAZIVKREDITOR], [VBDIKREDITOR], [ZRNKREDITOR], [PRIMATELJKREDITOR1], [PRIMATELJKREDITOR2], [PRIMATELJKREDITOR3] FROM [KREDITOR] WITH (UPDLOCK) WHERE [IDKREDITOR] = @IDKREDITOR ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKREDITOR", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["IDKREDITOR"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new KREDITORDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("KREDITOR") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVKREDITOROriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__VBDIKREDITOROriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZRNKREDITOROriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRIMATELJKREDITOR1Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRIMATELJKREDITOR2Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))
                {
                    this._Condition = true;
                }
                if (this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRIMATELJKREDITOR3Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6))))
                {
                    reader.Close();
                    throw new KREDITORDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("KREDITOR") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowKreditor()
        {
            this.rowKREDITOR = this.KREDITORSet.KREDITOR.NewKREDITORRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyKreditor();
            this.AfterConfirmKreditor();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [KREDITOR]  WHERE [IDKREDITOR] = @IDKREDITOR", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKREDITOR", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["IDKREDITOR"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsKreditor();
            }
            this.OnKREDITORUpdated(new KREDITOREventArgs(this.rowKREDITOR, StatementType.Delete));
            this.rowKREDITOR.Delete();
            this.sMode43 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
        }

        public virtual int Fill(KREDITORDataSet dataSet)
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
                    this.KREDITORSet = dataSet;
                    this.LoadChildKreditor(0, -1);
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
            this.KREDITORSet = (KREDITORDataSet) dataSet;
            if (this.KREDITORSet != null)
            {
                return this.Fill(this.KREDITORSet);
            }
            this.KREDITORSet = new KREDITORDataSet();
            this.Fill(this.KREDITORSet);
            dataSet.Merge(this.KREDITORSet);
            return 0;
        }

        public virtual int Fill(KREDITORDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDKREDITOR"]));
        }

        public virtual int Fill(KREDITORDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDKREDITOR"]));
        }

        public virtual int Fill(KREDITORDataSet dataSet, int iDKREDITOR)
        {
            if (!this.FillByIDKREDITOR(dataSet, iDKREDITOR))
            {
                throw new KREDITORNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KREDITOR") }));
            }
            return 0;
        }

        public virtual bool FillByIDKREDITOR(KREDITORDataSet dataSet, int iDKREDITOR)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.KREDITORSet = dataSet;
            this.rowKREDITOR = this.KREDITORSet.KREDITOR.NewKREDITORRow();
            this.rowKREDITOR.IDKREDITOR = iDKREDITOR;
            try
            {
                this.LoadByIDKREDITOR(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound43 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(KREDITORDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.KREDITORSet = dataSet;
            try
            {
                this.LoadChildKreditor(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKREDITOR], [NAZIVKREDITOR], [VBDIKREDITOR], [ZRNKREDITOR], [PRIMATELJKREDITOR1], [PRIMATELJKREDITOR2], [PRIMATELJKREDITOR3] FROM [KREDITOR] WITH (NOLOCK) WHERE [IDKREDITOR] = @IDKREDITOR ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKREDITOR", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["IDKREDITOR"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound43 = 1;
                this.rowKREDITOR["IDKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowKREDITOR["NAZIVKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowKREDITOR["VBDIKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowKREDITOR["ZRNKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowKREDITOR["PRIMATELJKREDITOR1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowKREDITOR["PRIMATELJKREDITOR2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowKREDITOR["PRIMATELJKREDITOR3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.sMode43 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode43;
            }
            else
            {
                this.RcdFound43 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDKREDITOR";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmKREDITORSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [KREDITOR] WITH (NOLOCK) ", false);
            this.KREDITORSelect1 = this.cmKREDITORSelect1.FetchData();
            if (this.KREDITORSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.KREDITORSelect1.GetInt32(0);
            }
            this.KREDITORSelect1.Close();
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
            this.RcdFound43 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVKREDITOROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__VBDIKREDITOROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZRNKREDITOROriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIMATELJKREDITOR1Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIMATELJKREDITOR2Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIMATELJKREDITOR3Original = RuntimeHelpers.GetObjectValue(new object());
            this._Condition = false;
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.KREDITORSet = new KREDITORDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertKreditor()
        {
            this.CheckOptimisticConcurrencyKreditor();
            this.AfterConfirmKreditor();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [KREDITOR] ([IDKREDITOR], [NAZIVKREDITOR], [VBDIKREDITOR], [ZRNKREDITOR], [PRIMATELJKREDITOR1], [PRIMATELJKREDITOR2], [PRIMATELJKREDITOR3]) VALUES (@IDKREDITOR, @NAZIVKREDITOR, @VBDIKREDITOR, @ZRNKREDITOR, @PRIMATELJKREDITOR1, @PRIMATELJKREDITOR2, @PRIMATELJKREDITOR3)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKREDITOR", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVKREDITOR", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIKREDITOR", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNKREDITOR", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKREDITOR1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKREDITOR2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKREDITOR3", DbType.String, 20));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["IDKREDITOR"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["NAZIVKREDITOR"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["VBDIKREDITOR"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["ZRNKREDITOR"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["PRIMATELJKREDITOR1"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["PRIMATELJKREDITOR2"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["PRIMATELJKREDITOR3"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new KREDITORDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnKREDITORUpdated(new KREDITOREventArgs(this.rowKREDITOR, StatementType.Insert));
        }

        private void LoadByIDKREDITOR(int startRow, int maxRows)
        {
            bool enforceConstraints = this.KREDITORSet.EnforceConstraints;
            this.KREDITORSet.KREDITOR.BeginLoadData();
            this.ScanByIDKREDITOR(startRow, maxRows);
            this.KREDITORSet.KREDITOR.EndLoadData();
            this.KREDITORSet.EnforceConstraints = enforceConstraints;
            if (this.KREDITORSet.KREDITOR.Count > 0)
            {
                this.rowKREDITOR = this.KREDITORSet.KREDITOR[this.KREDITORSet.KREDITOR.Count - 1];
            }
        }

        private void LoadChildKreditor(int startRow, int maxRows)
        {
            this.CreateNewRowKreditor();
            bool enforceConstraints = this.KREDITORSet.EnforceConstraints;
            this.KREDITORSet.KREDITOR.BeginLoadData();
            this.ScanStartKreditor(startRow, maxRows);
            this.KREDITORSet.KREDITOR.EndLoadData();
            this.KREDITORSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataKreditor(int maxRows)
        {
            int num = 0;
            if (this.RcdFound43 != 0)
            {
                this.ScanLoadKreditor();
                while ((this.RcdFound43 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowKreditor();
                    this.CreateNewRowKreditor();
                    this.ScanNextKreditor();
                }
            }
            if (num > 0)
            {
                this.RcdFound43 = 1;
            }
            this.ScanEndKreditor();
            if (this.KREDITORSet.KREDITOR.Count > 0)
            {
                this.rowKREDITOR = this.KREDITORSet.KREDITOR[this.KREDITORSet.KREDITOR.Count - 1];
            }
        }

        private void LoadRowKreditor()
        {
            this.AddRowKreditor();
        }

        private void OnKREDITORUpdated(KREDITOREventArgs e)
        {
            if (this.KREDITORUpdated != null)
            {
                KREDITORUpdateEventHandler kREDITORUpdatedEvent = this.KREDITORUpdated;
                if (kREDITORUpdatedEvent != null)
                {
                    kREDITORUpdatedEvent(this, e);
                }
            }
        }

        private void OnKREDITORUpdating(KREDITOREventArgs e)
        {
            if (this.KREDITORUpdating != null)
            {
                KREDITORUpdateEventHandler kREDITORUpdatingEvent = this.KREDITORUpdating;
                if (kREDITORUpdatingEvent != null)
                {
                    kREDITORUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowKreditor()
        {
            this.Gx_mode = Mode.FromRowState(this.rowKREDITOR.RowState);
            if (this.rowKREDITOR.RowState != DataRowState.Added)
            {
                this.m__NAZIVKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowKREDITOR["NAZIVKREDITOR", DataRowVersion.Original]);
                this.m__VBDIKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowKREDITOR["VBDIKREDITOR", DataRowVersion.Original]);
                this.m__ZRNKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowKREDITOR["ZRNKREDITOR", DataRowVersion.Original]);
                this.m__PRIMATELJKREDITOR1Original = RuntimeHelpers.GetObjectValue(this.rowKREDITOR["PRIMATELJKREDITOR1", DataRowVersion.Original]);
                this.m__PRIMATELJKREDITOR2Original = RuntimeHelpers.GetObjectValue(this.rowKREDITOR["PRIMATELJKREDITOR2", DataRowVersion.Original]);
                this.m__PRIMATELJKREDITOR3Original = RuntimeHelpers.GetObjectValue(this.rowKREDITOR["PRIMATELJKREDITOR3", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowKREDITOR["NAZIVKREDITOR"]);
                this.m__VBDIKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowKREDITOR["VBDIKREDITOR"]);
                this.m__ZRNKREDITOROriginal = RuntimeHelpers.GetObjectValue(this.rowKREDITOR["ZRNKREDITOR"]);
                this.m__PRIMATELJKREDITOR1Original = RuntimeHelpers.GetObjectValue(this.rowKREDITOR["PRIMATELJKREDITOR1"]);
                this.m__PRIMATELJKREDITOR2Original = RuntimeHelpers.GetObjectValue(this.rowKREDITOR["PRIMATELJKREDITOR2"]);
                this.m__PRIMATELJKREDITOR3Original = RuntimeHelpers.GetObjectValue(this.rowKREDITOR["PRIMATELJKREDITOR3"]);
            }
            this._Gxremove = this.rowKREDITOR.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowKREDITOR = (KREDITORDataSet.KREDITORRow) DataSetUtil.CloneOriginalDataRow(this.rowKREDITOR);
            }
        }

        private void ScanByIDKREDITOR(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDKREDITOR] = @IDKREDITOR";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString43 + "  FROM [KREDITOR] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDKREDITOR]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString43, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDKREDITOR] ) AS DK_PAGENUM   FROM [KREDITOR] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString43 + " FROM [KREDITOR] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDKREDITOR] ";
            }
            this.cmKREDITORSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmKREDITORSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmKREDITORSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKREDITOR", DbType.Int32));
            }
            this.cmKREDITORSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["IDKREDITOR"]));
            this.KREDITORSelect4 = this.cmKREDITORSelect4.FetchData();
            this.RcdFound43 = 0;
            this.ScanLoadKreditor();
            this.LoadDataKreditor(maxRows);
        }

        private void ScanEndKreditor()
        {
            this.KREDITORSelect4.Close();
        }

        private void ScanLoadKreditor()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmKREDITORSelect4.HasMoreRows)
            {
                this.RcdFound43 = 1;
                this.rowKREDITOR["IDKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.KREDITORSelect4, 0));
                this.rowKREDITOR["NAZIVKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KREDITORSelect4, 1));
                this.rowKREDITOR["VBDIKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KREDITORSelect4, 2));
                this.rowKREDITOR["ZRNKREDITOR"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KREDITORSelect4, 3));
                this.rowKREDITOR["PRIMATELJKREDITOR1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KREDITORSelect4, 4));
                this.rowKREDITOR["PRIMATELJKREDITOR2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KREDITORSelect4, 5));
                this.rowKREDITOR["PRIMATELJKREDITOR3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KREDITORSelect4, 6));
            }
        }

        private void ScanNextKreditor()
        {
            this.cmKREDITORSelect4.HasMoreRows = this.KREDITORSelect4.Read();
            this.RcdFound43 = 0;
            this.ScanLoadKreditor();
        }

        private void ScanStartKreditor(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString43 + "  FROM [KREDITOR] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDKREDITOR]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString43, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDKREDITOR] ) AS DK_PAGENUM   FROM [KREDITOR] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString43 + " FROM [KREDITOR] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDKREDITOR] ";
            }
            this.cmKREDITORSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.KREDITORSelect4 = this.cmKREDITORSelect4.FetchData();
            this.RcdFound43 = 0;
            this.ScanLoadKreditor();
            this.LoadDataKreditor(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.KREDITORSet = (KREDITORDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.KREDITORSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.KREDITORSet.KREDITOR.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        KREDITORDataSet.KREDITORRow current = (KREDITORDataSet.KREDITORRow) enumerator.Current;
                        this.rowKREDITOR = current;
                        if (Helpers.IsRowChanged(this.rowKREDITOR))
                        {
                            this.ReadRowKreditor();
                            if (this.rowKREDITOR.RowState == DataRowState.Added)
                            {
                                this.InsertKreditor();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateKreditor();
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

        private void UpdateKreditor()
        {
            this.CheckOptimisticConcurrencyKreditor();
            this.AfterConfirmKreditor();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [KREDITOR] SET [NAZIVKREDITOR]=@NAZIVKREDITOR, [VBDIKREDITOR]=@VBDIKREDITOR, [ZRNKREDITOR]=@ZRNKREDITOR, [PRIMATELJKREDITOR1]=@PRIMATELJKREDITOR1, [PRIMATELJKREDITOR2]=@PRIMATELJKREDITOR2, [PRIMATELJKREDITOR3]=@PRIMATELJKREDITOR3  WHERE [IDKREDITOR] = @IDKREDITOR", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVKREDITOR", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIKREDITOR", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNKREDITOR", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKREDITOR1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKREDITOR2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJKREDITOR3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKREDITOR", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["NAZIVKREDITOR"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["VBDIKREDITOR"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["ZRNKREDITOR"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["PRIMATELJKREDITOR1"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["PRIMATELJKREDITOR2"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["PRIMATELJKREDITOR3"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowKREDITOR["IDKREDITOR"]));
            command.ExecuteStmt();
            new kreditorupdateredundancy(ref this.dsDefault).execute(this.rowKREDITOR.IDKREDITOR);
            this.OnKREDITORUpdated(new KREDITOREventArgs(this.rowKREDITOR, StatementType.Update));
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
        public class KREDITORDataChangedException : DataChangedException
        {
            public KREDITORDataChangedException()
            {
            }

            public KREDITORDataChangedException(string message) : base(message)
            {
            }

            protected KREDITORDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KREDITORDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class KREDITORDataLockedException : DataLockedException
        {
            public KREDITORDataLockedException()
            {
            }

            public KREDITORDataLockedException(string message) : base(message)
            {
            }

            protected KREDITORDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KREDITORDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class KREDITORDuplicateKeyException : DuplicateKeyException
        {
            public KREDITORDuplicateKeyException()
            {
            }

            public KREDITORDuplicateKeyException(string message) : base(message)
            {
            }

            protected KREDITORDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KREDITORDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class KREDITOREventArgs : EventArgs
        {
            private KREDITORDataSet.KREDITORRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public KREDITOREventArgs(KREDITORDataSet.KREDITORRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public KREDITORDataSet.KREDITORRow Row
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
        public class KREDITORNotFoundException : DataNotFoundException
        {
            public KREDITORNotFoundException()
            {
            }

            public KREDITORNotFoundException(string message) : base(message)
            {
            }

            protected KREDITORNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KREDITORNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void KREDITORUpdateEventHandler(object sender, KREDITORDataAdapter.KREDITOREventArgs e);

        [Serializable]
        public class OBRACUNKreditiInvalidDeleteException : InvalidDeleteException
        {
            public OBRACUNKreditiInvalidDeleteException()
            {
            }

            public OBRACUNKreditiInvalidDeleteException(string message) : base(message)
            {
            }

            protected OBRACUNKreditiInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNKreditiInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKKreditiInvalidDeleteException : InvalidDeleteException
        {
            public RADNIKKreditiInvalidDeleteException()
            {
            }

            public RADNIKKreditiInvalidDeleteException(string message) : base(message)
            {
            }

            protected RADNIKKreditiInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKKreditiInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

