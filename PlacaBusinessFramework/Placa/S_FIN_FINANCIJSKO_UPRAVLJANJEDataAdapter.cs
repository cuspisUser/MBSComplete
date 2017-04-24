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

    public class S_FIN_FINANCIJSKO_UPRAVLJANJEDataAdapter : IDataAdapter, IS_FIN_FINANCIJSKO_UPRAVLJANJEDataAdapter
    {
        private DateTime AV8RAZDOBL;
        private DateTime AV9RAZDOBL;
        private ReadWriteCommand cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect1;
        private ReadWriteCommand cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet.S_FIN_FINANCIJSKO_UPRAVLJANJERow rowS_FIN_FINANCIJSKO_UPRAVLJANJE;
        private IDataReader S_FIN_FINANCIJSKO_UPRAVLJANJESelect1;
        private IDataReader S_FIN_FINANCIJSKO_UPRAVLJANJESelect2;
        private S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet S_FIN_FINANCIJSKO_UPRAVLJANJESet;

        private void AddRowS_fin_financijsko_upravljanje()
        {
            this.S_FIN_FINANCIJSKO_UPRAVLJANJESet.S_FIN_FINANCIJSKO_UPRAVLJANJE.AddS_FIN_FINANCIJSKO_UPRAVLJANJERow(this.rowS_FIN_FINANCIJSKO_UPRAVLJANJE);
            this.rowS_FIN_FINANCIJSKO_UPRAVLJANJE.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect2 = this.connDefault.GetCommand("S_FIN_FINANCIJSKO_UPRAVLJANJE", true);
            this.cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect2.IDbCommand.Parameters.Clear();
            this.cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEOD", this.AV8RAZDOBL));
            this.cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEDO", this.AV9RAZDOBL));
            this.cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect2.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_FINANCIJSKO_UPRAVLJANJESelect2 = this.cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect2.FetchData();
            while (this.cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect2.HasMoreRows = this.S_FIN_FINANCIJSKO_UPRAVLJANJESelect2.Read();
            }
            int num = 0;
            while (this.cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_FIN_FINANCIJSKO_UPRAVLJANJE["IDORGJED"] = RuntimeHelpers.GetObjectValue(this.S_FIN_FINANCIJSKO_UPRAVLJANJESelect2["IDORGJED"]);
                this.rowS_FIN_FINANCIJSKO_UPRAVLJANJE["NAZIVORGJED"] = RuntimeHelpers.GetObjectValue(this.S_FIN_FINANCIJSKO_UPRAVLJANJESelect2["NAZIVORGJED"]);
                this.rowS_FIN_FINANCIJSKO_UPRAVLJANJE["VISAK_ILI_MANJAK_PRETHODNIH"] = RuntimeHelpers.GetObjectValue(this.S_FIN_FINANCIJSKO_UPRAVLJANJESelect2["VISAK_ILI_MANJAK_PRETHODNIH"]);
                this.rowS_FIN_FINANCIJSKO_UPRAVLJANJE["PRIHODI"] = RuntimeHelpers.GetObjectValue(this.S_FIN_FINANCIJSKO_UPRAVLJANJESelect2["PRIHODI"]);
                this.rowS_FIN_FINANCIJSKO_UPRAVLJANJE["RASHODI"] = RuntimeHelpers.GetObjectValue(this.S_FIN_FINANCIJSKO_UPRAVLJANJESelect2["RASHODI"]);
                this.rowS_FIN_FINANCIJSKO_UPRAVLJANJE["VISAK_ILI_MANJAK_TEKUCE"] = RuntimeHelpers.GetObjectValue(this.S_FIN_FINANCIJSKO_UPRAVLJANJESelect2["VISAK_ILI_MANJAK_TEKUCE"]);
                this.rowS_FIN_FINANCIJSKO_UPRAVLJANJE["VISAK_ILI_MANJAK_UKUPNI"] = RuntimeHelpers.GetObjectValue(this.S_FIN_FINANCIJSKO_UPRAVLJANJESelect2["VISAK_ILI_MANJAK_UKUPNI"]);
                this.rowS_FIN_FINANCIJSKO_UPRAVLJANJE["NENAPLACENO"] = RuntimeHelpers.GetObjectValue(this.S_FIN_FINANCIJSKO_UPRAVLJANJESelect2["NENAPLACENO"]);
                this.rowS_FIN_FINANCIJSKO_UPRAVLJANJE["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_FINANCIJSKO_UPRAVLJANJESelect2["IDMJESTOTROSKA"]);
                this.rowS_FIN_FINANCIJSKO_UPRAVLJANJE["NAZIVMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_FINANCIJSKO_UPRAVLJANJESelect2["NAZIVMJESTOTROSKA"]);
                this.AddRowS_fin_financijsko_upravljanje();
                num++;
                this.rowS_FIN_FINANCIJSKO_UPRAVLJANJE = this.S_FIN_FINANCIJSKO_UPRAVLJANJESet.S_FIN_FINANCIJSKO_UPRAVLJANJE.NewS_FIN_FINANCIJSKO_UPRAVLJANJERow();
                this.cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect2.HasMoreRows = this.S_FIN_FINANCIJSKO_UPRAVLJANJESelect2.Read();
            }
            this.S_FIN_FINANCIJSKO_UPRAVLJANJESelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, DateTime.Parse(this.fillDataParameters[0].Value.ToString()), DateTime.Parse(this.fillDataParameters[1].Value.ToString()));
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_FIN_FINANCIJSKO_UPRAVLJANJESet = (S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet) dataSet;
            if (this.S_FIN_FINANCIJSKO_UPRAVLJANJESet != null)
            {
                return this.Fill(this.S_FIN_FINANCIJSKO_UPRAVLJANJESet);
            }
            this.S_FIN_FINANCIJSKO_UPRAVLJANJESet = new S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet();
            this.Fill(this.S_FIN_FINANCIJSKO_UPRAVLJANJESet);
            dataSet.Merge(this.S_FIN_FINANCIJSKO_UPRAVLJANJESet);
            return 0;
        }

        public virtual int Fill(S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet dataSet, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_FINANCIJSKO_UPRAVLJANJESet = dataSet;
            this.rowS_FIN_FINANCIJSKO_UPRAVLJANJE = this.S_FIN_FINANCIJSKO_UPRAVLJANJESet.S_FIN_FINANCIJSKO_UPRAVLJANJE.NewS_FIN_FINANCIJSKO_UPRAVLJANJERow();
            this.SetFillParameters(rAZDOBLJEOD, rAZDOBLJEDO);
            this.AV8RAZDOBL = DateTimeUtil.ResetTime(rAZDOBLJEOD);
            this.AV9RAZDOBL = DateTimeUtil.ResetTime(rAZDOBLJEDO);
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

        public virtual int FillPage(S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, DateTime.Parse(this.fillDataParameters[0].Value.ToString()), DateTime.Parse(this.fillDataParameters[1].Value.ToString()), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_FIN_FINANCIJSKO_UPRAVLJANJESet = (S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet) dataSet;
            if (this.S_FIN_FINANCIJSKO_UPRAVLJANJESet != null)
            {
                return this.FillPage(this.S_FIN_FINANCIJSKO_UPRAVLJANJESet, startRow, maxRows);
            }
            this.S_FIN_FINANCIJSKO_UPRAVLJANJESet = new S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet();
            this.FillPage(this.S_FIN_FINANCIJSKO_UPRAVLJANJESet, startRow, maxRows);
            dataSet.Merge(this.S_FIN_FINANCIJSKO_UPRAVLJANJESet);
            return 0;
        }

        public virtual int FillPage(S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet dataSet, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_FINANCIJSKO_UPRAVLJANJESet = dataSet;
            this.rowS_FIN_FINANCIJSKO_UPRAVLJANJE = this.S_FIN_FINANCIJSKO_UPRAVLJANJESet.S_FIN_FINANCIJSKO_UPRAVLJANJE.NewS_FIN_FINANCIJSKO_UPRAVLJANJERow();
            this.SetFillParameters(rAZDOBLJEOD, rAZDOBLJEDO);
            this.AV8RAZDOBL = DateTimeUtil.ResetTime(rAZDOBLJEOD);
            this.AV9RAZDOBL = DateTimeUtil.ResetTime(rAZDOBLJEDO);
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
                parameter.ParameterName = "RAZDOBLJEOD";
                parameter.DbType = DbType.Date;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "RAZDOBLJEDO";
                parameter2.DbType = DbType.Date;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect1 = this.connDefault.GetCommand("S_FIN_FINANCIJSKO_UPRAVLJANJE", true);
            this.cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect1.IDbCommand.Parameters.Clear();
            this.cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEOD", rAZDOBLJEOD));
            this.cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEDO", rAZDOBLJEDO));
            this.cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect1.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_FINANCIJSKO_UPRAVLJANJESelect1 = this.cmS_FIN_FINANCIJSKO_UPRAVLJANJESelect1.FetchData();
            if (this.S_FIN_FINANCIJSKO_UPRAVLJANJESelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_FIN_FINANCIJSKO_UPRAVLJANJESelect1.GetInt32(0);
            }
            this.S_FIN_FINANCIJSKO_UPRAVLJANJESelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(rAZDOBLJEOD, rAZDOBLJEDO);
                internalRecordCount = this.GetInternalRecordCount(rAZDOBLJEOD, rAZDOBLJEDO);
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
            this.AV8RAZDOBL = DateTime.MinValue;
            this.AV9RAZDOBL = DateTime.MinValue;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = rAZDOBLJEOD;
                this.fillDataParameters[1].Value = rAZDOBLJEDO;
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

