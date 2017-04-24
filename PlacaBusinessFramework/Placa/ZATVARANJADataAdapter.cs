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

    public class ZATVARANJADataAdapter : IDataAdapter, IZATVARANJADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmZATVARANJASelect1;
        private ReadWriteCommand cmZATVARANJASelect2;
        private ReadWriteCommand cmZATVARANJASelect3;
        private ReadWriteCommand cmZATVARANJASelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__ZATVARANJAIZNOSOriginal;
        private readonly string m_SelectString201 = "TM1.[ZATVARANJAIZNOS], TM1.[GK1IDGKSTAVKA] AS GK1IDGKSTAVKA, TM1.[GK2IDGKSTAVKA] AS GK2IDGKSTAVKA";
        private string m_WhereString;
        private short RcdFound201;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private ZATVARANJADataSet.ZATVARANJARow rowZATVARANJA;
        private string scmdbuf;
        private StatementType sMode201;
        private IDataReader ZATVARANJASelect1;
        private IDataReader ZATVARANJASelect2;
        private IDataReader ZATVARANJASelect3;
        private IDataReader ZATVARANJASelect6;
        private ZATVARANJADataSet ZATVARANJASet;

        public event ZATVARANJAUpdateEventHandler ZATVARANJAUpdated;

        public event ZATVARANJAUpdateEventHandler ZATVARANJAUpdating;

        private void AddRowZatvaranja()
        {
            this.ZATVARANJASet.ZATVARANJA.AddZATVARANJARow(this.rowZATVARANJA);
        }

        private void AfterConfirmZatvaranja()
        {
            this.OnZATVARANJAUpdating(new ZATVARANJAEventArgs(this.rowZATVARANJA, this.Gx_mode));
        }

        private void CheckIntegrityErrorsZatvaranja()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDGKSTAVKA] AS GK1IDGKSTAVKA FROM [GKSTAVKA] WITH (NOLOCK) WHERE [IDGKSTAVKA] = @GK1IDGKSTAVKA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK1IDGKSTAVKA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["GK1IDGKSTAVKA"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new GKSTAVKAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("GKSTAVKA") }));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [IDGKSTAVKA] AS GK2IDGKSTAVKA FROM [GKSTAVKA] WITH (NOLOCK) WHERE [IDGKSTAVKA] = @GK2IDGKSTAVKA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK2IDGKSTAVKA", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["GK2IDGKSTAVKA"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new GKSTAVKAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("GKSTAVKA") }));
            }
            reader2.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyZatvaranja()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [ZATVARANJAIZNOS], [GK1IDGKSTAVKA] AS GK1IDGKSTAVKA, [GK2IDGKSTAVKA] AS GK2IDGKSTAVKA FROM [ZATVARANJA] WITH (UPDLOCK) WHERE [GK1IDGKSTAVKA] = @GK1IDGKSTAVKA AND [GK2IDGKSTAVKA] = @GK2IDGKSTAVKA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK1IDGKSTAVKA", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK2IDGKSTAVKA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["GK1IDGKSTAVKA"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["GK2IDGKSTAVKA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new ZATVARANJADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("ZATVARANJA") }));
                }
                if (!command.HasMoreRows || !this.m__ZATVARANJAIZNOSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0))))
                {
                    reader.Close();
                    throw new ZATVARANJADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("ZATVARANJA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowZatvaranja()
        {
            this.rowZATVARANJA = this.ZATVARANJASet.ZATVARANJA.NewZATVARANJARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyZatvaranja();
            this.AfterConfirmZatvaranja();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [ZATVARANJA]  WHERE [GK1IDGKSTAVKA] = @GK1IDGKSTAVKA AND [GK2IDGKSTAVKA] = @GK2IDGKSTAVKA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK1IDGKSTAVKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK2IDGKSTAVKA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["GK1IDGKSTAVKA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["GK2IDGKSTAVKA"]));
            command.ExecuteStmt();
            this.OnZATVARANJAUpdated(new ZATVARANJAEventArgs(this.rowZATVARANJA, StatementType.Delete));
            this.rowZATVARANJA.Delete();
            this.sMode201 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode201;
        }

        public virtual int Fill(ZATVARANJADataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), int.Parse(this.fillDataParameters[1].Value.ToString()));
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.ZATVARANJASet = dataSet;
                    this.LoadChildZatvaranja(0, -1);
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
            this.ZATVARANJASet = (ZATVARANJADataSet) dataSet;
            if (this.ZATVARANJASet != null)
            {
                return this.Fill(this.ZATVARANJASet);
            }
            this.ZATVARANJASet = new ZATVARANJADataSet();
            this.Fill(this.ZATVARANJASet);
            dataSet.Merge(this.ZATVARANJASet);
            return 0;
        }

        public virtual int Fill(ZATVARANJADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["GK1IDGKSTAVKA"]), Conversions.ToInteger(dataRecord["GK2IDGKSTAVKA"]));
        }

        public virtual int Fill(ZATVARANJADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["GK1IDGKSTAVKA"]), Conversions.ToInteger(dataRecord["GK2IDGKSTAVKA"]));
        }

        public virtual int Fill(ZATVARANJADataSet dataSet, int gK1IDGKSTAVKA, int gK2IDGKSTAVKA)
        {
            if (!this.FillByGK1IDGKSTAVKAGK2IDGKSTAVKA(dataSet, gK1IDGKSTAVKA, gK2IDGKSTAVKA))
            {
                throw new ZATVARANJANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ZATVARANJA") }));
            }
            return 0;
        }

        public virtual int FillByGK1IDGKSTAVKA(ZATVARANJADataSet dataSet, int gK1IDGKSTAVKA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ZATVARANJASet = dataSet;
            this.rowZATVARANJA = this.ZATVARANJASet.ZATVARANJA.NewZATVARANJARow();
            this.rowZATVARANJA.GK1IDGKSTAVKA = gK1IDGKSTAVKA;
            try
            {
                this.LoadByGK1IDGKSTAVKA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByGK1IDGKSTAVKAGK2IDGKSTAVKA(ZATVARANJADataSet dataSet, int gK1IDGKSTAVKA, int gK2IDGKSTAVKA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ZATVARANJASet = dataSet;
            this.rowZATVARANJA = this.ZATVARANJASet.ZATVARANJA.NewZATVARANJARow();
            this.rowZATVARANJA.GK1IDGKSTAVKA = gK1IDGKSTAVKA;
            this.rowZATVARANJA.GK2IDGKSTAVKA = gK2IDGKSTAVKA;
            try
            {
                this.LoadByGK1IDGKSTAVKAGK2IDGKSTAVKA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound201 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByGK2IDGKSTAVKA(ZATVARANJADataSet dataSet, int gK2IDGKSTAVKA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ZATVARANJASet = dataSet;
            this.rowZATVARANJA = this.ZATVARANJASet.ZATVARANJA.NewZATVARANJARow();
            this.rowZATVARANJA.GK2IDGKSTAVKA = gK2IDGKSTAVKA;
            try
            {
                this.LoadByGK2IDGKSTAVKA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(ZATVARANJADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ZATVARANJASet = dataSet;
            try
            {
                this.LoadChildZatvaranja(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByGK1IDGKSTAVKA(ZATVARANJADataSet dataSet, int gK1IDGKSTAVKA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ZATVARANJASet = dataSet;
            this.rowZATVARANJA = this.ZATVARANJASet.ZATVARANJA.NewZATVARANJARow();
            this.rowZATVARANJA.GK1IDGKSTAVKA = gK1IDGKSTAVKA;
            try
            {
                this.LoadByGK1IDGKSTAVKA(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByGK2IDGKSTAVKA(ZATVARANJADataSet dataSet, int gK2IDGKSTAVKA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ZATVARANJASet = dataSet;
            this.rowZATVARANJA = this.ZATVARANJASet.ZATVARANJA.NewZATVARANJARow();
            this.rowZATVARANJA.GK2IDGKSTAVKA = gK2IDGKSTAVKA;
            try
            {
                this.LoadByGK2IDGKSTAVKA(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [ZATVARANJAIZNOS], [GK1IDGKSTAVKA] AS GK1IDGKSTAVKA, [GK2IDGKSTAVKA] AS GK2IDGKSTAVKA FROM [ZATVARANJA] WITH (NOLOCK) WHERE [GK1IDGKSTAVKA] = @GK1IDGKSTAVKA AND [GK2IDGKSTAVKA] = @GK2IDGKSTAVKA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK1IDGKSTAVKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK2IDGKSTAVKA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["GK1IDGKSTAVKA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["GK2IDGKSTAVKA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound201 = 1;
                this.rowZATVARANJA["ZATVARANJAIZNOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 0));
                this.rowZATVARANJA["GK1IDGKSTAVKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 1));
                this.rowZATVARANJA["GK2IDGKSTAVKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2));
                this.sMode201 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode201;
            }
            else
            {
                this.RcdFound201 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                DbParameter parameter = factory.CreateParameter();
                parameter.ParameterName = "GK1IDGKSTAVKA";
                parameter.DbType = DbType.Int32;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "GK2IDGKSTAVKA";
                parameter2.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmZATVARANJASelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [ZATVARANJA] WITH (NOLOCK) ", false);
            this.ZATVARANJASelect3 = this.cmZATVARANJASelect3.FetchData();
            if (this.ZATVARANJASelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.ZATVARANJASelect3.GetInt32(0);
            }
            this.ZATVARANJASelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByGK1IDGKSTAVKA(int gK1IDGKSTAVKA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmZATVARANJASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [ZATVARANJA] WITH (NOLOCK) WHERE [GK1IDGKSTAVKA] = @GK1IDGKSTAVKA ", false);
            if (this.cmZATVARANJASelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmZATVARANJASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK1IDGKSTAVKA", DbType.Int32));
            }
            this.cmZATVARANJASelect1.SetParameter(0, gK1IDGKSTAVKA);
            this.ZATVARANJASelect1 = this.cmZATVARANJASelect1.FetchData();
            if (this.ZATVARANJASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.ZATVARANJASelect1.GetInt32(0);
            }
            this.ZATVARANJASelect1.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByGK2IDGKSTAVKA(int gK2IDGKSTAVKA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmZATVARANJASelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [ZATVARANJA] WITH (NOLOCK) WHERE [GK2IDGKSTAVKA] = @GK2IDGKSTAVKA ", false);
            if (this.cmZATVARANJASelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmZATVARANJASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK2IDGKSTAVKA", DbType.Int32));
            }
            this.cmZATVARANJASelect2.SetParameter(0, gK2IDGKSTAVKA);
            this.ZATVARANJASelect2 = this.cmZATVARANJASelect2.FetchData();
            if (this.ZATVARANJASelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.ZATVARANJASelect2.GetInt32(0);
            }
            this.ZATVARANJASelect2.Close();
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

        public virtual int GetRecordCountByGK1IDGKSTAVKA(int gK1IDGKSTAVKA)
        {
            int num2 = 0;
            try
            {
                this.InitializeMembers();
                num2 = this.GetInternalRecordCountByGK1IDGKSTAVKA(gK1IDGKSTAVKA);
            }
            finally
            {
                this.Cleanup();
            }
            return num2;
        }

        public virtual int GetRecordCountByGK2IDGKSTAVKA(int gK2IDGKSTAVKA)
        {
            int num2 = 0;
            try
            {
                this.InitializeMembers();
                num2 = this.GetInternalRecordCountByGK2IDGKSTAVKA(gK2IDGKSTAVKA);
            }
            finally
            {
                this.Cleanup();
            }
            return num2;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound201 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__ZATVARANJAIZNOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.ZATVARANJASet = new ZATVARANJADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertZatvaranja()
        {
            this.CheckOptimisticConcurrencyZatvaranja();
            this.AfterConfirmZatvaranja();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [ZATVARANJA] ([ZATVARANJAIZNOS], [GK1IDGKSTAVKA], [GK2IDGKSTAVKA]) VALUES (@ZATVARANJAIZNOS, @GK1IDGKSTAVKA, @GK2IDGKSTAVKA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZATVARANJAIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK1IDGKSTAVKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK2IDGKSTAVKA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["ZATVARANJAIZNOS"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["GK1IDGKSTAVKA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["GK2IDGKSTAVKA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new ZATVARANJADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsZatvaranja();
            }
            this.OnZATVARANJAUpdated(new ZATVARANJAEventArgs(this.rowZATVARANJA, StatementType.Insert));
        }

        private void LoadByGK1IDGKSTAVKA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.ZATVARANJASet.EnforceConstraints;
            this.ZATVARANJASet.ZATVARANJA.BeginLoadData();
            this.ScanByGK1IDGKSTAVKA(startRow, maxRows);
            this.ZATVARANJASet.ZATVARANJA.EndLoadData();
            this.ZATVARANJASet.EnforceConstraints = enforceConstraints;
            if (this.ZATVARANJASet.ZATVARANJA.Count > 0)
            {
                this.rowZATVARANJA = this.ZATVARANJASet.ZATVARANJA[this.ZATVARANJASet.ZATVARANJA.Count - 1];
            }
        }

        private void LoadByGK1IDGKSTAVKAGK2IDGKSTAVKA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.ZATVARANJASet.EnforceConstraints;
            this.ZATVARANJASet.ZATVARANJA.BeginLoadData();
            this.ScanByGK1IDGKSTAVKAGK2IDGKSTAVKA(startRow, maxRows);
            this.ZATVARANJASet.ZATVARANJA.EndLoadData();
            this.ZATVARANJASet.EnforceConstraints = enforceConstraints;
            if (this.ZATVARANJASet.ZATVARANJA.Count > 0)
            {
                this.rowZATVARANJA = this.ZATVARANJASet.ZATVARANJA[this.ZATVARANJASet.ZATVARANJA.Count - 1];
            }
        }

        private void LoadByGK2IDGKSTAVKA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.ZATVARANJASet.EnforceConstraints;
            this.ZATVARANJASet.ZATVARANJA.BeginLoadData();
            this.ScanByGK2IDGKSTAVKA(startRow, maxRows);
            this.ZATVARANJASet.ZATVARANJA.EndLoadData();
            this.ZATVARANJASet.EnforceConstraints = enforceConstraints;
            if (this.ZATVARANJASet.ZATVARANJA.Count > 0)
            {
                this.rowZATVARANJA = this.ZATVARANJASet.ZATVARANJA[this.ZATVARANJASet.ZATVARANJA.Count - 1];
            }
        }

        private void LoadChildZatvaranja(int startRow, int maxRows)
        {
            this.CreateNewRowZatvaranja();
            bool enforceConstraints = this.ZATVARANJASet.EnforceConstraints;
            this.ZATVARANJASet.ZATVARANJA.BeginLoadData();
            this.ScanStartZatvaranja(startRow, maxRows);
            this.ZATVARANJASet.ZATVARANJA.EndLoadData();
            this.ZATVARANJASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataZatvaranja(int maxRows)
        {
            int num = 0;
            if (this.RcdFound201 != 0)
            {
                this.ScanLoadZatvaranja();
                while ((this.RcdFound201 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowZatvaranja();
                    this.CreateNewRowZatvaranja();
                    this.ScanNextZatvaranja();
                }
            }
            if (num > 0)
            {
                this.RcdFound201 = 1;
            }
            this.ScanEndZatvaranja();
            if (this.ZATVARANJASet.ZATVARANJA.Count > 0)
            {
                this.rowZATVARANJA = this.ZATVARANJASet.ZATVARANJA[this.ZATVARANJASet.ZATVARANJA.Count - 1];
            }
        }

        private void LoadRowZatvaranja()
        {
            this.AddRowZatvaranja();
        }

        private void OnZATVARANJAUpdated(ZATVARANJAEventArgs e)
        {
            if (this.ZATVARANJAUpdated != null)
            {
                ZATVARANJAUpdateEventHandler zATVARANJAUpdatedEvent = this.ZATVARANJAUpdated;
                if (zATVARANJAUpdatedEvent != null)
                {
                    zATVARANJAUpdatedEvent(this, e);
                }
            }
        }

        private void OnZATVARANJAUpdating(ZATVARANJAEventArgs e)
        {
            if (this.ZATVARANJAUpdating != null)
            {
                ZATVARANJAUpdateEventHandler zATVARANJAUpdatingEvent = this.ZATVARANJAUpdating;
                if (zATVARANJAUpdatingEvent != null)
                {
                    zATVARANJAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowZatvaranja()
        {
            this.Gx_mode = Mode.FromRowState(this.rowZATVARANJA.RowState);
            if (this.rowZATVARANJA.RowState != DataRowState.Added)
            {
                this.m__ZATVARANJAIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["ZATVARANJAIZNOS", DataRowVersion.Original]);
            }
            else
            {
                this.m__ZATVARANJAIZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["ZATVARANJAIZNOS"]);
            }
            this._Gxremove = this.rowZATVARANJA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowZATVARANJA = (ZATVARANJADataSet.ZATVARANJARow) DataSetUtil.CloneOriginalDataRow(this.rowZATVARANJA);
            }
        }

        private void ScanByGK1IDGKSTAVKA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[GK1IDGKSTAVKA] = @GK1IDGKSTAVKA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString201 + "  FROM [ZATVARANJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[GK1IDGKSTAVKA], TM1.[GK2IDGKSTAVKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString201, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[GK1IDGKSTAVKA], TM1.[GK2IDGKSTAVKA] ) AS DK_PAGENUM   FROM [ZATVARANJA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString201 + " FROM [ZATVARANJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[GK1IDGKSTAVKA], TM1.[GK2IDGKSTAVKA] ";
            }
            this.cmZATVARANJASelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmZATVARANJASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmZATVARANJASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK1IDGKSTAVKA", DbType.Int32));
            }
            this.cmZATVARANJASelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["GK1IDGKSTAVKA"]));
            this.ZATVARANJASelect6 = this.cmZATVARANJASelect6.FetchData();
            this.RcdFound201 = 0;
            this.ScanLoadZatvaranja();
            this.LoadDataZatvaranja(maxRows);
        }

        private void ScanByGK1IDGKSTAVKAGK2IDGKSTAVKA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[GK1IDGKSTAVKA] = @GK1IDGKSTAVKA and TM1.[GK2IDGKSTAVKA] = @GK2IDGKSTAVKA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString201 + "  FROM [ZATVARANJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[GK1IDGKSTAVKA], TM1.[GK2IDGKSTAVKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString201, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[GK1IDGKSTAVKA], TM1.[GK2IDGKSTAVKA] ) AS DK_PAGENUM   FROM [ZATVARANJA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString201 + " FROM [ZATVARANJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[GK1IDGKSTAVKA], TM1.[GK2IDGKSTAVKA] ";
            }
            this.cmZATVARANJASelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmZATVARANJASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmZATVARANJASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK1IDGKSTAVKA", DbType.Int32));
                this.cmZATVARANJASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK2IDGKSTAVKA", DbType.Int32));
            }
            this.cmZATVARANJASelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["GK1IDGKSTAVKA"]));
            this.cmZATVARANJASelect6.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["GK2IDGKSTAVKA"]));
            this.ZATVARANJASelect6 = this.cmZATVARANJASelect6.FetchData();
            this.RcdFound201 = 0;
            this.ScanLoadZatvaranja();
            this.LoadDataZatvaranja(maxRows);
        }

        private void ScanByGK2IDGKSTAVKA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[GK2IDGKSTAVKA] = @GK2IDGKSTAVKA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString201 + "  FROM [ZATVARANJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[GK1IDGKSTAVKA], TM1.[GK2IDGKSTAVKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString201, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[GK1IDGKSTAVKA], TM1.[GK2IDGKSTAVKA] ) AS DK_PAGENUM   FROM [ZATVARANJA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString201 + " FROM [ZATVARANJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[GK1IDGKSTAVKA], TM1.[GK2IDGKSTAVKA] ";
            }
            this.cmZATVARANJASelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmZATVARANJASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmZATVARANJASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK2IDGKSTAVKA", DbType.Int32));
            }
            this.cmZATVARANJASelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["GK2IDGKSTAVKA"]));
            this.ZATVARANJASelect6 = this.cmZATVARANJASelect6.FetchData();
            this.RcdFound201 = 0;
            this.ScanLoadZatvaranja();
            this.LoadDataZatvaranja(maxRows);
        }

        private void ScanEndZatvaranja()
        {
            this.ZATVARANJASelect6.Close();
        }

        private void ScanLoadZatvaranja()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmZATVARANJASelect6.HasMoreRows)
            {
                this.RcdFound201 = 1;
                this.rowZATVARANJA["ZATVARANJAIZNOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.ZATVARANJASelect6, 0));
                this.rowZATVARANJA["GK1IDGKSTAVKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ZATVARANJASelect6, 1));
                this.rowZATVARANJA["GK2IDGKSTAVKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ZATVARANJASelect6, 2));
            }
        }

        private void ScanNextZatvaranja()
        {
            this.cmZATVARANJASelect6.HasMoreRows = this.ZATVARANJASelect6.Read();
            this.RcdFound201 = 0;
            this.ScanLoadZatvaranja();
        }

        private void ScanStartZatvaranja(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString201 + "  FROM [ZATVARANJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[GK1IDGKSTAVKA], TM1.[GK2IDGKSTAVKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString201, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[GK1IDGKSTAVKA], TM1.[GK2IDGKSTAVKA] ) AS DK_PAGENUM   FROM [ZATVARANJA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString201 + " FROM [ZATVARANJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[GK1IDGKSTAVKA], TM1.[GK2IDGKSTAVKA] ";
            }
            this.cmZATVARANJASelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.ZATVARANJASelect6 = this.cmZATVARANJASelect6.FetchData();
            this.RcdFound201 = 0;
            this.ScanLoadZatvaranja();
            this.LoadDataZatvaranja(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.ZATVARANJASet = (ZATVARANJADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.ZATVARANJASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.ZATVARANJASet.ZATVARANJA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ZATVARANJADataSet.ZATVARANJARow current = (ZATVARANJADataSet.ZATVARANJARow) enumerator.Current;
                        this.rowZATVARANJA = current;
                        if (Helpers.IsRowChanged(this.rowZATVARANJA))
                        {
                            this.ReadRowZatvaranja();
                            if (this.rowZATVARANJA.RowState == DataRowState.Added)
                            {
                                this.InsertZatvaranja();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateZatvaranja();
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

        private void UpdateZatvaranja()
        {
            this.CheckOptimisticConcurrencyZatvaranja();
            this.AfterConfirmZatvaranja();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [ZATVARANJA] SET [ZATVARANJAIZNOS]=@ZATVARANJAIZNOS  WHERE [GK1IDGKSTAVKA] = @GK1IDGKSTAVKA AND [GK2IDGKSTAVKA] = @GK2IDGKSTAVKA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZATVARANJAIZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK1IDGKSTAVKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GK2IDGKSTAVKA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["ZATVARANJAIZNOS"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["GK1IDGKSTAVKA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowZATVARANJA["GK2IDGKSTAVKA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsZatvaranja();
            }
            this.OnZATVARANJAUpdated(new ZATVARANJAEventArgs(this.rowZATVARANJA, StatementType.Update));
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
        public class ForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public ForeignKeyNotFoundException()
            {
            }

            public ForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected ForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GKSTAVKAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public GKSTAVKAForeignKeyNotFoundException()
            {
            }

            public GKSTAVKAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected GKSTAVKAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GKSTAVKAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ZATVARANJADataChangedException : DataChangedException
        {
            public ZATVARANJADataChangedException()
            {
            }

            public ZATVARANJADataChangedException(string message) : base(message)
            {
            }

            protected ZATVARANJADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ZATVARANJADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ZATVARANJADataLockedException : DataLockedException
        {
            public ZATVARANJADataLockedException()
            {
            }

            public ZATVARANJADataLockedException(string message) : base(message)
            {
            }

            protected ZATVARANJADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ZATVARANJADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ZATVARANJADuplicateKeyException : DuplicateKeyException
        {
            public ZATVARANJADuplicateKeyException()
            {
            }

            public ZATVARANJADuplicateKeyException(string message) : base(message)
            {
            }

            protected ZATVARANJADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ZATVARANJADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class ZATVARANJAEventArgs : EventArgs
        {
            private ZATVARANJADataSet.ZATVARANJARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public ZATVARANJAEventArgs(ZATVARANJADataSet.ZATVARANJARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public ZATVARANJADataSet.ZATVARANJARow Row
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
        public class ZATVARANJANotFoundException : DataNotFoundException
        {
            public ZATVARANJANotFoundException()
            {
            }

            public ZATVARANJANotFoundException(string message) : base(message)
            {
            }

            protected ZATVARANJANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ZATVARANJANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void ZATVARANJAUpdateEventHandler(object sender, ZATVARANJADataAdapter.ZATVARANJAEventArgs e);
    }
}

