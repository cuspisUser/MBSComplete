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

    public class S_OS_REKAP_TEMELJNICEDataAdapter : IDataAdapter, IS_OS_REKAP_TEMELJNICEDataAdapter
    {
        private int AV8BROJOST;
        private int AV9vrstaos;
        private ReadWriteCommand cmS_OS_REKAP_TEMELJNICESelect1;
        private ReadWriteCommand cmS_OS_REKAP_TEMELJNICESelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OS_REKAP_TEMELJNICEDataSet.S_OS_REKAP_TEMELJNICERow rowS_OS_REKAP_TEMELJNICE;
        private IDataReader S_OS_REKAP_TEMELJNICESelect1;
        private IDataReader S_OS_REKAP_TEMELJNICESelect2;
        private S_OS_REKAP_TEMELJNICEDataSet S_OS_REKAP_TEMELJNICESet;

        private void AddRowS_os_rekap_temeljnice()
        {
            this.S_OS_REKAP_TEMELJNICESet.S_OS_REKAP_TEMELJNICE.AddS_OS_REKAP_TEMELJNICERow(this.rowS_OS_REKAP_TEMELJNICE);
            this.rowS_OS_REKAP_TEMELJNICE.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OS_REKAP_TEMELJNICESelect2 = this.connDefault.GetCommand("S_OS_REKAP_TEMELJNICE", true);
            this.cmS_OS_REKAP_TEMELJNICESelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OS_REKAP_TEMELJNICESelect2.IDbCommand.Parameters.Clear();
            this.cmS_OS_REKAP_TEMELJNICESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJOSTEMELJNICE", this.AV8BROJOST));
            this.cmS_OS_REKAP_TEMELJNICESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@vrstaostemeljnice", this.AV9vrstaos));
            this.cmS_OS_REKAP_TEMELJNICESelect2.ErrorMask |= ErrorMask.Lock;
            this.S_OS_REKAP_TEMELJNICESelect2 = this.cmS_OS_REKAP_TEMELJNICESelect2.FetchData();
            while (this.cmS_OS_REKAP_TEMELJNICESelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OS_REKAP_TEMELJNICESelect2.HasMoreRows = this.S_OS_REKAP_TEMELJNICESelect2.Read();
            }
            int num = 0;
            while (this.cmS_OS_REKAP_TEMELJNICESelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OS_REKAP_TEMELJNICE["KTONABAVKEIDKONTO"] = RuntimeHelpers.GetObjectValue(this.S_OS_REKAP_TEMELJNICESelect2["KTONABAVKEIDKONTO"]);
                this.rowS_OS_REKAP_TEMELJNICE["KTOISPRAVKAIDKONTO"] = RuntimeHelpers.GetObjectValue(this.S_OS_REKAP_TEMELJNICESelect2["KTOISPRAVKAIDKONTO"]);
                this.rowS_OS_REKAP_TEMELJNICE["KTOIZVORAIDKONTO"] = RuntimeHelpers.GetObjectValue(this.S_OS_REKAP_TEMELJNICESelect2["KTOIZVORAIDKONTO"]);
                this.rowS_OS_REKAP_TEMELJNICE["OSDUGUJE"] = RuntimeHelpers.GetObjectValue(this.S_OS_REKAP_TEMELJNICESelect2["OSDUGUJE"]);
                this.rowS_OS_REKAP_TEMELJNICE["OSPOTRAZUJE"] = RuntimeHelpers.GetObjectValue(this.S_OS_REKAP_TEMELJNICESelect2["OSPOTRAZUJE"]);
                this.rowS_OS_REKAP_TEMELJNICE["IDOSDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.S_OS_REKAP_TEMELJNICESelect2["IDOSDOKUMENT"]);
                this.rowS_OS_REKAP_TEMELJNICE["OSBROJDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.S_OS_REKAP_TEMELJNICESelect2["OSBROJDOKUMENTA"]);
                this.rowS_OS_REKAP_TEMELJNICE["OSDATUMDOK"] = RuntimeHelpers.GetObjectValue(this.S_OS_REKAP_TEMELJNICESelect2["OSDATUMDOK"]);
                this.rowS_OS_REKAP_TEMELJNICE["OSOPIS"] = RuntimeHelpers.GetObjectValue(this.S_OS_REKAP_TEMELJNICESelect2["OSOPIS"]);
                this.AddRowS_os_rekap_temeljnice();
                num++;
                this.rowS_OS_REKAP_TEMELJNICE = this.S_OS_REKAP_TEMELJNICESet.S_OS_REKAP_TEMELJNICE.NewS_OS_REKAP_TEMELJNICERow();
                this.cmS_OS_REKAP_TEMELJNICESelect2.HasMoreRows = this.S_OS_REKAP_TEMELJNICESelect2.Read();
            }
            this.S_OS_REKAP_TEMELJNICESelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OS_REKAP_TEMELJNICEDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), int.Parse(this.fillDataParameters[1].Value.ToString()));
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_OS_REKAP_TEMELJNICESet = (S_OS_REKAP_TEMELJNICEDataSet) dataSet;
            if (this.S_OS_REKAP_TEMELJNICESet != null)
            {
                return this.Fill(this.S_OS_REKAP_TEMELJNICESet);
            }
            this.S_OS_REKAP_TEMELJNICESet = new S_OS_REKAP_TEMELJNICEDataSet();
            this.Fill(this.S_OS_REKAP_TEMELJNICESet);
            dataSet.Merge(this.S_OS_REKAP_TEMELJNICESet);
            return 0;
        }

        public virtual int Fill(S_OS_REKAP_TEMELJNICEDataSet dataSet, int bROJOSTEMELJNICE, int vrstaostemeljnice)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OS_REKAP_TEMELJNICESet = dataSet;
            this.rowS_OS_REKAP_TEMELJNICE = this.S_OS_REKAP_TEMELJNICESet.S_OS_REKAP_TEMELJNICE.NewS_OS_REKAP_TEMELJNICERow();
            this.SetFillParameters(bROJOSTEMELJNICE, vrstaostemeljnice);
            this.AV8BROJOST = bROJOSTEMELJNICE;
            this.AV9vrstaos = vrstaostemeljnice;
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

        public virtual int FillPage(S_OS_REKAP_TEMELJNICEDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), int.Parse(this.fillDataParameters[1].Value.ToString()), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_OS_REKAP_TEMELJNICESet = (S_OS_REKAP_TEMELJNICEDataSet) dataSet;
            if (this.S_OS_REKAP_TEMELJNICESet != null)
            {
                return this.FillPage(this.S_OS_REKAP_TEMELJNICESet, startRow, maxRows);
            }
            this.S_OS_REKAP_TEMELJNICESet = new S_OS_REKAP_TEMELJNICEDataSet();
            this.FillPage(this.S_OS_REKAP_TEMELJNICESet, startRow, maxRows);
            dataSet.Merge(this.S_OS_REKAP_TEMELJNICESet);
            return 0;
        }

        public virtual int FillPage(S_OS_REKAP_TEMELJNICEDataSet dataSet, int bROJOSTEMELJNICE, int vrstaostemeljnice, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OS_REKAP_TEMELJNICESet = dataSet;
            this.rowS_OS_REKAP_TEMELJNICE = this.S_OS_REKAP_TEMELJNICESet.S_OS_REKAP_TEMELJNICE.NewS_OS_REKAP_TEMELJNICERow();
            this.SetFillParameters(bROJOSTEMELJNICE, vrstaostemeljnice);
            this.AV8BROJOST = bROJOSTEMELJNICE;
            this.AV9vrstaos = vrstaostemeljnice;
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
                parameter.ParameterName = "BROJOSTEMELJNICE";
                parameter.DbType = DbType.Int32;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "vrstaostemeljnice";
                parameter2.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(int bROJOSTEMELJNICE, int vrstaostemeljnice)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_OS_REKAP_TEMELJNICESelect1 = this.connDefault.GetCommand("S_OS_REKAP_TEMELJNICE", true);
            this.cmS_OS_REKAP_TEMELJNICESelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OS_REKAP_TEMELJNICESelect1.IDbCommand.Parameters.Clear();
            this.cmS_OS_REKAP_TEMELJNICESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJOSTEMELJNICE", bROJOSTEMELJNICE));
            this.cmS_OS_REKAP_TEMELJNICESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@vrstaostemeljnice", vrstaostemeljnice));
            this.cmS_OS_REKAP_TEMELJNICESelect1.ErrorMask |= ErrorMask.Lock;
            this.S_OS_REKAP_TEMELJNICESelect1 = this.cmS_OS_REKAP_TEMELJNICESelect1.FetchData();
            if (this.S_OS_REKAP_TEMELJNICESelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OS_REKAP_TEMELJNICESelect1.GetInt32(0);
            }
            this.S_OS_REKAP_TEMELJNICESelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(int bROJOSTEMELJNICE, int vrstaostemeljnice)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(bROJOSTEMELJNICE, vrstaostemeljnice);
                internalRecordCount = this.GetInternalRecordCount(bROJOSTEMELJNICE, vrstaostemeljnice);
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
            this.AV8BROJOST = 0;
            this.AV9vrstaos = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(int bROJOSTEMELJNICE, int vrstaostemeljnice)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = bROJOSTEMELJNICE;
                this.fillDataParameters[1].Value = vrstaostemeljnice;
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

