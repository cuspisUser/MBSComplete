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

    public class RAD1SPREMEVEZADataAdapter : IDataAdapter, IRAD1SPREMEVEZADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmRAD1SPREMEVEZASelect1;
        private ReadWriteCommand cmRAD1SPREMEVEZASelect2;
        private ReadWriteCommand cmRAD1SPREMEVEZASelect3;
        private ReadWriteCommand cmRAD1SPREMEVEZASelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private readonly string m_SelectString288 = "TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA]";
        private string m_WhereString;
        private IDataReader RAD1SPREMEVEZASelect1;
        private IDataReader RAD1SPREMEVEZASelect2;
        private IDataReader RAD1SPREMEVEZASelect3;
        private IDataReader RAD1SPREMEVEZASelect6;
        private RAD1SPREMEVEZADataSet RAD1SPREMEVEZASet;
        private short RcdFound288;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow rowRAD1SPREMEVEZA;
        private string scmdbuf;
        private StatementType sMode288;

        public event RAD1SPREMEVEZAUpdateEventHandler RAD1SPREMEVEZAUpdated;

        public event RAD1SPREMEVEZAUpdateEventHandler RAD1SPREMEVEZAUpdating;

        private void AddRowRad1spremeveza()
        {
            this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.AddRAD1SPREMEVEZARow(this.rowRAD1SPREMEVEZA);
        }

        private void AfterConfirmRad1spremeveza()
        {
            this.OnRAD1SPREMEVEZAUpdating(new RAD1SPREMEVEZAEventArgs(this.rowRAD1SPREMEVEZA, this.Gx_mode));
        }

        private void CheckIntegrityErrorsRad1spremeveza()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [RAD1IDSPREME] FROM [RAD1SPREME] WITH (NOLOCK) WHERE [RAD1IDSPREME] = @RAD1IDSPREME ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1IDSPREME", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREMEVEZA["RAD1IDSPREME"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new RAD1SPREMEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RAD1SPREME") }));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [IDSTRUCNASPREMA] FROM [STRUCNASPREMA] WITH (NOLOCK) WHERE [IDSTRUCNASPREMA] = @IDSTRUCNASPREMA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREMEVEZA["IDSTRUCNASPREMA"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new STRUCNASPREMAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("STRUCNASPREMA") }));
            }
            reader2.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyRad1spremeveza()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [RAD1IDSPREME], [IDSTRUCNASPREMA] FROM [RAD1SPREMEVEZA] WITH (UPDLOCK) WHERE [RAD1IDSPREME] = @RAD1IDSPREME AND [IDSTRUCNASPREMA] = @IDSTRUCNASPREMA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1IDSPREME", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREMEVEZA["RAD1IDSPREME"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREMEVEZA["IDSTRUCNASPREMA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RAD1SPREMEVEZADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RAD1SPREMEVEZA") }));
                }
                if (!command.HasMoreRows)
                {
                    reader.Close();
                    throw new RAD1SPREMEVEZADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RAD1SPREMEVEZA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowRad1spremeveza()
        {
            this.rowRAD1SPREMEVEZA = this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.NewRAD1SPREMEVEZARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRad1spremeveza();
            this.AfterConfirmRad1spremeveza();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RAD1SPREMEVEZA]  WHERE [RAD1IDSPREME] = @RAD1IDSPREME AND [IDSTRUCNASPREMA] = @IDSTRUCNASPREMA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1IDSPREME", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREMEVEZA["RAD1IDSPREME"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREMEVEZA["IDSTRUCNASPREMA"]));
            command.ExecuteStmt();
            this.OnRAD1SPREMEVEZAUpdated(new RAD1SPREMEVEZAEventArgs(this.rowRAD1SPREMEVEZA, StatementType.Delete));
            this.rowRAD1SPREMEVEZA.Delete();
            this.sMode288 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode288;
        }

        public virtual int Fill(RAD1SPREMEVEZADataSet dataSet)
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
                    this.RAD1SPREMEVEZASet = dataSet;
                    this.LoadChildRad1spremeveza(0, -1);
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
            this.RAD1SPREMEVEZASet = (RAD1SPREMEVEZADataSet) dataSet;
            if (this.RAD1SPREMEVEZASet != null)
            {
                return this.Fill(this.RAD1SPREMEVEZASet);
            }
            this.RAD1SPREMEVEZASet = new RAD1SPREMEVEZADataSet();
            this.Fill(this.RAD1SPREMEVEZASet);
            dataSet.Merge(this.RAD1SPREMEVEZASet);
            return 0;
        }

        public virtual int Fill(RAD1SPREMEVEZADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["RAD1IDSPREME"]), Conversions.ToInteger(dataRecord["IDSTRUCNASPREMA"]));
        }

        public virtual int Fill(RAD1SPREMEVEZADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["RAD1IDSPREME"]), Conversions.ToInteger(dataRecord["IDSTRUCNASPREMA"]));
        }

        public virtual int Fill(RAD1SPREMEVEZADataSet dataSet, int rAD1IDSPREME, int iDSTRUCNASPREMA)
        {
            if (!this.FillByRAD1IDSPREMEIDSTRUCNASPREMA(dataSet, rAD1IDSPREME, iDSTRUCNASPREMA))
            {
                throw new RAD1SPREMEVEZANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RAD1SPREMEVEZA") }));
            }
            return 0;
        }

        public virtual int FillByIDSTRUCNASPREMA(RAD1SPREMEVEZADataSet dataSet, int iDSTRUCNASPREMA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1SPREMEVEZASet = dataSet;
            this.rowRAD1SPREMEVEZA = this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.NewRAD1SPREMEVEZARow();
            this.rowRAD1SPREMEVEZA.IDSTRUCNASPREMA = iDSTRUCNASPREMA;
            try
            {
                this.LoadByIDSTRUCNASPREMA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillByRAD1IDSPREME(RAD1SPREMEVEZADataSet dataSet, int rAD1IDSPREME)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1SPREMEVEZASet = dataSet;
            this.rowRAD1SPREMEVEZA = this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.NewRAD1SPREMEVEZARow();
            this.rowRAD1SPREMEVEZA.RAD1IDSPREME = rAD1IDSPREME;
            try
            {
                this.LoadByRAD1IDSPREME(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByRAD1IDSPREMEIDSTRUCNASPREMA(RAD1SPREMEVEZADataSet dataSet, int rAD1IDSPREME, int iDSTRUCNASPREMA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1SPREMEVEZASet = dataSet;
            this.rowRAD1SPREMEVEZA = this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.NewRAD1SPREMEVEZARow();
            this.rowRAD1SPREMEVEZA.RAD1IDSPREME = rAD1IDSPREME;
            this.rowRAD1SPREMEVEZA.IDSTRUCNASPREMA = iDSTRUCNASPREMA;
            try
            {
                this.LoadByRAD1IDSPREMEIDSTRUCNASPREMA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound288 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(RAD1SPREMEVEZADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1SPREMEVEZASet = dataSet;
            try
            {
                this.LoadChildRad1spremeveza(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDSTRUCNASPREMA(RAD1SPREMEVEZADataSet dataSet, int iDSTRUCNASPREMA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1SPREMEVEZASet = dataSet;
            this.rowRAD1SPREMEVEZA = this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.NewRAD1SPREMEVEZARow();
            this.rowRAD1SPREMEVEZA.IDSTRUCNASPREMA = iDSTRUCNASPREMA;
            try
            {
                this.LoadByIDSTRUCNASPREMA(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByRAD1IDSPREME(RAD1SPREMEVEZADataSet dataSet, int rAD1IDSPREME, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1SPREMEVEZASet = dataSet;
            this.rowRAD1SPREMEVEZA = this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.NewRAD1SPREMEVEZARow();
            this.rowRAD1SPREMEVEZA.RAD1IDSPREME = rAD1IDSPREME;
            try
            {
                this.LoadByRAD1IDSPREME(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [RAD1IDSPREME], [IDSTRUCNASPREMA] FROM [RAD1SPREMEVEZA] WITH (NOLOCK) WHERE [RAD1IDSPREME] = @RAD1IDSPREME AND [IDSTRUCNASPREMA] = @IDSTRUCNASPREMA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1IDSPREME", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREMEVEZA["RAD1IDSPREME"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREMEVEZA["IDSTRUCNASPREMA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound288 = 1;
                this.rowRAD1SPREMEVEZA["RAD1IDSPREME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowRAD1SPREMEVEZA["IDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 1));
                this.sMode288 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode288;
            }
            else
            {
                this.RcdFound288 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                DbParameter parameter = factory.CreateParameter();
                parameter.ParameterName = "RAD1IDSPREME";
                parameter.DbType = DbType.Int32;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "IDSTRUCNASPREMA";
                parameter2.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1SPREMEVEZASelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RAD1SPREMEVEZA] WITH (NOLOCK) ", false);
            this.RAD1SPREMEVEZASelect3 = this.cmRAD1SPREMEVEZASelect3.FetchData();
            if (this.RAD1SPREMEVEZASelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RAD1SPREMEVEZASelect3.GetInt32(0);
            }
            this.RAD1SPREMEVEZASelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDSTRUCNASPREMA(int iDSTRUCNASPREMA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1SPREMEVEZASelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RAD1SPREMEVEZA] WITH (NOLOCK) WHERE [IDSTRUCNASPREMA] = @IDSTRUCNASPREMA ", false);
            if (this.cmRAD1SPREMEVEZASelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1SPREMEVEZASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
            }
            this.cmRAD1SPREMEVEZASelect2.SetParameter(0, iDSTRUCNASPREMA);
            this.RAD1SPREMEVEZASelect2 = this.cmRAD1SPREMEVEZASelect2.FetchData();
            if (this.RAD1SPREMEVEZASelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RAD1SPREMEVEZASelect2.GetInt32(0);
            }
            this.RAD1SPREMEVEZASelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByRAD1IDSPREME(int rAD1IDSPREME)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1SPREMEVEZASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RAD1SPREMEVEZA] WITH (NOLOCK) WHERE [RAD1IDSPREME] = @RAD1IDSPREME ", false);
            if (this.cmRAD1SPREMEVEZASelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1SPREMEVEZASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1IDSPREME", DbType.Int32));
            }
            this.cmRAD1SPREMEVEZASelect1.SetParameter(0, rAD1IDSPREME);
            this.RAD1SPREMEVEZASelect1 = this.cmRAD1SPREMEVEZASelect1.FetchData();
            if (this.RAD1SPREMEVEZASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RAD1SPREMEVEZASelect1.GetInt32(0);
            }
            this.RAD1SPREMEVEZASelect1.Close();
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

        public virtual int GetRecordCountByIDSTRUCNASPREMA(int iDSTRUCNASPREMA)
        {
            int internalRecordCountByIDSTRUCNASPREMA;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDSTRUCNASPREMA = this.GetInternalRecordCountByIDSTRUCNASPREMA(iDSTRUCNASPREMA);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDSTRUCNASPREMA;
        }

        public virtual int GetRecordCountByRAD1IDSPREME(int rAD1IDSPREME)
        {
            int num2 = 0;
            try
            {
                this.InitializeMembers();
                num2 = this.GetInternalRecordCountByRAD1IDSPREME(rAD1IDSPREME);
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
            this.RcdFound288 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.RAD1SPREMEVEZASet = new RAD1SPREMEVEZADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertRad1spremeveza()
        {
            this.CheckOptimisticConcurrencyRad1spremeveza();
            this.AfterConfirmRad1spremeveza();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RAD1SPREMEVEZA] ([RAD1IDSPREME], [IDSTRUCNASPREMA]) VALUES (@RAD1IDSPREME, @IDSTRUCNASPREMA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1IDSPREME", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREMEVEZA["RAD1IDSPREME"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREMEVEZA["IDSTRUCNASPREMA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RAD1SPREMEVEZADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsRad1spremeveza();
            }
            this.OnRAD1SPREMEVEZAUpdated(new RAD1SPREMEVEZAEventArgs(this.rowRAD1SPREMEVEZA, StatementType.Insert));
        }

        private void LoadByIDSTRUCNASPREMA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RAD1SPREMEVEZASet.EnforceConstraints;
            this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.BeginLoadData();
            this.ScanByIDSTRUCNASPREMA(startRow, maxRows);
            this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.EndLoadData();
            this.RAD1SPREMEVEZASet.EnforceConstraints = enforceConstraints;
            if (this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.Count > 0)
            {
                this.rowRAD1SPREMEVEZA = this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA[this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.Count - 1];
            }
        }

        private void LoadByRAD1IDSPREME(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RAD1SPREMEVEZASet.EnforceConstraints;
            this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.BeginLoadData();
            this.ScanByRAD1IDSPREME(startRow, maxRows);
            this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.EndLoadData();
            this.RAD1SPREMEVEZASet.EnforceConstraints = enforceConstraints;
            if (this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.Count > 0)
            {
                this.rowRAD1SPREMEVEZA = this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA[this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.Count - 1];
            }
        }

        private void LoadByRAD1IDSPREMEIDSTRUCNASPREMA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RAD1SPREMEVEZASet.EnforceConstraints;
            this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.BeginLoadData();
            this.ScanByRAD1IDSPREMEIDSTRUCNASPREMA(startRow, maxRows);
            this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.EndLoadData();
            this.RAD1SPREMEVEZASet.EnforceConstraints = enforceConstraints;
            if (this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.Count > 0)
            {
                this.rowRAD1SPREMEVEZA = this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA[this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.Count - 1];
            }
        }

        private void LoadChildRad1spremeveza(int startRow, int maxRows)
        {
            this.CreateNewRowRad1spremeveza();
            bool enforceConstraints = this.RAD1SPREMEVEZASet.EnforceConstraints;
            this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.BeginLoadData();
            this.ScanStartRad1spremeveza(startRow, maxRows);
            this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.EndLoadData();
            this.RAD1SPREMEVEZASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataRad1spremeveza(int maxRows)
        {
            int num = 0;
            if (this.RcdFound288 != 0)
            {
                this.ScanLoadRad1spremeveza();
                while ((this.RcdFound288 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowRad1spremeveza();
                    this.CreateNewRowRad1spremeveza();
                    this.ScanNextRad1spremeveza();
                }
            }
            if (num > 0)
            {
                this.RcdFound288 = 1;
            }
            this.ScanEndRad1spremeveza();
            if (this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.Count > 0)
            {
                this.rowRAD1SPREMEVEZA = this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA[this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.Count - 1];
            }
        }

        private void LoadRowRad1spremeveza()
        {
            this.AddRowRad1spremeveza();
        }

        private void OnRAD1SPREMEVEZAUpdated(RAD1SPREMEVEZAEventArgs e)
        {
            if (this.RAD1SPREMEVEZAUpdated != null)
            {
                RAD1SPREMEVEZAUpdateEventHandler handler = this.RAD1SPREMEVEZAUpdated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnRAD1SPREMEVEZAUpdating(RAD1SPREMEVEZAEventArgs e)
        {
            if (this.RAD1SPREMEVEZAUpdating != null)
            {
                RAD1SPREMEVEZAUpdateEventHandler handler = this.RAD1SPREMEVEZAUpdating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void ReadRowRad1spremeveza()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRAD1SPREMEVEZA.RowState);
            if (this.rowRAD1SPREMEVEZA.RowState == DataRowState.Added)
            {
            }
            this._Gxremove = this.rowRAD1SPREMEVEZA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowRAD1SPREMEVEZA = (RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow) DataSetUtil.CloneOriginalDataRow(this.rowRAD1SPREMEVEZA);
            }
        }

        private void ScanByIDSTRUCNASPREMA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDSTRUCNASPREMA] = @IDSTRUCNASPREMA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString288 + "  FROM [RAD1SPREMEVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString288, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA] ) AS DK_PAGENUM   FROM [RAD1SPREMEVEZA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString288 + " FROM [RAD1SPREMEVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA] ";
            }
            this.cmRAD1SPREMEVEZASelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRAD1SPREMEVEZASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1SPREMEVEZASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
            }
            this.cmRAD1SPREMEVEZASelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREMEVEZA["IDSTRUCNASPREMA"]));
            this.RAD1SPREMEVEZASelect6 = this.cmRAD1SPREMEVEZASelect6.FetchData();
            this.RcdFound288 = 0;
            this.ScanLoadRad1spremeveza();
            this.LoadDataRad1spremeveza(maxRows);
        }

        private void ScanByRAD1IDSPREME(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[RAD1IDSPREME] = @RAD1IDSPREME";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString288 + "  FROM [RAD1SPREMEVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString288, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA] ) AS DK_PAGENUM   FROM [RAD1SPREMEVEZA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString288 + " FROM [RAD1SPREMEVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA] ";
            }
            this.cmRAD1SPREMEVEZASelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRAD1SPREMEVEZASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1SPREMEVEZASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1IDSPREME", DbType.Int32));
            }
            this.cmRAD1SPREMEVEZASelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREMEVEZA["RAD1IDSPREME"]));
            this.RAD1SPREMEVEZASelect6 = this.cmRAD1SPREMEVEZASelect6.FetchData();
            this.RcdFound288 = 0;
            this.ScanLoadRad1spremeveza();
            this.LoadDataRad1spremeveza(maxRows);
        }

        private void ScanByRAD1IDSPREMEIDSTRUCNASPREMA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[RAD1IDSPREME] = @RAD1IDSPREME and TM1.[IDSTRUCNASPREMA] = @IDSTRUCNASPREMA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString288 + "  FROM [RAD1SPREMEVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString288, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA] ) AS DK_PAGENUM   FROM [RAD1SPREMEVEZA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString288 + " FROM [RAD1SPREMEVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA] ";
            }
            this.cmRAD1SPREMEVEZASelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRAD1SPREMEVEZASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1SPREMEVEZASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1IDSPREME", DbType.Int32));
                this.cmRAD1SPREMEVEZASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
            }
            this.cmRAD1SPREMEVEZASelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREMEVEZA["RAD1IDSPREME"]));
            this.cmRAD1SPREMEVEZASelect6.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1SPREMEVEZA["IDSTRUCNASPREMA"]));
            this.RAD1SPREMEVEZASelect6 = this.cmRAD1SPREMEVEZASelect6.FetchData();
            this.RcdFound288 = 0;
            this.ScanLoadRad1spremeveza();
            this.LoadDataRad1spremeveza(maxRows);
        }

        private void ScanEndRad1spremeveza()
        {
            this.RAD1SPREMEVEZASelect6.Close();
        }

        private void ScanLoadRad1spremeveza()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRAD1SPREMEVEZASelect6.HasMoreRows)
            {
                this.RcdFound288 = 1;
                this.rowRAD1SPREMEVEZA["RAD1IDSPREME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RAD1SPREMEVEZASelect6, 0));
                this.rowRAD1SPREMEVEZA["IDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RAD1SPREMEVEZASelect6, 1));
            }
        }

        private void ScanNextRad1spremeveza()
        {
            this.cmRAD1SPREMEVEZASelect6.HasMoreRows = this.RAD1SPREMEVEZASelect6.Read();
            this.RcdFound288 = 0;
            this.ScanLoadRad1spremeveza();
        }

        private void ScanStartRad1spremeveza(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString288 + "  FROM [RAD1SPREMEVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString288, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA] ) AS DK_PAGENUM   FROM [RAD1SPREMEVEZA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString288 + " FROM [RAD1SPREMEVEZA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1IDSPREME], TM1.[IDSTRUCNASPREMA] ";
            }
            this.cmRAD1SPREMEVEZASelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.RAD1SPREMEVEZASelect6 = this.cmRAD1SPREMEVEZASelect6.FetchData();
            this.RcdFound288 = 0;
            this.ScanLoadRad1spremeveza();
            this.LoadDataRad1spremeveza(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.RAD1SPREMEVEZASet = (RAD1SPREMEVEZADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.RAD1SPREMEVEZASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.RAD1SPREMEVEZASet.RAD1SPREMEVEZA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow current = (RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow) enumerator.Current;
                        this.rowRAD1SPREMEVEZA = current;
                        if (Helpers.IsRowChanged(this.rowRAD1SPREMEVEZA))
                        {
                            this.ReadRowRad1spremeveza();
                            if (this.rowRAD1SPREMEVEZA.RowState == DataRowState.Added)
                            {
                                this.InsertRad1spremeveza();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateRad1spremeveza();
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

        private void UpdateRad1spremeveza()
        {
            this.CheckOptimisticConcurrencyRad1spremeveza();
            this.AfterConfirmRad1spremeveza();
            this.OnRAD1SPREMEVEZAUpdated(new RAD1SPREMEVEZAEventArgs(this.rowRAD1SPREMEVEZA, StatementType.Update));
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
        public class RAD1SPREMEForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public RAD1SPREMEForeignKeyNotFoundException()
            {
            }

            public RAD1SPREMEForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected RAD1SPREMEForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1SPREMEForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1SPREMEVEZADataChangedException : DataChangedException
        {
            public RAD1SPREMEVEZADataChangedException()
            {
            }

            public RAD1SPREMEVEZADataChangedException(string message) : base(message)
            {
            }

            protected RAD1SPREMEVEZADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1SPREMEVEZADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1SPREMEVEZADataLockedException : DataLockedException
        {
            public RAD1SPREMEVEZADataLockedException()
            {
            }

            public RAD1SPREMEVEZADataLockedException(string message) : base(message)
            {
            }

            protected RAD1SPREMEVEZADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1SPREMEVEZADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1SPREMEVEZADuplicateKeyException : DuplicateKeyException
        {
            public RAD1SPREMEVEZADuplicateKeyException()
            {
            }

            public RAD1SPREMEVEZADuplicateKeyException(string message) : base(message)
            {
            }

            protected RAD1SPREMEVEZADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1SPREMEVEZADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RAD1SPREMEVEZAEventArgs : EventArgs
        {
            private RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RAD1SPREMEVEZAEventArgs(RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RAD1SPREMEVEZADataSet.RAD1SPREMEVEZARow Row
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
        public class RAD1SPREMEVEZANotFoundException : DataNotFoundException
        {
            public RAD1SPREMEVEZANotFoundException()
            {
            }

            public RAD1SPREMEVEZANotFoundException(string message) : base(message)
            {
            }

            protected RAD1SPREMEVEZANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1SPREMEVEZANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void RAD1SPREMEVEZAUpdateEventHandler(object sender, RAD1SPREMEVEZADataAdapter.RAD1SPREMEVEZAEventArgs e);

        [Serializable]
        public class STRUCNASPREMAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public STRUCNASPREMAForeignKeyNotFoundException()
            {
            }

            public STRUCNASPREMAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected STRUCNASPREMAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRUCNASPREMAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

