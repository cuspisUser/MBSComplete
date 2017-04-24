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

    public class S_DD_IP1DataAdapter : IDataAdapter, IS_DD_IP1DataAdapter
    {
        private string AV8GODINAI;
        private ReadWriteCommand cmS_DD_IP1Select1;
        private ReadWriteCommand cmS_DD_IP1Select2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_DD_IP1DataSet.S_DD_IP1Row rowS_DD_IP1;
        private IDataReader S_DD_IP1Select1;
        private IDataReader S_DD_IP1Select2;
        private S_DD_IP1DataSet S_DD_IP1Set;

        private void AddRowS_dd_ip1()
        {
            this.S_DD_IP1Set.S_DD_IP1.AddS_DD_IP1Row(this.rowS_DD_IP1);
            this.rowS_DD_IP1.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_DD_IP1Select2 = this.connDefault.GetCommand("S_DD_IP1", true);
            this.cmS_DD_IP1Select2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_DD_IP1Select2.IDbCommand.Parameters.Clear();
            this.cmS_DD_IP1Select2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAISPLATE", this.AV8GODINAI));
            this.cmS_DD_IP1Select2.ErrorMask |= ErrorMask.Lock;
            this.S_DD_IP1Select2 = this.cmS_DD_IP1Select2.FetchData();
            while (this.cmS_DD_IP1Select2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_DD_IP1Select2.HasMoreRows = this.S_DD_IP1Select2.Read();
            }
            int num = 0;
            while (this.cmS_DD_IP1Select2.HasMoreRows && (num != maxRows))
            {
                this.rowS_DD_IP1["DDIDRADNIK"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["DDIDRADNIK"]);
                this.rowS_DD_IP1["DDPREZIME"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["DDPREZIME"]);
                this.rowS_DD_IP1["DDIME"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["DDIME"]);
                this.rowS_DD_IP1["BRUTO"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["BRUTO"]);
                this.rowS_DD_IP1["IZDACI"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["IZDACI"]);
                this.rowS_DD_IP1["DOPRINOSIIZ"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["DOPRINOSIIZ"]);
                this.rowS_DD_IP1["POREZIPRIREZ"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["POREZIPRIREZ"]);
                this.rowS_DD_IP1["NETO"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["NETO"]);
                this.rowS_DD_IP1["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["OPCINASTANOVANJAIDOPCINE"]);
                this.rowS_DD_IP1["P1422"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["P1422"]);
                this.rowS_DD_IP1["P1805"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["P1805"]);
                this.rowS_DD_IP1["P1457"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["P1457"]);
                this.rowS_DD_IP1["P1465"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["P1465"]);
                this.rowS_DD_IP1["P1473"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["P1473"]);
                this.rowS_DD_IP1["P1546"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["P1546"]);
                this.rowS_DD_IP1["P1570"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["P1570"]);
                this.rowS_DD_IP1["P1589"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["P1589"]);
                this.rowS_DD_IP1["P1597"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["P1597"]);
                this.rowS_DD_IP1["P1600"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["P1600"]);
                this.rowS_DD_IP1["P1813"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["P1813"]);
                this.rowS_DD_IP1["P1821"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["P1821"]);
                this.rowS_DD_IP1["P1830"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["P1830"]);
                this.rowS_DD_IP1["P1848"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["P1848"]);
                this.rowS_DD_IP1["DDJMBG"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["ddjmbg"]);
                this.rowS_DD_IP1["DDOIB"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["ddoib"]);
                this.rowS_DD_IP1["DDOZNACEN"] = RuntimeHelpers.GetObjectValue(this.S_DD_IP1Select2["DDOZNACEN"]);
                this.AddRowS_dd_ip1();
                num++;
                this.rowS_DD_IP1 = this.S_DD_IP1Set.S_DD_IP1.NewS_DD_IP1Row();
                this.cmS_DD_IP1Select2.HasMoreRows = this.S_DD_IP1Select2.Read();
            }
            this.S_DD_IP1Select2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_DD_IP1DataSet dataSet)
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
            this.S_DD_IP1Set = (S_DD_IP1DataSet) dataSet;
            if (this.S_DD_IP1Set != null)
            {
                return this.Fill(this.S_DD_IP1Set);
            }
            this.S_DD_IP1Set = new S_DD_IP1DataSet();
            this.Fill(this.S_DD_IP1Set);
            dataSet.Merge(this.S_DD_IP1Set);
            return 0;
        }

        public virtual int Fill(S_DD_IP1DataSet dataSet, string gODINAISPLATE)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_DD_IP1Set = dataSet;
            this.rowS_DD_IP1 = this.S_DD_IP1Set.S_DD_IP1.NewS_DD_IP1Row();
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

        public virtual int FillPage(S_DD_IP1DataSet dataSet, int startRow, int maxRows)
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
            this.S_DD_IP1Set = (S_DD_IP1DataSet) dataSet;
            if (this.S_DD_IP1Set != null)
            {
                return this.FillPage(this.S_DD_IP1Set, startRow, maxRows);
            }
            this.S_DD_IP1Set = new S_DD_IP1DataSet();
            this.FillPage(this.S_DD_IP1Set, startRow, maxRows);
            dataSet.Merge(this.S_DD_IP1Set);
            return 0;
        }

        public virtual int FillPage(S_DD_IP1DataSet dataSet, string gODINAISPLATE, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_DD_IP1Set = dataSet;
            this.rowS_DD_IP1 = this.S_DD_IP1Set.S_DD_IP1.NewS_DD_IP1Row();
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
            this.cmS_DD_IP1Select1 = this.connDefault.GetCommand("S_DD_IP1", true);
            this.cmS_DD_IP1Select1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_DD_IP1Select1.IDbCommand.Parameters.Clear();
            this.cmS_DD_IP1Select1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAISPLATE", gODINAISPLATE));
            this.cmS_DD_IP1Select1.ErrorMask |= ErrorMask.Lock;
            this.S_DD_IP1Select1 = this.cmS_DD_IP1Select1.FetchData();
            if (this.S_DD_IP1Select1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_DD_IP1Select1.GetInt32(0);
            }
            this.S_DD_IP1Select1.Close();
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

