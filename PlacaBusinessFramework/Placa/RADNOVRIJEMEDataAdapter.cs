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

    public class RADNOVRIJEMEDataAdapter : IDataAdapter, IRADNOVRIJEMEDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmRADNOVRIJEMESelect1;
        private ReadWriteCommand cmRADNOVRIJEMESelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVRADNOVRIJEMEOriginal;
        private readonly string m_SelectString284 = "TM1.[IDRADNOVRIJEME], TM1.[NAZIVRADNOVRIJEME]";
        private string m_WhereString;
        private IDataReader RADNOVRIJEMESelect1;
        private IDataReader RADNOVRIJEMESelect4;
        private RADNOVRIJEMEDataSet RADNOVRIJEMESet;
        private short RcdFound284;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private RADNOVRIJEMEDataSet.RADNOVRIJEMERow rowRADNOVRIJEME;
        private string scmdbuf;
        private StatementType sMode284;

        public event RADNOVRIJEMEUpdateEventHandler RADNOVRIJEMEUpdated;

        public event RADNOVRIJEMEUpdateEventHandler RADNOVRIJEMEUpdating;

        private void AddRowRadnovrijeme()
        {
            this.RADNOVRIJEMESet.RADNOVRIJEME.AddRADNOVRIJEMERow(this.rowRADNOVRIJEME);
        }

        private void AfterConfirmRadnovrijeme()
        {
            this.OnRADNOVRIJEMEUpdating(new RADNOVRIJEMEEventArgs(this.rowRADNOVRIJEME, this.Gx_mode));
        }

        private void CheckDeleteErrorsRadnovrijeme()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK] FROM [RADNIK] WITH (NOLOCK) WHERE [IDRADNOVRIJEME] = @IDRADNOVRIJEME ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOVRIJEME", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNOVRIJEME["IDRADNOVRIJEME"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIK" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyRadnovrijeme()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRADNOVRIJEME], [NAZIVRADNOVRIJEME] FROM [RADNOVRIJEME] WITH (UPDLOCK) WHERE [IDRADNOVRIJEME] = @IDRADNOVRIJEME ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOVRIJEME", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNOVRIJEME["IDRADNOVRIJEME"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RADNOVRIJEMEDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RADNOVRIJEME") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVRADNOVRIJEMEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new RADNOVRIJEMEDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RADNOVRIJEME") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowRadnovrijeme()
        {
            this.rowRADNOVRIJEME = this.RADNOVRIJEMESet.RADNOVRIJEME.NewRADNOVRIJEMERow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRadnovrijeme();
            this.AfterConfirmRadnovrijeme();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RADNOVRIJEME]  WHERE [IDRADNOVRIJEME] = @IDRADNOVRIJEME", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOVRIJEME", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNOVRIJEME["IDRADNOVRIJEME"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsRadnovrijeme();
            }
            this.OnRADNOVRIJEMEUpdated(new RADNOVRIJEMEEventArgs(this.rowRADNOVRIJEME, StatementType.Delete));
            this.rowRADNOVRIJEME.Delete();
            this.sMode284 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode284;
        }

        public virtual int Fill(RADNOVRIJEMEDataSet dataSet)
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
                    this.RADNOVRIJEMESet = dataSet;
                    this.LoadChildRadnovrijeme(0, -1);
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
            this.RADNOVRIJEMESet = (RADNOVRIJEMEDataSet) dataSet;
            if (this.RADNOVRIJEMESet != null)
            {
                return this.Fill(this.RADNOVRIJEMESet);
            }
            this.RADNOVRIJEMESet = new RADNOVRIJEMEDataSet();
            this.Fill(this.RADNOVRIJEMESet);
            dataSet.Merge(this.RADNOVRIJEMESet);
            return 0;
        }

        public virtual int Fill(RADNOVRIJEMEDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDRADNOVRIJEME"]));
        }

        public virtual int Fill(RADNOVRIJEMEDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDRADNOVRIJEME"]));
        }

        public virtual int Fill(RADNOVRIJEMEDataSet dataSet, int iDRADNOVRIJEME)
        {
            if (!this.FillByIDRADNOVRIJEME(dataSet, iDRADNOVRIJEME))
            {
                throw new RADNOVRIJEMENotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RADNOVRIJEME") }));
            }
            return 0;
        }

        public virtual bool FillByIDRADNOVRIJEME(RADNOVRIJEMEDataSet dataSet, int iDRADNOVRIJEME)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNOVRIJEMESet = dataSet;
            this.rowRADNOVRIJEME = this.RADNOVRIJEMESet.RADNOVRIJEME.NewRADNOVRIJEMERow();
            this.rowRADNOVRIJEME.IDRADNOVRIJEME = iDRADNOVRIJEME;
            try
            {
                this.LoadByIDRADNOVRIJEME(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound284 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(RADNOVRIJEMEDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RADNOVRIJEMESet = dataSet;
            try
            {
                this.LoadChildRadnovrijeme(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDRADNOVRIJEME], [NAZIVRADNOVRIJEME] FROM [RADNOVRIJEME] WITH (NOLOCK) WHERE [IDRADNOVRIJEME] = @IDRADNOVRIJEME ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOVRIJEME", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNOVRIJEME["IDRADNOVRIJEME"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound284 = 1;
                this.rowRADNOVRIJEME["IDRADNOVRIJEME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowRADNOVRIJEME["NAZIVRADNOVRIJEME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode284 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode284;
            }
            else
            {
                this.RcdFound284 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDRADNOVRIJEME";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRADNOVRIJEMESelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RADNOVRIJEME] WITH (NOLOCK) ", false);
            this.RADNOVRIJEMESelect1 = this.cmRADNOVRIJEMESelect1.FetchData();
            if (this.RADNOVRIJEMESelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RADNOVRIJEMESelect1.GetInt32(0);
            }
            this.RADNOVRIJEMESelect1.Close();
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
            this.RcdFound284 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVRADNOVRIJEMEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.RADNOVRIJEMESet = new RADNOVRIJEMEDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertRadnovrijeme()
        {
            this.CheckOptimisticConcurrencyRadnovrijeme();
            this.AfterConfirmRadnovrijeme();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RADNOVRIJEME] ([IDRADNOVRIJEME], [NAZIVRADNOVRIJEME]) VALUES (@IDRADNOVRIJEME, @NAZIVRADNOVRIJEME)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOVRIJEME", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVRADNOVRIJEME", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNOVRIJEME["IDRADNOVRIJEME"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNOVRIJEME["NAZIVRADNOVRIJEME"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RADNOVRIJEMEDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnRADNOVRIJEMEUpdated(new RADNOVRIJEMEEventArgs(this.rowRADNOVRIJEME, StatementType.Insert));
        }

        private void LoadByIDRADNOVRIJEME(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RADNOVRIJEMESet.EnforceConstraints;
            this.RADNOVRIJEMESet.RADNOVRIJEME.BeginLoadData();
            this.ScanByIDRADNOVRIJEME(startRow, maxRows);
            this.RADNOVRIJEMESet.RADNOVRIJEME.EndLoadData();
            this.RADNOVRIJEMESet.EnforceConstraints = enforceConstraints;
            if (this.RADNOVRIJEMESet.RADNOVRIJEME.Count > 0)
            {
                this.rowRADNOVRIJEME = this.RADNOVRIJEMESet.RADNOVRIJEME[this.RADNOVRIJEMESet.RADNOVRIJEME.Count - 1];
            }
        }

        private void LoadChildRadnovrijeme(int startRow, int maxRows)
        {
            this.CreateNewRowRadnovrijeme();
            bool enforceConstraints = this.RADNOVRIJEMESet.EnforceConstraints;
            this.RADNOVRIJEMESet.RADNOVRIJEME.BeginLoadData();
            this.ScanStartRadnovrijeme(startRow, maxRows);
            this.RADNOVRIJEMESet.RADNOVRIJEME.EndLoadData();
            this.RADNOVRIJEMESet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataRadnovrijeme(int maxRows)
        {
            int num = 0;
            if (this.RcdFound284 != 0)
            {
                this.ScanLoadRadnovrijeme();
                while ((this.RcdFound284 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowRadnovrijeme();
                    this.CreateNewRowRadnovrijeme();
                    this.ScanNextRadnovrijeme();
                }
            }
            if (num > 0)
            {
                this.RcdFound284 = 1;
            }
            this.ScanEndRadnovrijeme();
            if (this.RADNOVRIJEMESet.RADNOVRIJEME.Count > 0)
            {
                this.rowRADNOVRIJEME = this.RADNOVRIJEMESet.RADNOVRIJEME[this.RADNOVRIJEMESet.RADNOVRIJEME.Count - 1];
            }
        }

        private void LoadRowRadnovrijeme()
        {
            this.AddRowRadnovrijeme();
        }

        private void OnRADNOVRIJEMEUpdated(RADNOVRIJEMEEventArgs e)
        {
            if (this.RADNOVRIJEMEUpdated != null)
            {
                RADNOVRIJEMEUpdateEventHandler rADNOVRIJEMEUpdatedEvent = this.RADNOVRIJEMEUpdated;
                if (rADNOVRIJEMEUpdatedEvent != null)
                {
                    rADNOVRIJEMEUpdatedEvent(this, e);
                }
            }
        }

        private void OnRADNOVRIJEMEUpdating(RADNOVRIJEMEEventArgs e)
        {
            if (this.RADNOVRIJEMEUpdating != null)
            {
                RADNOVRIJEMEUpdateEventHandler rADNOVRIJEMEUpdatingEvent = this.RADNOVRIJEMEUpdating;
                if (rADNOVRIJEMEUpdatingEvent != null)
                {
                    rADNOVRIJEMEUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowRadnovrijeme()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRADNOVRIJEME.RowState);
            if (this.rowRADNOVRIJEME.RowState != DataRowState.Added)
            {
                this.m__NAZIVRADNOVRIJEMEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNOVRIJEME["NAZIVRADNOVRIJEME", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVRADNOVRIJEMEOriginal = RuntimeHelpers.GetObjectValue(this.rowRADNOVRIJEME["NAZIVRADNOVRIJEME"]);
            }
            this._Gxremove = this.rowRADNOVRIJEME.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowRADNOVRIJEME = (RADNOVRIJEMEDataSet.RADNOVRIJEMERow) DataSetUtil.CloneOriginalDataRow(this.rowRADNOVRIJEME);
            }
        }

        private void ScanByIDRADNOVRIJEME(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDRADNOVRIJEME] = @IDRADNOVRIJEME";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString284 + "  FROM [RADNOVRIJEME] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNOVRIJEME]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString284, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNOVRIJEME] ) AS DK_PAGENUM   FROM [RADNOVRIJEME] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString284 + " FROM [RADNOVRIJEME] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNOVRIJEME] ";
            }
            this.cmRADNOVRIJEMESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRADNOVRIJEMESelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmRADNOVRIJEMESelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOVRIJEME", DbType.Int32));
            }
            this.cmRADNOVRIJEMESelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNOVRIJEME["IDRADNOVRIJEME"]));
            this.RADNOVRIJEMESelect4 = this.cmRADNOVRIJEMESelect4.FetchData();
            this.RcdFound284 = 0;
            this.ScanLoadRadnovrijeme();
            this.LoadDataRadnovrijeme(maxRows);
        }

        private void ScanEndRadnovrijeme()
        {
            this.RADNOVRIJEMESelect4.Close();
        }

        private void ScanLoadRadnovrijeme()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRADNOVRIJEMESelect4.HasMoreRows)
            {
                this.RcdFound284 = 1;
                this.rowRADNOVRIJEME["IDRADNOVRIJEME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RADNOVRIJEMESelect4, 0));
                this.rowRADNOVRIJEME["NAZIVRADNOVRIJEME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RADNOVRIJEMESelect4, 1));
            }
        }

        private void ScanNextRadnovrijeme()
        {
            this.cmRADNOVRIJEMESelect4.HasMoreRows = this.RADNOVRIJEMESelect4.Read();
            this.RcdFound284 = 0;
            this.ScanLoadRadnovrijeme();
        }

        private void ScanStartRadnovrijeme(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString284 + "  FROM [RADNOVRIJEME] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNOVRIJEME]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString284, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDRADNOVRIJEME] ) AS DK_PAGENUM   FROM [RADNOVRIJEME] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString284 + " FROM [RADNOVRIJEME] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDRADNOVRIJEME] ";
            }
            this.cmRADNOVRIJEMESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.RADNOVRIJEMESelect4 = this.cmRADNOVRIJEMESelect4.FetchData();
            this.RcdFound284 = 0;
            this.ScanLoadRadnovrijeme();
            this.LoadDataRadnovrijeme(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.RADNOVRIJEMESet = (RADNOVRIJEMEDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.RADNOVRIJEMESet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.RADNOVRIJEMESet.RADNOVRIJEME.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        RADNOVRIJEMEDataSet.RADNOVRIJEMERow current = (RADNOVRIJEMEDataSet.RADNOVRIJEMERow) enumerator.Current;
                        this.rowRADNOVRIJEME = current;
                        if (Helpers.IsRowChanged(this.rowRADNOVRIJEME))
                        {
                            this.ReadRowRadnovrijeme();
                            if (this.rowRADNOVRIJEME.RowState == DataRowState.Added)
                            {
                                this.InsertRadnovrijeme();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateRadnovrijeme();
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

        private void UpdateRadnovrijeme()
        {
            this.CheckOptimisticConcurrencyRadnovrijeme();
            this.AfterConfirmRadnovrijeme();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [RADNOVRIJEME] SET [NAZIVRADNOVRIJEME]=@NAZIVRADNOVRIJEME  WHERE [IDRADNOVRIJEME] = @IDRADNOVRIJEME", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVRADNOVRIJEME", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNOVRIJEME", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRADNOVRIJEME["NAZIVRADNOVRIJEME"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRADNOVRIJEME["IDRADNOVRIJEME"]));
            command.ExecuteStmt();
            this.OnRADNOVRIJEMEUpdated(new RADNOVRIJEMEEventArgs(this.rowRADNOVRIJEME, StatementType.Update));
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
        public class RADNIKInvalidDeleteException : InvalidDeleteException
        {
            public RADNIKInvalidDeleteException()
            {
            }

            public RADNIKInvalidDeleteException(string message) : base(message)
            {
            }

            protected RADNIKInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNOVRIJEMEDataChangedException : DataChangedException
        {
            public RADNOVRIJEMEDataChangedException()
            {
            }

            public RADNOVRIJEMEDataChangedException(string message) : base(message)
            {
            }

            protected RADNOVRIJEMEDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNOVRIJEMEDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNOVRIJEMEDataLockedException : DataLockedException
        {
            public RADNOVRIJEMEDataLockedException()
            {
            }

            public RADNOVRIJEMEDataLockedException(string message) : base(message)
            {
            }

            protected RADNOVRIJEMEDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNOVRIJEMEDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNOVRIJEMEDuplicateKeyException : DuplicateKeyException
        {
            public RADNOVRIJEMEDuplicateKeyException()
            {
            }

            public RADNOVRIJEMEDuplicateKeyException(string message) : base(message)
            {
            }

            protected RADNOVRIJEMEDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNOVRIJEMEDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RADNOVRIJEMEEventArgs : EventArgs
        {
            private RADNOVRIJEMEDataSet.RADNOVRIJEMERow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RADNOVRIJEMEEventArgs(RADNOVRIJEMEDataSet.RADNOVRIJEMERow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RADNOVRIJEMEDataSet.RADNOVRIJEMERow Row
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
        public class RADNOVRIJEMENotFoundException : DataNotFoundException
        {
            public RADNOVRIJEMENotFoundException()
            {
            }

            public RADNOVRIJEMENotFoundException(string message) : base(message)
            {
            }

            protected RADNOVRIJEMENotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNOVRIJEMENotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void RADNOVRIJEMEUpdateEventHandler(object sender, RADNOVRIJEMEDataAdapter.RADNOVRIJEMEEventArgs e);
    }
}

