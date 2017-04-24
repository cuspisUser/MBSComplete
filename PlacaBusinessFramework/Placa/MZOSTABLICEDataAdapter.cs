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

    public class MZOSTABLICEDataAdapter : IDataAdapter, IMZOSTABLICEDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmMZOSTABLICESelect1;
        private ReadWriteCommand cmMZOSTABLICESelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__OPISMZOSTABLICEOriginal;
        private readonly string m_SelectString134 = "TM1.[IDMZOSTABLICE], TM1.[OPISMZOSTABLICE]";
        private string m_WhereString;
        private IDataReader MZOSTABLICESelect1;
        private IDataReader MZOSTABLICESelect4;
        private MZOSTABLICEDataSet MZOSTABLICESet;
        private short RcdFound134;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private MZOSTABLICEDataSet.MZOSTABLICERow rowMZOSTABLICE;
        private string scmdbuf;
        private StatementType sMode134;

        public event MZOSTABLICEUpdateEventHandler MZOSTABLICEUpdated;

        public event MZOSTABLICEUpdateEventHandler MZOSTABLICEUpdating;

        private void AddRowMzostablice()
        {
            this.MZOSTABLICESet.MZOSTABLICE.AddMZOSTABLICERow(this.rowMZOSTABLICE);
        }

        private void AfterConfirmMzostablice()
        {
            this.OnMZOSTABLICEUpdating(new MZOSTABLICEEventArgs(this.rowMZOSTABLICE, this.Gx_mode));
        }

        private void CheckDeleteErrorsMzostablice()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDGRUPEKOEF], [IDELEMENT] FROM [GRUPEKOEFLevel1] WITH (NOLOCK) WHERE [IDMZOSTABLICE] = @IDMZOSTABLICE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMZOSTABLICE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMZOSTABLICE["IDMZOSTABLICE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new GRUPEKOEFLevel1InvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Level1" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyMzostablice()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDMZOSTABLICE], [OPISMZOSTABLICE] FROM [MZOSTABLICE] WITH (UPDLOCK) WHERE [IDMZOSTABLICE] = @IDMZOSTABLICE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMZOSTABLICE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMZOSTABLICE["IDMZOSTABLICE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new MZOSTABLICEDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("MZOSTABLICE") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPISMZOSTABLICEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new MZOSTABLICEDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("MZOSTABLICE") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowMzostablice()
        {
            this.rowMZOSTABLICE = this.MZOSTABLICESet.MZOSTABLICE.NewMZOSTABLICERow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyMzostablice();
            this.AfterConfirmMzostablice();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [MZOSTABLICE]  WHERE [IDMZOSTABLICE] = @IDMZOSTABLICE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMZOSTABLICE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMZOSTABLICE["IDMZOSTABLICE"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsMzostablice();
            }
            this.OnMZOSTABLICEUpdated(new MZOSTABLICEEventArgs(this.rowMZOSTABLICE, StatementType.Delete));
            this.rowMZOSTABLICE.Delete();
            this.sMode134 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode134;
        }

        public virtual int Fill(MZOSTABLICEDataSet dataSet)
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
                    this.MZOSTABLICESet = dataSet;
                    this.LoadChildMzostablice(0, -1);
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
            this.MZOSTABLICESet = (MZOSTABLICEDataSet) dataSet;
            if (this.MZOSTABLICESet != null)
            {
                return this.Fill(this.MZOSTABLICESet);
            }
            this.MZOSTABLICESet = new MZOSTABLICEDataSet();
            this.Fill(this.MZOSTABLICESet);
            dataSet.Merge(this.MZOSTABLICESet);
            return 0;
        }

        public virtual int Fill(MZOSTABLICEDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDMZOSTABLICE"]));
        }

        public virtual int Fill(MZOSTABLICEDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDMZOSTABLICE"]));
        }

        public virtual int Fill(MZOSTABLICEDataSet dataSet, int iDMZOSTABLICE)
        {
            if (!this.FillByIDMZOSTABLICE(dataSet, iDMZOSTABLICE))
            {
                throw new MZOSTABLICENotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("MZOSTABLICE") }));
            }
            return 0;
        }

        public virtual bool FillByIDMZOSTABLICE(MZOSTABLICEDataSet dataSet, int iDMZOSTABLICE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.MZOSTABLICESet = dataSet;
            this.rowMZOSTABLICE = this.MZOSTABLICESet.MZOSTABLICE.NewMZOSTABLICERow();
            this.rowMZOSTABLICE.IDMZOSTABLICE = iDMZOSTABLICE;
            try
            {
                this.LoadByIDMZOSTABLICE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound134 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(MZOSTABLICEDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.MZOSTABLICESet = dataSet;
            try
            {
                this.LoadChildMzostablice(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDMZOSTABLICE], [OPISMZOSTABLICE] FROM [MZOSTABLICE] WITH (NOLOCK) WHERE [IDMZOSTABLICE] = @IDMZOSTABLICE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMZOSTABLICE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMZOSTABLICE["IDMZOSTABLICE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound134 = 1;
                this.rowMZOSTABLICE["IDMZOSTABLICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowMZOSTABLICE["OPISMZOSTABLICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode134 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode134;
            }
            else
            {
                this.RcdFound134 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDMZOSTABLICE";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmMZOSTABLICESelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [MZOSTABLICE] WITH (NOLOCK) ", false);
            this.MZOSTABLICESelect1 = this.cmMZOSTABLICESelect1.FetchData();
            if (this.MZOSTABLICESelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.MZOSTABLICESelect1.GetInt32(0);
            }
            this.MZOSTABLICESelect1.Close();
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
            this.RcdFound134 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__OPISMZOSTABLICEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.MZOSTABLICESet = new MZOSTABLICEDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertMzostablice()
        {
            this.CheckOptimisticConcurrencyMzostablice();
            this.AfterConfirmMzostablice();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [MZOSTABLICE] ([IDMZOSTABLICE], [OPISMZOSTABLICE]) VALUES (@IDMZOSTABLICE, @OPISMZOSTABLICE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMZOSTABLICE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISMZOSTABLICE", DbType.String, 20));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMZOSTABLICE["IDMZOSTABLICE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowMZOSTABLICE["OPISMZOSTABLICE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new MZOSTABLICEDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnMZOSTABLICEUpdated(new MZOSTABLICEEventArgs(this.rowMZOSTABLICE, StatementType.Insert));
        }

        private void LoadByIDMZOSTABLICE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.MZOSTABLICESet.EnforceConstraints;
            this.MZOSTABLICESet.MZOSTABLICE.BeginLoadData();
            this.ScanByIDMZOSTABLICE(startRow, maxRows);
            this.MZOSTABLICESet.MZOSTABLICE.EndLoadData();
            this.MZOSTABLICESet.EnforceConstraints = enforceConstraints;
            if (this.MZOSTABLICESet.MZOSTABLICE.Count > 0)
            {
                this.rowMZOSTABLICE = this.MZOSTABLICESet.MZOSTABLICE[this.MZOSTABLICESet.MZOSTABLICE.Count - 1];
            }
        }

        private void LoadChildMzostablice(int startRow, int maxRows)
        {
            this.CreateNewRowMzostablice();
            bool enforceConstraints = this.MZOSTABLICESet.EnforceConstraints;
            this.MZOSTABLICESet.MZOSTABLICE.BeginLoadData();
            this.ScanStartMzostablice(startRow, maxRows);
            this.MZOSTABLICESet.MZOSTABLICE.EndLoadData();
            this.MZOSTABLICESet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataMzostablice(int maxRows)
        {
            int num = 0;
            if (this.RcdFound134 != 0)
            {
                this.ScanLoadMzostablice();
                while ((this.RcdFound134 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowMzostablice();
                    this.CreateNewRowMzostablice();
                    this.ScanNextMzostablice();
                }
            }
            if (num > 0)
            {
                this.RcdFound134 = 1;
            }
            this.ScanEndMzostablice();
            if (this.MZOSTABLICESet.MZOSTABLICE.Count > 0)
            {
                this.rowMZOSTABLICE = this.MZOSTABLICESet.MZOSTABLICE[this.MZOSTABLICESet.MZOSTABLICE.Count - 1];
            }
        }

        private void LoadRowMzostablice()
        {
            this.AddRowMzostablice();
        }

        private void OnMZOSTABLICEUpdated(MZOSTABLICEEventArgs e)
        {
            if (this.MZOSTABLICEUpdated != null)
            {
                MZOSTABLICEUpdateEventHandler mZOSTABLICEUpdatedEvent = this.MZOSTABLICEUpdated;
                if (mZOSTABLICEUpdatedEvent != null)
                {
                    mZOSTABLICEUpdatedEvent(this, e);
                }
            }
        }

        private void OnMZOSTABLICEUpdating(MZOSTABLICEEventArgs e)
        {
            if (this.MZOSTABLICEUpdating != null)
            {
                MZOSTABLICEUpdateEventHandler mZOSTABLICEUpdatingEvent = this.MZOSTABLICEUpdating;
                if (mZOSTABLICEUpdatingEvent != null)
                {
                    mZOSTABLICEUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowMzostablice()
        {
            this.Gx_mode = Mode.FromRowState(this.rowMZOSTABLICE.RowState);
            if (this.rowMZOSTABLICE.RowState != DataRowState.Added)
            {
                this.m__OPISMZOSTABLICEOriginal = RuntimeHelpers.GetObjectValue(this.rowMZOSTABLICE["OPISMZOSTABLICE", DataRowVersion.Original]);
            }
            else
            {
                this.m__OPISMZOSTABLICEOriginal = RuntimeHelpers.GetObjectValue(this.rowMZOSTABLICE["OPISMZOSTABLICE"]);
            }
            this._Gxremove = this.rowMZOSTABLICE.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowMZOSTABLICE = (MZOSTABLICEDataSet.MZOSTABLICERow) DataSetUtil.CloneOriginalDataRow(this.rowMZOSTABLICE);
            }
        }

        private void ScanByIDMZOSTABLICE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDMZOSTABLICE] = @IDMZOSTABLICE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString134 + "  FROM [MZOSTABLICE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDMZOSTABLICE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString134, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDMZOSTABLICE] ) AS DK_PAGENUM   FROM [MZOSTABLICE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString134 + " FROM [MZOSTABLICE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDMZOSTABLICE] ";
            }
            this.cmMZOSTABLICESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmMZOSTABLICESelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmMZOSTABLICESelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMZOSTABLICE", DbType.Int32));
            }
            this.cmMZOSTABLICESelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMZOSTABLICE["IDMZOSTABLICE"]));
            this.MZOSTABLICESelect4 = this.cmMZOSTABLICESelect4.FetchData();
            this.RcdFound134 = 0;
            this.ScanLoadMzostablice();
            this.LoadDataMzostablice(maxRows);
        }

        private void ScanEndMzostablice()
        {
            this.MZOSTABLICESelect4.Close();
        }

        private void ScanLoadMzostablice()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmMZOSTABLICESelect4.HasMoreRows)
            {
                this.RcdFound134 = 1;
                this.rowMZOSTABLICE["IDMZOSTABLICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.MZOSTABLICESelect4, 0));
                this.rowMZOSTABLICE["OPISMZOSTABLICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.MZOSTABLICESelect4, 1));
            }
        }

        private void ScanNextMzostablice()
        {
            this.cmMZOSTABLICESelect4.HasMoreRows = this.MZOSTABLICESelect4.Read();
            this.RcdFound134 = 0;
            this.ScanLoadMzostablice();
        }

        private void ScanStartMzostablice(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString134 + "  FROM [MZOSTABLICE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDMZOSTABLICE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString134, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDMZOSTABLICE] ) AS DK_PAGENUM   FROM [MZOSTABLICE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString134 + " FROM [MZOSTABLICE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDMZOSTABLICE] ";
            }
            this.cmMZOSTABLICESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.MZOSTABLICESelect4 = this.cmMZOSTABLICESelect4.FetchData();
            this.RcdFound134 = 0;
            this.ScanLoadMzostablice();
            this.LoadDataMzostablice(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.MZOSTABLICESet = (MZOSTABLICEDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.MZOSTABLICESet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.MZOSTABLICESet.MZOSTABLICE.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        MZOSTABLICEDataSet.MZOSTABLICERow current = (MZOSTABLICEDataSet.MZOSTABLICERow) enumerator.Current;
                        this.rowMZOSTABLICE = current;
                        if (Helpers.IsRowChanged(this.rowMZOSTABLICE))
                        {
                            this.ReadRowMzostablice();
                            if (this.rowMZOSTABLICE.RowState == DataRowState.Added)
                            {
                                this.InsertMzostablice();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateMzostablice();
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

        private void UpdateMzostablice()
        {
            this.CheckOptimisticConcurrencyMzostablice();
            this.AfterConfirmMzostablice();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [MZOSTABLICE] SET [OPISMZOSTABLICE]=@OPISMZOSTABLICE  WHERE [IDMZOSTABLICE] = @IDMZOSTABLICE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISMZOSTABLICE", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMZOSTABLICE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMZOSTABLICE["OPISMZOSTABLICE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowMZOSTABLICE["IDMZOSTABLICE"]));
            command.ExecuteStmt();
            this.OnMZOSTABLICEUpdated(new MZOSTABLICEEventArgs(this.rowMZOSTABLICE, StatementType.Update));
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
        public class GRUPEKOEFLevel1InvalidDeleteException : InvalidDeleteException
        {
            public GRUPEKOEFLevel1InvalidDeleteException()
            {
            }

            public GRUPEKOEFLevel1InvalidDeleteException(string message) : base(message)
            {
            }

            protected GRUPEKOEFLevel1InvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GRUPEKOEFLevel1InvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class MZOSTABLICEDataChangedException : DataChangedException
        {
            public MZOSTABLICEDataChangedException()
            {
            }

            public MZOSTABLICEDataChangedException(string message) : base(message)
            {
            }

            protected MZOSTABLICEDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public MZOSTABLICEDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class MZOSTABLICEDataLockedException : DataLockedException
        {
            public MZOSTABLICEDataLockedException()
            {
            }

            public MZOSTABLICEDataLockedException(string message) : base(message)
            {
            }

            protected MZOSTABLICEDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public MZOSTABLICEDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class MZOSTABLICEDuplicateKeyException : DuplicateKeyException
        {
            public MZOSTABLICEDuplicateKeyException()
            {
            }

            public MZOSTABLICEDuplicateKeyException(string message) : base(message)
            {
            }

            protected MZOSTABLICEDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public MZOSTABLICEDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class MZOSTABLICEEventArgs : EventArgs
        {
            private MZOSTABLICEDataSet.MZOSTABLICERow m_dataRow;
            private System.Data.StatementType m_statementType;

            public MZOSTABLICEEventArgs(MZOSTABLICEDataSet.MZOSTABLICERow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public MZOSTABLICEDataSet.MZOSTABLICERow Row
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
        public class MZOSTABLICENotFoundException : DataNotFoundException
        {
            public MZOSTABLICENotFoundException()
            {
            }

            public MZOSTABLICENotFoundException(string message) : base(message)
            {
            }

            protected MZOSTABLICENotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public MZOSTABLICENotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void MZOSTABLICEUpdateEventHandler(object sender, MZOSTABLICEDataAdapter.MZOSTABLICEEventArgs e);
    }
}

