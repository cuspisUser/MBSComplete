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

    public class S_PLACA_RAD1M_DIO2DataAdapter : IDataAdapter, IS_PLACA_RAD1M_DIO2DataAdapter
    {
        private string AV8MJESECI;
        private string AV9GODINAI;
        private ReadWriteCommand cmS_PLACA_RAD1M_DIO2Select1;
        private ReadWriteCommand cmS_PLACA_RAD1M_DIO2Select2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_PLACA_RAD1M_DIO2DataSet.S_PLACA_RAD1M_DIO2Row rowS_PLACA_RAD1M_DIO2;
        private IDataReader S_PLACA_RAD1M_DIO2Select1;
        private IDataReader S_PLACA_RAD1M_DIO2Select2;
        private S_PLACA_RAD1M_DIO2DataSet S_PLACA_RAD1M_DIO2Set;

        private void AddRowS_placa_rad1m_dio2()
        {
            this.S_PLACA_RAD1M_DIO2Set.S_PLACA_RAD1M_DIO2.AddS_PLACA_RAD1M_DIO2Row(this.rowS_PLACA_RAD1M_DIO2);
            this.rowS_PLACA_RAD1M_DIO2.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_PLACA_RAD1M_DIO2Select2 = this.connDefault.GetCommand("S_PLACA_RAD1M_DIO2", true);
            this.cmS_PLACA_RAD1M_DIO2Select2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_PLACA_RAD1M_DIO2Select2.IDbCommand.Parameters.Clear();
            this.cmS_PLACA_RAD1M_DIO2Select2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECISPLATE", this.AV8MJESECI));
            this.cmS_PLACA_RAD1M_DIO2Select2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAISPLATE", this.AV9GODINAI));
            this.cmS_PLACA_RAD1M_DIO2Select2.ErrorMask |= ErrorMask.Lock;
            this.S_PLACA_RAD1M_DIO2Select2 = this.cmS_PLACA_RAD1M_DIO2Select2.FetchData();
            while (this.cmS_PLACA_RAD1M_DIO2Select2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_PLACA_RAD1M_DIO2Select2.HasMoreRows = this.S_PLACA_RAD1M_DIO2Select2.Read();
            }
            int num = 0;
            while (this.cmS_PLACA_RAD1M_DIO2Select2.HasMoreRows && (num != maxRows))
            {
                this.rowS_PLACA_RAD1M_DIO2["BROJRADNIKANETOPOTPORE"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1M_DIO2Select2["BROJRADNIKANETOPOTPORE"]);
                this.rowS_PLACA_RAD1M_DIO2["BROJRADNIKANETO"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1M_DIO2Select2["BROJRADNIKANETO"]);
                this.rowS_PLACA_RAD1M_DIO2["NETO"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1M_DIO2Select2["NETO"]);
                this.rowS_PLACA_RAD1M_DIO2["BRUTO"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1M_DIO2Select2["BRUTO"]);
                this.rowS_PLACA_RAD1M_DIO2["satibruto"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1M_DIO2Select2["SATIBRUTO"]);
                this.rowS_PLACA_RAD1M_DIO2["NNETO"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1M_DIO2Select2["NNETO"]);
                this.rowS_PLACA_RAD1M_DIO2["NBRUTO"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1M_DIO2Select2["NBRUTO"]);
                this.rowS_PLACA_RAD1M_DIO2["vrsta"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1M_DIO2Select2["VRSTA"]);
                this.rowS_PLACA_RAD1M_DIO2["SVRHA"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1M_DIO2Select2["SVRHA"]);
                this.rowS_PLACA_RAD1M_DIO2["DATISP"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1M_DIO2Select2["DATISP"]);
                this.AddRowS_placa_rad1m_dio2();
                num++;
                this.rowS_PLACA_RAD1M_DIO2 = this.S_PLACA_RAD1M_DIO2Set.S_PLACA_RAD1M_DIO2.NewS_PLACA_RAD1M_DIO2Row();
                this.cmS_PLACA_RAD1M_DIO2Select2.HasMoreRows = this.S_PLACA_RAD1M_DIO2Select2.Read();
            }
            this.S_PLACA_RAD1M_DIO2Select2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_PLACA_RAD1M_DIO2DataSet dataSet)
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
            this.S_PLACA_RAD1M_DIO2Set = (S_PLACA_RAD1M_DIO2DataSet) dataSet;
            if (this.S_PLACA_RAD1M_DIO2Set != null)
            {
                return this.Fill(this.S_PLACA_RAD1M_DIO2Set);
            }
            this.S_PLACA_RAD1M_DIO2Set = new S_PLACA_RAD1M_DIO2DataSet();
            this.Fill(this.S_PLACA_RAD1M_DIO2Set);
            dataSet.Merge(this.S_PLACA_RAD1M_DIO2Set);
            return 0;
        }

        public virtual int Fill(S_PLACA_RAD1M_DIO2DataSet dataSet, string mJESECISPLATE, string gODINAISPLATE)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_PLACA_RAD1M_DIO2Set = dataSet;
            this.rowS_PLACA_RAD1M_DIO2 = this.S_PLACA_RAD1M_DIO2Set.S_PLACA_RAD1M_DIO2.NewS_PLACA_RAD1M_DIO2Row();
            this.SetFillParameters(mJESECISPLATE, gODINAISPLATE);
            this.AV8MJESECI = mJESECISPLATE;
            this.AV9GODINAI = gODINAISPLATE;
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

        public virtual int FillPage(S_PLACA_RAD1M_DIO2DataSet dataSet, int startRow, int maxRows)
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
            this.S_PLACA_RAD1M_DIO2Set = (S_PLACA_RAD1M_DIO2DataSet) dataSet;
            if (this.S_PLACA_RAD1M_DIO2Set != null)
            {
                return this.FillPage(this.S_PLACA_RAD1M_DIO2Set, startRow, maxRows);
            }
            this.S_PLACA_RAD1M_DIO2Set = new S_PLACA_RAD1M_DIO2DataSet();
            this.FillPage(this.S_PLACA_RAD1M_DIO2Set, startRow, maxRows);
            dataSet.Merge(this.S_PLACA_RAD1M_DIO2Set);
            return 0;
        }

        public virtual int FillPage(S_PLACA_RAD1M_DIO2DataSet dataSet, string mJESECISPLATE, string gODINAISPLATE, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_PLACA_RAD1M_DIO2Set = dataSet;
            this.rowS_PLACA_RAD1M_DIO2 = this.S_PLACA_RAD1M_DIO2Set.S_PLACA_RAD1M_DIO2.NewS_PLACA_RAD1M_DIO2Row();
            this.SetFillParameters(mJESECISPLATE, gODINAISPLATE);
            this.AV8MJESECI = mJESECISPLATE;
            this.AV9GODINAI = gODINAISPLATE;
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
                parameter.ParameterName = "MJESECISPLATE";
                parameter.DbType = DbType.String;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "GODINAISPLATE";
                parameter2.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string mJESECISPLATE, string gODINAISPLATE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_PLACA_RAD1M_DIO2Select1 = this.connDefault.GetCommand("S_PLACA_RAD1M_DIO2", true);
            this.cmS_PLACA_RAD1M_DIO2Select1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_PLACA_RAD1M_DIO2Select1.IDbCommand.Parameters.Clear();
            this.cmS_PLACA_RAD1M_DIO2Select1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECISPLATE", mJESECISPLATE));
            this.cmS_PLACA_RAD1M_DIO2Select1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAISPLATE", gODINAISPLATE));
            this.cmS_PLACA_RAD1M_DIO2Select1.ErrorMask |= ErrorMask.Lock;
            this.S_PLACA_RAD1M_DIO2Select1 = this.cmS_PLACA_RAD1M_DIO2Select1.FetchData();
            if (this.S_PLACA_RAD1M_DIO2Select1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_PLACA_RAD1M_DIO2Select1.GetInt32(0);
            }
            this.S_PLACA_RAD1M_DIO2Select1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string mJESECISPLATE, string gODINAISPLATE)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(mJESECISPLATE, gODINAISPLATE);
                internalRecordCount = this.GetInternalRecordCount(mJESECISPLATE, gODINAISPLATE);
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
            this.AV8MJESECI = "";
            this.AV9GODINAI = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string mJESECISPLATE, string gODINAISPLATE)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = mJESECISPLATE;
                this.fillDataParameters[1].Value = gODINAISPLATE;
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

