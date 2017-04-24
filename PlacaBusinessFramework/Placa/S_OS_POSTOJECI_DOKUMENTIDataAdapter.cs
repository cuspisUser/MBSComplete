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

    public class S_OS_POSTOJECI_DOKUMENTIDataAdapter : IDataAdapter, IS_OS_POSTOJECI_DOKUMENTIDataAdapter
    {
        private ReadWriteCommand cmS_OS_POSTOJECI_DOKUMENTISelect1;
        private ReadWriteCommand cmS_OS_POSTOJECI_DOKUMENTISelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OS_POSTOJECI_DOKUMENTIDataSet.S_OS_POSTOJECI_DOKUMENTIRow rowS_OS_POSTOJECI_DOKUMENTI;
        private IDataReader S_OS_POSTOJECI_DOKUMENTISelect1;
        private IDataReader S_OS_POSTOJECI_DOKUMENTISelect2;
        private S_OS_POSTOJECI_DOKUMENTIDataSet S_OS_POSTOJECI_DOKUMENTISet;

        private void AddRowS_os_postojeci_dokumenti()
        {
            this.S_OS_POSTOJECI_DOKUMENTISet.S_OS_POSTOJECI_DOKUMENTI.AddS_OS_POSTOJECI_DOKUMENTIRow(this.rowS_OS_POSTOJECI_DOKUMENTI);
            this.rowS_OS_POSTOJECI_DOKUMENTI.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OS_POSTOJECI_DOKUMENTISelect2 = this.connDefault.GetCommand("S_OS_POSTOJECI_DOKUMENTI", true);
            this.cmS_OS_POSTOJECI_DOKUMENTISelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OS_POSTOJECI_DOKUMENTISelect2.IDbCommand.Parameters.Clear();
            this.cmS_OS_POSTOJECI_DOKUMENTISelect2.ErrorMask |= ErrorMask.Lock;
            this.S_OS_POSTOJECI_DOKUMENTISelect2 = this.cmS_OS_POSTOJECI_DOKUMENTISelect2.FetchData();
            while (this.cmS_OS_POSTOJECI_DOKUMENTISelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OS_POSTOJECI_DOKUMENTISelect2.HasMoreRows = this.S_OS_POSTOJECI_DOKUMENTISelect2.Read();
            }
            int num = 0;
            while (this.cmS_OS_POSTOJECI_DOKUMENTISelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OS_POSTOJECI_DOKUMENTI["IDOSDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.S_OS_POSTOJECI_DOKUMENTISelect2["IDOSDOKUMENT"]);
                this.rowS_OS_POSTOJECI_DOKUMENTI["OSDATUMDOK"] = RuntimeHelpers.GetObjectValue(this.S_OS_POSTOJECI_DOKUMENTISelect2["OSDATUMDOK"]);
                this.rowS_OS_POSTOJECI_DOKUMENTI["OSBROJDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.S_OS_POSTOJECI_DOKUMENTISelect2["OSBROJDOKUMENTA"]);
                this.rowS_OS_POSTOJECI_DOKUMENTI["OSOPIS"] = RuntimeHelpers.GetObjectValue(this.S_OS_POSTOJECI_DOKUMENTISelect2["OSOPIS"]);
                this.AddRowS_os_postojeci_dokumenti();
                num++;
                this.rowS_OS_POSTOJECI_DOKUMENTI = this.S_OS_POSTOJECI_DOKUMENTISet.S_OS_POSTOJECI_DOKUMENTI.NewS_OS_POSTOJECI_DOKUMENTIRow();
                this.cmS_OS_POSTOJECI_DOKUMENTISelect2.HasMoreRows = this.S_OS_POSTOJECI_DOKUMENTISelect2.Read();
            }
            this.S_OS_POSTOJECI_DOKUMENTISelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OS_POSTOJECI_DOKUMENTIDataSet dataSet)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OS_POSTOJECI_DOKUMENTISet = dataSet;
            this.rowS_OS_POSTOJECI_DOKUMENTI = this.S_OS_POSTOJECI_DOKUMENTISet.S_OS_POSTOJECI_DOKUMENTI.NewS_OS_POSTOJECI_DOKUMENTIRow();
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

        public virtual int Fill(DataSet dataSet)
        {
            this.S_OS_POSTOJECI_DOKUMENTISet = (S_OS_POSTOJECI_DOKUMENTIDataSet) dataSet;
            if (this.S_OS_POSTOJECI_DOKUMENTISet != null)
            {
                return this.Fill(this.S_OS_POSTOJECI_DOKUMENTISet);
            }
            this.S_OS_POSTOJECI_DOKUMENTISet = new S_OS_POSTOJECI_DOKUMENTIDataSet();
            this.Fill(this.S_OS_POSTOJECI_DOKUMENTISet);
            dataSet.Merge(this.S_OS_POSTOJECI_DOKUMENTISet);
            return 0;
        }

        public virtual int FillPage(S_OS_POSTOJECI_DOKUMENTIDataSet dataSet, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OS_POSTOJECI_DOKUMENTISet = dataSet;
            this.rowS_OS_POSTOJECI_DOKUMENTI = this.S_OS_POSTOJECI_DOKUMENTISet.S_OS_POSTOJECI_DOKUMENTI.NewS_OS_POSTOJECI_DOKUMENTIRow();
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

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_OS_POSTOJECI_DOKUMENTISet = (S_OS_POSTOJECI_DOKUMENTIDataSet) dataSet;
            if (this.S_OS_POSTOJECI_DOKUMENTISet != null)
            {
                return this.FillPage(this.S_OS_POSTOJECI_DOKUMENTISet, startRow, maxRows);
            }
            this.S_OS_POSTOJECI_DOKUMENTISet = new S_OS_POSTOJECI_DOKUMENTIDataSet();
            this.FillPage(this.S_OS_POSTOJECI_DOKUMENTISet, startRow, maxRows);
            dataSet.Merge(this.S_OS_POSTOJECI_DOKUMENTISet);
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
                this.fillDataParameters = new DbParameter[0];
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_OS_POSTOJECI_DOKUMENTISelect1 = this.connDefault.GetCommand("S_OS_POSTOJECI_DOKUMENTI", true);
            this.cmS_OS_POSTOJECI_DOKUMENTISelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OS_POSTOJECI_DOKUMENTISelect1.IDbCommand.Parameters.Clear();
            this.cmS_OS_POSTOJECI_DOKUMENTISelect1.ErrorMask |= ErrorMask.Lock;
            this.S_OS_POSTOJECI_DOKUMENTISelect1 = this.cmS_OS_POSTOJECI_DOKUMENTISelect1.FetchData();
            if (this.S_OS_POSTOJECI_DOKUMENTISelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OS_POSTOJECI_DOKUMENTISelect1.GetInt32(0);
            }
            this.S_OS_POSTOJECI_DOKUMENTISelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount()
        {
            int internalRecordCount;
            try
            {
                internalRecordCount = this.GetInternalRecordCount();
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
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
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

