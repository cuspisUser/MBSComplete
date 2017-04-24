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

    public class FINPOREZDataAdapter : IDataAdapter, IFINPOREZDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmFINPOREZSelect1;
        private ReadWriteCommand cmFINPOREZSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private IDataReader FINPOREZSelect1;
        private IDataReader FINPOREZSelect4;
        private FINPOREZDataSet FINPOREZSet;
        private StatementType Gx_mode;
        private object m__FINPOREZNAZIVPOREZOriginal;
        private object m__FINPOREZSTOPAOriginal;
        private object m__OSNOVICAUKNIZIIRAOriginal;
        private readonly string m_SelectString206 = "TM1.[FINPOREZIDPOREZ], TM1.[FINPOREZNAZIVPOREZ], TM1.[FINPOREZSTOPA], TM1.[OSNOVICAUKNIZIIRA]";
        private string m_WhereString;
        private short RcdFound206;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private FINPOREZDataSet.FINPOREZRow rowFINPOREZ;
        private string scmdbuf;
        private StatementType sMode206;

        public event FINPOREZUpdateEventHandler FINPOREZUpdated;

        public event FINPOREZUpdateEventHandler FINPOREZUpdating;

        private void AddRowFinporez()
        {
            this.FINPOREZSet.FINPOREZ.AddFINPOREZRow(this.rowFINPOREZ);
        }

        private void AfterConfirmFinporez()
        {
            this.OnFINPOREZUpdating(new FINPOREZEventArgs(this.rowFINPOREZ, this.Gx_mode));
        }

        private void CheckDeleteErrorsFinporez()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDPROIZVOD] FROM [PROIZVOD] WITH (NOLOCK) WHERE [FINPOREZIDPOREZ] = @FINPOREZIDPOREZ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZIDPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowFINPOREZ["FINPOREZIDPOREZ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new PROIZVODInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "PROIZVOD" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyFinporez()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [FINPOREZIDPOREZ], [FINPOREZNAZIVPOREZ], [FINPOREZSTOPA], [OSNOVICAUKNIZIIRA] FROM [FINPOREZ] WITH (UPDLOCK) WHERE [FINPOREZIDPOREZ] = @FINPOREZIDPOREZ ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZIDPOREZ", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowFINPOREZ["FINPOREZIDPOREZ"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new FINPOREZDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("FINPOREZ") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__FINPOREZNAZIVPOREZOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || (!this.m__FINPOREZSTOPAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))) || !this.m__OSNOVICAUKNIZIIRAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 3)))))
                {
                    reader.Close();
                    throw new FINPOREZDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("FINPOREZ") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowFinporez()
        {
            this.rowFINPOREZ = this.FINPOREZSet.FINPOREZ.NewFINPOREZRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyFinporez();
            this.AfterConfirmFinporez();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [FINPOREZ]  WHERE [FINPOREZIDPOREZ] = @FINPOREZIDPOREZ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZIDPOREZ", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowFINPOREZ["FINPOREZIDPOREZ"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsFinporez();
            }
            this.OnFINPOREZUpdated(new FINPOREZEventArgs(this.rowFINPOREZ, StatementType.Delete));
            this.rowFINPOREZ.Delete();
            this.sMode206 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode206;
        }

        public virtual int Fill(FINPOREZDataSet dataSet)
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
                    this.FINPOREZSet = dataSet;
                    this.LoadChildFinporez(0, -1);
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
            this.FINPOREZSet = (FINPOREZDataSet) dataSet;
            if (this.FINPOREZSet != null)
            {
                return this.Fill(this.FINPOREZSet);
            }
            this.FINPOREZSet = new FINPOREZDataSet();
            this.Fill(this.FINPOREZSet);
            dataSet.Merge(this.FINPOREZSet);
            return 0;
        }

        public virtual int Fill(FINPOREZDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["FINPOREZIDPOREZ"]));
        }

        public virtual int Fill(FINPOREZDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["FINPOREZIDPOREZ"]));
        }

        public virtual int Fill(FINPOREZDataSet dataSet, int fINPOREZIDPOREZ)
        {
            if (!this.FillByFINPOREZIDPOREZ(dataSet, fINPOREZIDPOREZ))
            {
                throw new FINPOREZNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("FINPOREZ") }));
            }
            return 0;
        }

        public virtual bool FillByFINPOREZIDPOREZ(FINPOREZDataSet dataSet, int fINPOREZIDPOREZ)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.FINPOREZSet = dataSet;
            this.rowFINPOREZ = this.FINPOREZSet.FINPOREZ.NewFINPOREZRow();
            this.rowFINPOREZ.FINPOREZIDPOREZ = fINPOREZIDPOREZ;
            try
            {
                this.LoadByFINPOREZIDPOREZ(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound206 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(FINPOREZDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.FINPOREZSet = dataSet;
            try
            {
                this.LoadChildFinporez(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [FINPOREZIDPOREZ], [FINPOREZNAZIVPOREZ], [FINPOREZSTOPA], [OSNOVICAUKNIZIIRA] FROM [FINPOREZ] WITH (NOLOCK) WHERE [FINPOREZIDPOREZ] = @FINPOREZIDPOREZ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZIDPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowFINPOREZ["FINPOREZIDPOREZ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound206 = 1;
                this.rowFINPOREZ["FINPOREZIDPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowFINPOREZ["FINPOREZNAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowFINPOREZ["FINPOREZSTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
                this.rowFINPOREZ["OSNOVICAUKNIZIIRA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 3));
                this.sMode206 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode206;
            }
            else
            {
                this.RcdFound206 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "FINPOREZIDPOREZ";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmFINPOREZSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [FINPOREZ] WITH (NOLOCK) ", false);
            this.FINPOREZSelect1 = this.cmFINPOREZSelect1.FetchData();
            if (this.FINPOREZSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.FINPOREZSelect1.GetInt32(0);
            }
            this.FINPOREZSelect1.Close();
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
            this.RcdFound206 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__FINPOREZNAZIVPOREZOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__FINPOREZSTOPAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OSNOVICAUKNIZIIRAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.FINPOREZSet = new FINPOREZDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertFinporez()
        {
            this.CheckOptimisticConcurrencyFinporez();
            this.AfterConfirmFinporez();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [FINPOREZ] ([FINPOREZIDPOREZ], [FINPOREZNAZIVPOREZ], [FINPOREZSTOPA], [OSNOVICAUKNIZIIRA]) VALUES (@FINPOREZIDPOREZ, @FINPOREZNAZIVPOREZ, @FINPOREZSTOPA, @OSNOVICAUKNIZIIRA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZIDPOREZ", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZNAZIVPOREZ", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZSTOPA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICAUKNIZIIRA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowFINPOREZ["FINPOREZIDPOREZ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowFINPOREZ["FINPOREZNAZIVPOREZ"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowFINPOREZ["FINPOREZSTOPA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowFINPOREZ["OSNOVICAUKNIZIIRA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new FINPOREZDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnFINPOREZUpdated(new FINPOREZEventArgs(this.rowFINPOREZ, StatementType.Insert));
        }

        private void LoadByFINPOREZIDPOREZ(int startRow, int maxRows)
        {
            bool enforceConstraints = this.FINPOREZSet.EnforceConstraints;
            this.FINPOREZSet.FINPOREZ.BeginLoadData();
            this.ScanByFINPOREZIDPOREZ(startRow, maxRows);
            this.FINPOREZSet.FINPOREZ.EndLoadData();
            this.FINPOREZSet.EnforceConstraints = enforceConstraints;
            if (this.FINPOREZSet.FINPOREZ.Count > 0)
            {
                this.rowFINPOREZ = this.FINPOREZSet.FINPOREZ[this.FINPOREZSet.FINPOREZ.Count - 1];
            }
        }

        private void LoadChildFinporez(int startRow, int maxRows)
        {
            this.CreateNewRowFinporez();
            bool enforceConstraints = this.FINPOREZSet.EnforceConstraints;
            this.FINPOREZSet.FINPOREZ.BeginLoadData();
            this.ScanStartFinporez(startRow, maxRows);
            this.FINPOREZSet.FINPOREZ.EndLoadData();
            this.FINPOREZSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataFinporez(int maxRows)
        {
            int num = 0;
            if (this.RcdFound206 != 0)
            {
                this.ScanLoadFinporez();
                while ((this.RcdFound206 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowFinporez();
                    this.CreateNewRowFinporez();
                    this.ScanNextFinporez();
                }
            }
            if (num > 0)
            {
                this.RcdFound206 = 1;
            }
            this.ScanEndFinporez();
            if (this.FINPOREZSet.FINPOREZ.Count > 0)
            {
                this.rowFINPOREZ = this.FINPOREZSet.FINPOREZ[this.FINPOREZSet.FINPOREZ.Count - 1];
            }
        }

        private void LoadRowFinporez()
        {
            this.AddRowFinporez();
        }

        private void OnFINPOREZUpdated(FINPOREZEventArgs e)
        {
            if (this.FINPOREZUpdated != null)
            {
                FINPOREZUpdateEventHandler fINPOREZUpdatedEvent = this.FINPOREZUpdated;
                if (fINPOREZUpdatedEvent != null)
                {
                    fINPOREZUpdatedEvent(this, e);
                }
            }
        }

        private void OnFINPOREZUpdating(FINPOREZEventArgs e)
        {
            if (this.FINPOREZUpdating != null)
            {
                FINPOREZUpdateEventHandler fINPOREZUpdatingEvent = this.FINPOREZUpdating;
                if (fINPOREZUpdatingEvent != null)
                {
                    fINPOREZUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowFinporez()
        {
            this.Gx_mode = Mode.FromRowState(this.rowFINPOREZ.RowState);
            if (this.rowFINPOREZ.RowState != DataRowState.Added)
            {
                this.m__FINPOREZNAZIVPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowFINPOREZ["FINPOREZNAZIVPOREZ", DataRowVersion.Original]);
                this.m__FINPOREZSTOPAOriginal = RuntimeHelpers.GetObjectValue(this.rowFINPOREZ["FINPOREZSTOPA", DataRowVersion.Original]);
                this.m__OSNOVICAUKNIZIIRAOriginal = RuntimeHelpers.GetObjectValue(this.rowFINPOREZ["OSNOVICAUKNIZIIRA", DataRowVersion.Original]);
            }
            else
            {
                this.m__FINPOREZNAZIVPOREZOriginal = RuntimeHelpers.GetObjectValue(this.rowFINPOREZ["FINPOREZNAZIVPOREZ"]);
                this.m__FINPOREZSTOPAOriginal = RuntimeHelpers.GetObjectValue(this.rowFINPOREZ["FINPOREZSTOPA"]);
                this.m__OSNOVICAUKNIZIIRAOriginal = RuntimeHelpers.GetObjectValue(this.rowFINPOREZ["OSNOVICAUKNIZIIRA"]);
            }
            this._Gxremove = this.rowFINPOREZ.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowFINPOREZ = (FINPOREZDataSet.FINPOREZRow) DataSetUtil.CloneOriginalDataRow(this.rowFINPOREZ);
            }
        }

        private void ScanByFINPOREZIDPOREZ(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[FINPOREZIDPOREZ] = @FINPOREZIDPOREZ";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString206 + "  FROM [FINPOREZ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[FINPOREZIDPOREZ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString206, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[FINPOREZIDPOREZ] ) AS DK_PAGENUM   FROM [FINPOREZ] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString206 + " FROM [FINPOREZ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[FINPOREZIDPOREZ] ";
            }
            this.cmFINPOREZSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmFINPOREZSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmFINPOREZSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZIDPOREZ", DbType.Int32));
            }
            this.cmFINPOREZSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowFINPOREZ["FINPOREZIDPOREZ"]));
            this.FINPOREZSelect4 = this.cmFINPOREZSelect4.FetchData();
            this.RcdFound206 = 0;
            this.ScanLoadFinporez();
            this.LoadDataFinporez(maxRows);
        }

        private void ScanEndFinporez()
        {
            this.FINPOREZSelect4.Close();
        }

        private void ScanLoadFinporez()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmFINPOREZSelect4.HasMoreRows)
            {
                this.RcdFound206 = 1;
                this.rowFINPOREZ["FINPOREZIDPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.FINPOREZSelect4, 0));
                this.rowFINPOREZ["FINPOREZNAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.FINPOREZSelect4, 1));
                this.rowFINPOREZ["FINPOREZSTOPA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.FINPOREZSelect4, 2));
                this.rowFINPOREZ["OSNOVICAUKNIZIIRA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.FINPOREZSelect4, 3));
            }
        }

        private void ScanNextFinporez()
        {
            this.cmFINPOREZSelect4.HasMoreRows = this.FINPOREZSelect4.Read();
            this.RcdFound206 = 0;
            this.ScanLoadFinporez();
        }

        private void ScanStartFinporez(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString206 + "  FROM [FINPOREZ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[FINPOREZIDPOREZ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString206, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[FINPOREZIDPOREZ] ) AS DK_PAGENUM   FROM [FINPOREZ] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString206 + " FROM [FINPOREZ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[FINPOREZIDPOREZ] ";
            }
            this.cmFINPOREZSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.FINPOREZSelect4 = this.cmFINPOREZSelect4.FetchData();
            this.RcdFound206 = 0;
            this.ScanLoadFinporez();
            this.LoadDataFinporez(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.FINPOREZSet = (FINPOREZDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.FINPOREZSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.FINPOREZSet.FINPOREZ.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        FINPOREZDataSet.FINPOREZRow current = (FINPOREZDataSet.FINPOREZRow) enumerator.Current;
                        this.rowFINPOREZ = current;
                        if (Helpers.IsRowChanged(this.rowFINPOREZ))
                        {
                            this.ReadRowFinporez();
                            if (this.rowFINPOREZ.RowState == DataRowState.Added)
                            {
                                this.InsertFinporez();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateFinporez();
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

        private void UpdateFinporez()
        {
            this.CheckOptimisticConcurrencyFinporez();
            this.AfterConfirmFinporez();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [FINPOREZ] SET [FINPOREZNAZIVPOREZ]=@FINPOREZNAZIVPOREZ, [FINPOREZSTOPA]=@FINPOREZSTOPA, [OSNOVICAUKNIZIIRA]=@OSNOVICAUKNIZIIRA  WHERE [FINPOREZIDPOREZ] = @FINPOREZIDPOREZ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZNAZIVPOREZ", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZSTOPA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OSNOVICAUKNIZIIRA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZIDPOREZ", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowFINPOREZ["FINPOREZNAZIVPOREZ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowFINPOREZ["FINPOREZSTOPA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowFINPOREZ["OSNOVICAUKNIZIIRA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowFINPOREZ["FINPOREZIDPOREZ"]));
            command.ExecuteStmt();
            this.OnFINPOREZUpdated(new FINPOREZEventArgs(this.rowFINPOREZ, StatementType.Update));
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
        public class FINPOREZDataChangedException : DataChangedException
        {
            public FINPOREZDataChangedException()
            {
            }

            public FINPOREZDataChangedException(string message) : base(message)
            {
            }

            protected FINPOREZDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public FINPOREZDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class FINPOREZDataLockedException : DataLockedException
        {
            public FINPOREZDataLockedException()
            {
            }

            public FINPOREZDataLockedException(string message) : base(message)
            {
            }

            protected FINPOREZDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public FINPOREZDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class FINPOREZDuplicateKeyException : DuplicateKeyException
        {
            public FINPOREZDuplicateKeyException()
            {
            }

            public FINPOREZDuplicateKeyException(string message) : base(message)
            {
            }

            protected FINPOREZDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public FINPOREZDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class FINPOREZEventArgs : EventArgs
        {
            private FINPOREZDataSet.FINPOREZRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public FINPOREZEventArgs(FINPOREZDataSet.FINPOREZRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public FINPOREZDataSet.FINPOREZRow Row
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
        public class FINPOREZNotFoundException : DataNotFoundException
        {
            public FINPOREZNotFoundException()
            {
            }

            public FINPOREZNotFoundException(string message) : base(message)
            {
            }

            protected FINPOREZNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public FINPOREZNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void FINPOREZUpdateEventHandler(object sender, FINPOREZDataAdapter.FINPOREZEventArgs e);

        [Serializable]
        public class PROIZVODInvalidDeleteException : InvalidDeleteException
        {
            public PROIZVODInvalidDeleteException()
            {
            }

            public PROIZVODInvalidDeleteException(string message) : base(message)
            {
            }

            protected PROIZVODInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PROIZVODInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

