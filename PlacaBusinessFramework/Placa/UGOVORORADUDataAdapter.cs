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

    public class UGOVORORADUDataAdapter : IDataAdapter, IUGOVORORADUDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmUGOVORORADUSelect1;
        private ReadWriteCommand cmUGOVORORADUSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVUGOVORORADUOriginal;
        private readonly string m_SelectString271 = "TM1.[IDUGOVORORADU], TM1.[NAZIVUGOVORORADU]";
        private string m_WhereString;
        private short RcdFound271;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private UGOVORORADUDataSet.UGOVORORADURow rowUGOVORORADU;
        private string scmdbuf;
        private StatementType sMode271;
        private IDataReader UGOVORORADUSelect1;
        private IDataReader UGOVORORADUSelect4;
        private UGOVORORADUDataSet UGOVORORADUSet;

        public event UGOVORORADUUpdateEventHandler UGOVORORADUUpdated;

        public event UGOVORORADUUpdateEventHandler UGOVORORADUUpdating;

        private void AddRowUgovororadu()
        {
            this.UGOVORORADUSet.UGOVORORADU.AddUGOVORORADURow(this.rowUGOVORORADU);
        }

        private void AfterConfirmUgovororadu()
        {
            this.OnUGOVORORADUUpdating(new UGOVORORADUEventArgs(this.rowUGOVORORADU, this.Gx_mode));
        }

        private void CheckDeleteErrorsUgovororadu()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK] FROM [RADNIK] WITH (NOLOCK) WHERE [IDUGOVORORADU] = @IDUGOVORORADU ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUGOVORORADU", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUGOVORORADU["IDUGOVORORADU"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIK" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyUgovororadu()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDUGOVORORADU], [NAZIVUGOVORORADU] FROM [UGOVORORADU] WITH (UPDLOCK) WHERE [IDUGOVORORADU] = @IDUGOVORORADU ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUGOVORORADU", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUGOVORORADU["IDUGOVORORADU"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new UGOVORORADUDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("UGOVORORADU") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVUGOVORORADUOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new UGOVORORADUDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("UGOVORORADU") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowUgovororadu()
        {
            this.rowUGOVORORADU = this.UGOVORORADUSet.UGOVORORADU.NewUGOVORORADURow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyUgovororadu();
            this.AfterConfirmUgovororadu();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [UGOVORORADU]  WHERE [IDUGOVORORADU] = @IDUGOVORORADU", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUGOVORORADU", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUGOVORORADU["IDUGOVORORADU"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsUgovororadu();
            }
            this.OnUGOVORORADUUpdated(new UGOVORORADUEventArgs(this.rowUGOVORORADU, StatementType.Delete));
            this.rowUGOVORORADU.Delete();
            this.sMode271 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode271;
        }

        public virtual int Fill(UGOVORORADUDataSet dataSet)
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
                    this.UGOVORORADUSet = dataSet;
                    this.LoadChildUgovororadu(0, -1);
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
            this.UGOVORORADUSet = (UGOVORORADUDataSet) dataSet;
            if (this.UGOVORORADUSet != null)
            {
                return this.Fill(this.UGOVORORADUSet);
            }
            this.UGOVORORADUSet = new UGOVORORADUDataSet();
            this.Fill(this.UGOVORORADUSet);
            dataSet.Merge(this.UGOVORORADUSet);
            return 0;
        }

        public virtual int Fill(UGOVORORADUDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDUGOVORORADU"]));
        }

        public virtual int Fill(UGOVORORADUDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDUGOVORORADU"]));
        }

        public virtual int Fill(UGOVORORADUDataSet dataSet, int iDUGOVORORADU)
        {
            if (!this.FillByIDUGOVORORADU(dataSet, iDUGOVORORADU))
            {
                throw new UGOVORORADUNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("UGOVORORADU") }));
            }
            return 0;
        }

        public virtual bool FillByIDUGOVORORADU(UGOVORORADUDataSet dataSet, int iDUGOVORORADU)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.UGOVORORADUSet = dataSet;
            this.rowUGOVORORADU = this.UGOVORORADUSet.UGOVORORADU.NewUGOVORORADURow();
            this.rowUGOVORORADU.IDUGOVORORADU = iDUGOVORORADU;
            try
            {
                this.LoadByIDUGOVORORADU(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound271 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(UGOVORORADUDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.UGOVORORADUSet = dataSet;
            try
            {
                this.LoadChildUgovororadu(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDUGOVORORADU], [NAZIVUGOVORORADU] FROM [UGOVORORADU] WITH (NOLOCK) WHERE [IDUGOVORORADU] = @IDUGOVORORADU ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUGOVORORADU", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUGOVORORADU["IDUGOVORORADU"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound271 = 1;
                this.rowUGOVORORADU["IDUGOVORORADU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowUGOVORORADU["NAZIVUGOVORORADU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode271 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode271;
            }
            else
            {
                this.RcdFound271 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDUGOVORORADU";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmUGOVORORADUSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [UGOVORORADU] WITH (NOLOCK) ", false);
            this.UGOVORORADUSelect1 = this.cmUGOVORORADUSelect1.FetchData();
            if (this.UGOVORORADUSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.UGOVORORADUSelect1.GetInt32(0);
            }
            this.UGOVORORADUSelect1.Close();
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
            this.RcdFound271 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVUGOVORORADUOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.UGOVORORADUSet = new UGOVORORADUDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertUgovororadu()
        {
            this.CheckOptimisticConcurrencyUgovororadu();
            this.AfterConfirmUgovororadu();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [UGOVORORADU] ([IDUGOVORORADU], [NAZIVUGOVORORADU]) VALUES (@IDUGOVORORADU, @NAZIVUGOVORORADU)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUGOVORORADU", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVUGOVORORADU", DbType.String, 20));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUGOVORORADU["IDUGOVORORADU"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowUGOVORORADU["NAZIVUGOVORORADU"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new UGOVORORADUDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnUGOVORORADUUpdated(new UGOVORORADUEventArgs(this.rowUGOVORORADU, StatementType.Insert));
        }

        private void LoadByIDUGOVORORADU(int startRow, int maxRows)
        {
            bool enforceConstraints = this.UGOVORORADUSet.EnforceConstraints;
            this.UGOVORORADUSet.UGOVORORADU.BeginLoadData();
            this.ScanByIDUGOVORORADU(startRow, maxRows);
            this.UGOVORORADUSet.UGOVORORADU.EndLoadData();
            this.UGOVORORADUSet.EnforceConstraints = enforceConstraints;
            if (this.UGOVORORADUSet.UGOVORORADU.Count > 0)
            {
                this.rowUGOVORORADU = this.UGOVORORADUSet.UGOVORORADU[this.UGOVORORADUSet.UGOVORORADU.Count - 1];
            }
        }

        private void LoadChildUgovororadu(int startRow, int maxRows)
        {
            this.CreateNewRowUgovororadu();
            bool enforceConstraints = this.UGOVORORADUSet.EnforceConstraints;
            this.UGOVORORADUSet.UGOVORORADU.BeginLoadData();
            this.ScanStartUgovororadu(startRow, maxRows);
            this.UGOVORORADUSet.UGOVORORADU.EndLoadData();
            this.UGOVORORADUSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataUgovororadu(int maxRows)
        {
            int num = 0;
            if (this.RcdFound271 != 0)
            {
                this.ScanLoadUgovororadu();
                while ((this.RcdFound271 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowUgovororadu();
                    this.CreateNewRowUgovororadu();
                    this.ScanNextUgovororadu();
                }
            }
            if (num > 0)
            {
                this.RcdFound271 = 1;
            }
            this.ScanEndUgovororadu();
            if (this.UGOVORORADUSet.UGOVORORADU.Count > 0)
            {
                this.rowUGOVORORADU = this.UGOVORORADUSet.UGOVORORADU[this.UGOVORORADUSet.UGOVORORADU.Count - 1];
            }
        }

        private void LoadRowUgovororadu()
        {
            this.AddRowUgovororadu();
        }

        private void OnUGOVORORADUUpdated(UGOVORORADUEventArgs e)
        {
            if (this.UGOVORORADUUpdated != null)
            {
                UGOVORORADUUpdateEventHandler uGOVORORADUUpdatedEvent = this.UGOVORORADUUpdated;
                if (uGOVORORADUUpdatedEvent != null)
                {
                    uGOVORORADUUpdatedEvent(this, e);
                }
            }
        }

        private void OnUGOVORORADUUpdating(UGOVORORADUEventArgs e)
        {
            if (this.UGOVORORADUUpdating != null)
            {
                UGOVORORADUUpdateEventHandler uGOVORORADUUpdatingEvent = this.UGOVORORADUUpdating;
                if (uGOVORORADUUpdatingEvent != null)
                {
                    uGOVORORADUUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowUgovororadu()
        {
            this.Gx_mode = Mode.FromRowState(this.rowUGOVORORADU.RowState);
            if (this.rowUGOVORORADU.RowState != DataRowState.Added)
            {
                this.m__NAZIVUGOVORORADUOriginal = RuntimeHelpers.GetObjectValue(this.rowUGOVORORADU["NAZIVUGOVORORADU", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVUGOVORORADUOriginal = RuntimeHelpers.GetObjectValue(this.rowUGOVORORADU["NAZIVUGOVORORADU"]);
            }
            this._Gxremove = this.rowUGOVORORADU.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowUGOVORORADU = (UGOVORORADUDataSet.UGOVORORADURow) DataSetUtil.CloneOriginalDataRow(this.rowUGOVORORADU);
            }
        }

        private void ScanByIDUGOVORORADU(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDUGOVORORADU] = @IDUGOVORORADU";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString271 + "  FROM [UGOVORORADU] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDUGOVORORADU]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString271, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDUGOVORORADU] ) AS DK_PAGENUM   FROM [UGOVORORADU] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString271 + " FROM [UGOVORORADU] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDUGOVORORADU] ";
            }
            this.cmUGOVORORADUSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmUGOVORORADUSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmUGOVORORADUSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUGOVORORADU", DbType.Int32));
            }
            this.cmUGOVORORADUSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUGOVORORADU["IDUGOVORORADU"]));
            this.UGOVORORADUSelect4 = this.cmUGOVORORADUSelect4.FetchData();
            this.RcdFound271 = 0;
            this.ScanLoadUgovororadu();
            this.LoadDataUgovororadu(maxRows);
        }

        private void ScanEndUgovororadu()
        {
            this.UGOVORORADUSelect4.Close();
        }

        private void ScanLoadUgovororadu()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmUGOVORORADUSelect4.HasMoreRows)
            {
                this.RcdFound271 = 1;
                this.rowUGOVORORADU["IDUGOVORORADU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.UGOVORORADUSelect4, 0));
                this.rowUGOVORORADU["NAZIVUGOVORORADU"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UGOVORORADUSelect4, 1));
            }
        }

        private void ScanNextUgovororadu()
        {
            this.cmUGOVORORADUSelect4.HasMoreRows = this.UGOVORORADUSelect4.Read();
            this.RcdFound271 = 0;
            this.ScanLoadUgovororadu();
        }

        private void ScanStartUgovororadu(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString271 + "  FROM [UGOVORORADU] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDUGOVORORADU]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString271, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDUGOVORORADU] ) AS DK_PAGENUM   FROM [UGOVORORADU] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString271 + " FROM [UGOVORORADU] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDUGOVORORADU] ";
            }
            this.cmUGOVORORADUSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.UGOVORORADUSelect4 = this.cmUGOVORORADUSelect4.FetchData();
            this.RcdFound271 = 0;
            this.ScanLoadUgovororadu();
            this.LoadDataUgovororadu(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.UGOVORORADUSet = (UGOVORORADUDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.UGOVORORADUSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.UGOVORORADUSet.UGOVORORADU.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        UGOVORORADUDataSet.UGOVORORADURow current = (UGOVORORADUDataSet.UGOVORORADURow) enumerator.Current;
                        this.rowUGOVORORADU = current;
                        if (Helpers.IsRowChanged(this.rowUGOVORORADU))
                        {
                            this.ReadRowUgovororadu();
                            if (this.rowUGOVORORADU.RowState == DataRowState.Added)
                            {
                                this.InsertUgovororadu();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateUgovororadu();
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

        private void UpdateUgovororadu()
        {
            this.CheckOptimisticConcurrencyUgovororadu();
            this.AfterConfirmUgovororadu();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [UGOVORORADU] SET [NAZIVUGOVORORADU]=@NAZIVUGOVORORADU  WHERE [IDUGOVORORADU] = @IDUGOVORORADU", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVUGOVORORADU", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUGOVORORADU", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUGOVORORADU["NAZIVUGOVORORADU"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowUGOVORORADU["IDUGOVORORADU"]));
            command.ExecuteStmt();
            this.OnUGOVORORADUUpdated(new UGOVORORADUEventArgs(this.rowUGOVORORADU, StatementType.Update));
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
        public class UGOVORORADUDataChangedException : DataChangedException
        {
            public UGOVORORADUDataChangedException()
            {
            }

            public UGOVORORADUDataChangedException(string message) : base(message)
            {
            }

            protected UGOVORORADUDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UGOVORORADUDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class UGOVORORADUDataLockedException : DataLockedException
        {
            public UGOVORORADUDataLockedException()
            {
            }

            public UGOVORORADUDataLockedException(string message) : base(message)
            {
            }

            protected UGOVORORADUDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UGOVORORADUDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class UGOVORORADUDuplicateKeyException : DuplicateKeyException
        {
            public UGOVORORADUDuplicateKeyException()
            {
            }

            public UGOVORORADUDuplicateKeyException(string message) : base(message)
            {
            }

            protected UGOVORORADUDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UGOVORORADUDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class UGOVORORADUEventArgs : EventArgs
        {
            private UGOVORORADUDataSet.UGOVORORADURow m_dataRow;
            private System.Data.StatementType m_statementType;

            public UGOVORORADUEventArgs(UGOVORORADUDataSet.UGOVORORADURow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public UGOVORORADUDataSet.UGOVORORADURow Row
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
        public class UGOVORORADUNotFoundException : DataNotFoundException
        {
            public UGOVORORADUNotFoundException()
            {
            }

            public UGOVORORADUNotFoundException(string message) : base(message)
            {
            }

            protected UGOVORORADUNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UGOVORORADUNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void UGOVORORADUUpdateEventHandler(object sender, UGOVORORADUDataAdapter.UGOVORORADUEventArgs e);
    }
}

