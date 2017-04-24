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

    public class RAD1GELEMENTIDataAdapter : IDataAdapter, IRAD1GELEMENTIDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmRAD1GELEMENTISelect1;
        private ReadWriteCommand cmRAD1GELEMENTISelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__RAD1GELEMENTINAZIVOriginal;
        private readonly string m_SelectString281 = "TM1.[RAD1GELEMENTIID], TM1.[RAD1GELEMENTINAZIV]";
        private string m_WhereString;
        private IDataReader RAD1GELEMENTISelect1;
        private IDataReader RAD1GELEMENTISelect4;
        private RAD1GELEMENTIDataSet RAD1GELEMENTISet;
        private short RcdFound281;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private RAD1GELEMENTIDataSet.RAD1GELEMENTIRow rowRAD1GELEMENTI;
        private string scmdbuf;
        private StatementType sMode281;

        public event RAD1GELEMENTIUpdateEventHandler RAD1GELEMENTIUpdated;

        public event RAD1GELEMENTIUpdateEventHandler RAD1GELEMENTIUpdating;

        private void AddRowRad1gelementi()
        {
            this.RAD1GELEMENTISet.RAD1GELEMENTI.AddRAD1GELEMENTIRow(this.rowRAD1GELEMENTI);
        }

        private void AfterConfirmRad1gelementi()
        {
            this.OnRAD1GELEMENTIUpdating(new RAD1GELEMENTIEventArgs(this.rowRAD1GELEMENTI, this.Gx_mode));
        }

        private void CheckDeleteErrorsRad1gelementi()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [RAD1GELEMENTIID], [IDELEMENT] FROM [RAD1GELEMENTIVEZA] WITH (NOLOCK) WHERE [RAD1GELEMENTIID] = @RAD1GELEMENTIID ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTIID", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTI["RAD1GELEMENTIID"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RAD1GELEMENTIVEZAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RAD1GELEMENTIVEZA" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyRad1gelementi()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [RAD1GELEMENTIID], [RAD1GELEMENTINAZIV] FROM [RAD1GELEMENTI] WITH (UPDLOCK) WHERE [RAD1GELEMENTIID] = @RAD1GELEMENTIID ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTIID", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTI["RAD1GELEMENTIID"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RAD1GELEMENTIDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RAD1GELEMENTI") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__RAD1GELEMENTINAZIVOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new RAD1GELEMENTIDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RAD1GELEMENTI") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowRad1gelementi()
        {
            this.rowRAD1GELEMENTI = this.RAD1GELEMENTISet.RAD1GELEMENTI.NewRAD1GELEMENTIRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRad1gelementi();
            this.AfterConfirmRad1gelementi();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RAD1GELEMENTI]  WHERE [RAD1GELEMENTIID] = @RAD1GELEMENTIID", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTIID", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTI["RAD1GELEMENTIID"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsRad1gelementi();
            }
            this.OnRAD1GELEMENTIUpdated(new RAD1GELEMENTIEventArgs(this.rowRAD1GELEMENTI, StatementType.Delete));
            this.rowRAD1GELEMENTI.Delete();
            this.sMode281 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode281;
        }

        public virtual int Fill(RAD1GELEMENTIDataSet dataSet)
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
                    this.RAD1GELEMENTISet = dataSet;
                    this.LoadChildRad1gelementi(0, -1);
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
            this.RAD1GELEMENTISet = (RAD1GELEMENTIDataSet) dataSet;
            if (this.RAD1GELEMENTISet != null)
            {
                return this.Fill(this.RAD1GELEMENTISet);
            }
            this.RAD1GELEMENTISet = new RAD1GELEMENTIDataSet();
            this.Fill(this.RAD1GELEMENTISet);
            dataSet.Merge(this.RAD1GELEMENTISet);
            return 0;
        }

        public virtual int Fill(RAD1GELEMENTIDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["RAD1GELEMENTIID"]));
        }

        public virtual int Fill(RAD1GELEMENTIDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["RAD1GELEMENTIID"]));
        }

        public virtual int Fill(RAD1GELEMENTIDataSet dataSet, int rAD1GELEMENTIID)
        {
            if (!this.FillByRAD1GELEMENTIID(dataSet, rAD1GELEMENTIID))
            {
                throw new RAD1GELEMENTINotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RAD1GELEMENTI") }));
            }
            return 0;
        }

        public virtual bool FillByRAD1GELEMENTIID(RAD1GELEMENTIDataSet dataSet, int rAD1GELEMENTIID)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1GELEMENTISet = dataSet;
            this.rowRAD1GELEMENTI = this.RAD1GELEMENTISet.RAD1GELEMENTI.NewRAD1GELEMENTIRow();
            this.rowRAD1GELEMENTI.RAD1GELEMENTIID = rAD1GELEMENTIID;
            try
            {
                this.LoadByRAD1GELEMENTIID(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound281 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(RAD1GELEMENTIDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1GELEMENTISet = dataSet;
            try
            {
                this.LoadChildRad1gelementi(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [RAD1GELEMENTIID], [RAD1GELEMENTINAZIV] FROM [RAD1GELEMENTI] WITH (NOLOCK) WHERE [RAD1GELEMENTIID] = @RAD1GELEMENTIID ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTIID", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTI["RAD1GELEMENTIID"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound281 = 1;
                this.rowRAD1GELEMENTI["RAD1GELEMENTIID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowRAD1GELEMENTI["RAD1GELEMENTINAZIV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode281 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode281;
            }
            else
            {
                this.RcdFound281 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "RAD1GELEMENTIID";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1GELEMENTISelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RAD1GELEMENTI] WITH (NOLOCK) ", false);
            this.RAD1GELEMENTISelect1 = this.cmRAD1GELEMENTISelect1.FetchData();
            if (this.RAD1GELEMENTISelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RAD1GELEMENTISelect1.GetInt32(0);
            }
            this.RAD1GELEMENTISelect1.Close();
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
            this.RcdFound281 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__RAD1GELEMENTINAZIVOriginal = RuntimeHelpers.GetObjectValue(new object());
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.RAD1GELEMENTISet = new RAD1GELEMENTIDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertRad1gelementi()
        {
            this.CheckOptimisticConcurrencyRad1gelementi();
            this.AfterConfirmRad1gelementi();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RAD1GELEMENTI] ([RAD1GELEMENTIID], [RAD1GELEMENTINAZIV]) VALUES (@RAD1GELEMENTIID, @RAD1GELEMENTINAZIV)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTIID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTINAZIV", DbType.String, 30));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTI["RAD1GELEMENTIID"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTI["RAD1GELEMENTINAZIV"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RAD1GELEMENTIDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnRAD1GELEMENTIUpdated(new RAD1GELEMENTIEventArgs(this.rowRAD1GELEMENTI, StatementType.Insert));
        }

        private void LoadByRAD1GELEMENTIID(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RAD1GELEMENTISet.EnforceConstraints;
            this.RAD1GELEMENTISet.RAD1GELEMENTI.BeginLoadData();
            this.ScanByRAD1GELEMENTIID(startRow, maxRows);
            this.RAD1GELEMENTISet.RAD1GELEMENTI.EndLoadData();
            this.RAD1GELEMENTISet.EnforceConstraints = enforceConstraints;
            if (this.RAD1GELEMENTISet.RAD1GELEMENTI.Count > 0)
            {
                this.rowRAD1GELEMENTI = this.RAD1GELEMENTISet.RAD1GELEMENTI[this.RAD1GELEMENTISet.RAD1GELEMENTI.Count - 1];
            }
        }

        private void LoadChildRad1gelementi(int startRow, int maxRows)
        {
            this.CreateNewRowRad1gelementi();
            bool enforceConstraints = this.RAD1GELEMENTISet.EnforceConstraints;
            this.RAD1GELEMENTISet.RAD1GELEMENTI.BeginLoadData();
            this.ScanStartRad1gelementi(startRow, maxRows);
            this.RAD1GELEMENTISet.RAD1GELEMENTI.EndLoadData();
            this.RAD1GELEMENTISet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataRad1gelementi(int maxRows)
        {
            int num = 0;
            if (this.RcdFound281 != 0)
            {
                this.ScanLoadRad1gelementi();
                while ((this.RcdFound281 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowRad1gelementi();
                    this.CreateNewRowRad1gelementi();
                    this.ScanNextRad1gelementi();
                }
            }
            if (num > 0)
            {
                this.RcdFound281 = 1;
            }
            this.ScanEndRad1gelementi();
            if (this.RAD1GELEMENTISet.RAD1GELEMENTI.Count > 0)
            {
                this.rowRAD1GELEMENTI = this.RAD1GELEMENTISet.RAD1GELEMENTI[this.RAD1GELEMENTISet.RAD1GELEMENTI.Count - 1];
            }
        }

        private void LoadRowRad1gelementi()
        {
            this.AddRowRad1gelementi();
        }

        private void OnRAD1GELEMENTIUpdated(RAD1GELEMENTIEventArgs e)
        {
            if (this.RAD1GELEMENTIUpdated != null)
            {
                RAD1GELEMENTIUpdateEventHandler handler = this.RAD1GELEMENTIUpdated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnRAD1GELEMENTIUpdating(RAD1GELEMENTIEventArgs e)
        {
            if (this.RAD1GELEMENTIUpdating != null)
            {
                RAD1GELEMENTIUpdateEventHandler handler = this.RAD1GELEMENTIUpdating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void ReadRowRad1gelementi()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRAD1GELEMENTI.RowState);
            if (this.rowRAD1GELEMENTI.RowState != DataRowState.Added)
            {
                this.m__RAD1GELEMENTINAZIVOriginal = RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTI["RAD1GELEMENTINAZIV", DataRowVersion.Original]);
            }
            else
            {
                this.m__RAD1GELEMENTINAZIVOriginal = RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTI["RAD1GELEMENTINAZIV"]);
            }
            this._Gxremove = this.rowRAD1GELEMENTI.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowRAD1GELEMENTI = (RAD1GELEMENTIDataSet.RAD1GELEMENTIRow) DataSetUtil.CloneOriginalDataRow(this.rowRAD1GELEMENTI);
            }
        }

        private void ScanByRAD1GELEMENTIID(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[RAD1GELEMENTIID] = @RAD1GELEMENTIID";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString281 + "  FROM [RAD1GELEMENTI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1GELEMENTIID]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString281, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1GELEMENTIID] ) AS DK_PAGENUM   FROM [RAD1GELEMENTI] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString281 + " FROM [RAD1GELEMENTI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1GELEMENTIID] ";
            }
            this.cmRAD1GELEMENTISelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRAD1GELEMENTISelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1GELEMENTISelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTIID", DbType.Int32));
            }
            this.cmRAD1GELEMENTISelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTI["RAD1GELEMENTIID"]));
            this.RAD1GELEMENTISelect4 = this.cmRAD1GELEMENTISelect4.FetchData();
            this.RcdFound281 = 0;
            this.ScanLoadRad1gelementi();
            this.LoadDataRad1gelementi(maxRows);
        }

        private void ScanEndRad1gelementi()
        {
            this.RAD1GELEMENTISelect4.Close();
        }

        private void ScanLoadRad1gelementi()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRAD1GELEMENTISelect4.HasMoreRows)
            {
                this.RcdFound281 = 1;
                this.rowRAD1GELEMENTI["RAD1GELEMENTIID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RAD1GELEMENTISelect4, 0));
                this.rowRAD1GELEMENTI["RAD1GELEMENTINAZIV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RAD1GELEMENTISelect4, 1));
            }
        }

        private void ScanNextRad1gelementi()
        {
            this.cmRAD1GELEMENTISelect4.HasMoreRows = this.RAD1GELEMENTISelect4.Read();
            this.RcdFound281 = 0;
            this.ScanLoadRad1gelementi();
        }

        private void ScanStartRad1gelementi(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString281 + "  FROM [RAD1GELEMENTI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1GELEMENTIID]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString281, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1GELEMENTIID] ) AS DK_PAGENUM   FROM [RAD1GELEMENTI] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString281 + " FROM [RAD1GELEMENTI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1GELEMENTIID] ";
            }
            this.cmRAD1GELEMENTISelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.RAD1GELEMENTISelect4 = this.cmRAD1GELEMENTISelect4.FetchData();
            this.RcdFound281 = 0;
            this.ScanLoadRad1gelementi();
            this.LoadDataRad1gelementi(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.RAD1GELEMENTISet = (RAD1GELEMENTIDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.RAD1GELEMENTISet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.RAD1GELEMENTISet.RAD1GELEMENTI.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        RAD1GELEMENTIDataSet.RAD1GELEMENTIRow current = (RAD1GELEMENTIDataSet.RAD1GELEMENTIRow) enumerator.Current;
                        this.rowRAD1GELEMENTI = current;
                        if (Helpers.IsRowChanged(this.rowRAD1GELEMENTI))
                        {
                            this.ReadRowRad1gelementi();
                            if (this.rowRAD1GELEMENTI.RowState == DataRowState.Added)
                            {
                                this.InsertRad1gelementi();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateRad1gelementi();
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

        private void UpdateRad1gelementi()
        {
            this.CheckOptimisticConcurrencyRad1gelementi();
            this.AfterConfirmRad1gelementi();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [RAD1GELEMENTI] SET [RAD1GELEMENTINAZIV]=@RAD1GELEMENTINAZIV  WHERE [RAD1GELEMENTIID] = @RAD1GELEMENTIID", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTINAZIV", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTIID", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTI["RAD1GELEMENTINAZIV"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1GELEMENTI["RAD1GELEMENTIID"]));
            command.ExecuteStmt();
            this.OnRAD1GELEMENTIUpdated(new RAD1GELEMENTIEventArgs(this.rowRAD1GELEMENTI, StatementType.Update));
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
        public class RAD1GELEMENTIDataChangedException : DataChangedException
        {
            public RAD1GELEMENTIDataChangedException()
            {
            }

            public RAD1GELEMENTIDataChangedException(string message) : base(message)
            {
            }

            protected RAD1GELEMENTIDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1GELEMENTIDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1GELEMENTIDataLockedException : DataLockedException
        {
            public RAD1GELEMENTIDataLockedException()
            {
            }

            public RAD1GELEMENTIDataLockedException(string message) : base(message)
            {
            }

            protected RAD1GELEMENTIDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1GELEMENTIDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1GELEMENTIDuplicateKeyException : DuplicateKeyException
        {
            public RAD1GELEMENTIDuplicateKeyException()
            {
            }

            public RAD1GELEMENTIDuplicateKeyException(string message) : base(message)
            {
            }

            protected RAD1GELEMENTIDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1GELEMENTIDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RAD1GELEMENTIEventArgs : EventArgs
        {
            private RAD1GELEMENTIDataSet.RAD1GELEMENTIRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RAD1GELEMENTIEventArgs(RAD1GELEMENTIDataSet.RAD1GELEMENTIRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RAD1GELEMENTIDataSet.RAD1GELEMENTIRow Row
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
        public class RAD1GELEMENTINotFoundException : DataNotFoundException
        {
            public RAD1GELEMENTINotFoundException()
            {
            }

            public RAD1GELEMENTINotFoundException(string message) : base(message)
            {
            }

            protected RAD1GELEMENTINotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1GELEMENTINotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void RAD1GELEMENTIUpdateEventHandler(object sender, RAD1GELEMENTIDataAdapter.RAD1GELEMENTIEventArgs e);

        [Serializable]
        public class RAD1GELEMENTIVEZAInvalidDeleteException : InvalidDeleteException
        {
            public RAD1GELEMENTIVEZAInvalidDeleteException()
            {
            }

            public RAD1GELEMENTIVEZAInvalidDeleteException(string message) : base(message)
            {
            }

            protected RAD1GELEMENTIVEZAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1GELEMENTIVEZAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

