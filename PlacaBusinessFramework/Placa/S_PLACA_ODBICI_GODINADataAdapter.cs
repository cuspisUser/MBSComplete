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

    public class S_PLACA_ODBICI_GODINADataAdapter : IDataAdapter, IS_PLACA_ODBICI_GODINADataAdapter
    {
        private string AV8GODINAI;
        private ReadWriteCommand cmS_PLACA_ODBICI_GODINASelect1;
        private ReadWriteCommand cmS_PLACA_ODBICI_GODINASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_PLACA_ODBICI_GODINADataSet.S_PLACA_ODBICI_GODINARow rowS_PLACA_ODBICI_GODINA;
        private IDataReader S_PLACA_ODBICI_GODINASelect1;
        private IDataReader S_PLACA_ODBICI_GODINASelect2;
        private S_PLACA_ODBICI_GODINADataSet S_PLACA_ODBICI_GODINASet;

        private void AddRowS_placa_odbici_godina()
        {
            this.S_PLACA_ODBICI_GODINASet.S_PLACA_ODBICI_GODINA.AddS_PLACA_ODBICI_GODINARow(this.rowS_PLACA_ODBICI_GODINA);
            this.rowS_PLACA_ODBICI_GODINA.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_PLACA_ODBICI_GODINASelect2 = this.connDefault.GetCommand("S_PLACA_ODBICI_GODINA", true);
            this.cmS_PLACA_ODBICI_GODINASelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_PLACA_ODBICI_GODINASelect2.IDbCommand.Parameters.Clear();
            this.cmS_PLACA_ODBICI_GODINASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAISPLATE", this.AV8GODINAI));
            this.cmS_PLACA_ODBICI_GODINASelect2.ErrorMask |= ErrorMask.Lock;
            this.S_PLACA_ODBICI_GODINASelect2 = this.cmS_PLACA_ODBICI_GODINASelect2.FetchData();
            while (this.cmS_PLACA_ODBICI_GODINASelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_PLACA_ODBICI_GODINASelect2.HasMoreRows = this.S_PLACA_ODBICI_GODINASelect2.Read();
            }
            int num = 0;
            while (this.cmS_PLACA_ODBICI_GODINASelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_PLACA_ODBICI_GODINA["OLAKSICE"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_ODBICI_GODINASelect2["OLAKSICE"]);
                this.rowS_PLACA_ODBICI_GODINA["ODBITAK"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_ODBICI_GODINASelect2["ODBITAK"]);
                this.rowS_PLACA_ODBICI_GODINA["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_ODBICI_GODINASelect2["IDRADNIK"]);
                this.AddRowS_placa_odbici_godina();
                num++;
                this.rowS_PLACA_ODBICI_GODINA = this.S_PLACA_ODBICI_GODINASet.S_PLACA_ODBICI_GODINA.NewS_PLACA_ODBICI_GODINARow();
                this.cmS_PLACA_ODBICI_GODINASelect2.HasMoreRows = this.S_PLACA_ODBICI_GODINASelect2.Read();
            }
            this.S_PLACA_ODBICI_GODINASelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_PLACA_ODBICI_GODINADataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, this.fillDataParameters[0].Value.ToString());
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_PLACA_ODBICI_GODINASet = (S_PLACA_ODBICI_GODINADataSet) dataSet;
            if (this.S_PLACA_ODBICI_GODINASet != null)
            {
                return this.Fill(this.S_PLACA_ODBICI_GODINASet);
            }
            this.S_PLACA_ODBICI_GODINASet = new S_PLACA_ODBICI_GODINADataSet();
            this.Fill(this.S_PLACA_ODBICI_GODINASet);
            dataSet.Merge(this.S_PLACA_ODBICI_GODINASet);
            return 0;
        }

        public virtual int Fill(S_PLACA_ODBICI_GODINADataSet dataSet, string gODINAISPLATE)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_PLACA_ODBICI_GODINASet = dataSet;
            this.rowS_PLACA_ODBICI_GODINA = this.S_PLACA_ODBICI_GODINASet.S_PLACA_ODBICI_GODINA.NewS_PLACA_ODBICI_GODINARow();
            this.SetFillParameters(gODINAISPLATE);
            this.AV8GODINAI = gODINAISPLATE;
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

        public virtual int FillPage(S_PLACA_ODBICI_GODINADataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, this.fillDataParameters[0].Value.ToString(), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_PLACA_ODBICI_GODINASet = (S_PLACA_ODBICI_GODINADataSet) dataSet;
            if (this.S_PLACA_ODBICI_GODINASet != null)
            {
                return this.FillPage(this.S_PLACA_ODBICI_GODINASet, startRow, maxRows);
            }
            this.S_PLACA_ODBICI_GODINASet = new S_PLACA_ODBICI_GODINADataSet();
            this.FillPage(this.S_PLACA_ODBICI_GODINASet, startRow, maxRows);
            dataSet.Merge(this.S_PLACA_ODBICI_GODINASet);
            return 0;
        }

        public virtual int FillPage(S_PLACA_ODBICI_GODINADataSet dataSet, string gODINAISPLATE, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_PLACA_ODBICI_GODINASet = dataSet;
            this.rowS_PLACA_ODBICI_GODINA = this.S_PLACA_ODBICI_GODINASet.S_PLACA_ODBICI_GODINA.NewS_PLACA_ODBICI_GODINARow();
            this.SetFillParameters(gODINAISPLATE);
            this.AV8GODINAI = gODINAISPLATE;
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
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "GODINAISPLATE";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string gODINAISPLATE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_PLACA_ODBICI_GODINASelect1 = this.connDefault.GetCommand("S_PLACA_ODBICI_GODINA", true);
            this.cmS_PLACA_ODBICI_GODINASelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_PLACA_ODBICI_GODINASelect1.IDbCommand.Parameters.Clear();
            this.cmS_PLACA_ODBICI_GODINASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAISPLATE", gODINAISPLATE));
            this.cmS_PLACA_ODBICI_GODINASelect1.ErrorMask |= ErrorMask.Lock;
            this.S_PLACA_ODBICI_GODINASelect1 = this.cmS_PLACA_ODBICI_GODINASelect1.FetchData();
            if (this.S_PLACA_ODBICI_GODINASelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_PLACA_ODBICI_GODINASelect1.GetInt32(0);
            }
            this.S_PLACA_ODBICI_GODINASelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string gODINAISPLATE)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(gODINAISPLATE);
                internalRecordCount = this.GetInternalRecordCount(gODINAISPLATE);
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
            this.AV8GODINAI = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string gODINAISPLATE)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = gODINAISPLATE;
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

