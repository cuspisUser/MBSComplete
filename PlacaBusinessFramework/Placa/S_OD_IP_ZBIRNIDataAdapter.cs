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

    public class S_OD_IP_ZBIRNIDataAdapter : IDataAdapter, IS_OD_IP_ZBIRNIDataAdapter
    {
        private string AV8GODINA;
        private ReadWriteCommand cmS_OD_IP_ZBIRNISelect1;
        private ReadWriteCommand cmS_OD_IP_ZBIRNISelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OD_IP_ZBIRNIDataSet.S_OD_IP_ZBIRNIRow rowS_OD_IP_ZBIRNI;
        private IDataReader S_OD_IP_ZBIRNISelect1;
        private IDataReader S_OD_IP_ZBIRNISelect2;
        private S_OD_IP_ZBIRNIDataSet S_OD_IP_ZBIRNISet;

        private void AddRowS_od_ip_zbirni()
        {
            this.S_OD_IP_ZBIRNISet.S_OD_IP_ZBIRNI.AddS_OD_IP_ZBIRNIRow(this.rowS_OD_IP_ZBIRNI);
            this.rowS_OD_IP_ZBIRNI.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OD_IP_ZBIRNISelect2 = this.connDefault.GetCommand("S_PLACA_IP_ZBIRNI", true);
            this.cmS_OD_IP_ZBIRNISelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_IP_ZBIRNISelect2.IDbCommand.Parameters.Clear();
            this.cmS_OD_IP_ZBIRNISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINA", this.AV8GODINA));
            this.cmS_OD_IP_ZBIRNISelect2.ErrorMask |= ErrorMask.Lock;
            this.S_OD_IP_ZBIRNISelect2 = this.cmS_OD_IP_ZBIRNISelect2.FetchData();
            while (this.cmS_OD_IP_ZBIRNISelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OD_IP_ZBIRNISelect2.HasMoreRows = this.S_OD_IP_ZBIRNISelect2.Read();
            }
            int num = 0;
            while (this.cmS_OD_IP_ZBIRNISelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OD_IP_ZBIRNI["ukupnobruto"] = RuntimeHelpers.GetObjectValue(this.S_OD_IP_ZBIRNISelect2["UKUPNOBRUTO"]);
                this.rowS_OD_IP_ZBIRNI["ukupnodoprinosi"] = RuntimeHelpers.GetObjectValue(this.S_OD_IP_ZBIRNISelect2["UKUPNODOPRINOSI"]);
                this.rowS_OD_IP_ZBIRNI["ukupnoolaksice"] = RuntimeHelpers.GetObjectValue(this.S_OD_IP_ZBIRNISelect2["UKUPNOOLAKSICE"]);
                this.rowS_OD_IP_ZBIRNI["dohodak"] = RuntimeHelpers.GetObjectValue(this.S_OD_IP_ZBIRNISelect2["DOHODAK"]);
                this.rowS_OD_IP_ZBIRNI["UKUPNOOO"] = RuntimeHelpers.GetObjectValue(this.S_OD_IP_ZBIRNISelect2["UKUPNOOO"]);
                this.rowS_OD_IP_ZBIRNI["poreznaosnovica"] = RuntimeHelpers.GetObjectValue(this.S_OD_IP_ZBIRNISelect2["POREZNAOSNOVICA"]);
                this.rowS_OD_IP_ZBIRNI["POREZPRIREZ"] = RuntimeHelpers.GetObjectValue(this.S_OD_IP_ZBIRNISelect2["POREZPRIREZ"]);
                this.rowS_OD_IP_ZBIRNI["netoisplata"] = RuntimeHelpers.GetObjectValue(this.S_OD_IP_ZBIRNISelect2["NETOISPLATA"]);
                this.rowS_OD_IP_ZBIRNI["netoplaca"] = RuntimeHelpers.GetObjectValue(this.S_OD_IP_ZBIRNISelect2["NETOPLACA"]);
                this.rowS_OD_IP_ZBIRNI["POREZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.S_OD_IP_ZBIRNISelect2["POREZKRIZNI"]);
                this.rowS_OD_IP_ZBIRNI["PREZIME"] = RuntimeHelpers.GetObjectValue(this.S_OD_IP_ZBIRNISelect2["PREZIME"]);
                this.rowS_OD_IP_ZBIRNI["IME"] = RuntimeHelpers.GetObjectValue(this.S_OD_IP_ZBIRNISelect2["IME"]);
                this.rowS_OD_IP_ZBIRNI["OIB"] = RuntimeHelpers.GetObjectValue(this.S_OD_IP_ZBIRNISelect2["OIB"]);
                this.AddRowS_od_ip_zbirni();
                num++;
                this.rowS_OD_IP_ZBIRNI = this.S_OD_IP_ZBIRNISet.S_OD_IP_ZBIRNI.NewS_OD_IP_ZBIRNIRow();
                this.cmS_OD_IP_ZBIRNISelect2.HasMoreRows = this.S_OD_IP_ZBIRNISelect2.Read();
            }
            this.S_OD_IP_ZBIRNISelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OD_IP_ZBIRNIDataSet dataSet)
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
            this.S_OD_IP_ZBIRNISet = (S_OD_IP_ZBIRNIDataSet) dataSet;
            if (this.S_OD_IP_ZBIRNISet != null)
            {
                return this.Fill(this.S_OD_IP_ZBIRNISet);
            }
            this.S_OD_IP_ZBIRNISet = new S_OD_IP_ZBIRNIDataSet();
            this.Fill(this.S_OD_IP_ZBIRNISet);
            dataSet.Merge(this.S_OD_IP_ZBIRNISet);
            return 0;
        }

        public virtual int Fill(S_OD_IP_ZBIRNIDataSet dataSet, string gODINA)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_IP_ZBIRNISet = dataSet;
            this.rowS_OD_IP_ZBIRNI = this.S_OD_IP_ZBIRNISet.S_OD_IP_ZBIRNI.NewS_OD_IP_ZBIRNIRow();
            this.SetFillParameters(gODINA);
            this.AV8GODINA = gODINA;
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

        public virtual int FillPage(S_OD_IP_ZBIRNIDataSet dataSet, int startRow, int maxRows)
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
            this.S_OD_IP_ZBIRNISet = (S_OD_IP_ZBIRNIDataSet) dataSet;
            if (this.S_OD_IP_ZBIRNISet != null)
            {
                return this.FillPage(this.S_OD_IP_ZBIRNISet, startRow, maxRows);
            }
            this.S_OD_IP_ZBIRNISet = new S_OD_IP_ZBIRNIDataSet();
            this.FillPage(this.S_OD_IP_ZBIRNISet, startRow, maxRows);
            dataSet.Merge(this.S_OD_IP_ZBIRNISet);
            return 0;
        }

        public virtual int FillPage(S_OD_IP_ZBIRNIDataSet dataSet, string gODINA, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_IP_ZBIRNISet = dataSet;
            this.rowS_OD_IP_ZBIRNI = this.S_OD_IP_ZBIRNISet.S_OD_IP_ZBIRNI.NewS_OD_IP_ZBIRNIRow();
            this.SetFillParameters(gODINA);
            this.AV8GODINA = gODINA;
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
                parameter.ParameterName = "GODINA";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string gODINA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_OD_IP_ZBIRNISelect1 = this.connDefault.GetCommand("S_PLACA_IP_ZBIRNI", true);
            this.cmS_OD_IP_ZBIRNISelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_IP_ZBIRNISelect1.IDbCommand.Parameters.Clear();
            this.cmS_OD_IP_ZBIRNISelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINA", gODINA));
            this.cmS_OD_IP_ZBIRNISelect1.ErrorMask |= ErrorMask.Lock;
            this.S_OD_IP_ZBIRNISelect1 = this.cmS_OD_IP_ZBIRNISelect1.FetchData();
            if (this.S_OD_IP_ZBIRNISelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OD_IP_ZBIRNISelect1.GetInt32(0);
            }
            this.S_OD_IP_ZBIRNISelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string gODINA)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(gODINA);
                internalRecordCount = this.GetInternalRecordCount(gODINA);
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
            this.AV8GODINA = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string gODINA)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = gODINA;
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

