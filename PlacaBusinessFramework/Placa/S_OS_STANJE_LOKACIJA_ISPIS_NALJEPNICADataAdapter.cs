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

    public class S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataAdapter : IDataAdapter, IS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataAdapter
    {
        private int AV8IDLOKAC;
        private ReadWriteCommand cmS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect1;
        private ReadWriteCommand cmS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataSet.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICARow rowS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA;
        private IDataReader S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect1;
        private IDataReader S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2;
        private S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataSet S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASet;

        private void AddRowS_os_stanje_lokacija_ispis_naljepnica()
        {
            this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASet.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.AddS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICARow(this.rowS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA);
            this.rowS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2 = this.connDefault.GetCommand("S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA", true);
            this.cmS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2.IDbCommand.Parameters.Clear();
            this.cmS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDLOKACIJE", this.AV8IDLOKAC));
            this.cmS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2.ErrorMask |= ErrorMask.Lock;
            this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2 = this.cmS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2.FetchData();
            while (this.cmS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2.HasMoreRows = this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2.Read();
            }
            int num = 0;
            while (this.cmS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA["IDLOKACIJE"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2["IDLOKACIJE"]);
                this.rowS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA["INVBROJ"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2["INVBROJ"]);
                this.rowS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA["ULAZ"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2["ULAZ"]);
                this.rowS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA["IZLAZ"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2["IZLAZ"]);
                this.rowS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA["STANJE"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2["STANJE"]);
                this.rowS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA["OPISLOKACIJE"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2["OPISLOKACIJE"]);
                this.rowS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA["NAZIVOS"] = RuntimeHelpers.GetObjectValue(this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2["NAZIVOS"]);
                this.AddRowS_os_stanje_lokacija_ispis_naljepnica();
                num++;
                this.rowS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA = this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASet.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.NewS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICARow();
                this.cmS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2.HasMoreRows = this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2.Read();
            }
            this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataSet dataSet)
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
            this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASet = (S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataSet) dataSet;
            if (this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASet != null)
            {
                return this.Fill(this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASet);
            }
            this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASet = new S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataSet();
            this.Fill(this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASet);
            dataSet.Merge(this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASet);
            return 0;
        }

        public virtual int Fill(S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataSet dataSet, int iDLOKACIJE)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASet = dataSet;
            this.rowS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA = this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASet.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.NewS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICARow();
            this.SetFillParameters(iDLOKACIJE);
            this.AV8IDLOKAC = iDLOKACIJE;
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

        public virtual int FillPage(S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataSet dataSet, int startRow, int maxRows)
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
            this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASet = (S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataSet) dataSet;
            if (this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASet != null)
            {
                return this.FillPage(this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASet, startRow, maxRows);
            }
            this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASet = new S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataSet();
            this.FillPage(this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASet, startRow, maxRows);
            dataSet.Merge(this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASet);
            return 0;
        }

        public virtual int FillPage(S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataSet dataSet, int iDLOKACIJE, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASet = dataSet;
            this.rowS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA = this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASet.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.NewS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICARow();
            this.SetFillParameters(iDLOKACIJE);
            this.AV8IDLOKAC = iDLOKACIJE;
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
                parameter.ParameterName = "IDLOKACIJE";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(int iDLOKACIJE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect1 = this.connDefault.GetCommand("S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA", true);
            this.cmS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect1.IDbCommand.Parameters.Clear();
            this.cmS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDLOKACIJE", iDLOKACIJE));
            this.cmS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect1.ErrorMask |= ErrorMask.Lock;
            this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect1 = this.cmS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect1.FetchData();
            if (this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect1.GetInt32(0);
            }
            this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICASelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(int iDLOKACIJE)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(iDLOKACIJE);
                internalRecordCount = this.GetInternalRecordCount(iDLOKACIJE);
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
            this.AV8IDLOKAC = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(int iDLOKACIJE)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = iDLOKACIJE;
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

