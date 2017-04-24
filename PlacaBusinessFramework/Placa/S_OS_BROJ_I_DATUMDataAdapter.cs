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

    public class S_OS_BROJ_I_DATUMDataAdapter : IDataAdapter, IS_OS_BROJ_I_DATUMDataAdapter
    {
        private ReadWriteCommand cmS_OS_BROJ_I_DATUMSelect1;
        private ReadWriteCommand cmS_OS_BROJ_I_DATUMSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OS_BROJ_I_DATUMDataSet.S_OS_BROJ_I_DATUMRow rowS_OS_BROJ_I_DATUM;
        private IDataReader S_OS_BROJ_I_DATUMSelect1;
        private IDataReader S_OS_BROJ_I_DATUMSelect2;
        private S_OS_BROJ_I_DATUMDataSet S_OS_BROJ_I_DATUMSet;

        private void AddRowS_os_broj_i_datum()
        {
            this.S_OS_BROJ_I_DATUMSet.S_OS_BROJ_I_DATUM.AddS_OS_BROJ_I_DATUMRow(this.rowS_OS_BROJ_I_DATUM);
            this.rowS_OS_BROJ_I_DATUM.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OS_BROJ_I_DATUMSelect2 = this.connDefault.GetCommand("S_OS_BROJ_I_DATUM", true);
            this.cmS_OS_BROJ_I_DATUMSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OS_BROJ_I_DATUMSelect2.IDbCommand.Parameters.Clear();
            this.cmS_OS_BROJ_I_DATUMSelect2.ErrorMask |= ErrorMask.Lock;
            this.S_OS_BROJ_I_DATUMSelect2 = this.cmS_OS_BROJ_I_DATUMSelect2.FetchData();
            while (this.cmS_OS_BROJ_I_DATUMSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OS_BROJ_I_DATUMSelect2.HasMoreRows = this.S_OS_BROJ_I_DATUMSelect2.Read();
            }
            int num = 0;
            while (this.cmS_OS_BROJ_I_DATUMSelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OS_BROJ_I_DATUM["BROJDOK"] = RuntimeHelpers.GetObjectValue(this.S_OS_BROJ_I_DATUMSelect2["BROJDOK"]);
                this.rowS_OS_BROJ_I_DATUM["ZADNJIDATUM"] = RuntimeHelpers.GetObjectValue(this.S_OS_BROJ_I_DATUMSelect2["ZADNJIDATUM"]);
                this.AddRowS_os_broj_i_datum();
                num++;
                this.rowS_OS_BROJ_I_DATUM = this.S_OS_BROJ_I_DATUMSet.S_OS_BROJ_I_DATUM.NewS_OS_BROJ_I_DATUMRow();
                this.cmS_OS_BROJ_I_DATUMSelect2.HasMoreRows = this.S_OS_BROJ_I_DATUMSelect2.Read();
            }
            this.S_OS_BROJ_I_DATUMSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OS_BROJ_I_DATUMDataSet dataSet)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OS_BROJ_I_DATUMSet = dataSet;
            this.rowS_OS_BROJ_I_DATUM = this.S_OS_BROJ_I_DATUMSet.S_OS_BROJ_I_DATUM.NewS_OS_BROJ_I_DATUMRow();
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
            this.S_OS_BROJ_I_DATUMSet = (S_OS_BROJ_I_DATUMDataSet) dataSet;
            if (this.S_OS_BROJ_I_DATUMSet != null)
            {
                return this.Fill(this.S_OS_BROJ_I_DATUMSet);
            }
            this.S_OS_BROJ_I_DATUMSet = new S_OS_BROJ_I_DATUMDataSet();
            this.Fill(this.S_OS_BROJ_I_DATUMSet);
            dataSet.Merge(this.S_OS_BROJ_I_DATUMSet);
            return 0;
        }

        public virtual int FillPage(S_OS_BROJ_I_DATUMDataSet dataSet, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OS_BROJ_I_DATUMSet = dataSet;
            this.rowS_OS_BROJ_I_DATUM = this.S_OS_BROJ_I_DATUMSet.S_OS_BROJ_I_DATUM.NewS_OS_BROJ_I_DATUMRow();
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
            this.S_OS_BROJ_I_DATUMSet = (S_OS_BROJ_I_DATUMDataSet) dataSet;
            if (this.S_OS_BROJ_I_DATUMSet != null)
            {
                return this.FillPage(this.S_OS_BROJ_I_DATUMSet, startRow, maxRows);
            }
            this.S_OS_BROJ_I_DATUMSet = new S_OS_BROJ_I_DATUMDataSet();
            this.FillPage(this.S_OS_BROJ_I_DATUMSet, startRow, maxRows);
            dataSet.Merge(this.S_OS_BROJ_I_DATUMSet);
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
            this.cmS_OS_BROJ_I_DATUMSelect1 = this.connDefault.GetCommand("S_OS_BROJ_I_DATUM", true);
            this.cmS_OS_BROJ_I_DATUMSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OS_BROJ_I_DATUMSelect1.IDbCommand.Parameters.Clear();
            this.cmS_OS_BROJ_I_DATUMSelect1.ErrorMask |= ErrorMask.Lock;
            this.S_OS_BROJ_I_DATUMSelect1 = this.cmS_OS_BROJ_I_DATUMSelect1.FetchData();
            if (this.S_OS_BROJ_I_DATUMSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OS_BROJ_I_DATUMSelect1.GetInt32(0);
            }
            this.S_OS_BROJ_I_DATUMSelect1.Close();
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

