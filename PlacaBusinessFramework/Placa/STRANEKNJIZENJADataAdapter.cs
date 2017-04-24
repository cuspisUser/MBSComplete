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

    public class STRANEKNJIZENJADataAdapter : IDataAdapter, ISTRANEKNJIZENJADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmSTRANEKNJIZENJASelect1;
        private ReadWriteCommand cmSTRANEKNJIZENJASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVSTRANEKNJIZENJAOriginal;
        private readonly string m_SelectString215 = "TM1.[IDSTRANEKNJIZENJA], TM1.[NAZIVSTRANEKNJIZENJA]";
        private string m_WhereString;
        private short RcdFound215;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private STRANEKNJIZENJADataSet.STRANEKNJIZENJARow rowSTRANEKNJIZENJA;
        private string scmdbuf;
        private StatementType sMode215;
        private IDataReader STRANEKNJIZENJASelect1;
        private IDataReader STRANEKNJIZENJASelect4;
        private STRANEKNJIZENJADataSet STRANEKNJIZENJASet;

        public event STRANEKNJIZENJAUpdateEventHandler STRANEKNJIZENJAUpdated;

        public event STRANEKNJIZENJAUpdateEventHandler STRANEKNJIZENJAUpdating;

        private void AddRowStraneknjizenja()
        {
            this.STRANEKNJIZENJASet.STRANEKNJIZENJA.AddSTRANEKNJIZENJARow(this.rowSTRANEKNJIZENJA);
        }

        private void AfterConfirmStraneknjizenja()
        {
            this.OnSTRANEKNJIZENJAUpdating(new STRANEKNJIZENJAEventArgs(this.rowSTRANEKNJIZENJA, this.Gx_mode));
        }

        private void CheckDeleteErrorsStraneknjizenja()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMADD], [SHEMADDSTANDARDID] FROM [SHEMADDSHEMADDSTANDARD] WITH (NOLOCK) WHERE [STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA] = @IDSTRANEKNJIZENJA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANEKNJIZENJA", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANEKNJIZENJA["IDSTRANEKNJIZENJA"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new SHEMADDSHEMADDSTANDARDInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMADDSTANDARD" }));
            }
            reader2.Close();
            ReadWriteCommand command6 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAPLACA], [SHEMAPLACASTANDARDID] FROM [SHEMAPLACASHEMAPLACASTANDARD] WITH (NOLOCK) WHERE [STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA] = @IDSTRANEKNJIZENJA ", false);
            if (command6.IDbCommand.Parameters.Count == 0)
            {
                command6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANEKNJIZENJA", DbType.Int32));
            }
            command6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANEKNJIZENJA["IDSTRANEKNJIZENJA"]));
            IDataReader reader6 = command6.FetchData();
            if (command6.HasMoreRows)
            {
                reader6.Close();
                throw new SHEMAPLACASHEMAPLACASTANDARDInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAPLACASTANDARD" }));
            }
            reader6.Close();
            ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAPLACA], [SHEMAPLELEMENTIDELEMENT], [KONTOELEMENTIDKONTO], [STRANEELEMENTIDSTRANEKNJIZENJA] FROM [SHEMAPLACASHEMAPLACAELEMENT] WITH (NOLOCK) WHERE [STRANEELEMENTIDSTRANEKNJIZENJA] = @IDSTRANEKNJIZENJA ", false);
            if (command5.IDbCommand.Parameters.Count == 0)
            {
                command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANEKNJIZENJA", DbType.Int32));
            }
            command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANEKNJIZENJA["IDSTRANEKNJIZENJA"]));
            IDataReader reader5 = command5.FetchData();
            if (command5.HasMoreRows)
            {
                reader5.Close();
                throw new SHEMAPLACASHEMAPLACAELEMENTInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAPLACAELEMENT" }));
            }
            reader5.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMADD], [SHEMADDDOPRINOSIDDOPRINOS], [KONTODOPIDKONTO] FROM [SHEMADDSHEMADDDOPRINOS] WITH (NOLOCK) WHERE [STRANEDOPIDSTRANEKNJIZENJA] = @IDSTRANEKNJIZENJA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANEKNJIZENJA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANEKNJIZENJA["IDSTRANEKNJIZENJA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new SHEMADDSHEMADDDOPRINOSInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Doprinosi" }));
            }
            reader.Close();
            ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAPLACA], [SHEMAPLDOPIDDOPRINOS], [KONTODOPIDKONTO] FROM [SHEMAPLACASHEMAPLACADOP] WITH (NOLOCK) WHERE [STRANEDOPIDSTRANEKNJIZENJA] = @IDSTRANEKNJIZENJA ", false);
            if (command4.IDbCommand.Parameters.Count == 0)
            {
                command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANEKNJIZENJA", DbType.Int32));
            }
            command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANEKNJIZENJA["IDSTRANEKNJIZENJA"]));
            IDataReader reader4 = command4.FetchData();
            if (command4.HasMoreRows)
            {
                reader4.Close();
                throw new SHEMAPLACASHEMAPLACADOPInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Doprinosi" }));
            }
            reader4.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAIRA], [SHEMAIRAKONTOIDKONTO], [SHEMAIRASTRANEIDSTRANEKNJIZENJA] FROM [SHEMAIRASHEMAIRAKONTIRANJE] WITH (NOLOCK) WHERE [SHEMAIRASTRANEIDSTRANEKNJIZENJA] = @IDSTRANEKNJIZENJA ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANEKNJIZENJA", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANEKNJIZENJA["IDSTRANEKNJIZENJA"]));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                reader3.Close();
                throw new SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAIRAKONTIRANJE" }));
            }
            reader3.Close();
            ReadWriteCommand command7 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAURA], [SHEMAURAKONTOIDKONTO], [SHEMAURASTRANEIDSTRANEKNJIZENJA], [IDURAVRSTAIZNOSA] FROM [SHEMAURASHEMAURAKONTIRANJE] WITH (NOLOCK) WHERE [SHEMAURASTRANEIDSTRANEKNJIZENJA] = @IDSTRANEKNJIZENJA ", false);
            if (command7.IDbCommand.Parameters.Count == 0)
            {
                command7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANEKNJIZENJA", DbType.Int32));
            }
            command7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANEKNJIZENJA["IDSTRANEKNJIZENJA"]));
            IDataReader reader7 = command7.FetchData();
            if (command7.HasMoreRows)
            {
                reader7.Close();
                throw new SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAURAKONTIRANJE" }));
            }
            reader7.Close();
        }

        private void CheckOptimisticConcurrencyStraneknjizenja()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSTRANEKNJIZENJA], [NAZIVSTRANEKNJIZENJA] FROM [STRANEKNJIZENJA] WITH (UPDLOCK) WHERE [IDSTRANEKNJIZENJA] = @IDSTRANEKNJIZENJA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANEKNJIZENJA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANEKNJIZENJA["IDSTRANEKNJIZENJA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new STRANEKNJIZENJADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("STRANEKNJIZENJA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVSTRANEKNJIZENJAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new STRANEKNJIZENJADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("STRANEKNJIZENJA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowStraneknjizenja()
        {
            this.rowSTRANEKNJIZENJA = this.STRANEKNJIZENJASet.STRANEKNJIZENJA.NewSTRANEKNJIZENJARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyStraneknjizenja();
            this.AfterConfirmStraneknjizenja();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [STRANEKNJIZENJA]  WHERE [IDSTRANEKNJIZENJA] = @IDSTRANEKNJIZENJA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANEKNJIZENJA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANEKNJIZENJA["IDSTRANEKNJIZENJA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsStraneknjizenja();
            }
            this.OnSTRANEKNJIZENJAUpdated(new STRANEKNJIZENJAEventArgs(this.rowSTRANEKNJIZENJA, StatementType.Delete));
            this.rowSTRANEKNJIZENJA.Delete();
            this.sMode215 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode215;
        }

        public virtual int Fill(STRANEKNJIZENJADataSet dataSet)
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
                    this.STRANEKNJIZENJASet = dataSet;
                    this.LoadChildStraneknjizenja(0, -1);
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
            this.STRANEKNJIZENJASet = (STRANEKNJIZENJADataSet) dataSet;
            if (this.STRANEKNJIZENJASet != null)
            {
                return this.Fill(this.STRANEKNJIZENJASet);
            }
            this.STRANEKNJIZENJASet = new STRANEKNJIZENJADataSet();
            this.Fill(this.STRANEKNJIZENJASet);
            dataSet.Merge(this.STRANEKNJIZENJASet);
            return 0;
        }

        public virtual int Fill(STRANEKNJIZENJADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSTRANEKNJIZENJA"]));
        }

        public virtual int Fill(STRANEKNJIZENJADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSTRANEKNJIZENJA"]));
        }

        public virtual int Fill(STRANEKNJIZENJADataSet dataSet, int iDSTRANEKNJIZENJA)
        {
            if (!this.FillByIDSTRANEKNJIZENJA(dataSet, iDSTRANEKNJIZENJA))
            {
                throw new STRANEKNJIZENJANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("STRANEKNJIZENJA") }));
            }
            return 0;
        }

        public virtual bool FillByIDSTRANEKNJIZENJA(STRANEKNJIZENJADataSet dataSet, int iDSTRANEKNJIZENJA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.STRANEKNJIZENJASet = dataSet;
            this.rowSTRANEKNJIZENJA = this.STRANEKNJIZENJASet.STRANEKNJIZENJA.NewSTRANEKNJIZENJARow();
            this.rowSTRANEKNJIZENJA.IDSTRANEKNJIZENJA = iDSTRANEKNJIZENJA;
            try
            {
                this.LoadByIDSTRANEKNJIZENJA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound215 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(STRANEKNJIZENJADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.STRANEKNJIZENJASet = dataSet;
            try
            {
                this.LoadChildStraneknjizenja(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSTRANEKNJIZENJA], [NAZIVSTRANEKNJIZENJA] FROM [STRANEKNJIZENJA] WITH (NOLOCK) WHERE [IDSTRANEKNJIZENJA] = @IDSTRANEKNJIZENJA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANEKNJIZENJA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANEKNJIZENJA["IDSTRANEKNJIZENJA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound215 = 1;
                this.rowSTRANEKNJIZENJA["IDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowSTRANEKNJIZENJA["NAZIVSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode215 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode215;
            }
            else
            {
                this.RcdFound215 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDSTRANEKNJIZENJA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSTRANEKNJIZENJASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [STRANEKNJIZENJA] WITH (NOLOCK) ", false);
            this.STRANEKNJIZENJASelect1 = this.cmSTRANEKNJIZENJASelect1.FetchData();
            if (this.STRANEKNJIZENJASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.STRANEKNJIZENJASelect1.GetInt32(0);
            }
            this.STRANEKNJIZENJASelect1.Close();
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
            this.RcdFound215 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVSTRANEKNJIZENJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.STRANEKNJIZENJASet = new STRANEKNJIZENJADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertStraneknjizenja()
        {
            this.CheckOptimisticConcurrencyStraneknjizenja();
            this.AfterConfirmStraneknjizenja();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [STRANEKNJIZENJA] ([IDSTRANEKNJIZENJA], [NAZIVSTRANEKNJIZENJA]) VALUES (@IDSTRANEKNJIZENJA, @NAZIVSTRANEKNJIZENJA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANEKNJIZENJA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSTRANEKNJIZENJA", DbType.String, 30));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANEKNJIZENJA["IDSTRANEKNJIZENJA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSTRANEKNJIZENJA["NAZIVSTRANEKNJIZENJA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new STRANEKNJIZENJADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnSTRANEKNJIZENJAUpdated(new STRANEKNJIZENJAEventArgs(this.rowSTRANEKNJIZENJA, StatementType.Insert));
        }

        private void LoadByIDSTRANEKNJIZENJA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.STRANEKNJIZENJASet.EnforceConstraints;
            this.STRANEKNJIZENJASet.STRANEKNJIZENJA.BeginLoadData();
            this.ScanByIDSTRANEKNJIZENJA(startRow, maxRows);
            this.STRANEKNJIZENJASet.STRANEKNJIZENJA.EndLoadData();
            this.STRANEKNJIZENJASet.EnforceConstraints = enforceConstraints;
            if (this.STRANEKNJIZENJASet.STRANEKNJIZENJA.Count > 0)
            {
                this.rowSTRANEKNJIZENJA = this.STRANEKNJIZENJASet.STRANEKNJIZENJA[this.STRANEKNJIZENJASet.STRANEKNJIZENJA.Count - 1];
            }
        }

        private void LoadChildStraneknjizenja(int startRow, int maxRows)
        {
            this.CreateNewRowStraneknjizenja();
            bool enforceConstraints = this.STRANEKNJIZENJASet.EnforceConstraints;
            this.STRANEKNJIZENJASet.STRANEKNJIZENJA.BeginLoadData();
            this.ScanStartStraneknjizenja(startRow, maxRows);
            this.STRANEKNJIZENJASet.STRANEKNJIZENJA.EndLoadData();
            this.STRANEKNJIZENJASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataStraneknjizenja(int maxRows)
        {
            int num = 0;
            if (this.RcdFound215 != 0)
            {
                this.ScanLoadStraneknjizenja();
                while ((this.RcdFound215 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowStraneknjizenja();
                    this.CreateNewRowStraneknjizenja();
                    this.ScanNextStraneknjizenja();
                }
            }
            if (num > 0)
            {
                this.RcdFound215 = 1;
            }
            this.ScanEndStraneknjizenja();
            if (this.STRANEKNJIZENJASet.STRANEKNJIZENJA.Count > 0)
            {
                this.rowSTRANEKNJIZENJA = this.STRANEKNJIZENJASet.STRANEKNJIZENJA[this.STRANEKNJIZENJASet.STRANEKNJIZENJA.Count - 1];
            }
        }

        private void LoadRowStraneknjizenja()
        {
            this.AddRowStraneknjizenja();
        }

        private void OnSTRANEKNJIZENJAUpdated(STRANEKNJIZENJAEventArgs e)
        {
            if (this.STRANEKNJIZENJAUpdated != null)
            {
                STRANEKNJIZENJAUpdateEventHandler sTRANEKNJIZENJAUpdatedEvent = this.STRANEKNJIZENJAUpdated;
                if (sTRANEKNJIZENJAUpdatedEvent != null)
                {
                    sTRANEKNJIZENJAUpdatedEvent(this, e);
                }
            }
        }

        private void OnSTRANEKNJIZENJAUpdating(STRANEKNJIZENJAEventArgs e)
        {
            if (this.STRANEKNJIZENJAUpdating != null)
            {
                STRANEKNJIZENJAUpdateEventHandler sTRANEKNJIZENJAUpdatingEvent = this.STRANEKNJIZENJAUpdating;
                if (sTRANEKNJIZENJAUpdatingEvent != null)
                {
                    sTRANEKNJIZENJAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowStraneknjizenja()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSTRANEKNJIZENJA.RowState);
            if (this.rowSTRANEKNJIZENJA.RowState != DataRowState.Added)
            {
                this.m__NAZIVSTRANEKNJIZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowSTRANEKNJIZENJA["NAZIVSTRANEKNJIZENJA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVSTRANEKNJIZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowSTRANEKNJIZENJA["NAZIVSTRANEKNJIZENJA"]);
            }
            this._Gxremove = this.rowSTRANEKNJIZENJA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowSTRANEKNJIZENJA = (STRANEKNJIZENJADataSet.STRANEKNJIZENJARow) DataSetUtil.CloneOriginalDataRow(this.rowSTRANEKNJIZENJA);
            }
        }

        private void ScanByIDSTRANEKNJIZENJA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDSTRANEKNJIZENJA] = @IDSTRANEKNJIZENJA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString215 + "  FROM [STRANEKNJIZENJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSTRANEKNJIZENJA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString215, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSTRANEKNJIZENJA] ) AS DK_PAGENUM   FROM [STRANEKNJIZENJA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString215 + " FROM [STRANEKNJIZENJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSTRANEKNJIZENJA] ";
            }
            this.cmSTRANEKNJIZENJASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmSTRANEKNJIZENJASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmSTRANEKNJIZENJASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANEKNJIZENJA", DbType.Int32));
            }
            this.cmSTRANEKNJIZENJASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANEKNJIZENJA["IDSTRANEKNJIZENJA"]));
            this.STRANEKNJIZENJASelect4 = this.cmSTRANEKNJIZENJASelect4.FetchData();
            this.RcdFound215 = 0;
            this.ScanLoadStraneknjizenja();
            this.LoadDataStraneknjizenja(maxRows);
        }

        private void ScanEndStraneknjizenja()
        {
            this.STRANEKNJIZENJASelect4.Close();
        }

        private void ScanLoadStraneknjizenja()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSTRANEKNJIZENJASelect4.HasMoreRows)
            {
                this.RcdFound215 = 1;
                this.rowSTRANEKNJIZENJA["IDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.STRANEKNJIZENJASelect4, 0));
                this.rowSTRANEKNJIZENJA["NAZIVSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.STRANEKNJIZENJASelect4, 1));
            }
        }

        private void ScanNextStraneknjizenja()
        {
            this.cmSTRANEKNJIZENJASelect4.HasMoreRows = this.STRANEKNJIZENJASelect4.Read();
            this.RcdFound215 = 0;
            this.ScanLoadStraneknjizenja();
        }

        private void ScanStartStraneknjizenja(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString215 + "  FROM [STRANEKNJIZENJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSTRANEKNJIZENJA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString215, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSTRANEKNJIZENJA] ) AS DK_PAGENUM   FROM [STRANEKNJIZENJA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString215 + " FROM [STRANEKNJIZENJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSTRANEKNJIZENJA] ";
            }
            this.cmSTRANEKNJIZENJASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.STRANEKNJIZENJASelect4 = this.cmSTRANEKNJIZENJASelect4.FetchData();
            this.RcdFound215 = 0;
            this.ScanLoadStraneknjizenja();
            this.LoadDataStraneknjizenja(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.STRANEKNJIZENJASet = (STRANEKNJIZENJADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.STRANEKNJIZENJASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.STRANEKNJIZENJASet.STRANEKNJIZENJA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        STRANEKNJIZENJADataSet.STRANEKNJIZENJARow current = (STRANEKNJIZENJADataSet.STRANEKNJIZENJARow) enumerator.Current;
                        this.rowSTRANEKNJIZENJA = current;
                        if (Helpers.IsRowChanged(this.rowSTRANEKNJIZENJA))
                        {
                            this.ReadRowStraneknjizenja();
                            if (this.rowSTRANEKNJIZENJA.RowState == DataRowState.Added)
                            {
                                this.InsertStraneknjizenja();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateStraneknjizenja();
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

        private void UpdateStraneknjizenja()
        {
            this.CheckOptimisticConcurrencyStraneknjizenja();
            this.AfterConfirmStraneknjizenja();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [STRANEKNJIZENJA] SET [NAZIVSTRANEKNJIZENJA]=@NAZIVSTRANEKNJIZENJA  WHERE [IDSTRANEKNJIZENJA] = @IDSTRANEKNJIZENJA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSTRANEKNJIZENJA", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRANEKNJIZENJA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRANEKNJIZENJA["NAZIVSTRANEKNJIZENJA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSTRANEKNJIZENJA["IDSTRANEKNJIZENJA"]));
            command.ExecuteStmt();
            this.OnSTRANEKNJIZENJAUpdated(new STRANEKNJIZENJAEventArgs(this.rowSTRANEKNJIZENJA, StatementType.Update));
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

        [Serializable]
        public class STRANEKNJIZENJADataChangedException : DataChangedException
        {
            public STRANEKNJIZENJADataChangedException()
            {
            }

            public STRANEKNJIZENJADataChangedException(string message) : base(message)
            {
            }

            protected STRANEKNJIZENJADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRANEKNJIZENJADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class STRANEKNJIZENJADataLockedException : DataLockedException
        {
            public STRANEKNJIZENJADataLockedException()
            {
            }

            public STRANEKNJIZENJADataLockedException(string message) : base(message)
            {
            }

            protected STRANEKNJIZENJADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRANEKNJIZENJADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class STRANEKNJIZENJADuplicateKeyException : DuplicateKeyException
        {
            public STRANEKNJIZENJADuplicateKeyException()
            {
            }

            public STRANEKNJIZENJADuplicateKeyException(string message) : base(message)
            {
            }

            protected STRANEKNJIZENJADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRANEKNJIZENJADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class STRANEKNJIZENJAEventArgs : EventArgs
        {
            private STRANEKNJIZENJADataSet.STRANEKNJIZENJARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public STRANEKNJIZENJAEventArgs(STRANEKNJIZENJADataSet.STRANEKNJIZENJARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public STRANEKNJIZENJADataSet.STRANEKNJIZENJARow Row
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
        public class STRANEKNJIZENJANotFoundException : DataNotFoundException
        {
            public STRANEKNJIZENJANotFoundException()
            {
            }

            public STRANEKNJIZENJANotFoundException(string message) : base(message)
            {
            }

            protected STRANEKNJIZENJANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRANEKNJIZENJANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void STRANEKNJIZENJAUpdateEventHandler(object sender, STRANEKNJIZENJADataAdapter.STRANEKNJIZENJAEventArgs e);
    }
}

