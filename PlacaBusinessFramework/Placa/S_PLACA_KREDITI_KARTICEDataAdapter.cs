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

    public class S_PLACA_KREDITI_KARTICEDataAdapter : IDataAdapter, IS_PLACA_KREDITI_KARTICEDataAdapter
    {
        private string AV8IDOBRAC;
        private ReadWriteCommand cmS_PLACA_KREDITI_KARTICESelect1;
        private ReadWriteCommand cmS_PLACA_KREDITI_KARTICESelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_PLACA_KREDITI_KARTICEDataSet.S_PLACA_KREDITI_KARTICERow rowS_PLACA_KREDITI_KARTICE;
        private IDataReader S_PLACA_KREDITI_KARTICESelect1;
        private IDataReader S_PLACA_KREDITI_KARTICESelect2;
        private S_PLACA_KREDITI_KARTICEDataSet S_PLACA_KREDITI_KARTICESet;

        private void AddRowS_placa_krediti_kartice()
        {
            this.S_PLACA_KREDITI_KARTICESet.S_PLACA_KREDITI_KARTICE.AddS_PLACA_KREDITI_KARTICERow(this.rowS_PLACA_KREDITI_KARTICE);
            this.rowS_PLACA_KREDITI_KARTICE.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_PLACA_KREDITI_KARTICESelect2 = this.connDefault.GetCommand("S_PLACA_KREDITI_KARTICE", true);
            this.cmS_PLACA_KREDITI_KARTICESelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_PLACA_KREDITI_KARTICESelect2.IDbCommand.Parameters.Clear();
            this.cmS_PLACA_KREDITI_KARTICESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", this.AV8IDOBRAC));
            this.cmS_PLACA_KREDITI_KARTICESelect2.ErrorMask |= ErrorMask.Lock;
            this.S_PLACA_KREDITI_KARTICESelect2 = this.cmS_PLACA_KREDITI_KARTICESelect2.FetchData();
            while (this.cmS_PLACA_KREDITI_KARTICESelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_PLACA_KREDITI_KARTICESelect2.HasMoreRows = this.S_PLACA_KREDITI_KARTICESelect2.Read();
            }
            int num = 0;
            while (this.cmS_PLACA_KREDITI_KARTICESelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_PLACA_KREDITI_KARTICE["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KREDITI_KARTICESelect2["IDRADNIK"]);
                this.rowS_PLACA_KREDITI_KARTICE["NAZIVOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KREDITI_KARTICESelect2["NAZIVOBUSTAVA"]);
                this.rowS_PLACA_KREDITI_KARTICE["IZNOSOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KREDITI_KARTICESelect2["IZNOSOBUSTAVE"]);
                this.rowS_PLACA_KREDITI_KARTICE["POSTOTAKOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KREDITI_KARTICESelect2["POSTOTAKOBUSTAVE"]);
                this.rowS_PLACA_KREDITI_KARTICE["UKUNAMA"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KREDITI_KARTICESelect2["UKUNAMA"]);
                this.rowS_PLACA_KREDITI_KARTICE["ISPLACENOKASA"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KREDITI_KARTICESelect2["ISPLACENOKASA"]);
                this.rowS_PLACA_KREDITI_KARTICE["SALDOKASA"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KREDITI_KARTICESelect2["SALDOKASA"]);
                this.rowS_PLACA_KREDITI_KARTICE["DATUM"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KREDITI_KARTICESelect2["DATUM"]);
                this.rowS_PLACA_KREDITI_KARTICE["DATUMUGOVORA"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KREDITI_KARTICESelect2["DATUMUGOVORA"]);
                this.rowS_PLACA_KREDITI_KARTICE["vrsta"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KREDITI_KARTICESelect2["VRSTA"]);
                this.rowS_PLACA_KREDITI_KARTICE["IDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KREDITI_KARTICESelect2["IDOBRACUN"]);
                this.rowS_PLACA_KREDITI_KARTICE["SIFRAZAKARTICU"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_KREDITI_KARTICESelect2["SIFRAZAKARTICU"]);
                this.AddRowS_placa_krediti_kartice();
                num++;
                this.rowS_PLACA_KREDITI_KARTICE = this.S_PLACA_KREDITI_KARTICESet.S_PLACA_KREDITI_KARTICE.NewS_PLACA_KREDITI_KARTICERow();
                this.cmS_PLACA_KREDITI_KARTICESelect2.HasMoreRows = this.S_PLACA_KREDITI_KARTICESelect2.Read();
            }
            this.S_PLACA_KREDITI_KARTICESelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_PLACA_KREDITI_KARTICEDataSet dataSet)
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
            this.S_PLACA_KREDITI_KARTICESet = (S_PLACA_KREDITI_KARTICEDataSet) dataSet;
            if (this.S_PLACA_KREDITI_KARTICESet != null)
            {
                return this.Fill(this.S_PLACA_KREDITI_KARTICESet);
            }
            this.S_PLACA_KREDITI_KARTICESet = new S_PLACA_KREDITI_KARTICEDataSet();
            this.Fill(this.S_PLACA_KREDITI_KARTICESet);
            dataSet.Merge(this.S_PLACA_KREDITI_KARTICESet);
            return 0;
        }

        public virtual int Fill(S_PLACA_KREDITI_KARTICEDataSet dataSet, string iDOBRACUN)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_PLACA_KREDITI_KARTICESet = dataSet;
            this.rowS_PLACA_KREDITI_KARTICE = this.S_PLACA_KREDITI_KARTICESet.S_PLACA_KREDITI_KARTICE.NewS_PLACA_KREDITI_KARTICERow();
            this.SetFillParameters(iDOBRACUN);
            this.AV8IDOBRAC = iDOBRACUN;
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

        public virtual int FillPage(S_PLACA_KREDITI_KARTICEDataSet dataSet, int startRow, int maxRows)
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
            this.S_PLACA_KREDITI_KARTICESet = (S_PLACA_KREDITI_KARTICEDataSet) dataSet;
            if (this.S_PLACA_KREDITI_KARTICESet != null)
            {
                return this.FillPage(this.S_PLACA_KREDITI_KARTICESet, startRow, maxRows);
            }
            this.S_PLACA_KREDITI_KARTICESet = new S_PLACA_KREDITI_KARTICEDataSet();
            this.FillPage(this.S_PLACA_KREDITI_KARTICESet, startRow, maxRows);
            dataSet.Merge(this.S_PLACA_KREDITI_KARTICESet);
            return 0;
        }

        public virtual int FillPage(S_PLACA_KREDITI_KARTICEDataSet dataSet, string iDOBRACUN, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_PLACA_KREDITI_KARTICESet = dataSet;
            this.rowS_PLACA_KREDITI_KARTICE = this.S_PLACA_KREDITI_KARTICESet.S_PLACA_KREDITI_KARTICE.NewS_PLACA_KREDITI_KARTICERow();
            this.SetFillParameters(iDOBRACUN);
            this.AV8IDOBRAC = iDOBRACUN;
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
                parameter.ParameterName = "IDOBRACUN";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string iDOBRACUN)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_PLACA_KREDITI_KARTICESelect1 = this.connDefault.GetCommand("S_PLACA_KREDITI_KARTICE", true);
            this.cmS_PLACA_KREDITI_KARTICESelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_PLACA_KREDITI_KARTICESelect1.IDbCommand.Parameters.Clear();
            this.cmS_PLACA_KREDITI_KARTICESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", iDOBRACUN));
            this.cmS_PLACA_KREDITI_KARTICESelect1.ErrorMask |= ErrorMask.Lock;
            this.S_PLACA_KREDITI_KARTICESelect1 = this.cmS_PLACA_KREDITI_KARTICESelect1.FetchData();
            if (this.S_PLACA_KREDITI_KARTICESelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_PLACA_KREDITI_KARTICESelect1.GetInt32(0);
            }
            this.S_PLACA_KREDITI_KARTICESelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string iDOBRACUN)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(iDOBRACUN);
                internalRecordCount = this.GetInternalRecordCount(iDOBRACUN);
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
            this.AV8IDOBRAC = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string iDOBRACUN)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = iDOBRACUN;
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

