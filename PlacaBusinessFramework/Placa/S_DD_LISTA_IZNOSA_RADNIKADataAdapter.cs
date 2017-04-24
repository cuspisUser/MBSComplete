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

    public class S_DD_LISTA_IZNOSA_RADNIKADataAdapter : IDataAdapter, IS_DD_LISTA_IZNOSA_RADNIKADataAdapter
    {
        private string AV8IDOBRAC;
        private int AV9SORT;
        private ReadWriteCommand cmS_DD_LISTA_IZNOSA_RADNIKASelect1;
        private ReadWriteCommand cmS_DD_LISTA_IZNOSA_RADNIKASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_DD_LISTA_IZNOSA_RADNIKADataSet.S_DD_LISTA_IZNOSA_RADNIKARow rowS_DD_LISTA_IZNOSA_RADNIKA;
        private IDataReader S_DD_LISTA_IZNOSA_RADNIKASelect1;
        private IDataReader S_DD_LISTA_IZNOSA_RADNIKASelect2;
        private S_DD_LISTA_IZNOSA_RADNIKADataSet S_DD_LISTA_IZNOSA_RADNIKASet;

        private void AddRowS_dd_lista_iznosa_radnika()
        {
            this.S_DD_LISTA_IZNOSA_RADNIKASet.S_DD_LISTA_IZNOSA_RADNIKA.AddS_DD_LISTA_IZNOSA_RADNIKARow(this.rowS_DD_LISTA_IZNOSA_RADNIKA);
            this.rowS_DD_LISTA_IZNOSA_RADNIKA.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_DD_LISTA_IZNOSA_RADNIKASelect2 = this.connDefault.GetCommand("S_DD_LISTA_IZNOSA_RADNIKA", true);
            this.cmS_DD_LISTA_IZNOSA_RADNIKASelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_DD_LISTA_IZNOSA_RADNIKASelect2.IDbCommand.Parameters.Clear();
            this.cmS_DD_LISTA_IZNOSA_RADNIKASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", this.AV8IDOBRAC));
            this.cmS_DD_LISTA_IZNOSA_RADNIKASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SORT", this.AV9SORT));
            this.cmS_DD_LISTA_IZNOSA_RADNIKASelect2.ErrorMask |= ErrorMask.Lock;
            this.S_DD_LISTA_IZNOSA_RADNIKASelect2 = this.cmS_DD_LISTA_IZNOSA_RADNIKASelect2.FetchData();
            while (this.cmS_DD_LISTA_IZNOSA_RADNIKASelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_DD_LISTA_IZNOSA_RADNIKASelect2.HasMoreRows = this.S_DD_LISTA_IZNOSA_RADNIKASelect2.Read();
            }
            int num = 0;
            while (this.cmS_DD_LISTA_IZNOSA_RADNIKASelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_DD_LISTA_IZNOSA_RADNIKA["DDIDRADNIK"] = RuntimeHelpers.GetObjectValue(this.S_DD_LISTA_IZNOSA_RADNIKASelect2["DDIDRADNIK"]);
                this.rowS_DD_LISTA_IZNOSA_RADNIKA["DDPREZIME"] = RuntimeHelpers.GetObjectValue(this.S_DD_LISTA_IZNOSA_RADNIKASelect2["DDPREZIME"]);
                this.rowS_DD_LISTA_IZNOSA_RADNIKA["DDIME"] = RuntimeHelpers.GetObjectValue(this.S_DD_LISTA_IZNOSA_RADNIKASelect2["DDIME"]);
                this.rowS_DD_LISTA_IZNOSA_RADNIKA["ukupnobruto"] = RuntimeHelpers.GetObjectValue(this.S_DD_LISTA_IZNOSA_RADNIKASelect2["UKUPNOBRUTO"]);
                this.rowS_DD_LISTA_IZNOSA_RADNIKA["ukupnodoprinosi"] = RuntimeHelpers.GetObjectValue(this.S_DD_LISTA_IZNOSA_RADNIKASelect2["UKUPNODOPRINOSI"]);
                this.rowS_DD_LISTA_IZNOSA_RADNIKA["UKUPNOPOREZ"] = RuntimeHelpers.GetObjectValue(this.S_DD_LISTA_IZNOSA_RADNIKASelect2["UKUPNOPOREZ"]);
                this.rowS_DD_LISTA_IZNOSA_RADNIKA["UKUPNOPRIREZ"] = RuntimeHelpers.GetObjectValue(this.S_DD_LISTA_IZNOSA_RADNIKASelect2["UKUPNOPRIREZ"]);
                this.rowS_DD_LISTA_IZNOSA_RADNIKA["ukupnoporeziprirez"] = RuntimeHelpers.GetObjectValue(this.S_DD_LISTA_IZNOSA_RADNIKASelect2["UKUPNOPOREZIPRIREZ"]);
                this.rowS_DD_LISTA_IZNOSA_RADNIKA["netoplaca"] = RuntimeHelpers.GetObjectValue(this.S_DD_LISTA_IZNOSA_RADNIKASelect2["NETOPLACA"]);
                this.rowS_DD_LISTA_IZNOSA_RADNIKA["UKUPNODOPRINOSINA"] = RuntimeHelpers.GetObjectValue(this.S_DD_LISTA_IZNOSA_RADNIKASelect2["UKUPNODOPRINOSINA"]);
                this.rowS_DD_LISTA_IZNOSA_RADNIKA["POREZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.S_DD_LISTA_IZNOSA_RADNIKASelect2["POREZKRIZNI"]);
                this.rowS_DD_LISTA_IZNOSA_RADNIKA["netoplacamanjekrizni"] = RuntimeHelpers.GetObjectValue(this.S_DD_LISTA_IZNOSA_RADNIKASelect2["NETOPLACAMANJEKRIZNI"]);
                this.rowS_DD_LISTA_IZNOSA_RADNIKA["NAZIVKATEGORIJA"] = RuntimeHelpers.GetObjectValue(this.S_DD_LISTA_IZNOSA_RADNIKASelect2["NAZIVKATEGORIJA"]);
                this.rowS_DD_LISTA_IZNOSA_RADNIKA["PDVDRUGIDOHODAK"] = RuntimeHelpers.GetObjectValue(this.S_DD_LISTA_IZNOSA_RADNIKASelect2["PDVDRUGIDOHODAK"]);
                this.rowS_DD_LISTA_IZNOSA_RADNIKA["ZAISPLATU"] = RuntimeHelpers.GetObjectValue(this.S_DD_LISTA_IZNOSA_RADNIKASelect2["ZAISPLATU"]);
                this.rowS_DD_LISTA_IZNOSA_RADNIKA["UKUPNOIZDACI"] = RuntimeHelpers.GetObjectValue(this.S_DD_LISTA_IZNOSA_RADNIKASelect2["UKUPNOIZDACI"]);
                this.AddRowS_dd_lista_iznosa_radnika();
                num++;
                this.rowS_DD_LISTA_IZNOSA_RADNIKA = this.S_DD_LISTA_IZNOSA_RADNIKASet.S_DD_LISTA_IZNOSA_RADNIKA.NewS_DD_LISTA_IZNOSA_RADNIKARow();
                this.cmS_DD_LISTA_IZNOSA_RADNIKASelect2.HasMoreRows = this.S_DD_LISTA_IZNOSA_RADNIKASelect2.Read();
            }
            this.S_DD_LISTA_IZNOSA_RADNIKASelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_DD_LISTA_IZNOSA_RADNIKADataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, this.fillDataParameters[0].Value.ToString(), int.Parse(this.fillDataParameters[1].Value.ToString()));
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_DD_LISTA_IZNOSA_RADNIKASet = (S_DD_LISTA_IZNOSA_RADNIKADataSet) dataSet;
            if (this.S_DD_LISTA_IZNOSA_RADNIKASet != null)
            {
                return this.Fill(this.S_DD_LISTA_IZNOSA_RADNIKASet);
            }
            this.S_DD_LISTA_IZNOSA_RADNIKASet = new S_DD_LISTA_IZNOSA_RADNIKADataSet();
            this.Fill(this.S_DD_LISTA_IZNOSA_RADNIKASet);
            dataSet.Merge(this.S_DD_LISTA_IZNOSA_RADNIKASet);
            return 0;
        }

        public virtual int Fill(S_DD_LISTA_IZNOSA_RADNIKADataSet dataSet, string iDOBRACUN, int sORT)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_DD_LISTA_IZNOSA_RADNIKASet = dataSet;
            this.rowS_DD_LISTA_IZNOSA_RADNIKA = this.S_DD_LISTA_IZNOSA_RADNIKASet.S_DD_LISTA_IZNOSA_RADNIKA.NewS_DD_LISTA_IZNOSA_RADNIKARow();
            this.SetFillParameters(iDOBRACUN, sORT);
            this.AV8IDOBRAC = iDOBRACUN;
            this.AV9SORT = sORT;
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

        public virtual int FillPage(S_DD_LISTA_IZNOSA_RADNIKADataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, this.fillDataParameters[0].Value.ToString(), int.Parse(this.fillDataParameters[1].Value.ToString()), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_DD_LISTA_IZNOSA_RADNIKASet = (S_DD_LISTA_IZNOSA_RADNIKADataSet) dataSet;
            if (this.S_DD_LISTA_IZNOSA_RADNIKASet != null)
            {
                return this.FillPage(this.S_DD_LISTA_IZNOSA_RADNIKASet, startRow, maxRows);
            }
            this.S_DD_LISTA_IZNOSA_RADNIKASet = new S_DD_LISTA_IZNOSA_RADNIKADataSet();
            this.FillPage(this.S_DD_LISTA_IZNOSA_RADNIKASet, startRow, maxRows);
            dataSet.Merge(this.S_DD_LISTA_IZNOSA_RADNIKASet);
            return 0;
        }

        public virtual int FillPage(S_DD_LISTA_IZNOSA_RADNIKADataSet dataSet, string iDOBRACUN, int sORT, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_DD_LISTA_IZNOSA_RADNIKASet = dataSet;
            this.rowS_DD_LISTA_IZNOSA_RADNIKA = this.S_DD_LISTA_IZNOSA_RADNIKASet.S_DD_LISTA_IZNOSA_RADNIKA.NewS_DD_LISTA_IZNOSA_RADNIKARow();
            this.SetFillParameters(iDOBRACUN, sORT);
            this.AV8IDOBRAC = iDOBRACUN;
            this.AV9SORT = sORT;
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
                parameter.ParameterName = "IDOBRACUN";
                parameter.DbType = DbType.String;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "SORT";
                parameter2.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string iDOBRACUN, int sORT)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_DD_LISTA_IZNOSA_RADNIKASelect1 = this.connDefault.GetCommand("S_DD_LISTA_IZNOSA_RADNIKA", true);
            this.cmS_DD_LISTA_IZNOSA_RADNIKASelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_DD_LISTA_IZNOSA_RADNIKASelect1.IDbCommand.Parameters.Clear();
            this.cmS_DD_LISTA_IZNOSA_RADNIKASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", iDOBRACUN));
            this.cmS_DD_LISTA_IZNOSA_RADNIKASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SORT", sORT));
            this.cmS_DD_LISTA_IZNOSA_RADNIKASelect1.ErrorMask |= ErrorMask.Lock;
            this.S_DD_LISTA_IZNOSA_RADNIKASelect1 = this.cmS_DD_LISTA_IZNOSA_RADNIKASelect1.FetchData();
            if (this.S_DD_LISTA_IZNOSA_RADNIKASelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_DD_LISTA_IZNOSA_RADNIKASelect1.GetInt32(0);
            }
            this.S_DD_LISTA_IZNOSA_RADNIKASelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string iDOBRACUN, int sORT)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(iDOBRACUN, sORT);
                internalRecordCount = this.GetInternalRecordCount(iDOBRACUN, sORT);
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
            this.AV8IDOBRAC = "";
            this.AV9SORT = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string iDOBRACUN, int sORT)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = iDOBRACUN;
                this.fillDataParameters[1].Value = sORT;
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

