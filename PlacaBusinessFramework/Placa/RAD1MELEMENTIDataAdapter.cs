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

    public class RAD1MELEMENTIDataAdapter : IDataAdapter, IRAD1MELEMENTIDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmRAD1MELEMENTISelect1;
        private ReadWriteCommand cmRAD1MELEMENTISelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__RAD1ELEMENTINAZIVOriginal;
        private readonly string m_SelectString282 = "TM1.[RAD1ELEMENTIID], TM1.[RAD1ELEMENTINAZIV]";
        private string m_WhereString;
        private IDataReader RAD1MELEMENTISelect1;
        private IDataReader RAD1MELEMENTISelect4;
        private RAD1MELEMENTIDataSet RAD1MELEMENTISet;
        private short RcdFound282;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private RAD1MELEMENTIDataSet.RAD1MELEMENTIRow rowRAD1MELEMENTI;
        private string scmdbuf;
        private StatementType sMode282;

        public event RAD1MELEMENTIUpdateEventHandler RAD1MELEMENTIUpdated;

        public event RAD1MELEMENTIUpdateEventHandler RAD1MELEMENTIUpdating;

        private void AddRowRad1melementi()
        {
            this.RAD1MELEMENTISet.RAD1MELEMENTI.AddRAD1MELEMENTIRow(this.rowRAD1MELEMENTI);
        }

        private void AfterConfirmRad1melementi()
        {
            this.OnRAD1MELEMENTIUpdating(new RAD1MELEMENTIEventArgs(this.rowRAD1MELEMENTI, this.Gx_mode));
        }

        private void CheckDeleteErrorsRad1melementi()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [RAD1ELEMENTIID], [IDELEMENT] FROM [RAD1MELEMENTIVEZA] WITH (NOLOCK) WHERE [RAD1ELEMENTIID] = @RAD1ELEMENTIID ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTIID", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTI["RAD1ELEMENTIID"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RAD1MELEMENTIVEZAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RAD1MELEMENTIVEZA" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyRad1melementi()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [RAD1ELEMENTIID], [RAD1ELEMENTINAZIV] FROM [RAD1MELEMENTI] WITH (UPDLOCK) WHERE [RAD1ELEMENTIID] = @RAD1ELEMENTIID ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTIID", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTI["RAD1ELEMENTIID"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RAD1MELEMENTIDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RAD1MELEMENTI") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__RAD1ELEMENTINAZIVOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new RAD1MELEMENTIDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RAD1MELEMENTI") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowRad1melementi()
        {
            this.rowRAD1MELEMENTI = this.RAD1MELEMENTISet.RAD1MELEMENTI.NewRAD1MELEMENTIRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRad1melementi();
            this.AfterConfirmRad1melementi();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RAD1MELEMENTI]  WHERE [RAD1ELEMENTIID] = @RAD1ELEMENTIID", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTIID", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTI["RAD1ELEMENTIID"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsRad1melementi();
            }
            this.OnRAD1MELEMENTIUpdated(new RAD1MELEMENTIEventArgs(this.rowRAD1MELEMENTI, StatementType.Delete));
            this.rowRAD1MELEMENTI.Delete();
            this.sMode282 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode282;
        }

        public virtual int Fill(RAD1MELEMENTIDataSet dataSet)
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
                    this.RAD1MELEMENTISet = dataSet;
                    this.LoadChildRad1melementi(0, -1);
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
            this.RAD1MELEMENTISet = (RAD1MELEMENTIDataSet) dataSet;
            if (this.RAD1MELEMENTISet != null)
            {
                return this.Fill(this.RAD1MELEMENTISet);
            }
            this.RAD1MELEMENTISet = new RAD1MELEMENTIDataSet();
            this.Fill(this.RAD1MELEMENTISet);
            dataSet.Merge(this.RAD1MELEMENTISet);
            return 0;
        }

        public virtual int Fill(RAD1MELEMENTIDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["RAD1ELEMENTIID"]));
        }

        public virtual int Fill(RAD1MELEMENTIDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["RAD1ELEMENTIID"]));
        }

        public virtual int Fill(RAD1MELEMENTIDataSet dataSet, int rAD1ELEMENTIID)
        {
            if (!this.FillByRAD1ELEMENTIID(dataSet, rAD1ELEMENTIID))
            {
                throw new RAD1MELEMENTINotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RAD1MELEMENTI") }));
            }
            return 0;
        }

        public virtual bool FillByRAD1ELEMENTIID(RAD1MELEMENTIDataSet dataSet, int rAD1ELEMENTIID)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1MELEMENTISet = dataSet;
            this.rowRAD1MELEMENTI = this.RAD1MELEMENTISet.RAD1MELEMENTI.NewRAD1MELEMENTIRow();
            this.rowRAD1MELEMENTI.RAD1ELEMENTIID = rAD1ELEMENTIID;
            try
            {
                this.LoadByRAD1ELEMENTIID(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound282 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(RAD1MELEMENTIDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1MELEMENTISet = dataSet;
            try
            {
                this.LoadChildRad1melementi(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [RAD1ELEMENTIID], [RAD1ELEMENTINAZIV] FROM [RAD1MELEMENTI] WITH (NOLOCK) WHERE [RAD1ELEMENTIID] = @RAD1ELEMENTIID ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTIID", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTI["RAD1ELEMENTIID"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound282 = 1;
                this.rowRAD1MELEMENTI["RAD1ELEMENTIID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowRAD1MELEMENTI["RAD1ELEMENTINAZIV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode282 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode282;
            }
            else
            {
                this.RcdFound282 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "RAD1ELEMENTIID";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1MELEMENTISelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RAD1MELEMENTI] WITH (NOLOCK) ", false);
            this.RAD1MELEMENTISelect1 = this.cmRAD1MELEMENTISelect1.FetchData();
            if (this.RAD1MELEMENTISelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RAD1MELEMENTISelect1.GetInt32(0);
            }
            this.RAD1MELEMENTISelect1.Close();
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
            this.RcdFound282 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__RAD1ELEMENTINAZIVOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.RAD1MELEMENTISet = new RAD1MELEMENTIDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertRad1melementi()
        {
            this.CheckOptimisticConcurrencyRad1melementi();
            this.AfterConfirmRad1melementi();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RAD1MELEMENTI] ([RAD1ELEMENTIID], [RAD1ELEMENTINAZIV]) VALUES (@RAD1ELEMENTIID, @RAD1ELEMENTINAZIV)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTIID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTINAZIV", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTI["RAD1ELEMENTIID"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTI["RAD1ELEMENTINAZIV"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RAD1MELEMENTIDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnRAD1MELEMENTIUpdated(new RAD1MELEMENTIEventArgs(this.rowRAD1MELEMENTI, StatementType.Insert));
        }

        private void LoadByRAD1ELEMENTIID(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RAD1MELEMENTISet.EnforceConstraints;
            this.RAD1MELEMENTISet.RAD1MELEMENTI.BeginLoadData();
            this.ScanByRAD1ELEMENTIID(startRow, maxRows);
            this.RAD1MELEMENTISet.RAD1MELEMENTI.EndLoadData();
            this.RAD1MELEMENTISet.EnforceConstraints = enforceConstraints;
            if (this.RAD1MELEMENTISet.RAD1MELEMENTI.Count > 0)
            {
                this.rowRAD1MELEMENTI = this.RAD1MELEMENTISet.RAD1MELEMENTI[this.RAD1MELEMENTISet.RAD1MELEMENTI.Count - 1];
            }
        }

        private void LoadChildRad1melementi(int startRow, int maxRows)
        {
            this.CreateNewRowRad1melementi();
            bool enforceConstraints = this.RAD1MELEMENTISet.EnforceConstraints;
            this.RAD1MELEMENTISet.RAD1MELEMENTI.BeginLoadData();
            this.ScanStartRad1melementi(startRow, maxRows);
            this.RAD1MELEMENTISet.RAD1MELEMENTI.EndLoadData();
            this.RAD1MELEMENTISet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataRad1melementi(int maxRows)
        {
            int num = 0;
            if (this.RcdFound282 != 0)
            {
                this.ScanLoadRad1melementi();
                while ((this.RcdFound282 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowRad1melementi();
                    this.CreateNewRowRad1melementi();
                    this.ScanNextRad1melementi();
                }
            }
            if (num > 0)
            {
                this.RcdFound282 = 1;
            }
            this.ScanEndRad1melementi();
            if (this.RAD1MELEMENTISet.RAD1MELEMENTI.Count > 0)
            {
                this.rowRAD1MELEMENTI = this.RAD1MELEMENTISet.RAD1MELEMENTI[this.RAD1MELEMENTISet.RAD1MELEMENTI.Count - 1];
            }
        }

        private void LoadRowRad1melementi()
        {
            this.AddRowRad1melementi();
        }

        private void OnRAD1MELEMENTIUpdated(RAD1MELEMENTIEventArgs e)
        {
            if (this.RAD1MELEMENTIUpdated != null)
            {
                RAD1MELEMENTIUpdateEventHandler handler = this.RAD1MELEMENTIUpdated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnRAD1MELEMENTIUpdating(RAD1MELEMENTIEventArgs e)
        {
            if (this.RAD1MELEMENTIUpdating != null)
            {
                RAD1MELEMENTIUpdateEventHandler handler = this.RAD1MELEMENTIUpdating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void ReadRowRad1melementi()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRAD1MELEMENTI.RowState);
            if (this.rowRAD1MELEMENTI.RowState != DataRowState.Added)
            {
                this.m__RAD1ELEMENTINAZIVOriginal = RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTI["RAD1ELEMENTINAZIV", DataRowVersion.Original]);
            }
            else
            {
                this.m__RAD1ELEMENTINAZIVOriginal = RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTI["RAD1ELEMENTINAZIV"]);
            }
            this._Gxremove = this.rowRAD1MELEMENTI.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowRAD1MELEMENTI = (RAD1MELEMENTIDataSet.RAD1MELEMENTIRow) DataSetUtil.CloneOriginalDataRow(this.rowRAD1MELEMENTI);
            }
        }

        private void ScanByRAD1ELEMENTIID(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[RAD1ELEMENTIID] = @RAD1ELEMENTIID";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString282 + "  FROM [RAD1MELEMENTI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1ELEMENTIID]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString282, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1ELEMENTIID] ) AS DK_PAGENUM   FROM [RAD1MELEMENTI] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString282 + " FROM [RAD1MELEMENTI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1ELEMENTIID] ";
            }
            this.cmRAD1MELEMENTISelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRAD1MELEMENTISelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1MELEMENTISelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTIID", DbType.Int32));
            }
            this.cmRAD1MELEMENTISelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTI["RAD1ELEMENTIID"]));
            this.RAD1MELEMENTISelect4 = this.cmRAD1MELEMENTISelect4.FetchData();
            this.RcdFound282 = 0;
            this.ScanLoadRad1melementi();
            this.LoadDataRad1melementi(maxRows);
        }

        private void ScanEndRad1melementi()
        {
            this.RAD1MELEMENTISelect4.Close();
        }

        private void ScanLoadRad1melementi()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRAD1MELEMENTISelect4.HasMoreRows)
            {
                this.RcdFound282 = 1;
                this.rowRAD1MELEMENTI["RAD1ELEMENTIID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RAD1MELEMENTISelect4, 0));
                this.rowRAD1MELEMENTI["RAD1ELEMENTINAZIV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RAD1MELEMENTISelect4, 1));
            }
        }

        private void ScanNextRad1melementi()
        {
            this.cmRAD1MELEMENTISelect4.HasMoreRows = this.RAD1MELEMENTISelect4.Read();
            this.RcdFound282 = 0;
            this.ScanLoadRad1melementi();
        }

        private void ScanStartRad1melementi(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString282 + "  FROM [RAD1MELEMENTI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1ELEMENTIID]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString282, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1ELEMENTIID] ) AS DK_PAGENUM   FROM [RAD1MELEMENTI] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString282 + " FROM [RAD1MELEMENTI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1ELEMENTIID] ";
            }
            this.cmRAD1MELEMENTISelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.RAD1MELEMENTISelect4 = this.cmRAD1MELEMENTISelect4.FetchData();
            this.RcdFound282 = 0;
            this.ScanLoadRad1melementi();
            this.LoadDataRad1melementi(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.RAD1MELEMENTISet = (RAD1MELEMENTIDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.RAD1MELEMENTISet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.RAD1MELEMENTISet.RAD1MELEMENTI.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        RAD1MELEMENTIDataSet.RAD1MELEMENTIRow current = (RAD1MELEMENTIDataSet.RAD1MELEMENTIRow) enumerator.Current;
                        this.rowRAD1MELEMENTI = current;
                        if (Helpers.IsRowChanged(this.rowRAD1MELEMENTI))
                        {
                            this.ReadRowRad1melementi();
                            if (this.rowRAD1MELEMENTI.RowState == DataRowState.Added)
                            {
                                this.InsertRad1melementi();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateRad1melementi();
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
                
                ////this.connDefault.Rollback();
                
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        private void UpdateRad1melementi()
        {
            this.CheckOptimisticConcurrencyRad1melementi();
            this.AfterConfirmRad1melementi();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [RAD1MELEMENTI] SET [RAD1ELEMENTINAZIV]=@RAD1ELEMENTINAZIV  WHERE [RAD1ELEMENTIID] = @RAD1ELEMENTIID", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTINAZIV", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTIID", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTI["RAD1ELEMENTINAZIV"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1MELEMENTI["RAD1ELEMENTIID"]));
            command.ExecuteStmt();
            this.OnRAD1MELEMENTIUpdated(new RAD1MELEMENTIEventArgs(this.rowRAD1MELEMENTI, StatementType.Update));
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
        public class RAD1MELEMENTIDataChangedException : DataChangedException
        {
            public RAD1MELEMENTIDataChangedException()
            {
            }

            public RAD1MELEMENTIDataChangedException(string message) : base(message)
            {
            }

            protected RAD1MELEMENTIDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1MELEMENTIDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1MELEMENTIDataLockedException : DataLockedException
        {
            public RAD1MELEMENTIDataLockedException()
            {
            }

            public RAD1MELEMENTIDataLockedException(string message) : base(message)
            {
            }

            protected RAD1MELEMENTIDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1MELEMENTIDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1MELEMENTIDuplicateKeyException : DuplicateKeyException
        {
            public RAD1MELEMENTIDuplicateKeyException()
            {
            }

            public RAD1MELEMENTIDuplicateKeyException(string message) : base(message)
            {
            }

            protected RAD1MELEMENTIDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1MELEMENTIDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RAD1MELEMENTIEventArgs : EventArgs
        {
            private RAD1MELEMENTIDataSet.RAD1MELEMENTIRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RAD1MELEMENTIEventArgs(RAD1MELEMENTIDataSet.RAD1MELEMENTIRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RAD1MELEMENTIDataSet.RAD1MELEMENTIRow Row
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
        public class RAD1MELEMENTINotFoundException : DataNotFoundException
        {
            public RAD1MELEMENTINotFoundException()
            {
            }

            public RAD1MELEMENTINotFoundException(string message) : base(message)
            {
            }

            protected RAD1MELEMENTINotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1MELEMENTINotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void RAD1MELEMENTIUpdateEventHandler(object sender, RAD1MELEMENTIDataAdapter.RAD1MELEMENTIEventArgs e);

        [Serializable]
        public class RAD1MELEMENTIVEZAInvalidDeleteException : InvalidDeleteException
        {
            public RAD1MELEMENTIVEZAInvalidDeleteException()
            {
            }

            public RAD1MELEMENTIVEZAInvalidDeleteException(string message) : base(message)
            {
            }

            protected RAD1MELEMENTIVEZAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1MELEMENTIVEZAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

