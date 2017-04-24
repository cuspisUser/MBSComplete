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

    public class S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataAdapter : IDataAdapter, IS_OS_STANJE_LOKACIJA_SVI_BROJEVIDataAdapter
    {
        private ReadWriteCommand cmS_OS_STANJE_LOKACIJA_SVI_BROJEVISelect1;
        private ReadWriteCommand cmS_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet.S_OS_STANJE_LOKACIJA_SVI_BROJEVIRow rowS_OS_STANJE_LOKACIJA_SVI_BROJEVI;
        private IDataReader S_OS_STANJE_LOKACIJA_SVI_BROJEVISelect1;
        private IDataReader S_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2;
        private S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet S_OS_STANJE_LOKACIJA_SVI_BROJEVISet;

        private void AddRowS_os_stanje_lokacija_svi_brojevi()
        {
            this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISet.S_OS_STANJE_LOKACIJA_SVI_BROJEVI.AddS_OS_STANJE_LOKACIJA_SVI_BROJEVIRow(this.rowS_OS_STANJE_LOKACIJA_SVI_BROJEVI);
            this.rowS_OS_STANJE_LOKACIJA_SVI_BROJEVI.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2 = this.connDefault.GetCommand("S_OS_STANJE_LOKACIJA_SVI_BROJEVI", true);
            this.cmS_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2.IDbCommand.Parameters.Clear();
            this.cmS_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2.ErrorMask |= ErrorMask.Lock;
            this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2 = this.cmS_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2.FetchData();
            while (this.cmS_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2.HasMoreRows = this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2.Read();
            }
            int num = 0;
            while (this.cmS_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OS_STANJE_LOKACIJA_SVI_BROJEVI["IDLOKACIJE"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2["IDLOKACIJE"]);
                this.rowS_OS_STANJE_LOKACIJA_SVI_BROJEVI["INVBROJ"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2["INVBROJ"]);
                this.rowS_OS_STANJE_LOKACIJA_SVI_BROJEVI["ULAZ"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2["ULAZ"]);
                this.rowS_OS_STANJE_LOKACIJA_SVI_BROJEVI["IZLAZ"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2["IZLAZ"]);
                this.rowS_OS_STANJE_LOKACIJA_SVI_BROJEVI["STANJE"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2["STANJE"]);
                this.rowS_OS_STANJE_LOKACIJA_SVI_BROJEVI["OPISLOKACIJE"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2["OPISLOKACIJE"]);
                this.rowS_OS_STANJE_LOKACIJA_SVI_BROJEVI["NAZIVOS"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2["NAZIVOS"]);
                this.AddRowS_os_stanje_lokacija_svi_brojevi();
                num++;
                this.rowS_OS_STANJE_LOKACIJA_SVI_BROJEVI = this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISet.S_OS_STANJE_LOKACIJA_SVI_BROJEVI.NewS_OS_STANJE_LOKACIJA_SVI_BROJEVIRow();
                this.cmS_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2.HasMoreRows = this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2.Read();
            }
            this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet dataSet)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISet = dataSet;
            this.rowS_OS_STANJE_LOKACIJA_SVI_BROJEVI = this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISet.S_OS_STANJE_LOKACIJA_SVI_BROJEVI.NewS_OS_STANJE_LOKACIJA_SVI_BROJEVIRow();
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
            this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISet = (S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet) dataSet;
            if (this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISet != null)
            {
                return this.Fill(this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISet);
            }
            this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISet = new S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet();
            this.Fill(this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISet);
            dataSet.Merge(this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISet);
            return 0;
        }

        public virtual int FillPage(S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet dataSet, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISet = dataSet;
            this.rowS_OS_STANJE_LOKACIJA_SVI_BROJEVI = this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISet.S_OS_STANJE_LOKACIJA_SVI_BROJEVI.NewS_OS_STANJE_LOKACIJA_SVI_BROJEVIRow();
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
            this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISet = (S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet) dataSet;
            if (this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISet != null)
            {
                return this.FillPage(this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISet, startRow, maxRows);
            }
            this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISet = new S_OS_STANJE_LOKACIJA_SVI_BROJEVIDataSet();
            this.FillPage(this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISet, startRow, maxRows);
            dataSet.Merge(this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISet);
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
            this.cmS_OS_STANJE_LOKACIJA_SVI_BROJEVISelect1 = this.connDefault.GetCommand("S_OS_STANJE_LOKACIJA_SVI_BROJEVI", true);
            this.cmS_OS_STANJE_LOKACIJA_SVI_BROJEVISelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OS_STANJE_LOKACIJA_SVI_BROJEVISelect1.IDbCommand.Parameters.Clear();
            this.cmS_OS_STANJE_LOKACIJA_SVI_BROJEVISelect1.ErrorMask |= ErrorMask.Lock;
            this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISelect1 = this.cmS_OS_STANJE_LOKACIJA_SVI_BROJEVISelect1.FetchData();
            if (this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISelect1.GetInt32(0);
            }
            this.S_OS_STANJE_LOKACIJA_SVI_BROJEVISelect1.Close();
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

