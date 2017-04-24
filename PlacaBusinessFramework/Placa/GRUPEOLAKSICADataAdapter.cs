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

    public class GRUPEOLAKSICADataAdapter : IDataAdapter, IGRUPEOLAKSICADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmGRUPEOLAKSICASelect1;
        private ReadWriteCommand cmGRUPEOLAKSICASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private IDataReader GRUPEOLAKSICASelect1;
        private IDataReader GRUPEOLAKSICASelect4;
        private GRUPEOLAKSICADataSet GRUPEOLAKSICASet;
        private StatementType Gx_mode;
        private object m__MAXIMALNIIZNOSGRUPEOriginal;
        private object m__NAZIVGRUPEOLAKSICAOriginal;
        private readonly string m_SelectString6 = "TM1.[IDGRUPEOLAKSICA], TM1.[NAZIVGRUPEOLAKSICA], TM1.[MAXIMALNIIZNOSGRUPE]";
        private string m_WhereString;
        private short RcdFound6;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private GRUPEOLAKSICADataSet.GRUPEOLAKSICARow rowGRUPEOLAKSICA;
        private string scmdbuf;
        private StatementType sMode6;

        public event GRUPEOLAKSICAUpdateEventHandler GRUPEOLAKSICAUpdated;

        public event GRUPEOLAKSICAUpdateEventHandler GRUPEOLAKSICAUpdating;

        private void AddRowGrupeolaksica()
        {
            this.GRUPEOLAKSICASet.GRUPEOLAKSICA.AddGRUPEOLAKSICARow(this.rowGRUPEOLAKSICA);
        }

        private void AfterConfirmGrupeolaksica()
        {
            this.OnGRUPEOLAKSICAUpdating(new GRUPEOLAKSICAEventArgs(this.rowGRUPEOLAKSICA, this.Gx_mode));
        }

        private void CheckDeleteErrorsGrupeolaksica()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDOLAKSICE] FROM [OLAKSICE] WITH (NOLOCK) WHERE [IDGRUPEOLAKSICA] = @IDGRUPEOLAKSICA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEOLAKSICA["IDGRUPEOLAKSICA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new OLAKSICEInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "OLAKSICE" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyGrupeolaksica()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDGRUPEOLAKSICA], [NAZIVGRUPEOLAKSICA], [MAXIMALNIIZNOSGRUPE] FROM [GRUPEOLAKSICA] WITH (UPDLOCK) WHERE [IDGRUPEOLAKSICA] = @IDGRUPEOLAKSICA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEOLAKSICA["IDGRUPEOLAKSICA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new GRUPEOLAKSICADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("GRUPEOLAKSICA") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVGRUPEOLAKSICAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || !this.m__MAXIMALNIIZNOSGRUPEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))))
                {
                    reader.Close();
                    throw new GRUPEOLAKSICADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("GRUPEOLAKSICA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowGrupeolaksica()
        {
            this.rowGRUPEOLAKSICA = this.GRUPEOLAKSICASet.GRUPEOLAKSICA.NewGRUPEOLAKSICARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyGrupeolaksica();
            this.AfterConfirmGrupeolaksica();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [GRUPEOLAKSICA]  WHERE [IDGRUPEOLAKSICA] = @IDGRUPEOLAKSICA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEOLAKSICA["IDGRUPEOLAKSICA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsGrupeolaksica();
            }
            this.OnGRUPEOLAKSICAUpdated(new GRUPEOLAKSICAEventArgs(this.rowGRUPEOLAKSICA, StatementType.Delete));
            this.rowGRUPEOLAKSICA.Delete();
            this.sMode6 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode6;
        }

        public virtual int Fill(GRUPEOLAKSICADataSet dataSet)
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
                    this.GRUPEOLAKSICASet = dataSet;
                    this.LoadChildGrupeolaksica(0, -1);
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
            this.GRUPEOLAKSICASet = (GRUPEOLAKSICADataSet) dataSet;
            if (this.GRUPEOLAKSICASet != null)
            {
                return this.Fill(this.GRUPEOLAKSICASet);
            }
            this.GRUPEOLAKSICASet = new GRUPEOLAKSICADataSet();
            this.Fill(this.GRUPEOLAKSICASet);
            dataSet.Merge(this.GRUPEOLAKSICASet);
            return 0;
        }

        public virtual int Fill(GRUPEOLAKSICADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDGRUPEOLAKSICA"]));
        }

        public virtual int Fill(GRUPEOLAKSICADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDGRUPEOLAKSICA"]));
        }

        public virtual int Fill(GRUPEOLAKSICADataSet dataSet, int iDGRUPEOLAKSICA)
        {
            if (!this.FillByIDGRUPEOLAKSICA(dataSet, iDGRUPEOLAKSICA))
            {
                throw new GRUPEOLAKSICANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("GRUPEOLAKSICA") }));
            }
            return 0;
        }

        public virtual bool FillByIDGRUPEOLAKSICA(GRUPEOLAKSICADataSet dataSet, int iDGRUPEOLAKSICA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GRUPEOLAKSICASet = dataSet;
            this.rowGRUPEOLAKSICA = this.GRUPEOLAKSICASet.GRUPEOLAKSICA.NewGRUPEOLAKSICARow();
            this.rowGRUPEOLAKSICA.IDGRUPEOLAKSICA = iDGRUPEOLAKSICA;
            try
            {
                this.LoadByIDGRUPEOLAKSICA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound6 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(GRUPEOLAKSICADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GRUPEOLAKSICASet = dataSet;
            try
            {
                this.LoadChildGrupeolaksica(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDGRUPEOLAKSICA], [NAZIVGRUPEOLAKSICA], [MAXIMALNIIZNOSGRUPE] FROM [GRUPEOLAKSICA] WITH (NOLOCK) WHERE [IDGRUPEOLAKSICA] = @IDGRUPEOLAKSICA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEOLAKSICA["IDGRUPEOLAKSICA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound6 = 1;
                this.rowGRUPEOLAKSICA["IDGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowGRUPEOLAKSICA["NAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowGRUPEOLAKSICA["MAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
                this.sMode6 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode6;
            }
            else
            {
                this.RcdFound6 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDGRUPEOLAKSICA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGRUPEOLAKSICASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [GRUPEOLAKSICA] WITH (NOLOCK) ", false);
            this.GRUPEOLAKSICASelect1 = this.cmGRUPEOLAKSICASelect1.FetchData();
            if (this.GRUPEOLAKSICASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.GRUPEOLAKSICASelect1.GetInt32(0);
            }
            this.GRUPEOLAKSICASelect1.Close();
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
            this.RcdFound6 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVGRUPEOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MAXIMALNIIZNOSGRUPEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.GRUPEOLAKSICASet = new GRUPEOLAKSICADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertGrupeolaksica()
        {
            this.CheckOptimisticConcurrencyGrupeolaksica();
            this.AfterConfirmGrupeolaksica();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [GRUPEOLAKSICA] ([IDGRUPEOLAKSICA], [NAZIVGRUPEOLAKSICA], [MAXIMALNIIZNOSGRUPE]) VALUES (@IDGRUPEOLAKSICA, @NAZIVGRUPEOLAKSICA, @MAXIMALNIIZNOSGRUPE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVGRUPEOLAKSICA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MAXIMALNIIZNOSGRUPE", DbType.Currency));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEOLAKSICA["IDGRUPEOLAKSICA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowGRUPEOLAKSICA["NAZIVGRUPEOLAKSICA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowGRUPEOLAKSICA["MAXIMALNIIZNOSGRUPE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new GRUPEOLAKSICADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnGRUPEOLAKSICAUpdated(new GRUPEOLAKSICAEventArgs(this.rowGRUPEOLAKSICA, StatementType.Insert));
        }

        private void LoadByIDGRUPEOLAKSICA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.GRUPEOLAKSICASet.EnforceConstraints;
            this.GRUPEOLAKSICASet.GRUPEOLAKSICA.BeginLoadData();
            this.ScanByIDGRUPEOLAKSICA(startRow, maxRows);
            this.GRUPEOLAKSICASet.GRUPEOLAKSICA.EndLoadData();
            this.GRUPEOLAKSICASet.EnforceConstraints = enforceConstraints;
            if (this.GRUPEOLAKSICASet.GRUPEOLAKSICA.Count > 0)
            {
                this.rowGRUPEOLAKSICA = this.GRUPEOLAKSICASet.GRUPEOLAKSICA[this.GRUPEOLAKSICASet.GRUPEOLAKSICA.Count - 1];
            }
        }

        private void LoadChildGrupeolaksica(int startRow, int maxRows)
        {
            this.CreateNewRowGrupeolaksica();
            bool enforceConstraints = this.GRUPEOLAKSICASet.EnforceConstraints;
            this.GRUPEOLAKSICASet.GRUPEOLAKSICA.BeginLoadData();
            this.ScanStartGrupeolaksica(startRow, maxRows);
            this.GRUPEOLAKSICASet.GRUPEOLAKSICA.EndLoadData();
            this.GRUPEOLAKSICASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataGrupeolaksica(int maxRows)
        {
            int num = 0;
            if (this.RcdFound6 != 0)
            {
                this.ScanLoadGrupeolaksica();
                while ((this.RcdFound6 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowGrupeolaksica();
                    this.CreateNewRowGrupeolaksica();
                    this.ScanNextGrupeolaksica();
                }
            }
            if (num > 0)
            {
                this.RcdFound6 = 1;
            }
            this.ScanEndGrupeolaksica();
            if (this.GRUPEOLAKSICASet.GRUPEOLAKSICA.Count > 0)
            {
                this.rowGRUPEOLAKSICA = this.GRUPEOLAKSICASet.GRUPEOLAKSICA[this.GRUPEOLAKSICASet.GRUPEOLAKSICA.Count - 1];
            }
        }

        private void LoadRowGrupeolaksica()
        {
            this.AddRowGrupeolaksica();
        }

        private void OnGRUPEOLAKSICAUpdated(GRUPEOLAKSICAEventArgs e)
        {
            if (this.GRUPEOLAKSICAUpdated != null)
            {
                GRUPEOLAKSICAUpdateEventHandler gRUPEOLAKSICAUpdatedEvent = this.GRUPEOLAKSICAUpdated;
                if (gRUPEOLAKSICAUpdatedEvent != null)
                {
                    gRUPEOLAKSICAUpdatedEvent(this, e);
                }
            }
        }

        private void OnGRUPEOLAKSICAUpdating(GRUPEOLAKSICAEventArgs e)
        {
            if (this.GRUPEOLAKSICAUpdating != null)
            {
                GRUPEOLAKSICAUpdateEventHandler gRUPEOLAKSICAUpdatingEvent = this.GRUPEOLAKSICAUpdating;
                if (gRUPEOLAKSICAUpdatingEvent != null)
                {
                    gRUPEOLAKSICAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowGrupeolaksica()
        {
            this.Gx_mode = Mode.FromRowState(this.rowGRUPEOLAKSICA.RowState);
            if (this.rowGRUPEOLAKSICA.RowState != DataRowState.Added)
            {
                this.m__NAZIVGRUPEOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowGRUPEOLAKSICA["NAZIVGRUPEOLAKSICA", DataRowVersion.Original]);
                this.m__MAXIMALNIIZNOSGRUPEOriginal = RuntimeHelpers.GetObjectValue(this.rowGRUPEOLAKSICA["MAXIMALNIIZNOSGRUPE", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVGRUPEOLAKSICAOriginal = RuntimeHelpers.GetObjectValue(this.rowGRUPEOLAKSICA["NAZIVGRUPEOLAKSICA"]);
                this.m__MAXIMALNIIZNOSGRUPEOriginal = RuntimeHelpers.GetObjectValue(this.rowGRUPEOLAKSICA["MAXIMALNIIZNOSGRUPE"]);
            }
            this._Gxremove = this.rowGRUPEOLAKSICA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowGRUPEOLAKSICA = (GRUPEOLAKSICADataSet.GRUPEOLAKSICARow) DataSetUtil.CloneOriginalDataRow(this.rowGRUPEOLAKSICA);
            }
        }

        private void ScanByIDGRUPEOLAKSICA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDGRUPEOLAKSICA] = @IDGRUPEOLAKSICA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString6 + "  FROM [GRUPEOLAKSICA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDGRUPEOLAKSICA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString6, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGRUPEOLAKSICA] ) AS DK_PAGENUM   FROM [GRUPEOLAKSICA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString6 + " FROM [GRUPEOLAKSICA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDGRUPEOLAKSICA] ";
            }
            this.cmGRUPEOLAKSICASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmGRUPEOLAKSICASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmGRUPEOLAKSICASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
            }
            this.cmGRUPEOLAKSICASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEOLAKSICA["IDGRUPEOLAKSICA"]));
            this.GRUPEOLAKSICASelect4 = this.cmGRUPEOLAKSICASelect4.FetchData();
            this.RcdFound6 = 0;
            this.ScanLoadGrupeolaksica();
            this.LoadDataGrupeolaksica(maxRows);
        }

        private void ScanEndGrupeolaksica()
        {
            this.GRUPEOLAKSICASelect4.Close();
        }

        private void ScanLoadGrupeolaksica()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmGRUPEOLAKSICASelect4.HasMoreRows)
            {
                this.RcdFound6 = 1;
                this.rowGRUPEOLAKSICA["IDGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.GRUPEOLAKSICASelect4, 0));
                this.rowGRUPEOLAKSICA["NAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GRUPEOLAKSICASelect4, 1));
                this.rowGRUPEOLAKSICA["MAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.GRUPEOLAKSICASelect4, 2));
            }
        }

        private void ScanNextGrupeolaksica()
        {
            this.cmGRUPEOLAKSICASelect4.HasMoreRows = this.GRUPEOLAKSICASelect4.Read();
            this.RcdFound6 = 0;
            this.ScanLoadGrupeolaksica();
        }

        private void ScanStartGrupeolaksica(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString6 + "  FROM [GRUPEOLAKSICA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDGRUPEOLAKSICA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString6, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGRUPEOLAKSICA] ) AS DK_PAGENUM   FROM [GRUPEOLAKSICA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString6 + " FROM [GRUPEOLAKSICA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDGRUPEOLAKSICA] ";
            }
            this.cmGRUPEOLAKSICASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.GRUPEOLAKSICASelect4 = this.cmGRUPEOLAKSICASelect4.FetchData();
            this.RcdFound6 = 0;
            this.ScanLoadGrupeolaksica();
            this.LoadDataGrupeolaksica(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.GRUPEOLAKSICASet = (GRUPEOLAKSICADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.GRUPEOLAKSICASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.GRUPEOLAKSICASet.GRUPEOLAKSICA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        GRUPEOLAKSICADataSet.GRUPEOLAKSICARow current = (GRUPEOLAKSICADataSet.GRUPEOLAKSICARow) enumerator.Current;
                        this.rowGRUPEOLAKSICA = current;
                        if (Helpers.IsRowChanged(this.rowGRUPEOLAKSICA))
                        {
                            this.ReadRowGrupeolaksica();
                            if (this.rowGRUPEOLAKSICA.RowState == DataRowState.Added)
                            {
                                this.InsertGrupeolaksica();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateGrupeolaksica();
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

        private void UpdateGrupeolaksica()
        {
            this.CheckOptimisticConcurrencyGrupeolaksica();
            this.AfterConfirmGrupeolaksica();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [GRUPEOLAKSICA] SET [NAZIVGRUPEOLAKSICA]=@NAZIVGRUPEOLAKSICA, [MAXIMALNIIZNOSGRUPE]=@MAXIMALNIIZNOSGRUPE  WHERE [IDGRUPEOLAKSICA] = @IDGRUPEOLAKSICA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVGRUPEOLAKSICA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MAXIMALNIIZNOSGRUPE", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEOLAKSICA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEOLAKSICA["NAZIVGRUPEOLAKSICA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowGRUPEOLAKSICA["MAXIMALNIIZNOSGRUPE"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowGRUPEOLAKSICA["IDGRUPEOLAKSICA"]));
            command.ExecuteStmt();
            new grupeolaksicaupdateredundancy(ref this.dsDefault).execute(this.rowGRUPEOLAKSICA.IDGRUPEOLAKSICA);
            this.OnGRUPEOLAKSICAUpdated(new GRUPEOLAKSICAEventArgs(this.rowGRUPEOLAKSICA, StatementType.Update));
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
        public class GRUPEOLAKSICADataChangedException : DataChangedException
        {
            public GRUPEOLAKSICADataChangedException()
            {
            }

            public GRUPEOLAKSICADataChangedException(string message) : base(message)
            {
            }

            protected GRUPEOLAKSICADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GRUPEOLAKSICADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GRUPEOLAKSICADataLockedException : DataLockedException
        {
            public GRUPEOLAKSICADataLockedException()
            {
            }

            public GRUPEOLAKSICADataLockedException(string message) : base(message)
            {
            }

            protected GRUPEOLAKSICADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GRUPEOLAKSICADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GRUPEOLAKSICADuplicateKeyException : DuplicateKeyException
        {
            public GRUPEOLAKSICADuplicateKeyException()
            {
            }

            public GRUPEOLAKSICADuplicateKeyException(string message) : base(message)
            {
            }

            protected GRUPEOLAKSICADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GRUPEOLAKSICADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class GRUPEOLAKSICAEventArgs : EventArgs
        {
            private GRUPEOLAKSICADataSet.GRUPEOLAKSICARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public GRUPEOLAKSICAEventArgs(GRUPEOLAKSICADataSet.GRUPEOLAKSICARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public GRUPEOLAKSICADataSet.GRUPEOLAKSICARow Row
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
        public class GRUPEOLAKSICANotFoundException : DataNotFoundException
        {
            public GRUPEOLAKSICANotFoundException()
            {
            }

            public GRUPEOLAKSICANotFoundException(string message) : base(message)
            {
            }

            protected GRUPEOLAKSICANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GRUPEOLAKSICANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void GRUPEOLAKSICAUpdateEventHandler(object sender, GRUPEOLAKSICADataAdapter.GRUPEOLAKSICAEventArgs e);

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
    }
}

