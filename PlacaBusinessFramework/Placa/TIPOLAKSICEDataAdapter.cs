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

    public class TIPOLAKSICEDataAdapter : IDataAdapter, ITIPOLAKSICEDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmTIPOLAKSICESelect1;
        private ReadWriteCommand cmTIPOLAKSICESelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVTIPOLAKSICEOriginal;
        private readonly string m_SelectString37 = "TM1.[IDTIPOLAKSICE], TM1.[NAZIVTIPOLAKSICE]";
        private string m_WhereString;
        private short RcdFound37;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private TIPOLAKSICEDataSet.TIPOLAKSICERow rowTIPOLAKSICE;
        private string scmdbuf;
        private StatementType sMode37;
        private IDataReader TIPOLAKSICESelect1;
        private IDataReader TIPOLAKSICESelect4;
        private TIPOLAKSICEDataSet TIPOLAKSICESet;

        public event TIPOLAKSICEUpdateEventHandler TIPOLAKSICEUpdated;

        public event TIPOLAKSICEUpdateEventHandler TIPOLAKSICEUpdating;

        private void AddRowTipolaksice()
        {
            this.TIPOLAKSICESet.TIPOLAKSICE.AddTIPOLAKSICERow(this.rowTIPOLAKSICE);
        }

        private void AfterConfirmTipolaksice()
        {
            this.OnTIPOLAKSICEUpdating(new TIPOLAKSICEEventArgs(this.rowTIPOLAKSICE, this.Gx_mode));
        }

        private void CheckDeleteErrorsTipolaksice()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDOLAKSICE] FROM [OLAKSICE] WITH (NOLOCK) WHERE [IDTIPOLAKSICE] = @IDTIPOLAKSICE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPOLAKSICE["IDTIPOLAKSICE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new OLAKSICEInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "OLAKSICE" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyTipolaksice()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDTIPOLAKSICE], [NAZIVTIPOLAKSICE] FROM [TIPOLAKSICE] WITH (UPDLOCK) WHERE [IDTIPOLAKSICE] = @IDTIPOLAKSICE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPOLAKSICE["IDTIPOLAKSICE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new TIPOLAKSICEDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("TIPOLAKSICE") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVTIPOLAKSICEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new TIPOLAKSICEDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("TIPOLAKSICE") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowTipolaksice()
        {
            this.rowTIPOLAKSICE = this.TIPOLAKSICESet.TIPOLAKSICE.NewTIPOLAKSICERow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyTipolaksice();
            this.AfterConfirmTipolaksice();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [TIPOLAKSICE]  WHERE [IDTIPOLAKSICE] = @IDTIPOLAKSICE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPOLAKSICE["IDTIPOLAKSICE"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsTipolaksice();
            }
            this.OnTIPOLAKSICEUpdated(new TIPOLAKSICEEventArgs(this.rowTIPOLAKSICE, StatementType.Delete));
            this.rowTIPOLAKSICE.Delete();
            this.sMode37 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode37;
        }

        public virtual int Fill(TIPOLAKSICEDataSet dataSet)
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
                    this.TIPOLAKSICESet = dataSet;
                    this.LoadChildTipolaksice(0, -1);
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
            this.TIPOLAKSICESet = (TIPOLAKSICEDataSet) dataSet;
            if (this.TIPOLAKSICESet != null)
            {
                return this.Fill(this.TIPOLAKSICESet);
            }
            this.TIPOLAKSICESet = new TIPOLAKSICEDataSet();
            this.Fill(this.TIPOLAKSICESet);
            dataSet.Merge(this.TIPOLAKSICESet);
            return 0;
        }

        public virtual int Fill(TIPOLAKSICEDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDTIPOLAKSICE"]));
        }

        public virtual int Fill(TIPOLAKSICEDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDTIPOLAKSICE"]));
        }

        public virtual int Fill(TIPOLAKSICEDataSet dataSet, int iDTIPOLAKSICE)
        {
            if (!this.FillByIDTIPOLAKSICE(dataSet, iDTIPOLAKSICE))
            {
                throw new TIPOLAKSICENotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("TIPOLAKSICE") }));
            }
            return 0;
        }

        public virtual bool FillByIDTIPOLAKSICE(TIPOLAKSICEDataSet dataSet, int iDTIPOLAKSICE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.TIPOLAKSICESet = dataSet;
            this.rowTIPOLAKSICE = this.TIPOLAKSICESet.TIPOLAKSICE.NewTIPOLAKSICERow();
            this.rowTIPOLAKSICE.IDTIPOLAKSICE = iDTIPOLAKSICE;
            try
            {
                this.LoadByIDTIPOLAKSICE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound37 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(TIPOLAKSICEDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.TIPOLAKSICESet = dataSet;
            try
            {
                this.LoadChildTipolaksice(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDTIPOLAKSICE], [NAZIVTIPOLAKSICE] FROM [TIPOLAKSICE] WITH (NOLOCK) WHERE [IDTIPOLAKSICE] = @IDTIPOLAKSICE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPOLAKSICE["IDTIPOLAKSICE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound37 = 1;
                this.rowTIPOLAKSICE["IDTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowTIPOLAKSICE["NAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode37 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode37;
            }
            else
            {
                this.RcdFound37 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDTIPOLAKSICE";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmTIPOLAKSICESelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [TIPOLAKSICE] WITH (NOLOCK) ", false);
            this.TIPOLAKSICESelect1 = this.cmTIPOLAKSICESelect1.FetchData();
            if (this.TIPOLAKSICESelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.TIPOLAKSICESelect1.GetInt32(0);
            }
            this.TIPOLAKSICESelect1.Close();
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
            this.RcdFound37 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVTIPOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.TIPOLAKSICESet = new TIPOLAKSICEDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertTipolaksice()
        {
            this.CheckOptimisticConcurrencyTipolaksice();
            this.AfterConfirmTipolaksice();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [TIPOLAKSICE] ([IDTIPOLAKSICE], [NAZIVTIPOLAKSICE]) VALUES (@IDTIPOLAKSICE, @NAZIVTIPOLAKSICE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVTIPOLAKSICE", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPOLAKSICE["IDTIPOLAKSICE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowTIPOLAKSICE["NAZIVTIPOLAKSICE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new TIPOLAKSICEDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnTIPOLAKSICEUpdated(new TIPOLAKSICEEventArgs(this.rowTIPOLAKSICE, StatementType.Insert));
        }

        private void LoadByIDTIPOLAKSICE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.TIPOLAKSICESet.EnforceConstraints;
            this.TIPOLAKSICESet.TIPOLAKSICE.BeginLoadData();
            this.ScanByIDTIPOLAKSICE(startRow, maxRows);
            this.TIPOLAKSICESet.TIPOLAKSICE.EndLoadData();
            this.TIPOLAKSICESet.EnforceConstraints = enforceConstraints;
            if (this.TIPOLAKSICESet.TIPOLAKSICE.Count > 0)
            {
                this.rowTIPOLAKSICE = this.TIPOLAKSICESet.TIPOLAKSICE[this.TIPOLAKSICESet.TIPOLAKSICE.Count - 1];
            }
        }

        private void LoadChildTipolaksice(int startRow, int maxRows)
        {
            this.CreateNewRowTipolaksice();
            bool enforceConstraints = this.TIPOLAKSICESet.EnforceConstraints;
            this.TIPOLAKSICESet.TIPOLAKSICE.BeginLoadData();
            this.ScanStartTipolaksice(startRow, maxRows);
            this.TIPOLAKSICESet.TIPOLAKSICE.EndLoadData();
            this.TIPOLAKSICESet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataTipolaksice(int maxRows)
        {
            int num = 0;
            if (this.RcdFound37 != 0)
            {
                this.ScanLoadTipolaksice();
                while ((this.RcdFound37 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowTipolaksice();
                    this.CreateNewRowTipolaksice();
                    this.ScanNextTipolaksice();
                }
            }
            if (num > 0)
            {
                this.RcdFound37 = 1;
            }
            this.ScanEndTipolaksice();
            if (this.TIPOLAKSICESet.TIPOLAKSICE.Count > 0)
            {
                this.rowTIPOLAKSICE = this.TIPOLAKSICESet.TIPOLAKSICE[this.TIPOLAKSICESet.TIPOLAKSICE.Count - 1];
            }
        }

        private void LoadRowTipolaksice()
        {
            this.AddRowTipolaksice();
        }

        private void OnTIPOLAKSICEUpdated(TIPOLAKSICEEventArgs e)
        {
            if (this.TIPOLAKSICEUpdated != null)
            {
                TIPOLAKSICEUpdateEventHandler tIPOLAKSICEUpdatedEvent = this.TIPOLAKSICEUpdated;
                if (tIPOLAKSICEUpdatedEvent != null)
                {
                    tIPOLAKSICEUpdatedEvent(this, e);
                }
            }
        }

        private void OnTIPOLAKSICEUpdating(TIPOLAKSICEEventArgs e)
        {
            if (this.TIPOLAKSICEUpdating != null)
            {
                TIPOLAKSICEUpdateEventHandler tIPOLAKSICEUpdatingEvent = this.TIPOLAKSICEUpdating;
                if (tIPOLAKSICEUpdatingEvent != null)
                {
                    tIPOLAKSICEUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowTipolaksice()
        {
            this.Gx_mode = Mode.FromRowState(this.rowTIPOLAKSICE.RowState);
            if (this.rowTIPOLAKSICE.RowState != DataRowState.Added)
            {
                this.m__NAZIVTIPOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPOLAKSICE["NAZIVTIPOLAKSICE", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVTIPOLAKSICEOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPOLAKSICE["NAZIVTIPOLAKSICE"]);
            }
            this._Gxremove = this.rowTIPOLAKSICE.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowTIPOLAKSICE = (TIPOLAKSICEDataSet.TIPOLAKSICERow) DataSetUtil.CloneOriginalDataRow(this.rowTIPOLAKSICE);
            }
        }

        private void ScanByIDTIPOLAKSICE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDTIPOLAKSICE] = @IDTIPOLAKSICE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString37 + "  FROM [TIPOLAKSICE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPOLAKSICE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString37, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDTIPOLAKSICE] ) AS DK_PAGENUM   FROM [TIPOLAKSICE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString37 + " FROM [TIPOLAKSICE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPOLAKSICE] ";
            }
            this.cmTIPOLAKSICESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmTIPOLAKSICESelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmTIPOLAKSICESelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
            }
            this.cmTIPOLAKSICESelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPOLAKSICE["IDTIPOLAKSICE"]));
            this.TIPOLAKSICESelect4 = this.cmTIPOLAKSICESelect4.FetchData();
            this.RcdFound37 = 0;
            this.ScanLoadTipolaksice();
            this.LoadDataTipolaksice(maxRows);
        }

        private void ScanEndTipolaksice()
        {
            this.TIPOLAKSICESelect4.Close();
        }

        private void ScanLoadTipolaksice()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmTIPOLAKSICESelect4.HasMoreRows)
            {
                this.RcdFound37 = 1;
                this.rowTIPOLAKSICE["IDTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.TIPOLAKSICESelect4, 0));
                this.rowTIPOLAKSICE["NAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.TIPOLAKSICESelect4, 1));
            }
        }

        private void ScanNextTipolaksice()
        {
            this.cmTIPOLAKSICESelect4.HasMoreRows = this.TIPOLAKSICESelect4.Read();
            this.RcdFound37 = 0;
            this.ScanLoadTipolaksice();
        }

        private void ScanStartTipolaksice(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString37 + "  FROM [TIPOLAKSICE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPOLAKSICE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString37, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDTIPOLAKSICE] ) AS DK_PAGENUM   FROM [TIPOLAKSICE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString37 + " FROM [TIPOLAKSICE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPOLAKSICE] ";
            }
            this.cmTIPOLAKSICESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.TIPOLAKSICESelect4 = this.cmTIPOLAKSICESelect4.FetchData();
            this.RcdFound37 = 0;
            this.ScanLoadTipolaksice();
            this.LoadDataTipolaksice(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.TIPOLAKSICESet = (TIPOLAKSICEDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.TIPOLAKSICESet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.TIPOLAKSICESet.TIPOLAKSICE.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        TIPOLAKSICEDataSet.TIPOLAKSICERow current = (TIPOLAKSICEDataSet.TIPOLAKSICERow) enumerator.Current;
                        this.rowTIPOLAKSICE = current;
                        if (Helpers.IsRowChanged(this.rowTIPOLAKSICE))
                        {
                            this.ReadRowTipolaksice();
                            if (this.rowTIPOLAKSICE.RowState == DataRowState.Added)
                            {
                                this.InsertTipolaksice();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateTipolaksice();
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

        private void UpdateTipolaksice()
        {
            this.CheckOptimisticConcurrencyTipolaksice();
            this.AfterConfirmTipolaksice();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [TIPOLAKSICE] SET [NAZIVTIPOLAKSICE]=@NAZIVTIPOLAKSICE  WHERE [IDTIPOLAKSICE] = @IDTIPOLAKSICE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVTIPOLAKSICE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPOLAKSICE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPOLAKSICE["NAZIVTIPOLAKSICE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowTIPOLAKSICE["IDTIPOLAKSICE"]));
            command.ExecuteStmt();
            new tipolaksiceupdateredundancy(ref this.dsDefault).execute(this.rowTIPOLAKSICE.IDTIPOLAKSICE);
            this.OnTIPOLAKSICEUpdated(new TIPOLAKSICEEventArgs(this.rowTIPOLAKSICE, StatementType.Update));
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
        public class OLAKSICEInvalidDeleteException : InvalidDeleteException
        {
            public OLAKSICEInvalidDeleteException()
            {
            }

            public OLAKSICEInvalidDeleteException(string message) : base(message)
            {
            }

            protected OLAKSICEInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OLAKSICEInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPOLAKSICEDataChangedException : DataChangedException
        {
            public TIPOLAKSICEDataChangedException()
            {
            }

            public TIPOLAKSICEDataChangedException(string message) : base(message)
            {
            }

            protected TIPOLAKSICEDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPOLAKSICEDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPOLAKSICEDataLockedException : DataLockedException
        {
            public TIPOLAKSICEDataLockedException()
            {
            }

            public TIPOLAKSICEDataLockedException(string message) : base(message)
            {
            }

            protected TIPOLAKSICEDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPOLAKSICEDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPOLAKSICEDuplicateKeyException : DuplicateKeyException
        {
            public TIPOLAKSICEDuplicateKeyException()
            {
            }

            public TIPOLAKSICEDuplicateKeyException(string message) : base(message)
            {
            }

            protected TIPOLAKSICEDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPOLAKSICEDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class TIPOLAKSICEEventArgs : EventArgs
        {
            private TIPOLAKSICEDataSet.TIPOLAKSICERow m_dataRow;
            private System.Data.StatementType m_statementType;

            public TIPOLAKSICEEventArgs(TIPOLAKSICEDataSet.TIPOLAKSICERow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public TIPOLAKSICEDataSet.TIPOLAKSICERow Row
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
        public class TIPOLAKSICENotFoundException : DataNotFoundException
        {
            public TIPOLAKSICENotFoundException()
            {
            }

            public TIPOLAKSICENotFoundException(string message) : base(message)
            {
            }

            protected TIPOLAKSICENotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPOLAKSICENotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void TIPOLAKSICEUpdateEventHandler(object sender, TIPOLAKSICEDataAdapter.TIPOLAKSICEEventArgs e);
    }
}

