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

    public class BLGVRSTEDOKDataAdapter : IDataAdapter, IBLGVRSTEDOKDataAdapter
    {
        private bool _Gxremove;
        private IDataReader BLGVRSTEDOKSelect1;
        private IDataReader BLGVRSTEDOKSelect4;
        private BLGVRSTEDOKDataSet BLGVRSTEDOKSet;
        private ReadWriteCommand cmBLGVRSTEDOKSelect1;
        private ReadWriteCommand cmBLGVRSTEDOKSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVVRSTEDOKOriginal;
        private readonly string m_SelectString183 = "TM1.[IDBLGVRSTEDOK], TM1.[NAZIVVRSTEDOK]";
        private string m_WhereString;
        private short RcdFound183;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private BLGVRSTEDOKDataSet.BLGVRSTEDOKRow rowBLGVRSTEDOK;
        private string scmdbuf;
        private StatementType sMode183;

        public event BLGVRSTEDOKUpdateEventHandler BLGVRSTEDOKUpdated;

        public event BLGVRSTEDOKUpdateEventHandler BLGVRSTEDOKUpdating;

        private void AddRowBlgvrstedok()
        {
            this.BLGVRSTEDOKSet.BLGVRSTEDOK.AddBLGVRSTEDOKRow(this.rowBLGVRSTEDOK);
        }

        private void AfterConfirmBlgvrstedok()
        {
            this.OnBLGVRSTEDOKUpdating(new BLGVRSTEDOKEventArgs(this.rowBLGVRSTEDOK, this.Gx_mode));
        }

        private void CheckDeleteErrorsBlgvrstedok()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [BLGDOKIDDOKUMENT], [IDBLGVRSTEDOK], [blggodineIDGODINE], [BLGBROJDOKUMENTA] FROM [BLAGAJNAStavkeBlagajne] WITH (NOLOCK) WHERE [IDBLGVRSTEDOK] = @IDBLGVRSTEDOK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBLGVRSTEDOK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLGVRSTEDOK["IDBLGVRSTEDOK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new BLAGAJNAStavkeBlagajneInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "StavkeBlagajne" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyBlgvrstedok()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDBLGVRSTEDOK], [NAZIVVRSTEDOK] FROM [BLGVRSTEDOK] WITH (UPDLOCK) WHERE [IDBLGVRSTEDOK] = @IDBLGVRSTEDOK ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBLGVRSTEDOK", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLGVRSTEDOK["IDBLGVRSTEDOK"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new BLGVRSTEDOKDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("BLGVRSTEDOK") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVVRSTEDOKOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new BLGVRSTEDOKDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("BLGVRSTEDOK") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowBlgvrstedok()
        {
            this.rowBLGVRSTEDOK = this.BLGVRSTEDOKSet.BLGVRSTEDOK.NewBLGVRSTEDOKRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyBlgvrstedok();
            this.AfterConfirmBlgvrstedok();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [BLGVRSTEDOK]  WHERE [IDBLGVRSTEDOK] = @IDBLGVRSTEDOK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBLGVRSTEDOK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLGVRSTEDOK["IDBLGVRSTEDOK"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsBlgvrstedok();
            }
            this.OnBLGVRSTEDOKUpdated(new BLGVRSTEDOKEventArgs(this.rowBLGVRSTEDOK, StatementType.Delete));
            this.rowBLGVRSTEDOK.Delete();
            this.sMode183 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode183;
        }


        public virtual int Fill(BLGVRSTEDOKDataSet dataSet)
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
                    this.BLGVRSTEDOKSet = dataSet;
                    this.LoadChildBlgvrstedok(0, -1);
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
            this.BLGVRSTEDOKSet = (BLGVRSTEDOKDataSet) dataSet;
            if (this.BLGVRSTEDOKSet != null)
            {
                return this.Fill(this.BLGVRSTEDOKSet);
            }
            this.BLGVRSTEDOKSet = new BLGVRSTEDOKDataSet();
            this.Fill(this.BLGVRSTEDOKSet);
            dataSet.Merge(this.BLGVRSTEDOKSet);
            return 0;
        }

        public virtual int Fill(BLGVRSTEDOKDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDBLGVRSTEDOK"]));
        }

        public virtual int Fill(BLGVRSTEDOKDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDBLGVRSTEDOK"]));
        }

        public virtual int Fill(BLGVRSTEDOKDataSet dataSet, int iDBLGVRSTEDOK)
        {
            if (!this.FillByIDBLGVRSTEDOK(dataSet, iDBLGVRSTEDOK))
            {
                throw new BLGVRSTEDOKNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("BLGVRSTEDOK") }));
            }
            return 0;
        }

        public virtual bool FillByIDBLGVRSTEDOK(BLGVRSTEDOKDataSet dataSet, int iDBLGVRSTEDOK)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.BLGVRSTEDOKSet = dataSet;
            this.rowBLGVRSTEDOK = this.BLGVRSTEDOKSet.BLGVRSTEDOK.NewBLGVRSTEDOKRow();
            this.rowBLGVRSTEDOK.IDBLGVRSTEDOK = iDBLGVRSTEDOK;
            try
            {
                this.LoadByIDBLGVRSTEDOK(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound183 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(BLGVRSTEDOKDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.BLGVRSTEDOKSet = dataSet;
            try
            {
                this.LoadChildBlgvrstedok(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDBLGVRSTEDOK], [NAZIVVRSTEDOK] FROM [BLGVRSTEDOK] WITH (NOLOCK) WHERE [IDBLGVRSTEDOK] = @IDBLGVRSTEDOK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBLGVRSTEDOK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLGVRSTEDOK["IDBLGVRSTEDOK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound183 = 1;
                this.rowBLGVRSTEDOK["IDBLGVRSTEDOK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowBLGVRSTEDOK["NAZIVVRSTEDOK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode183 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode183;
            }
            else
            {
                this.RcdFound183 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDBLGVRSTEDOK";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmBLGVRSTEDOKSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [BLGVRSTEDOK] WITH (NOLOCK) ", false);
            this.BLGVRSTEDOKSelect1 = this.cmBLGVRSTEDOKSelect1.FetchData();
            if (this.BLGVRSTEDOKSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.BLGVRSTEDOKSelect1.GetInt32(0);
            }
            this.BLGVRSTEDOKSelect1.Close();
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
            this.RcdFound183 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVVRSTEDOKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.BLGVRSTEDOKSet = new BLGVRSTEDOKDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertBlgvrstedok()
        {
            this.CheckOptimisticConcurrencyBlgvrstedok();
            this.AfterConfirmBlgvrstedok();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [BLGVRSTEDOK] ([IDBLGVRSTEDOK], [NAZIVVRSTEDOK]) VALUES (@IDBLGVRSTEDOK, @NAZIVVRSTEDOK)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBLGVRSTEDOK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTEDOK", DbType.String, 30));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLGVRSTEDOK["IDBLGVRSTEDOK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBLGVRSTEDOK["NAZIVVRSTEDOK"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new BLGVRSTEDOKDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnBLGVRSTEDOKUpdated(new BLGVRSTEDOKEventArgs(this.rowBLGVRSTEDOK, StatementType.Insert));
        }

        private void LoadByIDBLGVRSTEDOK(int startRow, int maxRows)
        {
            bool enforceConstraints = this.BLGVRSTEDOKSet.EnforceConstraints;
            this.BLGVRSTEDOKSet.BLGVRSTEDOK.BeginLoadData();
            this.ScanByIDBLGVRSTEDOK(startRow, maxRows);
            this.BLGVRSTEDOKSet.BLGVRSTEDOK.EndLoadData();
            this.BLGVRSTEDOKSet.EnforceConstraints = enforceConstraints;
            if (this.BLGVRSTEDOKSet.BLGVRSTEDOK.Count > 0)
            {
                this.rowBLGVRSTEDOK = this.BLGVRSTEDOKSet.BLGVRSTEDOK[this.BLGVRSTEDOKSet.BLGVRSTEDOK.Count - 1];
            }
        }

        private void LoadChildBlgvrstedok(int startRow, int maxRows)
        {
            this.CreateNewRowBlgvrstedok();
            bool enforceConstraints = this.BLGVRSTEDOKSet.EnforceConstraints;
            this.BLGVRSTEDOKSet.BLGVRSTEDOK.BeginLoadData();
            this.ScanStartBlgvrstedok(startRow, maxRows);
            this.BLGVRSTEDOKSet.BLGVRSTEDOK.EndLoadData();
            this.BLGVRSTEDOKSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataBlgvrstedok(int maxRows)
        {
            int num = 0;
            if (this.RcdFound183 != 0)
            {
                this.ScanLoadBlgvrstedok();
                while ((this.RcdFound183 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowBlgvrstedok();
                    this.CreateNewRowBlgvrstedok();
                    this.ScanNextBlgvrstedok();
                }
            }
            if (num > 0)
            {
                this.RcdFound183 = 1;
            }
            this.ScanEndBlgvrstedok();
            if (this.BLGVRSTEDOKSet.BLGVRSTEDOK.Count > 0)
            {
                this.rowBLGVRSTEDOK = this.BLGVRSTEDOKSet.BLGVRSTEDOK[this.BLGVRSTEDOKSet.BLGVRSTEDOK.Count - 1];
            }
        }

        private void LoadRowBlgvrstedok()
        {
            this.AddRowBlgvrstedok();
        }

        private void OnBLGVRSTEDOKUpdated(BLGVRSTEDOKEventArgs e)
        {
            if (this.BLGVRSTEDOKUpdated != null)
            {
                BLGVRSTEDOKUpdateEventHandler bLGVRSTEDOKUpdatedEvent = this.BLGVRSTEDOKUpdated;
                if (bLGVRSTEDOKUpdatedEvent != null)
                {
                    bLGVRSTEDOKUpdatedEvent(this, e);
                }
            }
        }

        private void OnBLGVRSTEDOKUpdating(BLGVRSTEDOKEventArgs e)
        {
            if (this.BLGVRSTEDOKUpdating != null)
            {
                BLGVRSTEDOKUpdateEventHandler bLGVRSTEDOKUpdatingEvent = this.BLGVRSTEDOKUpdating;
                if (bLGVRSTEDOKUpdatingEvent != null)
                {
                    bLGVRSTEDOKUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowBlgvrstedok()
        {
            this.Gx_mode = Mode.FromRowState(this.rowBLGVRSTEDOK.RowState);
            if (this.rowBLGVRSTEDOK.RowState != DataRowState.Added)
            {
                this.m__NAZIVVRSTEDOKOriginal = RuntimeHelpers.GetObjectValue(this.rowBLGVRSTEDOK["NAZIVVRSTEDOK", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVVRSTEDOKOriginal = RuntimeHelpers.GetObjectValue(this.rowBLGVRSTEDOK["NAZIVVRSTEDOK"]);
            }
            this._Gxremove = this.rowBLGVRSTEDOK.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowBLGVRSTEDOK = (BLGVRSTEDOKDataSet.BLGVRSTEDOKRow) DataSetUtil.CloneOriginalDataRow(this.rowBLGVRSTEDOK);
            }
        }

        private void ScanByIDBLGVRSTEDOK(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDBLGVRSTEDOK] = @IDBLGVRSTEDOK";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString183 + "  FROM [BLGVRSTEDOK] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDBLGVRSTEDOK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString183, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDBLGVRSTEDOK] ) AS DK_PAGENUM   FROM [BLGVRSTEDOK] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString183 + " FROM [BLGVRSTEDOK] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDBLGVRSTEDOK] ";
            }
            this.cmBLGVRSTEDOKSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmBLGVRSTEDOKSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmBLGVRSTEDOKSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBLGVRSTEDOK", DbType.Int32));
            }
            this.cmBLGVRSTEDOKSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLGVRSTEDOK["IDBLGVRSTEDOK"]));
            this.BLGVRSTEDOKSelect4 = this.cmBLGVRSTEDOKSelect4.FetchData();
            this.RcdFound183 = 0;
            this.ScanLoadBlgvrstedok();
            this.LoadDataBlgvrstedok(maxRows);
        }

        private void ScanEndBlgvrstedok()
        {
            this.BLGVRSTEDOKSelect4.Close();
        }

        private void ScanLoadBlgvrstedok()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmBLGVRSTEDOKSelect4.HasMoreRows)
            {
                this.RcdFound183 = 1;
                this.rowBLGVRSTEDOK["IDBLGVRSTEDOK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.BLGVRSTEDOKSelect4, 0));
                this.rowBLGVRSTEDOK["NAZIVVRSTEDOK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BLGVRSTEDOKSelect4, 1));
            }
        }

        private void ScanNextBlgvrstedok()
        {
            this.cmBLGVRSTEDOKSelect4.HasMoreRows = this.BLGVRSTEDOKSelect4.Read();
            this.RcdFound183 = 0;
            this.ScanLoadBlgvrstedok();
        }

        private void ScanStartBlgvrstedok(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString183 + "  FROM [BLGVRSTEDOK] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDBLGVRSTEDOK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString183, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDBLGVRSTEDOK] ) AS DK_PAGENUM   FROM [BLGVRSTEDOK] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString183 + " FROM [BLGVRSTEDOK] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDBLGVRSTEDOK] ";
            }
            this.cmBLGVRSTEDOKSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.BLGVRSTEDOKSelect4 = this.cmBLGVRSTEDOKSelect4.FetchData();
            this.RcdFound183 = 0;
            this.ScanLoadBlgvrstedok();
            this.LoadDataBlgvrstedok(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.BLGVRSTEDOKSet = (BLGVRSTEDOKDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.BLGVRSTEDOKSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.BLGVRSTEDOKSet.BLGVRSTEDOK.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        BLGVRSTEDOKDataSet.BLGVRSTEDOKRow current = (BLGVRSTEDOKDataSet.BLGVRSTEDOKRow) enumerator.Current;
                        this.rowBLGVRSTEDOK = current;
                        if (Helpers.IsRowChanged(this.rowBLGVRSTEDOK))
                        {
                            this.ReadRowBlgvrstedok();
                            if (this.rowBLGVRSTEDOK.RowState == DataRowState.Added)
                            {
                                this.InsertBlgvrstedok();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateBlgvrstedok();
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

        private void UpdateBlgvrstedok()
        {
            this.CheckOptimisticConcurrencyBlgvrstedok();
            this.AfterConfirmBlgvrstedok();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [BLGVRSTEDOK] SET [NAZIVVRSTEDOK]=@NAZIVVRSTEDOK  WHERE [IDBLGVRSTEDOK] = @IDBLGVRSTEDOK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVRSTEDOK", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBLGVRSTEDOK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBLGVRSTEDOK["NAZIVVRSTEDOK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBLGVRSTEDOK["IDBLGVRSTEDOK"]));
            command.ExecuteStmt();
            this.OnBLGVRSTEDOKUpdated(new BLGVRSTEDOKEventArgs(this.rowBLGVRSTEDOK, StatementType.Update));
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
        public class BLAGAJNAStavkeBlagajneInvalidDeleteException : InvalidDeleteException
        {
            public BLAGAJNAStavkeBlagajneInvalidDeleteException()
            {
            }

            public BLAGAJNAStavkeBlagajneInvalidDeleteException(string message) : base(message)
            {
            }

            protected BLAGAJNAStavkeBlagajneInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLAGAJNAStavkeBlagajneInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BLGVRSTEDOKDataChangedException : DataChangedException
        {
            public BLGVRSTEDOKDataChangedException()
            {
            }

            public BLGVRSTEDOKDataChangedException(string message) : base(message)
            {
            }

            protected BLGVRSTEDOKDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLGVRSTEDOKDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BLGVRSTEDOKDataLockedException : DataLockedException
        {
            public BLGVRSTEDOKDataLockedException()
            {
            }

            public BLGVRSTEDOKDataLockedException(string message) : base(message)
            {
            }

            protected BLGVRSTEDOKDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLGVRSTEDOKDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BLGVRSTEDOKDuplicateKeyException : DuplicateKeyException
        {
            public BLGVRSTEDOKDuplicateKeyException()
            {
            }

            public BLGVRSTEDOKDuplicateKeyException(string message) : base(message)
            {
            }

            protected BLGVRSTEDOKDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLGVRSTEDOKDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class BLGVRSTEDOKEventArgs : EventArgs
        {
            private BLGVRSTEDOKDataSet.BLGVRSTEDOKRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public BLGVRSTEDOKEventArgs(BLGVRSTEDOKDataSet.BLGVRSTEDOKRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public BLGVRSTEDOKDataSet.BLGVRSTEDOKRow Row
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
        public class BLGVRSTEDOKNotFoundException : DataNotFoundException
        {
            public BLGVRSTEDOKNotFoundException()
            {
            }

            public BLGVRSTEDOKNotFoundException(string message) : base(message)
            {
            }

            protected BLGVRSTEDOKNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLGVRSTEDOKNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void BLGVRSTEDOKUpdateEventHandler(object sender, BLGVRSTEDOKDataAdapter.BLGVRSTEDOKEventArgs e);
    }
}

