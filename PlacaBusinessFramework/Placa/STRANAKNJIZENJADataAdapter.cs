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

    public class STRANAKNJIZENJADataAdapter : IDataAdapter, ISTRANAKNJIZENJADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmSTRANAKNJIZENJASelect1;
        private ReadWriteCommand cmSTRANAKNJIZENJASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVSTRANEOriginal;
        private readonly string m_SelectString158 = "TM1.[IDSTRANA], TM1.[NAZIVSTRANE]";
        private string m_WhereString;
        private short RcdFound158;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private STRANAKNJIZENJADataSet.STRANAKNJIZENJARow rowSTRANAKNJIZENJA;
        private string scmdbuf;
        private StatementType sMode158;
        private IDataReader STRANAKNJIZENJASelect1;
        private IDataReader STRANAKNJIZENJASelect4;
        private STRANAKNJIZENJADataSet STRANAKNJIZENJASet;

        public event STRANAKNJIZENJAUpdateEventHandler STRANAKNJIZENJAUpdated;

        public event STRANAKNJIZENJAUpdateEventHandler STRANAKNJIZENJAUpdating;

        private void AddRowStranaknjizenja()
        {
            this.STRANAKNJIZENJASet.STRANAKNJIZENJA.AddSTRANAKNJIZENJARow(this.rowSTRANAKNJIZENJA);
        }

        private void AfterConfirmStranaknjizenja()
        {
            this.OnSTRANAKNJIZENJAUpdating(new STRANAKNJIZENJAEventArgs(this.rowSTRANAKNJIZENJA, this.Gx_mode));
        }

        private void CheckDeleteErrorsStranaknjizenja()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDIRA], [IRAGODINA], [IDDOKUMENT], [IDORGJED] FROM [IRAidmje] WITH (NOLOCK) WHERE [IDSTRANA] = @IDSTRANA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANAKNJIZENJA["IDSTRANA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new IRAidmjeInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "idmje" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyStranaknjizenja()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSTRANA], [NAZIVSTRANE] FROM [STRANAKNJIZENJA] WITH (UPDLOCK) WHERE [IDSTRANA] = @IDSTRANA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANAKNJIZENJA["IDSTRANA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new STRANAKNJIZENJADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("STRANAKNJIZENJA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVSTRANEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new STRANAKNJIZENJADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("STRANAKNJIZENJA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowStranaknjizenja()
        {
            this.rowSTRANAKNJIZENJA = this.STRANAKNJIZENJASet.STRANAKNJIZENJA.NewSTRANAKNJIZENJARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyStranaknjizenja();
            this.AfterConfirmStranaknjizenja();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [STRANAKNJIZENJA]  WHERE [IDSTRANA] = @IDSTRANA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANAKNJIZENJA["IDSTRANA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsStranaknjizenja();
            }
            this.OnSTRANAKNJIZENJAUpdated(new STRANAKNJIZENJAEventArgs(this.rowSTRANAKNJIZENJA, StatementType.Delete));
            this.rowSTRANAKNJIZENJA.Delete();
            this.sMode158 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode158;
        }

        public virtual int Fill(STRANAKNJIZENJADataSet dataSet)
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
                    this.STRANAKNJIZENJASet = dataSet;
                    this.LoadChildStranaknjizenja(0, -1);
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
            this.STRANAKNJIZENJASet = (STRANAKNJIZENJADataSet) dataSet;
            if (this.STRANAKNJIZENJASet != null)
            {
                return this.Fill(this.STRANAKNJIZENJASet);
            }
            this.STRANAKNJIZENJASet = new STRANAKNJIZENJADataSet();
            this.Fill(this.STRANAKNJIZENJASet);
            dataSet.Merge(this.STRANAKNJIZENJASet);
            return 0;
        }

        public virtual int Fill(STRANAKNJIZENJADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSTRANA"]));
        }

        public virtual int Fill(STRANAKNJIZENJADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSTRANA"]));
        }

        public virtual int Fill(STRANAKNJIZENJADataSet dataSet, int iDSTRANA)
        {
            if (!this.FillByIDSTRANA(dataSet, iDSTRANA))
            {
                throw new STRANAKNJIZENJANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("STRANAKNJIZENJA") }));
            }
            return 0;
        }

        public virtual bool FillByIDSTRANA(STRANAKNJIZENJADataSet dataSet, int iDSTRANA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.STRANAKNJIZENJASet = dataSet;
            this.rowSTRANAKNJIZENJA = this.STRANAKNJIZENJASet.STRANAKNJIZENJA.NewSTRANAKNJIZENJARow();
            this.rowSTRANAKNJIZENJA.IDSTRANA = iDSTRANA;
            try
            {
                this.LoadByIDSTRANA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound158 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(STRANAKNJIZENJADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.STRANAKNJIZENJASet = dataSet;
            try
            {
                this.LoadChildStranaknjizenja(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSTRANA], [NAZIVSTRANE] FROM [STRANAKNJIZENJA] WITH (NOLOCK) WHERE [IDSTRANA] = @IDSTRANA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANAKNJIZENJA["IDSTRANA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound158 = 1;
                this.rowSTRANAKNJIZENJA["IDSTRANA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowSTRANAKNJIZENJA["NAZIVSTRANE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode158 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode158;
            }
            else
            {
                this.RcdFound158 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDSTRANA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSTRANAKNJIZENJASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [STRANAKNJIZENJA] WITH (NOLOCK) ", false);
            this.STRANAKNJIZENJASelect1 = this.cmSTRANAKNJIZENJASelect1.FetchData();
            if (this.STRANAKNJIZENJASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.STRANAKNJIZENJASelect1.GetInt32(0);
            }
            this.STRANAKNJIZENJASelect1.Close();
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
            this.RcdFound158 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVSTRANEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.STRANAKNJIZENJASet = new STRANAKNJIZENJADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertStranaknjizenja()
        {
            this.CheckOptimisticConcurrencyStranaknjizenja();
            this.AfterConfirmStranaknjizenja();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [STRANAKNJIZENJA] ([IDSTRANA], [NAZIVSTRANE]) VALUES (@IDSTRANA, @NAZIVSTRANE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSTRANE", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANAKNJIZENJA["IDSTRANA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSTRANAKNJIZENJA["NAZIVSTRANE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new STRANAKNJIZENJADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnSTRANAKNJIZENJAUpdated(new STRANAKNJIZENJAEventArgs(this.rowSTRANAKNJIZENJA, StatementType.Insert));
        }

        private void LoadByIDSTRANA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.STRANAKNJIZENJASet.EnforceConstraints;
            this.STRANAKNJIZENJASet.STRANAKNJIZENJA.BeginLoadData();
            this.ScanByIDSTRANA(startRow, maxRows);
            this.STRANAKNJIZENJASet.STRANAKNJIZENJA.EndLoadData();
            this.STRANAKNJIZENJASet.EnforceConstraints = enforceConstraints;
            if (this.STRANAKNJIZENJASet.STRANAKNJIZENJA.Count > 0)
            {
                this.rowSTRANAKNJIZENJA = this.STRANAKNJIZENJASet.STRANAKNJIZENJA[this.STRANAKNJIZENJASet.STRANAKNJIZENJA.Count - 1];
            }
        }

        private void LoadChildStranaknjizenja(int startRow, int maxRows)
        {
            this.CreateNewRowStranaknjizenja();
            bool enforceConstraints = this.STRANAKNJIZENJASet.EnforceConstraints;
            this.STRANAKNJIZENJASet.STRANAKNJIZENJA.BeginLoadData();
            this.ScanStartStranaknjizenja(startRow, maxRows);
            this.STRANAKNJIZENJASet.STRANAKNJIZENJA.EndLoadData();
            this.STRANAKNJIZENJASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataStranaknjizenja(int maxRows)
        {
            int num = 0;
            if (this.RcdFound158 != 0)
            {
                this.ScanLoadStranaknjizenja();
                while ((this.RcdFound158 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowStranaknjizenja();
                    this.CreateNewRowStranaknjizenja();
                    this.ScanNextStranaknjizenja();
                }
            }
            if (num > 0)
            {
                this.RcdFound158 = 1;
            }
            this.ScanEndStranaknjizenja();
            if (this.STRANAKNJIZENJASet.STRANAKNJIZENJA.Count > 0)
            {
                this.rowSTRANAKNJIZENJA = this.STRANAKNJIZENJASet.STRANAKNJIZENJA[this.STRANAKNJIZENJASet.STRANAKNJIZENJA.Count - 1];
            }
        }

        private void LoadRowStranaknjizenja()
        {
            this.AddRowStranaknjizenja();
        }

        private void OnSTRANAKNJIZENJAUpdated(STRANAKNJIZENJAEventArgs e)
        {
            if (this.STRANAKNJIZENJAUpdated != null)
            {
                STRANAKNJIZENJAUpdateEventHandler sTRANAKNJIZENJAUpdatedEvent = this.STRANAKNJIZENJAUpdated;
                if (sTRANAKNJIZENJAUpdatedEvent != null)
                {
                    sTRANAKNJIZENJAUpdatedEvent(this, e);
                }
            }
        }

        private void OnSTRANAKNJIZENJAUpdating(STRANAKNJIZENJAEventArgs e)
        {
            if (this.STRANAKNJIZENJAUpdating != null)
            {
                STRANAKNJIZENJAUpdateEventHandler sTRANAKNJIZENJAUpdatingEvent = this.STRANAKNJIZENJAUpdating;
                if (sTRANAKNJIZENJAUpdatingEvent != null)
                {
                    sTRANAKNJIZENJAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowStranaknjizenja()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSTRANAKNJIZENJA.RowState);
            if (this.rowSTRANAKNJIZENJA.RowState != DataRowState.Added)
            {
                this.m__NAZIVSTRANEOriginal = RuntimeHelpers.GetObjectValue(this.rowSTRANAKNJIZENJA["NAZIVSTRANE", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVSTRANEOriginal = RuntimeHelpers.GetObjectValue(this.rowSTRANAKNJIZENJA["NAZIVSTRANE"]);
            }
            this._Gxremove = this.rowSTRANAKNJIZENJA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowSTRANAKNJIZENJA = (STRANAKNJIZENJADataSet.STRANAKNJIZENJARow) DataSetUtil.CloneOriginalDataRow(this.rowSTRANAKNJIZENJA);
            }
        }

        private void ScanByIDSTRANA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDSTRANA] = @IDSTRANA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString158 + "  FROM [STRANAKNJIZENJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSTRANA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString158, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSTRANA] ) AS DK_PAGENUM   FROM [STRANAKNJIZENJA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString158 + " FROM [STRANAKNJIZENJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSTRANA] ";
            }
            this.cmSTRANAKNJIZENJASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmSTRANAKNJIZENJASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmSTRANAKNJIZENJASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANA", DbType.Int32));
            }
            this.cmSTRANAKNJIZENJASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANAKNJIZENJA["IDSTRANA"]));
            this.STRANAKNJIZENJASelect4 = this.cmSTRANAKNJIZENJASelect4.FetchData();
            this.RcdFound158 = 0;
            this.ScanLoadStranaknjizenja();
            this.LoadDataStranaknjizenja(maxRows);
        }

        private void ScanEndStranaknjizenja()
        {
            this.STRANAKNJIZENJASelect4.Close();
        }

        private void ScanLoadStranaknjizenja()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSTRANAKNJIZENJASelect4.HasMoreRows)
            {
                this.RcdFound158 = 1;
                this.rowSTRANAKNJIZENJA["IDSTRANA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.STRANAKNJIZENJASelect4, 0));
                this.rowSTRANAKNJIZENJA["NAZIVSTRANE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.STRANAKNJIZENJASelect4, 1));
            }
        }

        private void ScanNextStranaknjizenja()
        {
            this.cmSTRANAKNJIZENJASelect4.HasMoreRows = this.STRANAKNJIZENJASelect4.Read();
            this.RcdFound158 = 0;
            this.ScanLoadStranaknjizenja();
        }

        private void ScanStartStranaknjizenja(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString158 + "  FROM [STRANAKNJIZENJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSTRANA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString158, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSTRANA] ) AS DK_PAGENUM   FROM [STRANAKNJIZENJA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString158 + " FROM [STRANAKNJIZENJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSTRANA] ";
            }
            this.cmSTRANAKNJIZENJASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.STRANAKNJIZENJASelect4 = this.cmSTRANAKNJIZENJASelect4.FetchData();
            this.RcdFound158 = 0;
            this.ScanLoadStranaknjizenja();
            this.LoadDataStranaknjizenja(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.STRANAKNJIZENJASet = (STRANAKNJIZENJADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.STRANAKNJIZENJASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.STRANAKNJIZENJASet.STRANAKNJIZENJA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        STRANAKNJIZENJADataSet.STRANAKNJIZENJARow current = (STRANAKNJIZENJADataSet.STRANAKNJIZENJARow) enumerator.Current;
                        this.rowSTRANAKNJIZENJA = current;
                        if (Helpers.IsRowChanged(this.rowSTRANAKNJIZENJA))
                        {
                            this.ReadRowStranaknjizenja();
                            if (this.rowSTRANAKNJIZENJA.RowState == DataRowState.Added)
                            {
                                this.InsertStranaknjizenja();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateStranaknjizenja();
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

        private void UpdateStranaknjizenja()
        {
            this.CheckOptimisticConcurrencyStranaknjizenja();
            this.AfterConfirmStranaknjizenja();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [STRANAKNJIZENJA] SET [NAZIVSTRANE]=@NAZIVSTRANE  WHERE [IDSTRANA] = @IDSTRANA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSTRANE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANAKNJIZENJA["NAZIVSTRANE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSTRANAKNJIZENJA["IDSTRANA"]));
            command.ExecuteStmt();
            this.OnSTRANAKNJIZENJAUpdated(new STRANAKNJIZENJAEventArgs(this.rowSTRANAKNJIZENJA, StatementType.Update));
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
        public class IRAidmjeInvalidDeleteException : InvalidDeleteException
        {
            public IRAidmjeInvalidDeleteException()
            {
            }

            public IRAidmjeInvalidDeleteException(string message) : base(message)
            {
            }

            protected IRAidmjeInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IRAidmjeInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class STRANAKNJIZENJADataChangedException : DataChangedException
        {
            public STRANAKNJIZENJADataChangedException()
            {
            }

            public STRANAKNJIZENJADataChangedException(string message) : base(message)
            {
            }

            protected STRANAKNJIZENJADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRANAKNJIZENJADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class STRANAKNJIZENJADataLockedException : DataLockedException
        {
            public STRANAKNJIZENJADataLockedException()
            {
            }

            public STRANAKNJIZENJADataLockedException(string message) : base(message)
            {
            }

            protected STRANAKNJIZENJADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRANAKNJIZENJADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class STRANAKNJIZENJADuplicateKeyException : DuplicateKeyException
        {
            public STRANAKNJIZENJADuplicateKeyException()
            {
            }

            public STRANAKNJIZENJADuplicateKeyException(string message) : base(message)
            {
            }

            protected STRANAKNJIZENJADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRANAKNJIZENJADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class STRANAKNJIZENJAEventArgs : EventArgs
        {
            private STRANAKNJIZENJADataSet.STRANAKNJIZENJARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public STRANAKNJIZENJAEventArgs(STRANAKNJIZENJADataSet.STRANAKNJIZENJARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public STRANAKNJIZENJADataSet.STRANAKNJIZENJARow Row
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
        public class STRANAKNJIZENJANotFoundException : DataNotFoundException
        {
            public STRANAKNJIZENJANotFoundException()
            {
            }

            public STRANAKNJIZENJANotFoundException(string message) : base(message)
            {
            }

            protected STRANAKNJIZENJANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRANAKNJIZENJANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void STRANAKNJIZENJAUpdateEventHandler(object sender, STRANAKNJIZENJADataAdapter.STRANAKNJIZENJAEventArgs e);
    }
}

