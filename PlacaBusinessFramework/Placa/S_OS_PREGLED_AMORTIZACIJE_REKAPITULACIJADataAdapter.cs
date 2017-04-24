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

    public class S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataAdapter : IDataAdapter, IS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataAdapter
    {
        private int AV8brojdok;
        private ReadWriteCommand cmS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect1;
        private ReadWriteCommand cmS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow rowS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA;
        private IDataReader S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect1;
        private IDataReader S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2;
        private S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASet;

        private void AddRowS_os_pregled_amortizacije_rekapitulacija()
        {
            this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.AddS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow(this.rowS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA);
            this.rowS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2 = this.connDefault.GetCommand("S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA", true);
            this.cmS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2.IDbCommand.Parameters.Clear();
            this.cmS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@brojdok", this.AV8brojdok));
            this.cmS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2.ErrorMask |= ErrorMask.Lock;
            this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2 = this.cmS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2.FetchData();
            while (this.cmS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2.HasMoreRows = this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2.Read();
            }
            int num = 0;
            while (this.cmS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA["OSOPIS"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2["OSOPIS"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA["IDOSDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2["IDOSDOKUMENT"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA["OSBROJDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2["OSBROJDOKUMENTA"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA["OSKOLICINA"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2["OSKOLICINA"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA["OSSTOPA"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2["OSSTOPA"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA["OSOSNOVICA"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2["OSOSNOVICA"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA["ISPRAVAK"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2["ISPRAVAK"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA["ISPRAVAKPRETHODNIH"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2["ISPRAVAKPRETHODNIH"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA["KTONABAVKEIDKONTO"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2["KTONABAVKEIDKONTO"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA["KTOISPRAVKAIDKONTO"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2["KTOISPRAVKAIDKONTO"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA["KTOIZVORAIDKONTO"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2["KTOIZVORAIDKONTO"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA["NAZIVKONTO"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2["NAZIVKONTO"]);
                this.AddRowS_os_pregled_amortizacije_rekapitulacija();
                num++;
                this.rowS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA = this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.NewS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow();
                this.cmS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2.HasMoreRows = this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2.Read();
            }
            this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()));
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASet = (S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet) dataSet;
            if (this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASet != null)
            {
                return this.Fill(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASet);
            }
            this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASet = new S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet();
            this.Fill(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASet);
            dataSet.Merge(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASet);
            return 0;
        }

        public virtual int Fill(S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet dataSet, int brojdok)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASet = dataSet;
            this.rowS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA = this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.NewS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow();
            this.SetFillParameters(brojdok);
            this.AV8brojdok = brojdok;
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

        public virtual int FillPage(S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASet = (S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet) dataSet;
            if (this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASet != null)
            {
                return this.FillPage(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASet, startRow, maxRows);
            }
            this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASet = new S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet();
            this.FillPage(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASet, startRow, maxRows);
            dataSet.Merge(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASet);
            return 0;
        }

        public virtual int FillPage(S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet dataSet, int brojdok, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASet = dataSet;
            this.rowS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA = this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASet.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.NewS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJARow();
            this.SetFillParameters(brojdok);
            this.AV8brojdok = brojdok;
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
                parameter.ParameterName = "brojdok";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(int brojdok)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect1 = this.connDefault.GetCommand("S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA", true);
            this.cmS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect1.IDbCommand.Parameters.Clear();
            this.cmS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@brojdok", brojdok));
            this.cmS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect1.ErrorMask |= ErrorMask.Lock;
            this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect1 = this.cmS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect1.FetchData();
            if (this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect1.GetInt32(0);
            }
            this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJASelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(int brojdok)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(brojdok);
                internalRecordCount = this.GetInternalRecordCount(brojdok);
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
            this.AV8brojdok = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(int brojdok)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = brojdok;
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

