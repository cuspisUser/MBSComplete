namespace Placa
{
    using Deklarit.Data;
    using Deklarit.Utils;
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class S_FIN_IZVRSENJE_PLANADataAdapter : IDataAdapter, IS_FIN_IZVRSENJE_PLANADataAdapter
    {
        private int AV8IDORGJE;
        private string AV9godina;
        private ReadWriteCommand cmS_FIN_IZVRSENJE_PLANASelect1;
        private ReadWriteCommand cmS_FIN_IZVRSENJE_PLANASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_FIN_IZVRSENJE_PLANADataSet.S_FIN_IZVRSENJE_PLANARow rowS_FIN_IZVRSENJE_PLANA;
        private IDataReader S_FIN_IZVRSENJE_PLANASelect1;
        private IDataReader S_FIN_IZVRSENJE_PLANASelect2;
        private S_FIN_IZVRSENJE_PLANADataSet S_FIN_IZVRSENJE_PLANASet;

        private void AddRowS_fin_izvrsenje_plana()
        {
            this.S_FIN_IZVRSENJE_PLANASet.S_FIN_IZVRSENJE_PLANA.AddS_FIN_IZVRSENJE_PLANARow(this.rowS_FIN_IZVRSENJE_PLANA);
            this.rowS_FIN_IZVRSENJE_PLANA.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_FIN_IZVRSENJE_PLANASelect2 = this.connDefault.GetCommand("S_FIN_IZVRSENJE_PLANA", true);
            this.cmS_FIN_IZVRSENJE_PLANASelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_IZVRSENJE_PLANASelect2.IDbCommand.Parameters.Clear();
            this.cmS_FIN_IZVRSENJE_PLANASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", this.AV8IDORGJE));
            this.cmS_FIN_IZVRSENJE_PLANASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godina", this.AV9godina));
            this.cmS_FIN_IZVRSENJE_PLANASelect2.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_IZVRSENJE_PLANASelect2 = this.cmS_FIN_IZVRSENJE_PLANASelect2.FetchData();
            while (this.cmS_FIN_IZVRSENJE_PLANASelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_FIN_IZVRSENJE_PLANASelect2.HasMoreRows = this.S_FIN_IZVRSENJE_PLANASelect2.Read();
            }
            int num = 0;
            while (this.cmS_FIN_IZVRSENJE_PLANASelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_FIN_IZVRSENJE_PLANA["konto"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IZVRSENJE_PLANASelect2["KONTO"]);
                this.rowS_FIN_IZVRSENJE_PLANA["PLANIRANO"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IZVRSENJE_PLANASelect2["PLANIRANO"]);
                this.rowS_FIN_IZVRSENJE_PLANA["IZVRSENO"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IZVRSENJE_PLANASelect2["IZVRSENO"]);
                this.rowS_FIN_IZVRSENJE_PLANA["INDEKS"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IZVRSENJE_PLANASelect2["INDEKS"]);
                this.AddRowS_fin_izvrsenje_plana();
                num++;
                this.rowS_FIN_IZVRSENJE_PLANA = this.S_FIN_IZVRSENJE_PLANASet.S_FIN_IZVRSENJE_PLANA.NewS_FIN_IZVRSENJE_PLANARow();
                this.cmS_FIN_IZVRSENJE_PLANASelect2.HasMoreRows = this.S_FIN_IZVRSENJE_PLANASelect2.Read();
            }
            this.S_FIN_IZVRSENJE_PLANASelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_FIN_IZVRSENJE_PLANADataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), this.fillDataParameters[1].Value.ToString());
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_FIN_IZVRSENJE_PLANASet = (S_FIN_IZVRSENJE_PLANADataSet) dataSet;
            if (this.S_FIN_IZVRSENJE_PLANASet != null)
            {
                return this.Fill(this.S_FIN_IZVRSENJE_PLANASet);
            }
            this.S_FIN_IZVRSENJE_PLANASet = new S_FIN_IZVRSENJE_PLANADataSet();
            this.Fill(this.S_FIN_IZVRSENJE_PLANASet);
            dataSet.Merge(this.S_FIN_IZVRSENJE_PLANASet);
            return 0;
        }

        public virtual int Fill(S_FIN_IZVRSENJE_PLANADataSet dataSet, int iDORGJED, string godina)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_IZVRSENJE_PLANASet = dataSet;
            this.rowS_FIN_IZVRSENJE_PLANA = this.S_FIN_IZVRSENJE_PLANASet.S_FIN_IZVRSENJE_PLANA.NewS_FIN_IZVRSENJE_PLANARow();
            this.SetFillParameters(iDORGJED, godina);
            this.AV8IDORGJE = iDORGJED;
            this.AV9godina = godina;
            try
            {
                this.executePrivate(0, -1);
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(S_FIN_IZVRSENJE_PLANADataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), this.fillDataParameters[1].Value.ToString(), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_FIN_IZVRSENJE_PLANASet = (S_FIN_IZVRSENJE_PLANADataSet) dataSet;
            if (this.S_FIN_IZVRSENJE_PLANASet != null)
            {
                return this.FillPage(this.S_FIN_IZVRSENJE_PLANASet, startRow, maxRows);
            }
            this.S_FIN_IZVRSENJE_PLANASet = new S_FIN_IZVRSENJE_PLANADataSet();
            this.FillPage(this.S_FIN_IZVRSENJE_PLANASet, startRow, maxRows);
            dataSet.Merge(this.S_FIN_IZVRSENJE_PLANASet);
            return 0;
        }

        public virtual int FillPage(S_FIN_IZVRSENJE_PLANADataSet dataSet, int iDORGJED, string godina, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_IZVRSENJE_PLANASet = dataSet;
            this.rowS_FIN_IZVRSENJE_PLANA = this.S_FIN_IZVRSENJE_PLANASet.S_FIN_IZVRSENJE_PLANA.NewS_FIN_IZVRSENJE_PLANARow();
            this.SetFillParameters(iDORGJED, godina);
            this.AV8IDORGJE = iDORGJED;
            this.AV9godina = godina;
            try
            {
                this.executePrivate(startRow, maxRows);
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

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                DbParameter parameter = factory.CreateParameter();
                parameter.ParameterName = "IDORGJED";
                parameter.DbType = DbType.Int32;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "godina";
                parameter2.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(int iDORGJED, string godina)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_FIN_IZVRSENJE_PLANASelect1 = this.connDefault.GetCommand("S_FIN_IZVRSENJE_PLANA", true);
            this.cmS_FIN_IZVRSENJE_PLANASelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_IZVRSENJE_PLANASelect1.IDbCommand.Parameters.Clear();
            this.cmS_FIN_IZVRSENJE_PLANASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGJED", iDORGJED));
            this.cmS_FIN_IZVRSENJE_PLANASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godina", godina));
            this.cmS_FIN_IZVRSENJE_PLANASelect1.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_IZVRSENJE_PLANASelect1 = this.cmS_FIN_IZVRSENJE_PLANASelect1.FetchData();
            if (this.S_FIN_IZVRSENJE_PLANASelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_FIN_IZVRSENJE_PLANASelect1.GetInt32(0);
            }
            this.S_FIN_IZVRSENJE_PLANASelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(int iDORGJED, string godina)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(iDORGJED, godina);
                internalRecordCount = this.GetInternalRecordCount(iDORGJED, godina);
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
            this.AV8IDORGJE = 0;
            this.AV9godina = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(int iDORGJED, string godina)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = iDORGJED;
                this.fillDataParameters[1].Value = godina;
            }
        }

        public virtual int Update(DataSet dataSet)
        {
            throw new InvalidOperationException();
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
    }
}

