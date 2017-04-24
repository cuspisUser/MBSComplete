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

    public class S_OS_PREGLED_AMORTIZACIJEDataAdapter : IDataAdapter, IS_OS_PREGLED_AMORTIZACIJEDataAdapter
    {
        private int AV8BROJDOK;
        private ReadWriteCommand cmS_OS_PREGLED_AMORTIZACIJESelect1;
        private ReadWriteCommand cmS_OS_PREGLED_AMORTIZACIJESelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OS_PREGLED_AMORTIZACIJEDataSet.S_OS_PREGLED_AMORTIZACIJERow rowS_OS_PREGLED_AMORTIZACIJE;
        private IDataReader S_OS_PREGLED_AMORTIZACIJESelect1;
        private IDataReader S_OS_PREGLED_AMORTIZACIJESelect2;
        private S_OS_PREGLED_AMORTIZACIJEDataSet S_OS_PREGLED_AMORTIZACIJESet;

        private void AddRowS_os_pregled_amortizacije()
        {
            this.S_OS_PREGLED_AMORTIZACIJESet.S_OS_PREGLED_AMORTIZACIJE.AddS_OS_PREGLED_AMORTIZACIJERow(this.rowS_OS_PREGLED_AMORTIZACIJE);
            this.rowS_OS_PREGLED_AMORTIZACIJE.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OS_PREGLED_AMORTIZACIJESelect2 = this.connDefault.GetCommand("S_OS_PREGLED_AMORTIZACIJE", true);
            this.cmS_OS_PREGLED_AMORTIZACIJESelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OS_PREGLED_AMORTIZACIJESelect2.IDbCommand.Parameters.Clear();
            this.cmS_OS_PREGLED_AMORTIZACIJESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJDOK", this.AV8BROJDOK));
            this.cmS_OS_PREGLED_AMORTIZACIJESelect2.ErrorMask |= ErrorMask.Lock;
            this.S_OS_PREGLED_AMORTIZACIJESelect2 = this.cmS_OS_PREGLED_AMORTIZACIJESelect2.FetchData();
            while (this.cmS_OS_PREGLED_AMORTIZACIJESelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OS_PREGLED_AMORTIZACIJESelect2.HasMoreRows = this.S_OS_PREGLED_AMORTIZACIJESelect2.Read();
            }
            int num = 0;
            while (this.cmS_OS_PREGLED_AMORTIZACIJESelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OS_PREGLED_AMORTIZACIJE["NAZIVOS"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJESelect2["NAZIVOS"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE["OSOPIS"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJESelect2["OSOPIS"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE["INVBROJ"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJESelect2["INVBROJ"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE["IDOSDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJESelect2["IDOSDOKUMENT"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE["OSBROJDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJESelect2["OSBROJDOKUMENTA"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE["OSDATUMDOK"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJESelect2["OSDATUMDOK"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE["OSKOLICINA"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJESelect2["OSKOLICINA"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE["OSSTOPA"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJESelect2["OSSTOPA"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE["OSOSNOVICA"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJESelect2["OSOSNOVICA"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE["ISPRAVAK"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJESelect2["ISPRAVAK"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE["ISPRAVAKPRETHODNIH"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJESelect2["ISPRAVAKPRETHODNIH"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE["DATUMUPORABE"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJESelect2["DATUMUPORABE"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE["KTONABAVKEIDKONTO"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJESelect2["KTONABAVKEIDKONTO"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE["KTOISPRAVKAIDKONTO"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJESelect2["KTOISPRAVKAIDKONTO"]);
                this.rowS_OS_PREGLED_AMORTIZACIJE["KTOIZVORAIDKONTO"] = RuntimeHelpers.GetObjectValue(this.S_OS_PREGLED_AMORTIZACIJESelect2["KTOIZVORAIDKONTO"]);
                this.AddRowS_os_pregled_amortizacije();
                num++;
                this.rowS_OS_PREGLED_AMORTIZACIJE = this.S_OS_PREGLED_AMORTIZACIJESet.S_OS_PREGLED_AMORTIZACIJE.NewS_OS_PREGLED_AMORTIZACIJERow();
                this.cmS_OS_PREGLED_AMORTIZACIJESelect2.HasMoreRows = this.S_OS_PREGLED_AMORTIZACIJESelect2.Read();
            }
            this.S_OS_PREGLED_AMORTIZACIJESelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OS_PREGLED_AMORTIZACIJEDataSet dataSet)
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
            this.S_OS_PREGLED_AMORTIZACIJESet = (S_OS_PREGLED_AMORTIZACIJEDataSet) dataSet;
            if (this.S_OS_PREGLED_AMORTIZACIJESet != null)
            {
                return this.Fill(this.S_OS_PREGLED_AMORTIZACIJESet);
            }
            this.S_OS_PREGLED_AMORTIZACIJESet = new S_OS_PREGLED_AMORTIZACIJEDataSet();
            this.Fill(this.S_OS_PREGLED_AMORTIZACIJESet);
            dataSet.Merge(this.S_OS_PREGLED_AMORTIZACIJESet);
            return 0;
        }

        public virtual int Fill(S_OS_PREGLED_AMORTIZACIJEDataSet dataSet, int bROJDOK)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OS_PREGLED_AMORTIZACIJESet = dataSet;
            this.rowS_OS_PREGLED_AMORTIZACIJE = this.S_OS_PREGLED_AMORTIZACIJESet.S_OS_PREGLED_AMORTIZACIJE.NewS_OS_PREGLED_AMORTIZACIJERow();
            this.SetFillParameters(bROJDOK);
            this.AV8BROJDOK = bROJDOK;
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

        public virtual int FillPage(S_OS_PREGLED_AMORTIZACIJEDataSet dataSet, int startRow, int maxRows)
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
            this.S_OS_PREGLED_AMORTIZACIJESet = (S_OS_PREGLED_AMORTIZACIJEDataSet) dataSet;
            if (this.S_OS_PREGLED_AMORTIZACIJESet != null)
            {
                return this.FillPage(this.S_OS_PREGLED_AMORTIZACIJESet, startRow, maxRows);
            }
            this.S_OS_PREGLED_AMORTIZACIJESet = new S_OS_PREGLED_AMORTIZACIJEDataSet();
            this.FillPage(this.S_OS_PREGLED_AMORTIZACIJESet, startRow, maxRows);
            dataSet.Merge(this.S_OS_PREGLED_AMORTIZACIJESet);
            return 0;
        }

        public virtual int FillPage(S_OS_PREGLED_AMORTIZACIJEDataSet dataSet, int bROJDOK, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OS_PREGLED_AMORTIZACIJESet = dataSet;
            this.rowS_OS_PREGLED_AMORTIZACIJE = this.S_OS_PREGLED_AMORTIZACIJESet.S_OS_PREGLED_AMORTIZACIJE.NewS_OS_PREGLED_AMORTIZACIJERow();
            this.SetFillParameters(bROJDOK);
            this.AV8BROJDOK = bROJDOK;
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
                parameter.ParameterName = "BROJDOK";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(int bROJDOK)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_OS_PREGLED_AMORTIZACIJESelect1 = this.connDefault.GetCommand("S_OS_PREGLED_AMORTIZACIJE", true);
            this.cmS_OS_PREGLED_AMORTIZACIJESelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OS_PREGLED_AMORTIZACIJESelect1.IDbCommand.Parameters.Clear();
            this.cmS_OS_PREGLED_AMORTIZACIJESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJDOK", bROJDOK));
            this.cmS_OS_PREGLED_AMORTIZACIJESelect1.ErrorMask |= ErrorMask.Lock;
            this.S_OS_PREGLED_AMORTIZACIJESelect1 = this.cmS_OS_PREGLED_AMORTIZACIJESelect1.FetchData();
            if (this.S_OS_PREGLED_AMORTIZACIJESelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OS_PREGLED_AMORTIZACIJESelect1.GetInt32(0);
            }
            this.S_OS_PREGLED_AMORTIZACIJESelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(int bROJDOK)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(bROJDOK);
                internalRecordCount = this.GetInternalRecordCount(bROJDOK);
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
            this.AV8BROJDOK = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(int bROJDOK)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = bROJDOK;
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

