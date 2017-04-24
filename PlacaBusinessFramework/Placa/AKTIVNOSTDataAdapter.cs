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

    public class AKTIVNOSTDataAdapter : IDataAdapter, IAKTIVNOSTDataAdapter
    {
        private bool _Gxremove;
        private IDataReader AKTIVNOSTSelect1;
        private IDataReader AKTIVNOSTSelect4;
        private AKTIVNOSTDataSet AKTIVNOSTSet;
        private ReadWriteCommand cmAKTIVNOSTSelect1;
        private ReadWriteCommand cmAKTIVNOSTSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVAKTIVNOSTOriginal;
        private readonly string m_SelectString179 = "TM1.[IDAKTIVNOST], TM1.[NAZIVAKTIVNOST]";
        private string m_WhereString;
        private short RcdFound179;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private AKTIVNOSTDataSet.AKTIVNOSTRow rowAKTIVNOST;
        private string scmdbuf;
        private StatementType sMode179;

        public event AKTIVNOSTUpdateEventHandler AKTIVNOSTUpdated;

        public event AKTIVNOSTUpdateEventHandler AKTIVNOSTUpdating;

        private void AddRowAktivnost()
        {
            this.AKTIVNOSTSet.AKTIVNOST.AddAKTIVNOSTRow(this.rowAKTIVNOST);
        }

        private void AfterConfirmAktivnost()
        {
            this.OnAKTIVNOSTUpdating(new AKTIVNOSTEventArgs(this.rowAKTIVNOST, this.Gx_mode));
        }

        private void CheckDeleteErrorsAktivnost()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDKONTO] FROM [KONTO] WITH (NOLOCK) WHERE [IDAKTIVNOST] = @IDAKTIVNOST ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowAKTIVNOST["IDAKTIVNOST"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new KONTOInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Kontni plan" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyAktivnost()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDAKTIVNOST], [NAZIVAKTIVNOST] FROM [AKTIVNOST] WITH (UPDLOCK) WHERE [IDAKTIVNOST] = @IDAKTIVNOST ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowAKTIVNOST["IDAKTIVNOST"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new AKTIVNOSTDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("AKTIVNOST") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVAKTIVNOSTOriginal), RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))))
                {
                    reader.Close();
                    throw new AKTIVNOSTDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("AKTIVNOST") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowAktivnost()
        {
            this.rowAKTIVNOST = this.AKTIVNOSTSet.AKTIVNOST.NewAKTIVNOSTRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyAktivnost();
            this.AfterConfirmAktivnost();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [AKTIVNOST]  WHERE [IDAKTIVNOST] = @IDAKTIVNOST", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowAKTIVNOST["IDAKTIVNOST"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsAktivnost();
            }
            this.OnAKTIVNOSTUpdated(new AKTIVNOSTEventArgs(this.rowAKTIVNOST, StatementType.Delete));
            this.rowAKTIVNOST.Delete();
            this.sMode179 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode179;
        }


        public virtual int Fill(AKTIVNOSTDataSet dataSet)
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
                    this.AKTIVNOSTSet = dataSet;
                    this.LoadChildAktivnost(0, -1);
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
            this.AKTIVNOSTSet = (AKTIVNOSTDataSet) dataSet;
            if (this.AKTIVNOSTSet != null)
            {
                return this.Fill(this.AKTIVNOSTSet);
            }
            this.AKTIVNOSTSet = new AKTIVNOSTDataSet();
            this.Fill(this.AKTIVNOSTSet);
            dataSet.Merge(this.AKTIVNOSTSet);
            return 0;
        }

        public virtual int Fill(AKTIVNOSTDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDAKTIVNOST"]));
        }

        public virtual int Fill(AKTIVNOSTDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDAKTIVNOST"]));
        }

        public virtual int Fill(AKTIVNOSTDataSet dataSet, int iDAKTIVNOST)
        {
            if (!this.FillByIDAKTIVNOST(dataSet, iDAKTIVNOST))
            {
                throw new AKTIVNOSTNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("AKTIVNOST") }));
            }
            return 0;
        }

        public virtual bool FillByIDAKTIVNOST(AKTIVNOSTDataSet dataSet, int iDAKTIVNOST)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.AKTIVNOSTSet = dataSet;
            this.rowAKTIVNOST = this.AKTIVNOSTSet.AKTIVNOST.NewAKTIVNOSTRow();
            this.rowAKTIVNOST.IDAKTIVNOST = iDAKTIVNOST;
            try
            {
                this.LoadByIDAKTIVNOST(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound179 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(AKTIVNOSTDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.AKTIVNOSTSet = dataSet;
            try
            {
                this.LoadChildAktivnost(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDAKTIVNOST], [NAZIVAKTIVNOST] FROM [AKTIVNOST] WITH (NOLOCK) WHERE [IDAKTIVNOST] = @IDAKTIVNOST ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowAKTIVNOST["IDAKTIVNOST"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound179 = 1;
                this.rowAKTIVNOST["IDAKTIVNOST"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowAKTIVNOST["NAZIVAKTIVNOST"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))));
                this.sMode179 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode179;
            }
            else
            {
                this.RcdFound179 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDAKTIVNOST";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmAKTIVNOSTSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [AKTIVNOST] WITH (NOLOCK) ", false);
            this.AKTIVNOSTSelect1 = this.cmAKTIVNOSTSelect1.FetchData();
            if (this.AKTIVNOSTSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.AKTIVNOSTSelect1.GetInt32(0);
            }
            this.AKTIVNOSTSelect1.Close();
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
            this.RcdFound179 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVAKTIVNOSTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.AKTIVNOSTSet = new AKTIVNOSTDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertAktivnost()
        {
            this.CheckOptimisticConcurrencyAktivnost();
            this.AfterConfirmAktivnost();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [AKTIVNOST] ([IDAKTIVNOST], [NAZIVAKTIVNOST]) VALUES (@IDAKTIVNOST, @NAZIVAKTIVNOST)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVAKTIVNOST", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowAKTIVNOST["IDAKTIVNOST"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowAKTIVNOST["NAZIVAKTIVNOST"]))));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new AKTIVNOSTDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnAKTIVNOSTUpdated(new AKTIVNOSTEventArgs(this.rowAKTIVNOST, StatementType.Insert));
        }

        private void LoadByIDAKTIVNOST(int startRow, int maxRows)
        {
            bool enforceConstraints = this.AKTIVNOSTSet.EnforceConstraints;
            this.AKTIVNOSTSet.AKTIVNOST.BeginLoadData();
            this.ScanByIDAKTIVNOST(startRow, maxRows);
            this.AKTIVNOSTSet.AKTIVNOST.EndLoadData();
            this.AKTIVNOSTSet.EnforceConstraints = enforceConstraints;
            if (this.AKTIVNOSTSet.AKTIVNOST.Count > 0)
            {
                this.rowAKTIVNOST = this.AKTIVNOSTSet.AKTIVNOST[this.AKTIVNOSTSet.AKTIVNOST.Count - 1];
            }
        }

        private void LoadChildAktivnost(int startRow, int maxRows)
        {
            this.CreateNewRowAktivnost();
            bool enforceConstraints = this.AKTIVNOSTSet.EnforceConstraints;
            this.AKTIVNOSTSet.AKTIVNOST.BeginLoadData();
            this.ScanStartAktivnost(startRow, maxRows);
            this.AKTIVNOSTSet.AKTIVNOST.EndLoadData();
            this.AKTIVNOSTSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataAktivnost(int maxRows)
        {
            int num = 0;
            if (this.RcdFound179 != 0)
            {
                this.ScanLoadAktivnost();
                while ((this.RcdFound179 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowAktivnost();
                    this.CreateNewRowAktivnost();
                    this.ScanNextAktivnost();
                }
            }
            if (num > 0)
            {
                this.RcdFound179 = 1;
            }
            this.ScanEndAktivnost();
            if (this.AKTIVNOSTSet.AKTIVNOST.Count > 0)
            {
                this.rowAKTIVNOST = this.AKTIVNOSTSet.AKTIVNOST[this.AKTIVNOSTSet.AKTIVNOST.Count - 1];
            }
        }

        private void LoadRowAktivnost()
        {
            this.AddRowAktivnost();
        }

        private void OnAKTIVNOSTUpdated(AKTIVNOSTEventArgs e)
        {
            if (this.AKTIVNOSTUpdated != null)
            {
                AKTIVNOSTUpdateEventHandler aKTIVNOSTUpdatedEvent = this.AKTIVNOSTUpdated;
                if (aKTIVNOSTUpdatedEvent != null)
                {
                    aKTIVNOSTUpdatedEvent(this, e);
                }
            }
        }

        private void OnAKTIVNOSTUpdating(AKTIVNOSTEventArgs e)
        {
            if (this.AKTIVNOSTUpdating != null)
            {
                AKTIVNOSTUpdateEventHandler aKTIVNOSTUpdatingEvent = this.AKTIVNOSTUpdating;
                if (aKTIVNOSTUpdatingEvent != null)
                {
                    aKTIVNOSTUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowAktivnost()
        {
            this.Gx_mode = Mode.FromRowState(this.rowAKTIVNOST.RowState);
            if (this.rowAKTIVNOST.RowState != DataRowState.Added)
            {
                this.m__NAZIVAKTIVNOSTOriginal = RuntimeHelpers.GetObjectValue(this.rowAKTIVNOST["NAZIVAKTIVNOST", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVAKTIVNOSTOriginal = RuntimeHelpers.GetObjectValue(this.rowAKTIVNOST["NAZIVAKTIVNOST"]);
            }
            this._Gxremove = this.rowAKTIVNOST.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowAKTIVNOST = (AKTIVNOSTDataSet.AKTIVNOSTRow) DataSetUtil.CloneOriginalDataRow(this.rowAKTIVNOST);
            }
        }

        private void ScanByIDAKTIVNOST(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDAKTIVNOST] = @IDAKTIVNOST";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString179 + "  FROM [AKTIVNOST] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDAKTIVNOST]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString179, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDAKTIVNOST] ) AS DK_PAGENUM   FROM [AKTIVNOST] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString179 + " FROM [AKTIVNOST] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDAKTIVNOST] ";
            }
            this.cmAKTIVNOSTSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmAKTIVNOSTSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmAKTIVNOSTSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
            }
            this.cmAKTIVNOSTSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowAKTIVNOST["IDAKTIVNOST"]));
            this.AKTIVNOSTSelect4 = this.cmAKTIVNOSTSelect4.FetchData();
            this.RcdFound179 = 0;
            this.ScanLoadAktivnost();
            this.LoadDataAktivnost(maxRows);
        }

        private void ScanEndAktivnost()
        {
            this.AKTIVNOSTSelect4.Close();
        }

        private void ScanLoadAktivnost()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmAKTIVNOSTSelect4.HasMoreRows)
            {
                this.RcdFound179 = 1;
                this.rowAKTIVNOST["IDAKTIVNOST"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.AKTIVNOSTSelect4, 0));
                this.rowAKTIVNOST["NAZIVAKTIVNOST"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.AKTIVNOSTSelect4, 1))));
            }
        }

        private void ScanNextAktivnost()
        {
            this.cmAKTIVNOSTSelect4.HasMoreRows = this.AKTIVNOSTSelect4.Read();
            this.RcdFound179 = 0;
            this.ScanLoadAktivnost();
        }

        private void ScanStartAktivnost(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString179 + "  FROM [AKTIVNOST] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDAKTIVNOST]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString179, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDAKTIVNOST] ) AS DK_PAGENUM   FROM [AKTIVNOST] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString179 + " FROM [AKTIVNOST] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDAKTIVNOST] ";
            }
            this.cmAKTIVNOSTSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.AKTIVNOSTSelect4 = this.cmAKTIVNOSTSelect4.FetchData();
            this.RcdFound179 = 0;
            this.ScanLoadAktivnost();
            this.LoadDataAktivnost(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.AKTIVNOSTSet = (AKTIVNOSTDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.AKTIVNOSTSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.AKTIVNOSTSet.AKTIVNOST.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        AKTIVNOSTDataSet.AKTIVNOSTRow current = (AKTIVNOSTDataSet.AKTIVNOSTRow) enumerator.Current;
                        this.rowAKTIVNOST = current;
                        if (Helpers.IsRowChanged(this.rowAKTIVNOST))
                        {
                            this.ReadRowAktivnost();
                            if (this.rowAKTIVNOST.RowState == DataRowState.Added)
                            {
                                this.InsertAktivnost();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateAktivnost();
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

        private void UpdateAktivnost()
        {
            this.CheckOptimisticConcurrencyAktivnost();
            this.AfterConfirmAktivnost();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [AKTIVNOST] SET [NAZIVAKTIVNOST]=@NAZIVAKTIVNOST  WHERE [IDAKTIVNOST] = @IDAKTIVNOST", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVAKTIVNOST", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowAKTIVNOST["NAZIVAKTIVNOST"]))));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowAKTIVNOST["IDAKTIVNOST"]));
            command.ExecuteStmt();
            this.OnAKTIVNOSTUpdated(new AKTIVNOSTEventArgs(this.rowAKTIVNOST, StatementType.Update));
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
        public class AKTIVNOSTDataChangedException : DataChangedException
        {
            public AKTIVNOSTDataChangedException()
            {
            }

            public AKTIVNOSTDataChangedException(string message) : base(message)
            {
            }

            protected AKTIVNOSTDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public AKTIVNOSTDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class AKTIVNOSTDataLockedException : DataLockedException
        {
            public AKTIVNOSTDataLockedException()
            {
            }

            public AKTIVNOSTDataLockedException(string message) : base(message)
            {
            }

            protected AKTIVNOSTDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public AKTIVNOSTDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class AKTIVNOSTDuplicateKeyException : DuplicateKeyException
        {
            public AKTIVNOSTDuplicateKeyException()
            {
            }

            public AKTIVNOSTDuplicateKeyException(string message) : base(message)
            {
            }

            protected AKTIVNOSTDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public AKTIVNOSTDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class AKTIVNOSTEventArgs : EventArgs
        {
            private AKTIVNOSTDataSet.AKTIVNOSTRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public AKTIVNOSTEventArgs(AKTIVNOSTDataSet.AKTIVNOSTRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public AKTIVNOSTDataSet.AKTIVNOSTRow Row
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
        public class AKTIVNOSTNotFoundException : DataNotFoundException
        {
            public AKTIVNOSTNotFoundException()
            {
            }

            public AKTIVNOSTNotFoundException(string message) : base(message)
            {
            }

            protected AKTIVNOSTNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public AKTIVNOSTNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void AKTIVNOSTUpdateEventHandler(object sender, AKTIVNOSTDataAdapter.AKTIVNOSTEventArgs e);

        [Serializable]
        public class KONTOInvalidDeleteException : InvalidDeleteException
        {
            public KONTOInvalidDeleteException()
            {
            }

            public KONTOInvalidDeleteException(string message) : base(message)
            {
            }

            protected KONTOInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KONTOInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

