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

    public class ORGJEDDataAdapter : IDataAdapter, IORGJEDDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmORGJEDSelect1;
        private ReadWriteCommand cmORGJEDSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVORGJEDOriginal;
        private readonly string m_SelectString191 = "TM1.[IDORGJED], TM1.[NAZIVORGJED]";
        private string m_WhereString;
        private IDataReader ORGJEDSelect1;
        private IDataReader ORGJEDSelect4;
        private ORGJEDDataSet ORGJEDSet;
        private short RcdFound191;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private ORGJEDDataSet.ORGJEDRow rowORGJED;
        private string scmdbuf;
        private StatementType sMode191;

        public event ORGJEDUpdateEventHandler ORGJEDUpdated;

        public event ORGJEDUpdateEventHandler ORGJEDUpdating;

        private void AddRowOrgjed()
        {
            this.ORGJEDSet.ORGJED.AddORGJEDRow(this.rowORGJED);
        }

        private void AfterConfirmOrgjed()
        {
            this.OnORGJEDUpdating(new ORGJEDEventArgs(this.rowORGJED, this.Gx_mode));
        }

        private void CheckDeleteErrorsOrgjed()
        {
            ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMADD] FROM [SHEMADD] WITH (NOLOCK) WHERE [SHEMADDOJIDORGJED] = @IDORGJED ", false);
            if (command4.IDbCommand.Parameters.Count == 0)
            {
                command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
            }
            command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowORGJED["IDORGJED"]));
            IDataReader reader4 = command4.FetchData();
            if (command4.HasMoreRows)
            {
                reader4.Close();
                throw new SHEMADDInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMADD" }));
            }
            reader4.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT TOP 1 [IDPLAN], [PLANGODINAIDGODINE], [PLANOJIDORGJED] FROM [PLANORG] WITH (NOLOCK) WHERE [PLANOJIDORGJED] = @IDORGJED ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowORGJED["IDORGJED"]));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                reader3.Close();
                throw new PLANORGInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "ORG" }));
            }
            reader3.Close();
            ReadWriteCommand command6 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAPLACA] FROM [SHEMAPLACA] WITH (NOLOCK) WHERE [SHEMAPLOJIDORGJED] = @IDORGJED ", false);
            if (command6.IDbCommand.Parameters.Count == 0)
            {
                command6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
            }
            command6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowORGJED["IDORGJED"]));
            IDataReader reader6 = command6.FetchData();
            if (command6.HasMoreRows)
            {
                reader6.Close();
                throw new SHEMAPLACAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAPLACA" }));
            }
            reader6.Close();
            ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAIRA], [SHEMAIRAKONTOIDKONTO], [SHEMAIRASTRANEIDSTRANEKNJIZENJA] FROM [SHEMAIRASHEMAIRAKONTIRANJE] WITH (NOLOCK) WHERE [SHEMAIRAOJIDORGJED] = @IDORGJED ", false);
            if (command5.IDbCommand.Parameters.Count == 0)
            {
                command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
            }
            command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowORGJED["IDORGJED"]));
            IDataReader reader5 = command5.FetchData();
            if (command5.HasMoreRows)
            {
                reader5.Close();
                throw new SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAIRAKONTIRANJE" }));
            }
            reader5.Close();
            ReadWriteCommand command7 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAURA], [SHEMAURAKONTOIDKONTO], [SHEMAURASTRANEIDSTRANEKNJIZENJA], [IDURAVRSTAIZNOSA] FROM [SHEMAURASHEMAURAKONTIRANJE] WITH (NOLOCK) WHERE [SHEMAURAOJIDORGJED] = @IDORGJED ", false);
            if (command7.IDbCommand.Parameters.Count == 0)
            {
                command7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
            }
            command7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowORGJED["IDORGJED"]));
            IDataReader reader7 = command7.FetchData();
            if (command7.HasMoreRows)
            {
                reader7.Close();
                throw new SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAURAKONTIRANJE" }));
            }
            reader7.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [BLGDOKIDDOKUMENT], [IDBLGVRSTEDOK], [blggodineIDGODINE], [BLGBROJDOKUMENTA], [BLGSTAVKEBLAGAJNEKONTOIDKONTO] FROM [BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje] WITH (NOLOCK) WHERE [BLGORGJEDIDORGJED] = @IDORGJED ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowORGJED["IDORGJED"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "StavkeBlagajneKontiranje" }));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [IDGKSTAVKA] FROM [GKSTAVKA] WITH (NOLOCK) WHERE [IDORGJED] = @IDORGJED ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowORGJED["IDORGJED"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new GKSTAVKAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "GKSTAVKA" }));
            }
            reader2.Close();
        }

        private void CheckExtendedTableOrgjed()
        {
            this.rowORGJED.oj = this.rowORGJED.NAZIVORGJED + "  | " + NumberUtil.ToString((long) this.rowORGJED.IDORGJED, "");
        }

        private void CheckOptimisticConcurrencyOrgjed()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDORGJED], [NAZIVORGJED] FROM [ORGJED] WITH (UPDLOCK) WHERE [IDORGJED] = @IDORGJED ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowORGJED["IDORGJED"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new ORGJEDDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("ORGJED") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVORGJEDOriginal), RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))))
                {
                    reader.Close();
                    throw new ORGJEDDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("ORGJED") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowOrgjed()
        {
            this.rowORGJED = this.ORGJEDSet.ORGJED.NewORGJEDRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyOrgjed();
            this.OnDeleteControlsOrgjed();
            this.AfterConfirmOrgjed();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [ORGJED]  WHERE [IDORGJED] = @IDORGJED", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowORGJED["IDORGJED"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsOrgjed();
            }
            this.OnORGJEDUpdated(new ORGJEDEventArgs(this.rowORGJED, StatementType.Delete));
            this.rowORGJED.Delete();
            this.sMode191 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode191;
        }

        public virtual int Fill(ORGJEDDataSet dataSet)
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
                    this.ORGJEDSet = dataSet;
                    this.LoadChildOrgjed(0, -1);
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
            this.ORGJEDSet = (ORGJEDDataSet) dataSet;
            if (this.ORGJEDSet != null)
            {
                return this.Fill(this.ORGJEDSet);
            }
            this.ORGJEDSet = new ORGJEDDataSet();
            this.Fill(this.ORGJEDSet);
            dataSet.Merge(this.ORGJEDSet);
            return 0;
        }

        public virtual int Fill(ORGJEDDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDORGJED"]));
        }

        public virtual int Fill(ORGJEDDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDORGJED"]));
        }

        public virtual int Fill(ORGJEDDataSet dataSet, int iDORGJED)
        {
            if (!this.FillByIDORGJED(dataSet, iDORGJED))
            {
                throw new ORGJEDNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ORGJED") }));
            }
            return 0;
        }

        public virtual bool FillByIDORGJED(ORGJEDDataSet dataSet, int iDORGJED)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ORGJEDSet = dataSet;
            this.rowORGJED = this.ORGJEDSet.ORGJED.NewORGJEDRow();
            this.rowORGJED.IDORGJED = iDORGJED;
            try
            {
                this.LoadByIDORGJED(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound191 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(ORGJEDDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ORGJEDSet = dataSet;
            try
            {
                this.LoadChildOrgjed(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDORGJED], [NAZIVORGJED] FROM [ORGJED] WITH (NOLOCK) WHERE [IDORGJED] = @IDORGJED ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowORGJED["IDORGJED"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound191 = 1;
                this.rowORGJED["IDORGJED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowORGJED["NAZIVORGJED"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))));
                this.sMode191 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadOrgjed();
                this.Gx_mode = this.sMode191;
            }
            else
            {
                this.RcdFound191 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDORGJED";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmORGJEDSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [ORGJED] WITH (NOLOCK) ", false);
            this.ORGJEDSelect1 = this.cmORGJEDSelect1.FetchData();
            if (this.ORGJEDSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.ORGJEDSelect1.GetInt32(0);
            }
            this.ORGJEDSelect1.Close();
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
            this.RcdFound191 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVORGJEDOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.ORGJEDSet = new ORGJEDDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertOrgjed()
        {
            this.CheckOptimisticConcurrencyOrgjed();
            this.CheckExtendedTableOrgjed();
            this.AfterConfirmOrgjed();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [ORGJED] ([IDORGJED], [NAZIVORGJED]) VALUES (@IDORGJED, @NAZIVORGJED)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVORGJED", DbType.String, 100));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowORGJED["IDORGJED"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowORGJED["NAZIVORGJED"]))));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new ORGJEDDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnORGJEDUpdated(new ORGJEDEventArgs(this.rowORGJED, StatementType.Insert));
        }

        private void LoadByIDORGJED(int startRow, int maxRows)
        {
            bool enforceConstraints = this.ORGJEDSet.EnforceConstraints;
            this.ORGJEDSet.ORGJED.BeginLoadData();
            this.ScanByIDORGJED(startRow, maxRows);
            this.ORGJEDSet.ORGJED.EndLoadData();
            this.ORGJEDSet.EnforceConstraints = enforceConstraints;
            if (this.ORGJEDSet.ORGJED.Count > 0)
            {
                this.rowORGJED = this.ORGJEDSet.ORGJED[this.ORGJEDSet.ORGJED.Count - 1];
            }
        }

        private void LoadChildOrgjed(int startRow, int maxRows)
        {
            this.CreateNewRowOrgjed();
            bool enforceConstraints = this.ORGJEDSet.EnforceConstraints;
            this.ORGJEDSet.ORGJED.BeginLoadData();
            this.ScanStartOrgjed(startRow, maxRows);
            this.ORGJEDSet.ORGJED.EndLoadData();
            this.ORGJEDSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataOrgjed(int maxRows)
        {
            int num = 0;
            if (this.RcdFound191 != 0)
            {
                this.ScanLoadOrgjed();
                while ((this.RcdFound191 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowOrgjed();
                    this.CreateNewRowOrgjed();
                    this.ScanNextOrgjed();
                }
            }
            if (num > 0)
            {
                this.RcdFound191 = 1;
            }
            this.ScanEndOrgjed();
            if (this.ORGJEDSet.ORGJED.Count > 0)
            {
                this.rowORGJED = this.ORGJEDSet.ORGJED[this.ORGJEDSet.ORGJED.Count - 1];
            }
        }

        private void LoadOrgjed()
        {
            this.rowORGJED.oj = this.rowORGJED.NAZIVORGJED + "  | " + NumberUtil.ToString((long) this.rowORGJED.IDORGJED, "");
        }

        private void LoadRowOrgjed()
        {
            this.OnLoadActionsOrgjed();
            this.AddRowOrgjed();
        }

        private void OnDeleteControlsOrgjed()
        {
            this.rowORGJED.oj = this.rowORGJED.NAZIVORGJED + "  | " + NumberUtil.ToString((long) this.rowORGJED.IDORGJED, "");
        }

        private void OnLoadActionsOrgjed()
        {
            this.rowORGJED.oj = this.rowORGJED.NAZIVORGJED + "  | " + NumberUtil.ToString((long) this.rowORGJED.IDORGJED, "");
        }

        private void OnORGJEDUpdated(ORGJEDEventArgs e)
        {
            if (this.ORGJEDUpdated != null)
            {
                ORGJEDUpdateEventHandler oRGJEDUpdatedEvent = this.ORGJEDUpdated;
                if (oRGJEDUpdatedEvent != null)
                {
                    oRGJEDUpdatedEvent(this, e);
                }
            }
        }

        private void OnORGJEDUpdating(ORGJEDEventArgs e)
        {
            if (this.ORGJEDUpdating != null)
            {
                ORGJEDUpdateEventHandler oRGJEDUpdatingEvent = this.ORGJEDUpdating;
                if (oRGJEDUpdatingEvent != null)
                {
                    oRGJEDUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowOrgjed()
        {
            this.Gx_mode = Mode.FromRowState(this.rowORGJED.RowState);
            if (this.rowORGJED.RowState != DataRowState.Added)
            {
                this.m__NAZIVORGJEDOriginal = RuntimeHelpers.GetObjectValue(this.rowORGJED["NAZIVORGJED", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVORGJEDOriginal = RuntimeHelpers.GetObjectValue(this.rowORGJED["NAZIVORGJED"]);
            }
            this._Gxremove = this.rowORGJED.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowORGJED = (ORGJEDDataSet.ORGJEDRow) DataSetUtil.CloneOriginalDataRow(this.rowORGJED);
            }
        }

        private void ScanByIDORGJED(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDORGJED] = @IDORGJED";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString191 + "  FROM [ORGJED] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDORGJED]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString191, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDORGJED] ) AS DK_PAGENUM   FROM [ORGJED] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString191 + " FROM [ORGJED] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDORGJED] ";
            }
            this.cmORGJEDSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmORGJEDSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmORGJEDSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
            }
            this.cmORGJEDSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowORGJED["IDORGJED"]));
            this.ORGJEDSelect4 = this.cmORGJEDSelect4.FetchData();
            this.RcdFound191 = 0;
            this.ScanLoadOrgjed();
            this.LoadDataOrgjed(maxRows);
        }

        private void ScanEndOrgjed()
        {
            this.ORGJEDSelect4.Close();
        }

        private void ScanLoadOrgjed()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmORGJEDSelect4.HasMoreRows)
            {
                this.RcdFound191 = 1;
                this.rowORGJED["IDORGJED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ORGJEDSelect4, 0));
                this.rowORGJED["NAZIVORGJED"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ORGJEDSelect4, 1))));
            }
        }

        private void ScanNextOrgjed()
        {
            this.cmORGJEDSelect4.HasMoreRows = this.ORGJEDSelect4.Read();
            this.RcdFound191 = 0;
            this.ScanLoadOrgjed();
        }

        private void ScanStartOrgjed(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString191 + "  FROM [ORGJED] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDORGJED]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString191, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDORGJED] ) AS DK_PAGENUM   FROM [ORGJED] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString191 + " FROM [ORGJED] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDORGJED] ";
            }
            this.cmORGJEDSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.ORGJEDSelect4 = this.cmORGJEDSelect4.FetchData();
            this.RcdFound191 = 0;
            this.ScanLoadOrgjed();
            this.LoadDataOrgjed(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.ORGJEDSet = (ORGJEDDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.ORGJEDSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.ORGJEDSet.ORGJED.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ORGJEDDataSet.ORGJEDRow current = (ORGJEDDataSet.ORGJEDRow) enumerator.Current;
                        this.rowORGJED = current;
                        if (Helpers.IsRowChanged(this.rowORGJED))
                        {
                            this.ReadRowOrgjed();
                            if (this.rowORGJED.RowState == DataRowState.Added)
                            {
                                this.InsertOrgjed();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateOrgjed();
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

        private void UpdateOrgjed()
        {
            this.CheckOptimisticConcurrencyOrgjed();
            this.CheckExtendedTableOrgjed();
            this.AfterConfirmOrgjed();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [ORGJED] SET [NAZIVORGJED]=@NAZIVORGJED  WHERE [IDORGJED] = @IDORGJED", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVORGJED", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowORGJED["NAZIVORGJED"]))));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowORGJED["IDORGJED"]));
            command.ExecuteStmt();
            this.OnORGJEDUpdated(new ORGJEDEventArgs(this.rowORGJED, StatementType.Update));
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
        public class BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeInvalidDeleteException : InvalidDeleteException
        {
            public BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeInvalidDeleteException()
            {
            }

            public BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeInvalidDeleteException(string message) : base(message)
            {
            }

            protected BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GKSTAVKAInvalidDeleteException : InvalidDeleteException
        {
            public GKSTAVKAInvalidDeleteException()
            {
            }

            public GKSTAVKAInvalidDeleteException(string message) : base(message)
            {
            }

            protected GKSTAVKAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GKSTAVKAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ORGJEDDataChangedException : DataChangedException
        {
            public ORGJEDDataChangedException()
            {
            }

            public ORGJEDDataChangedException(string message) : base(message)
            {
            }

            protected ORGJEDDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ORGJEDDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ORGJEDDataLockedException : DataLockedException
        {
            public ORGJEDDataLockedException()
            {
            }

            public ORGJEDDataLockedException(string message) : base(message)
            {
            }

            protected ORGJEDDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ORGJEDDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ORGJEDDuplicateKeyException : DuplicateKeyException
        {
            public ORGJEDDuplicateKeyException()
            {
            }

            public ORGJEDDuplicateKeyException(string message) : base(message)
            {
            }

            protected ORGJEDDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ORGJEDDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class ORGJEDEventArgs : EventArgs
        {
            private ORGJEDDataSet.ORGJEDRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public ORGJEDEventArgs(ORGJEDDataSet.ORGJEDRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public ORGJEDDataSet.ORGJEDRow Row
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
        public class ORGJEDNotFoundException : DataNotFoundException
        {
            public ORGJEDNotFoundException()
            {
            }

            public ORGJEDNotFoundException(string message) : base(message)
            {
            }

            protected ORGJEDNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ORGJEDNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void ORGJEDUpdateEventHandler(object sender, ORGJEDDataAdapter.ORGJEDEventArgs e);

        [Serializable]
        public class PLANORGInvalidDeleteException : InvalidDeleteException
        {
            public PLANORGInvalidDeleteException()
            {
            }

            public PLANORGInvalidDeleteException(string message) : base(message)
            {
            }

            protected PLANORGInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PLANORGInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMADDInvalidDeleteException : InvalidDeleteException
        {
            public SHEMADDInvalidDeleteException()
            {
            }

            public SHEMADDInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMADDInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMADDInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException : InvalidDeleteException
        {
            public SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException()
            {
            }

            public SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAPLACAInvalidDeleteException : InvalidDeleteException
        {
            public SHEMAPLACAInvalidDeleteException()
            {
            }

            public SHEMAPLACAInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMAPLACAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException : InvalidDeleteException
        {
            public SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException()
            {
            }

            public SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

