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

    public class S_OD_KONACNI_POREZ_PO_OPCINAMADataAdapter : IDataAdapter, IS_OD_KONACNI_POREZ_PO_OPCINAMADataAdapter
    {
        private string AV8idobrac;
        private ReadWriteCommand cmS_OD_KONACNI_POREZ_PO_OPCINAMASelect1;
        private ReadWriteCommand cmS_OD_KONACNI_POREZ_PO_OPCINAMASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OD_KONACNI_POREZ_PO_OPCINAMADataSet.S_OD_KONACNI_POREZ_PO_OPCINAMARow rowS_OD_KONACNI_POREZ_PO_OPCINAMA;
        private IDataReader S_OD_KONACNI_POREZ_PO_OPCINAMASelect1;
        private IDataReader S_OD_KONACNI_POREZ_PO_OPCINAMASelect2;
        private S_OD_KONACNI_POREZ_PO_OPCINAMADataSet S_OD_KONACNI_POREZ_PO_OPCINAMASet;

        private void AddRowS_od_konacni_porez_po_opcinama()
        {
            this.S_OD_KONACNI_POREZ_PO_OPCINAMASet.S_OD_KONACNI_POREZ_PO_OPCINAMA.AddS_OD_KONACNI_POREZ_PO_OPCINAMARow(this.rowS_OD_KONACNI_POREZ_PO_OPCINAMA);
            this.rowS_OD_KONACNI_POREZ_PO_OPCINAMA.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OD_KONACNI_POREZ_PO_OPCINAMASelect2 = this.connDefault.GetCommand("S_PLACA_KONACNI_POREZ_PO_OPCINAMA", true);
            this.cmS_OD_KONACNI_POREZ_PO_OPCINAMASelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_KONACNI_POREZ_PO_OPCINAMASelect2.IDbCommand.Parameters.Clear();
            this.cmS_OD_KONACNI_POREZ_PO_OPCINAMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idobracun", this.AV8idobrac));
            this.cmS_OD_KONACNI_POREZ_PO_OPCINAMASelect2.ErrorMask |= ErrorMask.Lock;
            this.S_OD_KONACNI_POREZ_PO_OPCINAMASelect2 = this.cmS_OD_KONACNI_POREZ_PO_OPCINAMASelect2.FetchData();
            while (this.cmS_OD_KONACNI_POREZ_PO_OPCINAMASelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OD_KONACNI_POREZ_PO_OPCINAMASelect2.HasMoreRows = this.S_OD_KONACNI_POREZ_PO_OPCINAMASelect2.Read();
            }
            int num = 0;
            while (this.cmS_OD_KONACNI_POREZ_PO_OPCINAMASelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OD_KONACNI_POREZ_PO_OPCINAMA["SIFRAOPCINESTANOVANJA"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNI_POREZ_PO_OPCINAMASelect2["SIFRAOPCINESTANOVANJA"]);
                this.rowS_OD_KONACNI_POREZ_PO_OPCINAMA["NAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNI_POREZ_PO_OPCINAMASelect2["NAZIVOPCINE"]);
                this.rowS_OD_KONACNI_POREZ_PO_OPCINAMA["OBRACUNATOPOREZ"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNI_POREZ_PO_OPCINAMASelect2["OBRACUNATOPOREZ"]);
                this.rowS_OD_KONACNI_POREZ_PO_OPCINAMA["OBRACUNATOPRIREZ"] = RuntimeHelpers.GetObjectValue(this.S_OD_KONACNI_POREZ_PO_OPCINAMASelect2["OBRACUNATOPRIREZ"]);
                this.AddRowS_od_konacni_porez_po_opcinama();
                num++;
                this.rowS_OD_KONACNI_POREZ_PO_OPCINAMA = this.S_OD_KONACNI_POREZ_PO_OPCINAMASet.S_OD_KONACNI_POREZ_PO_OPCINAMA.NewS_OD_KONACNI_POREZ_PO_OPCINAMARow();
                this.cmS_OD_KONACNI_POREZ_PO_OPCINAMASelect2.HasMoreRows = this.S_OD_KONACNI_POREZ_PO_OPCINAMASelect2.Read();
            }
            this.S_OD_KONACNI_POREZ_PO_OPCINAMASelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OD_KONACNI_POREZ_PO_OPCINAMADataSet dataSet)
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
            this.S_OD_KONACNI_POREZ_PO_OPCINAMASet = (S_OD_KONACNI_POREZ_PO_OPCINAMADataSet) dataSet;
            if (this.S_OD_KONACNI_POREZ_PO_OPCINAMASet != null)
            {
                return this.Fill(this.S_OD_KONACNI_POREZ_PO_OPCINAMASet);
            }
            this.S_OD_KONACNI_POREZ_PO_OPCINAMASet = new S_OD_KONACNI_POREZ_PO_OPCINAMADataSet();
            this.Fill(this.S_OD_KONACNI_POREZ_PO_OPCINAMASet);
            dataSet.Merge(this.S_OD_KONACNI_POREZ_PO_OPCINAMASet);
            return 0;
        }

        public virtual int Fill(S_OD_KONACNI_POREZ_PO_OPCINAMADataSet dataSet, string idobracun)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_KONACNI_POREZ_PO_OPCINAMASet = dataSet;
            this.rowS_OD_KONACNI_POREZ_PO_OPCINAMA = this.S_OD_KONACNI_POREZ_PO_OPCINAMASet.S_OD_KONACNI_POREZ_PO_OPCINAMA.NewS_OD_KONACNI_POREZ_PO_OPCINAMARow();
            this.SetFillParameters(idobracun);
            this.AV8idobrac = idobracun;
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

        public virtual int FillPage(S_OD_KONACNI_POREZ_PO_OPCINAMADataSet dataSet, int startRow, int maxRows)
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
            this.S_OD_KONACNI_POREZ_PO_OPCINAMASet = (S_OD_KONACNI_POREZ_PO_OPCINAMADataSet) dataSet;
            if (this.S_OD_KONACNI_POREZ_PO_OPCINAMASet != null)
            {
                return this.FillPage(this.S_OD_KONACNI_POREZ_PO_OPCINAMASet, startRow, maxRows);
            }
            this.S_OD_KONACNI_POREZ_PO_OPCINAMASet = new S_OD_KONACNI_POREZ_PO_OPCINAMADataSet();
            this.FillPage(this.S_OD_KONACNI_POREZ_PO_OPCINAMASet, startRow, maxRows);
            dataSet.Merge(this.S_OD_KONACNI_POREZ_PO_OPCINAMASet);
            return 0;
        }

        public virtual int FillPage(S_OD_KONACNI_POREZ_PO_OPCINAMADataSet dataSet, string idobracun, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_KONACNI_POREZ_PO_OPCINAMASet = dataSet;
            this.rowS_OD_KONACNI_POREZ_PO_OPCINAMA = this.S_OD_KONACNI_POREZ_PO_OPCINAMASet.S_OD_KONACNI_POREZ_PO_OPCINAMA.NewS_OD_KONACNI_POREZ_PO_OPCINAMARow();
            this.SetFillParameters(idobracun);
            this.AV8idobrac = idobracun;
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
                parameter.ParameterName = "idobracun";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string idobracun)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_OD_KONACNI_POREZ_PO_OPCINAMASelect1 = this.connDefault.GetCommand("S_PLACA_KONACNI_POREZ_PO_OPCINAMA", true);
            this.cmS_OD_KONACNI_POREZ_PO_OPCINAMASelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_KONACNI_POREZ_PO_OPCINAMASelect1.IDbCommand.Parameters.Clear();
            this.cmS_OD_KONACNI_POREZ_PO_OPCINAMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idobracun", idobracun));
            this.cmS_OD_KONACNI_POREZ_PO_OPCINAMASelect1.ErrorMask |= ErrorMask.Lock;
            this.S_OD_KONACNI_POREZ_PO_OPCINAMASelect1 = this.cmS_OD_KONACNI_POREZ_PO_OPCINAMASelect1.FetchData();
            if (this.S_OD_KONACNI_POREZ_PO_OPCINAMASelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OD_KONACNI_POREZ_PO_OPCINAMASelect1.GetInt32(0);
            }
            this.S_OD_KONACNI_POREZ_PO_OPCINAMASelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string idobracun)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(idobracun);
                internalRecordCount = this.GetInternalRecordCount(idobracun);
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
            this.AV8idobrac = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string idobracun)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = idobracun;
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

