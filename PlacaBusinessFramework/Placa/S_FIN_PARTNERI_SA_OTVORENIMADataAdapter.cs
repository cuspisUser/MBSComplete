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

    public class S_FIN_PARTNERI_SA_OTVORENIMADataAdapter : IDataAdapter, IS_FIN_PARTNERI_SA_OTVORENIMADataAdapter
    {
        private int AV8godina;
        private ReadWriteCommand cmS_FIN_PARTNERI_SA_OTVORENIMASelect1;
        private ReadWriteCommand cmS_FIN_PARTNERI_SA_OTVORENIMASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_FIN_PARTNERI_SA_OTVORENIMADataSet.S_FIN_PARTNERI_SA_OTVORENIMARow rowS_FIN_PARTNERI_SA_OTVORENIMA;
        private IDataReader S_FIN_PARTNERI_SA_OTVORENIMASelect1;
        private IDataReader S_FIN_PARTNERI_SA_OTVORENIMASelect2;
        private S_FIN_PARTNERI_SA_OTVORENIMADataSet S_FIN_PARTNERI_SA_OTVORENIMASet;

        private void AddRowS_fin_partneri_sa_otvorenima()
        {
            this.S_FIN_PARTNERI_SA_OTVORENIMASet.S_FIN_PARTNERI_SA_OTVORENIMA.AddS_FIN_PARTNERI_SA_OTVORENIMARow(this.rowS_FIN_PARTNERI_SA_OTVORENIMA);
            this.rowS_FIN_PARTNERI_SA_OTVORENIMA.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_FIN_PARTNERI_SA_OTVORENIMASelect2 = this.connDefault.GetCommand("S_FIN_PARTNERI_SA_OTVORENIMA", true);
            this.cmS_FIN_PARTNERI_SA_OTVORENIMASelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_PARTNERI_SA_OTVORENIMASelect2.IDbCommand.Parameters.Clear();
            this.cmS_FIN_PARTNERI_SA_OTVORENIMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godina", this.AV8godina));
            this.cmS_FIN_PARTNERI_SA_OTVORENIMASelect2.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_PARTNERI_SA_OTVORENIMASelect2 = this.cmS_FIN_PARTNERI_SA_OTVORENIMASelect2.FetchData();
            while (this.cmS_FIN_PARTNERI_SA_OTVORENIMASelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_FIN_PARTNERI_SA_OTVORENIMASelect2.HasMoreRows = this.S_FIN_PARTNERI_SA_OTVORENIMASelect2.Read();
            }
            int num = 0;
            while (this.cmS_FIN_PARTNERI_SA_OTVORENIMASelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_FIN_PARTNERI_SA_OTVORENIMA["IDPARTNER"] = RuntimeHelpers.GetObjectValue(this.S_FIN_PARTNERI_SA_OTVORENIMASelect2["IDPARTNER"]);
                this.rowS_FIN_PARTNERI_SA_OTVORENIMA["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(this.S_FIN_PARTNERI_SA_OTVORENIMASelect2["NAZIVPARTNER"]);
                this.rowS_FIN_PARTNERI_SA_OTVORENIMA["PARTNERMJESTO"] = RuntimeHelpers.GetObjectValue(this.S_FIN_PARTNERI_SA_OTVORENIMASelect2["PARTNERMJESTO"]);
                this.AddRowS_fin_partneri_sa_otvorenima();
                num++;
                this.rowS_FIN_PARTNERI_SA_OTVORENIMA = this.S_FIN_PARTNERI_SA_OTVORENIMASet.S_FIN_PARTNERI_SA_OTVORENIMA.NewS_FIN_PARTNERI_SA_OTVORENIMARow();
                this.cmS_FIN_PARTNERI_SA_OTVORENIMASelect2.HasMoreRows = this.S_FIN_PARTNERI_SA_OTVORENIMASelect2.Read();
            }
            this.S_FIN_PARTNERI_SA_OTVORENIMASelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_FIN_PARTNERI_SA_OTVORENIMADataSet dataSet)
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
            this.S_FIN_PARTNERI_SA_OTVORENIMASet = (S_FIN_PARTNERI_SA_OTVORENIMADataSet) dataSet;
            if (this.S_FIN_PARTNERI_SA_OTVORENIMASet != null)
            {
                return this.Fill(this.S_FIN_PARTNERI_SA_OTVORENIMASet);
            }
            this.S_FIN_PARTNERI_SA_OTVORENIMASet = new S_FIN_PARTNERI_SA_OTVORENIMADataSet();
            this.Fill(this.S_FIN_PARTNERI_SA_OTVORENIMASet);
            dataSet.Merge(this.S_FIN_PARTNERI_SA_OTVORENIMASet);
            return 0;
        }

        public virtual int Fill(S_FIN_PARTNERI_SA_OTVORENIMADataSet dataSet, int godina)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_PARTNERI_SA_OTVORENIMASet = dataSet;
            this.rowS_FIN_PARTNERI_SA_OTVORENIMA = this.S_FIN_PARTNERI_SA_OTVORENIMASet.S_FIN_PARTNERI_SA_OTVORENIMA.NewS_FIN_PARTNERI_SA_OTVORENIMARow();
            this.SetFillParameters(godina);
            this.AV8godina = godina;
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

        public virtual int FillPage(S_FIN_PARTNERI_SA_OTVORENIMADataSet dataSet, int startRow, int maxRows)
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
            this.S_FIN_PARTNERI_SA_OTVORENIMASet = (S_FIN_PARTNERI_SA_OTVORENIMADataSet) dataSet;
            if (this.S_FIN_PARTNERI_SA_OTVORENIMASet != null)
            {
                return this.FillPage(this.S_FIN_PARTNERI_SA_OTVORENIMASet, startRow, maxRows);
            }
            this.S_FIN_PARTNERI_SA_OTVORENIMASet = new S_FIN_PARTNERI_SA_OTVORENIMADataSet();
            this.FillPage(this.S_FIN_PARTNERI_SA_OTVORENIMASet, startRow, maxRows);
            dataSet.Merge(this.S_FIN_PARTNERI_SA_OTVORENIMASet);
            return 0;
        }

        public virtual int FillPage(S_FIN_PARTNERI_SA_OTVORENIMADataSet dataSet, int godina, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_PARTNERI_SA_OTVORENIMASet = dataSet;
            this.rowS_FIN_PARTNERI_SA_OTVORENIMA = this.S_FIN_PARTNERI_SA_OTVORENIMASet.S_FIN_PARTNERI_SA_OTVORENIMA.NewS_FIN_PARTNERI_SA_OTVORENIMARow();
            this.SetFillParameters(godina);
            this.AV8godina = godina;
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
                parameter.ParameterName = "godina";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(int godina)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_FIN_PARTNERI_SA_OTVORENIMASelect1 = this.connDefault.GetCommand("S_FIN_PARTNERI_SA_OTVORENIMA", true);
            this.cmS_FIN_PARTNERI_SA_OTVORENIMASelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_PARTNERI_SA_OTVORENIMASelect1.IDbCommand.Parameters.Clear();
            this.cmS_FIN_PARTNERI_SA_OTVORENIMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godina", godina));
            this.cmS_FIN_PARTNERI_SA_OTVORENIMASelect1.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_PARTNERI_SA_OTVORENIMASelect1 = this.cmS_FIN_PARTNERI_SA_OTVORENIMASelect1.FetchData();
            if (this.S_FIN_PARTNERI_SA_OTVORENIMASelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_FIN_PARTNERI_SA_OTVORENIMASelect1.GetInt32(0);
            }
            this.S_FIN_PARTNERI_SA_OTVORENIMASelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(int godina)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(godina);
                internalRecordCount = this.GetInternalRecordCount(godina);
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
            this.AV8godina = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(int godina)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = godina;
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

