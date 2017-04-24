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

    public class S_OS_STANJE_LOKACIJADataAdapter : IDataAdapter, IS_OS_STANJE_LOKACIJADataAdapter
    {
        private long AV8invbroj;
        private ReadWriteCommand cmS_OS_STANJE_LOKACIJASelect1;
        private ReadWriteCommand cmS_OS_STANJE_LOKACIJASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OS_STANJE_LOKACIJADataSet.S_OS_STANJE_LOKACIJARow rowS_OS_STANJE_LOKACIJA;
        private IDataReader S_OS_STANJE_LOKACIJASelect1;
        private IDataReader S_OS_STANJE_LOKACIJASelect2;
        private S_OS_STANJE_LOKACIJADataSet S_OS_STANJE_LOKACIJASet;

        private void AddRowS_os_stanje_lokacija()
        {
            this.S_OS_STANJE_LOKACIJASet.S_OS_STANJE_LOKACIJA.AddS_OS_STANJE_LOKACIJARow(this.rowS_OS_STANJE_LOKACIJA);
            this.rowS_OS_STANJE_LOKACIJA.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OS_STANJE_LOKACIJASelect2 = this.connDefault.GetCommand("S_OS_STANJE_LOKACIJA", true);
            this.cmS_OS_STANJE_LOKACIJASelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OS_STANJE_LOKACIJASelect2.IDbCommand.Parameters.Clear();
            this.cmS_OS_STANJE_LOKACIJASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@invbroj", this.AV8invbroj));
            this.cmS_OS_STANJE_LOKACIJASelect2.ErrorMask |= ErrorMask.Lock;
            this.S_OS_STANJE_LOKACIJASelect2 = this.cmS_OS_STANJE_LOKACIJASelect2.FetchData();
            while (this.cmS_OS_STANJE_LOKACIJASelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OS_STANJE_LOKACIJASelect2.HasMoreRows = this.S_OS_STANJE_LOKACIJASelect2.Read();
            }
            int num = 0;
            while (this.cmS_OS_STANJE_LOKACIJASelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OS_STANJE_LOKACIJA["IDLOKACIJE"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJASelect2["IDLOKACIJE"]);
                this.rowS_OS_STANJE_LOKACIJA["INVBROJ"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJASelect2["INVBROJ"]);
                this.rowS_OS_STANJE_LOKACIJA["ULAZ"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJASelect2["ULAZ"]);
                this.rowS_OS_STANJE_LOKACIJA["IZLAZ"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJASelect2["IZLAZ"]);
                this.rowS_OS_STANJE_LOKACIJA["STANJE"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJASelect2["STANJE"]);
                this.rowS_OS_STANJE_LOKACIJA["OPISLOKACIJE"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJASelect2["OPISLOKACIJE"]);
                this.AddRowS_os_stanje_lokacija();
                num++;
                this.rowS_OS_STANJE_LOKACIJA = this.S_OS_STANJE_LOKACIJASet.S_OS_STANJE_LOKACIJA.NewS_OS_STANJE_LOKACIJARow();
                this.cmS_OS_STANJE_LOKACIJASelect2.HasMoreRows = this.S_OS_STANJE_LOKACIJASelect2.Read();
            }
            this.S_OS_STANJE_LOKACIJASelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OS_STANJE_LOKACIJADataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, long.Parse(this.fillDataParameters[0].Value.ToString()));
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_OS_STANJE_LOKACIJASet = (S_OS_STANJE_LOKACIJADataSet) dataSet;
            if (this.S_OS_STANJE_LOKACIJASet != null)
            {
                return this.Fill(this.S_OS_STANJE_LOKACIJASet);
            }
            this.S_OS_STANJE_LOKACIJASet = new S_OS_STANJE_LOKACIJADataSet();
            this.Fill(this.S_OS_STANJE_LOKACIJASet);
            dataSet.Merge(this.S_OS_STANJE_LOKACIJASet);
            return 0;
        }

        public virtual int Fill(S_OS_STANJE_LOKACIJADataSet dataSet, long invbroj)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OS_STANJE_LOKACIJASet = dataSet;
            this.rowS_OS_STANJE_LOKACIJA = this.S_OS_STANJE_LOKACIJASet.S_OS_STANJE_LOKACIJA.NewS_OS_STANJE_LOKACIJARow();
            this.SetFillParameters(invbroj);
            this.AV8invbroj = invbroj;
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

        public virtual int FillPage(S_OS_STANJE_LOKACIJADataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, long.Parse(this.fillDataParameters[0].Value.ToString()), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_OS_STANJE_LOKACIJASet = (S_OS_STANJE_LOKACIJADataSet) dataSet;
            if (this.S_OS_STANJE_LOKACIJASet != null)
            {
                return this.FillPage(this.S_OS_STANJE_LOKACIJASet, startRow, maxRows);
            }
            this.S_OS_STANJE_LOKACIJASet = new S_OS_STANJE_LOKACIJADataSet();
            this.FillPage(this.S_OS_STANJE_LOKACIJASet, startRow, maxRows);
            dataSet.Merge(this.S_OS_STANJE_LOKACIJASet);
            return 0;
        }

        public virtual int FillPage(S_OS_STANJE_LOKACIJADataSet dataSet, long invbroj, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OS_STANJE_LOKACIJASet = dataSet;
            this.rowS_OS_STANJE_LOKACIJA = this.S_OS_STANJE_LOKACIJASet.S_OS_STANJE_LOKACIJA.NewS_OS_STANJE_LOKACIJARow();
            this.SetFillParameters(invbroj);
            this.AV8invbroj = invbroj;
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
                parameter.ParameterName = "invbroj";
                parameter.DbType = DbType.Int64;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(long invbroj)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_OS_STANJE_LOKACIJASelect1 = this.connDefault.GetCommand("S_OS_STANJE_LOKACIJA", true);
            this.cmS_OS_STANJE_LOKACIJASelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OS_STANJE_LOKACIJASelect1.IDbCommand.Parameters.Clear();
            this.cmS_OS_STANJE_LOKACIJASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@invbroj", invbroj));
            this.cmS_OS_STANJE_LOKACIJASelect1.ErrorMask |= ErrorMask.Lock;
            this.S_OS_STANJE_LOKACIJASelect1 = this.cmS_OS_STANJE_LOKACIJASelect1.FetchData();
            if (this.S_OS_STANJE_LOKACIJASelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OS_STANJE_LOKACIJASelect1.GetInt32(0);
            }
            this.S_OS_STANJE_LOKACIJASelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(long invbroj)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(invbroj);
                internalRecordCount = this.GetInternalRecordCount(invbroj);
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
            this.AV8invbroj = 0L;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(long invbroj)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = invbroj;
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

