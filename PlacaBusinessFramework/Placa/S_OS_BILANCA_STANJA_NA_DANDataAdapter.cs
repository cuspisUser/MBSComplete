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

    public class S_OS_BILANCA_STANJA_NA_DANDataAdapter : IDataAdapter, IS_OS_BILANCA_STANJA_NA_DANDataAdapter
    {
        private short AV10vrsta;
        private DateTime AV8DATUM;
        private string AV9SORT;
        private ReadWriteCommand cmS_OS_BILANCA_STANJA_NA_DANSelect1;
        private ReadWriteCommand cmS_OS_BILANCA_STANJA_NA_DANSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OS_BILANCA_STANJA_NA_DANDataSet.S_OS_BILANCA_STANJA_NA_DANRow rowS_OS_BILANCA_STANJA_NA_DAN;
        private IDataReader S_OS_BILANCA_STANJA_NA_DANSelect1;
        private IDataReader S_OS_BILANCA_STANJA_NA_DANSelect2;
        private S_OS_BILANCA_STANJA_NA_DANDataSet S_OS_BILANCA_STANJA_NA_DANSet;

        private void AddRowS_os_bilanca_stanja_na_dan()
        {
            this.S_OS_BILANCA_STANJA_NA_DANSet.S_OS_BILANCA_STANJA_NA_DAN.AddS_OS_BILANCA_STANJA_NA_DANRow(this.rowS_OS_BILANCA_STANJA_NA_DAN);
            this.rowS_OS_BILANCA_STANJA_NA_DAN.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OS_BILANCA_STANJA_NA_DANSelect2 = this.connDefault.GetCommand("S_OS_BILANCA_STANJA_NA_DAN", true);
            this.cmS_OS_BILANCA_STANJA_NA_DANSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OS_BILANCA_STANJA_NA_DANSelect2.IDbCommand.Parameters.Clear();
            this.cmS_OS_BILANCA_STANJA_NA_DANSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUM", this.AV8DATUM));
            this.cmS_OS_BILANCA_STANJA_NA_DANSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SORT", this.AV9SORT));
            this.cmS_OS_BILANCA_STANJA_NA_DANSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@vrsta", this.AV10vrsta));
            this.cmS_OS_BILANCA_STANJA_NA_DANSelect2.ErrorMask |= ErrorMask.Lock;
            this.S_OS_BILANCA_STANJA_NA_DANSelect2 = this.cmS_OS_BILANCA_STANJA_NA_DANSelect2.FetchData();
            while (this.cmS_OS_BILANCA_STANJA_NA_DANSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OS_BILANCA_STANJA_NA_DANSelect2.HasMoreRows = this.S_OS_BILANCA_STANJA_NA_DANSelect2.Read();
            }
            int num = 0;
            while (this.cmS_OS_BILANCA_STANJA_NA_DANSelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OS_BILANCA_STANJA_NA_DAN["NAZIVOS"] = RuntimeHelpers.GetObjectValue(this.S_OS_BILANCA_STANJA_NA_DANSelect2["NAZIVOS"]);
                this.rowS_OS_BILANCA_STANJA_NA_DAN["INVBROJ"] = RuntimeHelpers.GetObjectValue(this.S_OS_BILANCA_STANJA_NA_DANSelect2["INVBROJ"]);
                this.rowS_OS_BILANCA_STANJA_NA_DAN["KOLICINA"] = RuntimeHelpers.GetObjectValue(this.S_OS_BILANCA_STANJA_NA_DANSelect2["KOLICINA"]);
                this.rowS_OS_BILANCA_STANJA_NA_DAN["NABAVNA"] = RuntimeHelpers.GetObjectValue(this.S_OS_BILANCA_STANJA_NA_DANSelect2["NABAVNA"]);
                this.rowS_OS_BILANCA_STANJA_NA_DAN["ISPRAVAK"] = RuntimeHelpers.GetObjectValue(this.S_OS_BILANCA_STANJA_NA_DANSelect2["ISPRAVAK"]);
                this.rowS_OS_BILANCA_STANJA_NA_DAN["SADASNJA"] = RuntimeHelpers.GetObjectValue(this.S_OS_BILANCA_STANJA_NA_DANSelect2["SADASNJA"]);
                this.rowS_OS_BILANCA_STANJA_NA_DAN["KTOISPRAVKAIDKONTO"] = RuntimeHelpers.GetObjectValue(this.S_OS_BILANCA_STANJA_NA_DANSelect2["KTOISPRAVKAIDKONTO"]);
                this.rowS_OS_BILANCA_STANJA_NA_DAN["KTONABAVKEIDKONTO"] = RuntimeHelpers.GetObjectValue(this.S_OS_BILANCA_STANJA_NA_DANSelect2["KTONABAVKEIDKONTO"]);
                this.rowS_OS_BILANCA_STANJA_NA_DAN["KTOIZVORAIDKONTO"] = RuntimeHelpers.GetObjectValue(this.S_OS_BILANCA_STANJA_NA_DANSelect2["KTOIZVORAIDKONTO"]);
                this.AddRowS_os_bilanca_stanja_na_dan();
                num++;
                this.rowS_OS_BILANCA_STANJA_NA_DAN = this.S_OS_BILANCA_STANJA_NA_DANSet.S_OS_BILANCA_STANJA_NA_DAN.NewS_OS_BILANCA_STANJA_NA_DANRow();
                this.cmS_OS_BILANCA_STANJA_NA_DANSelect2.HasMoreRows = this.S_OS_BILANCA_STANJA_NA_DANSelect2.Read();
            }
            this.S_OS_BILANCA_STANJA_NA_DANSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OS_BILANCA_STANJA_NA_DANDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, DateTime.Parse(this.fillDataParameters[0].Value.ToString()), this.fillDataParameters[1].Value.ToString(), short.Parse(this.fillDataParameters[2].Value.ToString()));
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_OS_BILANCA_STANJA_NA_DANSet = (S_OS_BILANCA_STANJA_NA_DANDataSet) dataSet;
            if (this.S_OS_BILANCA_STANJA_NA_DANSet != null)
            {
                return this.Fill(this.S_OS_BILANCA_STANJA_NA_DANSet);
            }
            this.S_OS_BILANCA_STANJA_NA_DANSet = new S_OS_BILANCA_STANJA_NA_DANDataSet();
            this.Fill(this.S_OS_BILANCA_STANJA_NA_DANSet);
            dataSet.Merge(this.S_OS_BILANCA_STANJA_NA_DANSet);
            return 0;
        }

        public virtual int Fill(S_OS_BILANCA_STANJA_NA_DANDataSet dataSet, DateTime dATUM, string sORT, short vrsta)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OS_BILANCA_STANJA_NA_DANSet = dataSet;
            this.rowS_OS_BILANCA_STANJA_NA_DAN = this.S_OS_BILANCA_STANJA_NA_DANSet.S_OS_BILANCA_STANJA_NA_DAN.NewS_OS_BILANCA_STANJA_NA_DANRow();
            this.SetFillParameters(dATUM, sORT, vrsta);
            this.AV8DATUM = DateTimeUtil.ResetTime(dATUM);
            this.AV9SORT = sORT;
            this.AV10vrsta = vrsta;
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

        public virtual int FillPage(S_OS_BILANCA_STANJA_NA_DANDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, DateTime.Parse(this.fillDataParameters[0].Value.ToString()), this.fillDataParameters[1].Value.ToString(), short.Parse(this.fillDataParameters[2].Value.ToString()), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_OS_BILANCA_STANJA_NA_DANSet = (S_OS_BILANCA_STANJA_NA_DANDataSet) dataSet;
            if (this.S_OS_BILANCA_STANJA_NA_DANSet != null)
            {
                return this.FillPage(this.S_OS_BILANCA_STANJA_NA_DANSet, startRow, maxRows);
            }
            this.S_OS_BILANCA_STANJA_NA_DANSet = new S_OS_BILANCA_STANJA_NA_DANDataSet();
            this.FillPage(this.S_OS_BILANCA_STANJA_NA_DANSet, startRow, maxRows);
            dataSet.Merge(this.S_OS_BILANCA_STANJA_NA_DANSet);
            return 0;
        }

        public virtual int FillPage(S_OS_BILANCA_STANJA_NA_DANDataSet dataSet, DateTime dATUM, string sORT, short vrsta, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OS_BILANCA_STANJA_NA_DANSet = dataSet;
            this.rowS_OS_BILANCA_STANJA_NA_DAN = this.S_OS_BILANCA_STANJA_NA_DANSet.S_OS_BILANCA_STANJA_NA_DAN.NewS_OS_BILANCA_STANJA_NA_DANRow();
            this.SetFillParameters(dATUM, sORT, vrsta);
            this.AV8DATUM = DateTimeUtil.ResetTime(dATUM);
            this.AV9SORT = sORT;
            this.AV10vrsta = vrsta;
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
                parameter.ParameterName = "DATUM";
                parameter.DbType = DbType.Date;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "SORT";
                parameter2.DbType = DbType.String;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "vrsta";
                parameter3.DbType = DbType.Int16;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(DateTime dATUM, string sORT, short vrsta)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_OS_BILANCA_STANJA_NA_DANSelect1 = this.connDefault.GetCommand("S_OS_BILANCA_STANJA_NA_DAN", true);
            this.cmS_OS_BILANCA_STANJA_NA_DANSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OS_BILANCA_STANJA_NA_DANSelect1.IDbCommand.Parameters.Clear();
            this.cmS_OS_BILANCA_STANJA_NA_DANSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUM", dATUM));
            this.cmS_OS_BILANCA_STANJA_NA_DANSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SORT", sORT));
            this.cmS_OS_BILANCA_STANJA_NA_DANSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@vrsta", vrsta));
            this.cmS_OS_BILANCA_STANJA_NA_DANSelect1.ErrorMask |= ErrorMask.Lock;
            this.S_OS_BILANCA_STANJA_NA_DANSelect1 = this.cmS_OS_BILANCA_STANJA_NA_DANSelect1.FetchData();
            if (this.S_OS_BILANCA_STANJA_NA_DANSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OS_BILANCA_STANJA_NA_DANSelect1.GetInt32(0);
            }
            this.S_OS_BILANCA_STANJA_NA_DANSelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(DateTime dATUM, string sORT, short vrsta)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(dATUM, sORT, vrsta);
                num2 = this.GetInternalRecordCount(dATUM, sORT, vrsta);
            }
            finally
            {
                this.Cleanup();
            }
            return num2;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.AV8DATUM = DateTime.MinValue;
            this.AV9SORT = "";
            this.AV10vrsta = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(DateTime dATUM, string sORT, short vrsta)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = dATUM;
                this.fillDataParameters[1].Value = sORT;
                this.fillDataParameters[2].Value = vrsta;
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

