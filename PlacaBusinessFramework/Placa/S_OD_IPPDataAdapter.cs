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

    public class S_OD_IPPDataAdapter : IDataAdapter, IS_OD_IPPDataAdapter
    {
        private string AV8mjesec;
        private string AV9godina;
        private ReadWriteCommand cmS_OD_IPPSelect1;
        private ReadWriteCommand cmS_OD_IPPSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OD_IPPDataSet.S_OD_IPPRow rowS_OD_IPP;
        private IDataReader S_OD_IPPSelect1;
        private IDataReader S_OD_IPPSelect2;
        private S_OD_IPPDataSet S_OD_IPPSet;

        private void AddRowS_od_ipp()
        {
            this.S_OD_IPPSet.S_OD_IPP.AddS_OD_IPPRow(this.rowS_OD_IPP);
            this.rowS_OD_IPP.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OD_IPPSelect2 = this.connDefault.GetCommand("S_PLACA_IPP", true);
            this.cmS_OD_IPPSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_IPPSelect2.IDbCommand.Parameters.Clear();
            this.cmS_OD_IPPSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@mjesec", this.AV8mjesec));
            this.cmS_OD_IPPSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godina", this.AV9godina));
            this.cmS_OD_IPPSelect2.ErrorMask |= ErrorMask.Lock;
            this.S_OD_IPPSelect2 = this.cmS_OD_IPPSelect2.FetchData();
            while (this.cmS_OD_IPPSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OD_IPPSelect2.HasMoreRows = this.S_OD_IPPSelect2.Read();
            }
            int num = 0;
            while (this.cmS_OD_IPPSelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OD_IPP["OSNOVICAKRIZNOGPOREZA"] = RuntimeHelpers.GetObjectValue(this.S_OD_IPPSelect2["OSNOVICAKRIZNOGPOREZA"]);
                this.rowS_OD_IPP["KRIZNIPOREZ"] = RuntimeHelpers.GetObjectValue(this.S_OD_IPPSelect2["KRIZNIPOREZ"]);
                this.rowS_OD_IPP["BROJRADNIKA"] = RuntimeHelpers.GetObjectValue(this.S_OD_IPPSelect2["BROJRADNIKA"]);
                this.AddRowS_od_ipp();
                num++;
                this.rowS_OD_IPP = this.S_OD_IPPSet.S_OD_IPP.NewS_OD_IPPRow();
                this.cmS_OD_IPPSelect2.HasMoreRows = this.S_OD_IPPSelect2.Read();
            }
            this.S_OD_IPPSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OD_IPPDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString());
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_OD_IPPSet = (S_OD_IPPDataSet) dataSet;
            if (this.S_OD_IPPSet != null)
            {
                return this.Fill(this.S_OD_IPPSet);
            }
            this.S_OD_IPPSet = new S_OD_IPPDataSet();
            this.Fill(this.S_OD_IPPSet);
            dataSet.Merge(this.S_OD_IPPSet);
            return 0;
        }

        public virtual int Fill(S_OD_IPPDataSet dataSet, string mjesec, string godina)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_IPPSet = dataSet;
            this.rowS_OD_IPP = this.S_OD_IPPSet.S_OD_IPP.NewS_OD_IPPRow();
            this.SetFillParameters(mjesec, godina);
            this.AV8mjesec = mjesec;
            this.AV9godina = godina;
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

        public virtual int FillPage(S_OD_IPPDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_OD_IPPSet = (S_OD_IPPDataSet) dataSet;
            if (this.S_OD_IPPSet != null)
            {
                return this.FillPage(this.S_OD_IPPSet, startRow, maxRows);
            }
            this.S_OD_IPPSet = new S_OD_IPPDataSet();
            this.FillPage(this.S_OD_IPPSet, startRow, maxRows);
            dataSet.Merge(this.S_OD_IPPSet);
            return 0;
        }

        public virtual int FillPage(S_OD_IPPDataSet dataSet, string mjesec, string godina, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_IPPSet = dataSet;
            this.rowS_OD_IPP = this.S_OD_IPPSet.S_OD_IPP.NewS_OD_IPPRow();
            this.SetFillParameters(mjesec, godina);
            this.AV8mjesec = mjesec;
            this.AV9godina = godina;
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
                parameter.ParameterName = "mjesec";
                parameter.DbType = DbType.String;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "godina";
                parameter2.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string mjesec, string godina)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_OD_IPPSelect1 = this.connDefault.GetCommand("S_PLACA_IPP", true);
            this.cmS_OD_IPPSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_IPPSelect1.IDbCommand.Parameters.Clear();
            this.cmS_OD_IPPSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@mjesec", mjesec));
            this.cmS_OD_IPPSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godina", godina));
            this.cmS_OD_IPPSelect1.ErrorMask |= ErrorMask.Lock;
            this.S_OD_IPPSelect1 = this.cmS_OD_IPPSelect1.FetchData();
            if (this.S_OD_IPPSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OD_IPPSelect1.GetInt32(0);
            }
            this.S_OD_IPPSelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string mjesec, string godina)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(mjesec, godina);
                internalRecordCount = this.GetInternalRecordCount(mjesec, godina);
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
            this.AV8mjesec = "";
            this.AV9godina = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string mjesec, string godina)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = mjesec;
                this.fillDataParameters[1].Value = godina;
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

