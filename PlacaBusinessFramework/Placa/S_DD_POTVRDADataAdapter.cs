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

    public class S_DD_POTVRDADataAdapter : IDataAdapter, IS_DD_POTVRDADataAdapter
    {
        private string AV8GODINAI;
        private ReadWriteCommand cmS_DD_POTVRDASelect1;
        private ReadWriteCommand cmS_DD_POTVRDASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_DD_POTVRDADataSet.S_DD_POTVRDARow rowS_DD_POTVRDA;
        private IDataReader S_DD_POTVRDASelect1;
        private IDataReader S_DD_POTVRDASelect2;
        private S_DD_POTVRDADataSet S_DD_POTVRDASet;

        private void AddRowS_dd_potvrda()
        {
            this.S_DD_POTVRDASet.S_DD_POTVRDA.AddS_DD_POTVRDARow(this.rowS_DD_POTVRDA);
            this.rowS_DD_POTVRDA.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_DD_POTVRDASelect2 = this.connDefault.GetCommand("S_DD_POTVRDA", true);
            this.cmS_DD_POTVRDASelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_DD_POTVRDASelect2.IDbCommand.Parameters.Clear();
            this.cmS_DD_POTVRDASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAISPLATE", this.AV8GODINAI));
            this.cmS_DD_POTVRDASelect2.ErrorMask |= ErrorMask.Lock;
            this.S_DD_POTVRDASelect2 = this.cmS_DD_POTVRDASelect2.FetchData();
            while (this.cmS_DD_POTVRDASelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_DD_POTVRDASelect2.HasMoreRows = this.S_DD_POTVRDASelect2.Read();
            }
            int num = 0;
            while (this.cmS_DD_POTVRDASelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_DD_POTVRDA["DDIDRADNIK"] = RuntimeHelpers.GetObjectValue(this.S_DD_POTVRDASelect2["DDIDRADNIK"]);
                this.rowS_DD_POTVRDA["DDPREZIME"] = RuntimeHelpers.GetObjectValue(this.S_DD_POTVRDASelect2["DDPREZIME"]);
                this.rowS_DD_POTVRDA["DDIME"] = RuntimeHelpers.GetObjectValue(this.S_DD_POTVRDASelect2["DDIME"]);
                this.rowS_DD_POTVRDA["BRUTO"] = RuntimeHelpers.GetObjectValue(this.S_DD_POTVRDASelect2["BRUTO"]);
                this.rowS_DD_POTVRDA["IZDACI"] = RuntimeHelpers.GetObjectValue(this.S_DD_POTVRDASelect2["IZDACI"]);
                this.rowS_DD_POTVRDA["DOPRINOSIIZ"] = RuntimeHelpers.GetObjectValue(this.S_DD_POTVRDASelect2["DOPRINOSIIZ"]);
                this.rowS_DD_POTVRDA["POREZIPRIREZ"] = RuntimeHelpers.GetObjectValue(this.S_DD_POTVRDASelect2["POREZIPRIREZ"]);
                this.rowS_DD_POTVRDA["NETO"] = RuntimeHelpers.GetObjectValue(this.S_DD_POTVRDASelect2["NETO"]);
                this.rowS_DD_POTVRDA["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.S_DD_POTVRDASelect2["OPCINASTANOVANJAIDOPCINE"]);
                this.rowS_DD_POTVRDA["DDDATUMOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.S_DD_POTVRDASelect2["DDDATUMOBRACUNA"]);
                this.rowS_DD_POTVRDA["NAZIVKATEGORIJA"] = RuntimeHelpers.GetObjectValue(this.S_DD_POTVRDASelect2["NAZIVKATEGORIJA"]);
                this.rowS_DD_POTVRDA["POSTOTAKIZDATKA"] = RuntimeHelpers.GetObjectValue(this.S_DD_POTVRDASelect2["POSTOTAKIZDATKA"]);
                this.rowS_DD_POTVRDA["ADRESA"] = RuntimeHelpers.GetObjectValue(this.S_DD_POTVRDASelect2["adresa"]);
                this.rowS_DD_POTVRDA["DDOIB"] = RuntimeHelpers.GetObjectValue(this.S_DD_POTVRDASelect2["ddoib"]);
                this.rowS_DD_POTVRDA["DDJMBG"] = RuntimeHelpers.GetObjectValue(this.S_DD_POTVRDASelect2["ddjmbg"]);
                this.rowS_DD_POTVRDA["POREZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.S_DD_POTVRDASelect2["POREZKRIZNI"]);
                this.AddRowS_dd_potvrda();
                num++;
                this.rowS_DD_POTVRDA = this.S_DD_POTVRDASet.S_DD_POTVRDA.NewS_DD_POTVRDARow();
                this.cmS_DD_POTVRDASelect2.HasMoreRows = this.S_DD_POTVRDASelect2.Read();
            }
            this.S_DD_POTVRDASelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_DD_POTVRDADataSet dataSet)
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
            this.S_DD_POTVRDASet = (S_DD_POTVRDADataSet) dataSet;
            if (this.S_DD_POTVRDASet != null)
            {
                return this.Fill(this.S_DD_POTVRDASet);
            }
            this.S_DD_POTVRDASet = new S_DD_POTVRDADataSet();
            this.Fill(this.S_DD_POTVRDASet);
            dataSet.Merge(this.S_DD_POTVRDASet);
            return 0;
        }

        public virtual int Fill(S_DD_POTVRDADataSet dataSet, string gODINAISPLATE)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_DD_POTVRDASet = dataSet;
            this.rowS_DD_POTVRDA = this.S_DD_POTVRDASet.S_DD_POTVRDA.NewS_DD_POTVRDARow();
            this.SetFillParameters(gODINAISPLATE);
            this.AV8GODINAI = gODINAISPLATE;
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

        public virtual int FillPage(S_DD_POTVRDADataSet dataSet, int startRow, int maxRows)
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
            this.S_DD_POTVRDASet = (S_DD_POTVRDADataSet) dataSet;
            if (this.S_DD_POTVRDASet != null)
            {
                return this.FillPage(this.S_DD_POTVRDASet, startRow, maxRows);
            }
            this.S_DD_POTVRDASet = new S_DD_POTVRDADataSet();
            this.FillPage(this.S_DD_POTVRDASet, startRow, maxRows);
            dataSet.Merge(this.S_DD_POTVRDASet);
            return 0;
        }

        public virtual int FillPage(S_DD_POTVRDADataSet dataSet, string gODINAISPLATE, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_DD_POTVRDASet = dataSet;
            this.rowS_DD_POTVRDA = this.S_DD_POTVRDASet.S_DD_POTVRDA.NewS_DD_POTVRDARow();
            this.SetFillParameters(gODINAISPLATE);
            this.AV8GODINAI = gODINAISPLATE;
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
                parameter.ParameterName = "GODINAISPLATE";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string gODINAISPLATE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_DD_POTVRDASelect1 = this.connDefault.GetCommand("S_DD_POTVRDA", true);
            this.cmS_DD_POTVRDASelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_DD_POTVRDASelect1.IDbCommand.Parameters.Clear();
            this.cmS_DD_POTVRDASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAISPLATE", gODINAISPLATE));
            this.cmS_DD_POTVRDASelect1.ErrorMask |= ErrorMask.Lock;
            this.S_DD_POTVRDASelect1 = this.cmS_DD_POTVRDASelect1.FetchData();
            if (this.S_DD_POTVRDASelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_DD_POTVRDASelect1.GetInt32(0);
            }
            this.S_DD_POTVRDASelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string gODINAISPLATE)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(gODINAISPLATE);
                internalRecordCount = this.GetInternalRecordCount(gODINAISPLATE);
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
            this.AV8GODINAI = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string gODINAISPLATE)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = gODINAISPLATE;
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

