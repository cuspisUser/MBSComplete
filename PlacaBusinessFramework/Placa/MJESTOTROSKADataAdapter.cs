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

    public class MJESTOTROSKADataAdapter : IDataAdapter, IMJESTOTROSKADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmMJESTOTROSKASelect1;
        private ReadWriteCommand cmMJESTOTROSKASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVMJESTOTROSKAOriginal;
        private readonly string m_SelectString190 = "TM1.[IDMJESTOTROSKA], TM1.[NAZIVMJESTOTROSKA]";
        private string m_WhereString;
        private IDataReader MJESTOTROSKASelect1;
        private IDataReader MJESTOTROSKASelect4;
        private MJESTOTROSKADataSet MJESTOTROSKASet;
        private short RcdFound190;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private MJESTOTROSKADataSet.MJESTOTROSKARow rowMJESTOTROSKA;
        private string scmdbuf;
        private StatementType sMode190;

        public event MJESTOTROSKAUpdateEventHandler MJESTOTROSKAUpdated;

        public event MJESTOTROSKAUpdateEventHandler MJESTOTROSKAUpdating;

        private void AddRowMjestotroska()
        {
            this.MJESTOTROSKASet.MJESTOTROSKA.AddMJESTOTROSKARow(this.rowMJESTOTROSKA);
        }

        private void AfterConfirmMjestotroska()
        {
            this.OnMJESTOTROSKAUpdating(new MJESTOTROSKAEventArgs(this.rowMJESTOTROSKA, this.Gx_mode));
        }

        private void CheckDeleteErrorsMjestotroska()
        {
            ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMADD], [SHEMADDSTANDARDID] FROM [SHEMADDSHEMADDSTANDARD] WITH (NOLOCK) WHERE [MTDDVRSTAIZNOSAIDMJESTOTROSKA] = @IDMJESTOTROSKA ", false);
            if (command4.IDbCommand.Parameters.Count == 0)
            {
                command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMJESTOTROSKA["IDMJESTOTROSKA"]));
            IDataReader reader4 = command4.FetchData();
            if (command4.HasMoreRows)
            {
                reader4.Close();
                throw new SHEMADDSHEMADDSTANDARDInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMADDSTANDARD" }));
            }
            reader4.Close();
            ReadWriteCommand command8 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAPLACA], [SHEMAPLACASTANDARDID] FROM [SHEMAPLACASHEMAPLACASTANDARD] WITH (NOLOCK) WHERE [MTPLACAVRSTAIZNOSAIDMJESTOTROSKA] = @IDMJESTOTROSKA ", false);
            if (command8.IDbCommand.Parameters.Count == 0)
            {
                command8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            command8.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMJESTOTROSKA["IDMJESTOTROSKA"]));
            IDataReader reader8 = command8.FetchData();
            if (command8.HasMoreRows)
            {
                reader8.Close();
                throw new SHEMAPLACASHEMAPLACASTANDARDInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAPLACASTANDARD" }));
            }
            reader8.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMADD], [SHEMADDDOPRINOSIDDOPRINOS], [KONTODOPIDKONTO] FROM [SHEMADDSHEMADDDOPRINOS] WITH (NOLOCK) WHERE [MTDOPIDMJESTOTROSKA] = @IDMJESTOTROSKA ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMJESTOTROSKA["IDMJESTOTROSKA"]));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                reader3.Close();
                throw new SHEMADDSHEMADDDOPRINOSInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Doprinosi" }));
            }
            reader3.Close();
            ReadWriteCommand command6 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAPLACA], [SHEMAPLDOPIDDOPRINOS], [KONTODOPIDKONTO] FROM [SHEMAPLACASHEMAPLACADOP] WITH (NOLOCK) WHERE [MTDOPIDMJESTOTROSKA] = @IDMJESTOTROSKA ", false);
            if (command6.IDbCommand.Parameters.Count == 0)
            {
                command6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            command6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMJESTOTROSKA["IDMJESTOTROSKA"]));
            IDataReader reader6 = command6.FetchData();
            if (command6.HasMoreRows)
            {
                reader6.Close();
                throw new SHEMAPLACASHEMAPLACADOPInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Doprinosi" }));
            }
            reader6.Close();
            ReadWriteCommand command7 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAPLACA], [SHEMAPLELEMENTIDELEMENT], [KONTOELEMENTIDKONTO], [STRANEELEMENTIDSTRANEKNJIZENJA] FROM [SHEMAPLACASHEMAPLACAELEMENT] WITH (NOLOCK) WHERE [MTELEMENTIDMJESTOTROSKA] = @IDMJESTOTROSKA ", false);
            if (command7.IDbCommand.Parameters.Count == 0)
            {
                command7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            command7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMJESTOTROSKA["IDMJESTOTROSKA"]));
            IDataReader reader7 = command7.FetchData();
            if (command7.HasMoreRows)
            {
                reader7.Close();
                throw new SHEMAPLACASHEMAPLACAELEMENTInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAPLACAELEMENT" }));
            }
            reader7.Close();
            ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAIRA], [SHEMAIRAKONTOIDKONTO], [SHEMAIRASTRANEIDSTRANEKNJIZENJA] FROM [SHEMAIRASHEMAIRAKONTIRANJE] WITH (NOLOCK) WHERE [SHEMAIRAMTIDMJESTOTROSKA] = @IDMJESTOTROSKA ", false);
            if (command5.IDbCommand.Parameters.Count == 0)
            {
                command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMJESTOTROSKA["IDMJESTOTROSKA"]));
            IDataReader reader5 = command5.FetchData();
            if (command5.HasMoreRows)
            {
                reader5.Close();
                throw new SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAIRAKONTIRANJE" }));
            }
            reader5.Close();
            ReadWriteCommand command9 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAURA], [SHEMAURAKONTOIDKONTO], [SHEMAURASTRANEIDSTRANEKNJIZENJA], [IDURAVRSTAIZNOSA] FROM [SHEMAURASHEMAURAKONTIRANJE] WITH (NOLOCK) WHERE [SHEMAURAMTIDMJESTOTROSKA] = @IDMJESTOTROSKA ", false);
            if (command9.IDbCommand.Parameters.Count == 0)
            {
                command9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            command9.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMJESTOTROSKA["IDMJESTOTROSKA"]));
            IDataReader reader9 = command9.FetchData();
            if (command9.HasMoreRows)
            {
                reader9.Close();
                throw new SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAURAKONTIRANJE" }));
            }
            reader9.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [BLGDOKIDDOKUMENT], [IDBLGVRSTEDOK], [blggodineIDGODINE], [BLGBROJDOKUMENTA], [BLGSTAVKEBLAGAJNEKONTOIDKONTO] FROM [BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje] WITH (NOLOCK) WHERE [BLGMTIDMJESTOTROSKA] = @IDMJESTOTROSKA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMJESTOTROSKA["IDMJESTOTROSKA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "StavkeBlagajneKontiranje" }));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [IDGKSTAVKA] FROM [GKSTAVKA] WITH (NOLOCK) WHERE [IDMJESTOTROSKA] = @IDMJESTOTROSKA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMJESTOTROSKA["IDMJESTOTROSKA"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new GKSTAVKAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "GKSTAVKA" }));
            }
            reader2.Close();
        }

        private void CheckExtendedTableMjestotroska()
        {
            this.rowMJESTOTROSKA.mt = this.rowMJESTOTROSKA.NAZIVMJESTOTROSKA + " | " + NumberUtil.ToString((long) this.rowMJESTOTROSKA.IDMJESTOTROSKA, "");
        }

        private void CheckOptimisticConcurrencyMjestotroska()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDMJESTOTROSKA], [NAZIVMJESTOTROSKA] FROM [MJESTOTROSKA] WITH (UPDLOCK) WHERE [IDMJESTOTROSKA] = @IDMJESTOTROSKA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMJESTOTROSKA["IDMJESTOTROSKA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new MJESTOTROSKADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("MJESTOTROSKA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVMJESTOTROSKAOriginal), RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))))
                {
                    reader.Close();
                    throw new MJESTOTROSKADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("MJESTOTROSKA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowMjestotroska()
        {
            this.rowMJESTOTROSKA = this.MJESTOTROSKASet.MJESTOTROSKA.NewMJESTOTROSKARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyMjestotroska();
            this.OnDeleteControlsMjestotroska();
            this.AfterConfirmMjestotroska();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [MJESTOTROSKA]  WHERE [IDMJESTOTROSKA] = @IDMJESTOTROSKA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMJESTOTROSKA["IDMJESTOTROSKA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsMjestotroska();
            }
            this.OnMJESTOTROSKAUpdated(new MJESTOTROSKAEventArgs(this.rowMJESTOTROSKA, StatementType.Delete));
            this.rowMJESTOTROSKA.Delete();
            this.sMode190 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode190;
        }

        public virtual int Fill(MJESTOTROSKADataSet dataSet)
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
                    this.MJESTOTROSKASet = dataSet;
                    this.LoadChildMjestotroska(0, -1);
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
            this.MJESTOTROSKASet = (MJESTOTROSKADataSet) dataSet;
            if (this.MJESTOTROSKASet != null)
            {
                return this.Fill(this.MJESTOTROSKASet);
            }
            this.MJESTOTROSKASet = new MJESTOTROSKADataSet();
            this.Fill(this.MJESTOTROSKASet);
            dataSet.Merge(this.MJESTOTROSKASet);
            return 0;
        }

        public virtual int Fill(MJESTOTROSKADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDMJESTOTROSKA"]));
        }

        public virtual int Fill(MJESTOTROSKADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDMJESTOTROSKA"]));
        }

        public virtual int Fill(MJESTOTROSKADataSet dataSet, int iDMJESTOTROSKA)
        {
            if (!this.FillByIDMJESTOTROSKA(dataSet, iDMJESTOTROSKA))
            {
                throw new MJESTOTROSKANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("MJESTOTROSKA") }));
            }
            return 0;
        }

        public virtual bool FillByIDMJESTOTROSKA(MJESTOTROSKADataSet dataSet, int iDMJESTOTROSKA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.MJESTOTROSKASet = dataSet;
            this.rowMJESTOTROSKA = this.MJESTOTROSKASet.MJESTOTROSKA.NewMJESTOTROSKARow();
            this.rowMJESTOTROSKA.IDMJESTOTROSKA = iDMJESTOTROSKA;
            try
            {
                this.LoadByIDMJESTOTROSKA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound190 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(MJESTOTROSKADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.MJESTOTROSKASet = dataSet;
            try
            {
                this.LoadChildMjestotroska(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDMJESTOTROSKA], [NAZIVMJESTOTROSKA] FROM [MJESTOTROSKA] WITH (NOLOCK) WHERE [IDMJESTOTROSKA] = @IDMJESTOTROSKA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMJESTOTROSKA["IDMJESTOTROSKA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound190 = 1;
                this.rowMJESTOTROSKA["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowMJESTOTROSKA["NAZIVMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))));
                this.sMode190 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadMjestotroska();
                this.Gx_mode = this.sMode190;
            }
            else
            {
                this.RcdFound190 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDMJESTOTROSKA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmMJESTOTROSKASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [MJESTOTROSKA] WITH (NOLOCK) ", false);
            this.MJESTOTROSKASelect1 = this.cmMJESTOTROSKASelect1.FetchData();
            if (this.MJESTOTROSKASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.MJESTOTROSKASelect1.GetInt32(0);
            }
            this.MJESTOTROSKASelect1.Close();
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
            this.RcdFound190 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.MJESTOTROSKASet = new MJESTOTROSKADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertMjestotroska()
        {
            this.CheckOptimisticConcurrencyMjestotroska();
            this.CheckExtendedTableMjestotroska();
            this.AfterConfirmMjestotroska();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [MJESTOTROSKA] ([IDMJESTOTROSKA], [NAZIVMJESTOTROSKA]) VALUES (@IDMJESTOTROSKA, @NAZIVMJESTOTROSKA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVMJESTOTROSKA", DbType.String, 120));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMJESTOTROSKA["IDMJESTOTROSKA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowMJESTOTROSKA["NAZIVMJESTOTROSKA"]))));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new MJESTOTROSKADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnMJESTOTROSKAUpdated(new MJESTOTROSKAEventArgs(this.rowMJESTOTROSKA, StatementType.Insert));
        }

        private void LoadByIDMJESTOTROSKA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.MJESTOTROSKASet.EnforceConstraints;
            this.MJESTOTROSKASet.MJESTOTROSKA.BeginLoadData();
            this.ScanByIDMJESTOTROSKA(startRow, maxRows);
            this.MJESTOTROSKASet.MJESTOTROSKA.EndLoadData();
            this.MJESTOTROSKASet.EnforceConstraints = enforceConstraints;
            if (this.MJESTOTROSKASet.MJESTOTROSKA.Count > 0)
            {
                this.rowMJESTOTROSKA = this.MJESTOTROSKASet.MJESTOTROSKA[this.MJESTOTROSKASet.MJESTOTROSKA.Count - 1];
            }
        }

        private void LoadChildMjestotroska(int startRow, int maxRows)
        {
            this.CreateNewRowMjestotroska();
            bool enforceConstraints = this.MJESTOTROSKASet.EnforceConstraints;
            this.MJESTOTROSKASet.MJESTOTROSKA.BeginLoadData();
            this.ScanStartMjestotroska(startRow, maxRows);
            this.MJESTOTROSKASet.MJESTOTROSKA.EndLoadData();
            this.MJESTOTROSKASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataMjestotroska(int maxRows)
        {
            int num = 0;
            if (this.RcdFound190 != 0)
            {
                this.ScanLoadMjestotroska();
                while ((this.RcdFound190 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowMjestotroska();
                    this.CreateNewRowMjestotroska();
                    this.ScanNextMjestotroska();
                }
            }
            if (num > 0)
            {
                this.RcdFound190 = 1;
            }
            this.ScanEndMjestotroska();
            if (this.MJESTOTROSKASet.MJESTOTROSKA.Count > 0)
            {
                this.rowMJESTOTROSKA = this.MJESTOTROSKASet.MJESTOTROSKA[this.MJESTOTROSKASet.MJESTOTROSKA.Count - 1];
            }
        }

        private void LoadMjestotroska()
        {
            this.rowMJESTOTROSKA.mt = this.rowMJESTOTROSKA.NAZIVMJESTOTROSKA + " | " + NumberUtil.ToString((long) this.rowMJESTOTROSKA.IDMJESTOTROSKA, "");
        }

        private void LoadRowMjestotroska()
        {
            this.OnLoadActionsMjestotroska();
            this.AddRowMjestotroska();
        }

        private void OnDeleteControlsMjestotroska()
        {
            this.rowMJESTOTROSKA.mt = this.rowMJESTOTROSKA.NAZIVMJESTOTROSKA + " | " + NumberUtil.ToString((long) this.rowMJESTOTROSKA.IDMJESTOTROSKA, "");
        }

        private void OnLoadActionsMjestotroska()
        {
            this.rowMJESTOTROSKA.mt = this.rowMJESTOTROSKA.NAZIVMJESTOTROSKA + " | " + NumberUtil.ToString((long) this.rowMJESTOTROSKA.IDMJESTOTROSKA, "");
        }

        private void OnMJESTOTROSKAUpdated(MJESTOTROSKAEventArgs e)
        {
            if (this.MJESTOTROSKAUpdated != null)
            {
                MJESTOTROSKAUpdateEventHandler mJESTOTROSKAUpdatedEvent = this.MJESTOTROSKAUpdated;
                if (mJESTOTROSKAUpdatedEvent != null)
                {
                    mJESTOTROSKAUpdatedEvent(this, e);
                }
            }
        }

        private void OnMJESTOTROSKAUpdating(MJESTOTROSKAEventArgs e)
        {
            if (this.MJESTOTROSKAUpdating != null)
            {
                MJESTOTROSKAUpdateEventHandler mJESTOTROSKAUpdatingEvent = this.MJESTOTROSKAUpdating;
                if (mJESTOTROSKAUpdatingEvent != null)
                {
                    mJESTOTROSKAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowMjestotroska()
        {
            this.Gx_mode = Mode.FromRowState(this.rowMJESTOTROSKA.RowState);
            if (this.rowMJESTOTROSKA.RowState != DataRowState.Added)
            {
                this.m__NAZIVMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowMJESTOTROSKA["NAZIVMJESTOTROSKA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVMJESTOTROSKAOriginal = RuntimeHelpers.GetObjectValue(this.rowMJESTOTROSKA["NAZIVMJESTOTROSKA"]);
            }
            this._Gxremove = this.rowMJESTOTROSKA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowMJESTOTROSKA = (MJESTOTROSKADataSet.MJESTOTROSKARow) DataSetUtil.CloneOriginalDataRow(this.rowMJESTOTROSKA);
            }
        }

        private void ScanByIDMJESTOTROSKA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDMJESTOTROSKA] = @IDMJESTOTROSKA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString190 + "  FROM [MJESTOTROSKA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDMJESTOTROSKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString190, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDMJESTOTROSKA] ) AS DK_PAGENUM   FROM [MJESTOTROSKA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString190 + " FROM [MJESTOTROSKA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDMJESTOTROSKA] ";
            }
            this.cmMJESTOTROSKASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmMJESTOTROSKASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmMJESTOTROSKASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            this.cmMJESTOTROSKASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowMJESTOTROSKA["IDMJESTOTROSKA"]));
            this.MJESTOTROSKASelect4 = this.cmMJESTOTROSKASelect4.FetchData();
            this.RcdFound190 = 0;
            this.ScanLoadMjestotroska();
            this.LoadDataMjestotroska(maxRows);
        }

        private void ScanEndMjestotroska()
        {
            this.MJESTOTROSKASelect4.Close();
        }

        private void ScanLoadMjestotroska()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmMJESTOTROSKASelect4.HasMoreRows)
            {
                this.RcdFound190 = 1;
                this.rowMJESTOTROSKA["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.MJESTOTROSKASelect4, 0));
                this.rowMJESTOTROSKA["NAZIVMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.MJESTOTROSKASelect4, 1))));
            }
        }

        private void ScanNextMjestotroska()
        {
            this.cmMJESTOTROSKASelect4.HasMoreRows = this.MJESTOTROSKASelect4.Read();
            this.RcdFound190 = 0;
            this.ScanLoadMjestotroska();
        }

        private void ScanStartMjestotroska(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString190 + "  FROM [MJESTOTROSKA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDMJESTOTROSKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString190, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDMJESTOTROSKA] ) AS DK_PAGENUM   FROM [MJESTOTROSKA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString190 + " FROM [MJESTOTROSKA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDMJESTOTROSKA] ";
            }
            this.cmMJESTOTROSKASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.MJESTOTROSKASelect4 = this.cmMJESTOTROSKASelect4.FetchData();
            this.RcdFound190 = 0;
            this.ScanLoadMjestotroska();
            this.LoadDataMjestotroska(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.MJESTOTROSKASet = (MJESTOTROSKADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.MJESTOTROSKASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.MJESTOTROSKASet.MJESTOTROSKA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        MJESTOTROSKADataSet.MJESTOTROSKARow current = (MJESTOTROSKADataSet.MJESTOTROSKARow) enumerator.Current;
                        this.rowMJESTOTROSKA = current;
                        if (Helpers.IsRowChanged(this.rowMJESTOTROSKA))
                        {
                            this.ReadRowMjestotroska();
                            if (this.rowMJESTOTROSKA.RowState == DataRowState.Added)
                            {
                                this.InsertMjestotroska();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateMjestotroska();
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

        private void UpdateMjestotroska()
        {
            this.CheckOptimisticConcurrencyMjestotroska();
            this.CheckExtendedTableMjestotroska();
            this.AfterConfirmMjestotroska();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [MJESTOTROSKA] SET [NAZIVMJESTOTROSKA]=@NAZIVMJESTOTROSKA  WHERE [IDMJESTOTROSKA] = @IDMJESTOTROSKA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVMJESTOTROSKA", DbType.String, 120));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMJESTOTROSKA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowMJESTOTROSKA["NAZIVMJESTOTROSKA"]))));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowMJESTOTROSKA["IDMJESTOTROSKA"]));
            command.ExecuteStmt();
            this.OnMJESTOTROSKAUpdated(new MJESTOTROSKAEventArgs(this.rowMJESTOTROSKA, StatementType.Update));
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
        public class MJESTOTROSKADataChangedException : DataChangedException
        {
            public MJESTOTROSKADataChangedException()
            {
            }

            public MJESTOTROSKADataChangedException(string message) : base(message)
            {
            }

            protected MJESTOTROSKADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public MJESTOTROSKADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class MJESTOTROSKADataLockedException : DataLockedException
        {
            public MJESTOTROSKADataLockedException()
            {
            }

            public MJESTOTROSKADataLockedException(string message) : base(message)
            {
            }

            protected MJESTOTROSKADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public MJESTOTROSKADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class MJESTOTROSKADuplicateKeyException : DuplicateKeyException
        {
            public MJESTOTROSKADuplicateKeyException()
            {
            }

            public MJESTOTROSKADuplicateKeyException(string message) : base(message)
            {
            }

            protected MJESTOTROSKADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public MJESTOTROSKADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class MJESTOTROSKAEventArgs : EventArgs
        {
            private MJESTOTROSKADataSet.MJESTOTROSKARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public MJESTOTROSKAEventArgs(MJESTOTROSKADataSet.MJESTOTROSKARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public MJESTOTROSKADataSet.MJESTOTROSKARow Row
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
        public class MJESTOTROSKANotFoundException : DataNotFoundException
        {
            public MJESTOTROSKANotFoundException()
            {
            }

            public MJESTOTROSKANotFoundException(string message) : base(message)
            {
            }

            protected MJESTOTROSKANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public MJESTOTROSKANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void MJESTOTROSKAUpdateEventHandler(object sender, MJESTOTROSKADataAdapter.MJESTOTROSKAEventArgs e);

        [Serializable]
        public class SHEMADDSHEMADDDOPRINOSInvalidDeleteException : InvalidDeleteException
        {
            public SHEMADDSHEMADDDOPRINOSInvalidDeleteException()
            {
            }

            public SHEMADDSHEMADDDOPRINOSInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMADDSHEMADDDOPRINOSInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMADDSHEMADDDOPRINOSInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMADDSHEMADDSTANDARDInvalidDeleteException : InvalidDeleteException
        {
            public SHEMADDSHEMADDSTANDARDInvalidDeleteException()
            {
            }

            public SHEMADDSHEMADDSTANDARDInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMADDSHEMADDSTANDARDInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMADDSHEMADDSTANDARDInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
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
        public class SHEMAPLACASHEMAPLACADOPInvalidDeleteException : InvalidDeleteException
        {
            public SHEMAPLACASHEMAPLACADOPInvalidDeleteException()
            {
            }

            public SHEMAPLACASHEMAPLACADOPInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMAPLACASHEMAPLACADOPInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACASHEMAPLACADOPInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAPLACASHEMAPLACAELEMENTInvalidDeleteException : InvalidDeleteException
        {
            public SHEMAPLACASHEMAPLACAELEMENTInvalidDeleteException()
            {
            }

            public SHEMAPLACASHEMAPLACAELEMENTInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMAPLACASHEMAPLACAELEMENTInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACASHEMAPLACAELEMENTInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAPLACASHEMAPLACASTANDARDInvalidDeleteException : InvalidDeleteException
        {
            public SHEMAPLACASHEMAPLACASTANDARDInvalidDeleteException()
            {
            }

            public SHEMAPLACASHEMAPLACASTANDARDInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMAPLACASHEMAPLACASTANDARDInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACASHEMAPLACASTANDARDInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
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

