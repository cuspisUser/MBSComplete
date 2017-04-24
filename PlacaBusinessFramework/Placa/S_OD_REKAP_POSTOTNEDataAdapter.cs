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

    public class S_OD_REKAP_POSTOTNEDataAdapter : IDataAdapter, IS_OD_REKAP_POSTOTNEDataAdapter
    {
        private string AV8IDOBRAC;
        private ReadWriteCommand cmS_OD_REKAP_POSTOTNESelect1;
        private ReadWriteCommand cmS_OD_REKAP_POSTOTNESelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OD_REKAP_POSTOTNEDataSet.S_OD_REKAP_POSTOTNERow rowS_OD_REKAP_POSTOTNE;
        private IDataReader S_OD_REKAP_POSTOTNESelect1;
        private IDataReader S_OD_REKAP_POSTOTNESelect2;
        private S_OD_REKAP_POSTOTNEDataSet S_OD_REKAP_POSTOTNESet;

        private void AddRowS_od_rekap_postotne()
        {
            this.S_OD_REKAP_POSTOTNESet.S_OD_REKAP_POSTOTNE.AddS_OD_REKAP_POSTOTNERow(this.rowS_OD_REKAP_POSTOTNE);
            this.rowS_OD_REKAP_POSTOTNE.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OD_REKAP_POSTOTNESelect2 = this.connDefault.GetCommand("S_PLACA_OBUSTAVE_POSTOTNE", true);
            this.cmS_OD_REKAP_POSTOTNESelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_REKAP_POSTOTNESelect2.IDbCommand.Parameters.Clear();
            this.cmS_OD_REKAP_POSTOTNESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", this.AV8IDOBRAC));
            this.cmS_OD_REKAP_POSTOTNESelect2.ErrorMask |= ErrorMask.Lock;
            this.S_OD_REKAP_POSTOTNESelect2 = this.cmS_OD_REKAP_POSTOTNESelect2.FetchData();
            while (this.cmS_OD_REKAP_POSTOTNESelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OD_REKAP_POSTOTNESelect2.HasMoreRows = this.S_OD_REKAP_POSTOTNESelect2.Read();
            }
            int num = 0;
            while (this.cmS_OD_REKAP_POSTOTNESelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OD_REKAP_POSTOTNE["OBRACUNATO"] = RuntimeHelpers.GetObjectValue(this.S_OD_REKAP_POSTOTNESelect2["OBRACUNATO"]);
                this.rowS_OD_REKAP_POSTOTNE["NAZIVOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.S_OD_REKAP_POSTOTNESelect2["NAZIVOBUSTAVA"]);
                this.rowS_OD_REKAP_POSTOTNE["IDOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.S_OD_REKAP_POSTOTNESelect2["IDOBUSTAVA"]);
                this.rowS_OD_REKAP_POSTOTNE["PRIMATELJOBUSTAVA1"] = RuntimeHelpers.GetObjectValue(this.S_OD_REKAP_POSTOTNESelect2["PRIMATELJOBUSTAVA1"]);
                this.rowS_OD_REKAP_POSTOTNE["PRIMATELJOBUSTAVA2"] = RuntimeHelpers.GetObjectValue(this.S_OD_REKAP_POSTOTNESelect2["PRIMATELJOBUSTAVA2"]);
                this.rowS_OD_REKAP_POSTOTNE["PREZIME"] = RuntimeHelpers.GetObjectValue(this.S_OD_REKAP_POSTOTNESelect2["PREZIME"]);
                this.rowS_OD_REKAP_POSTOTNE["IME"] = RuntimeHelpers.GetObjectValue(this.S_OD_REKAP_POSTOTNESelect2["IME"]);
                this.rowS_OD_REKAP_POSTOTNE["JMBG"] = RuntimeHelpers.GetObjectValue(this.S_OD_REKAP_POSTOTNESelect2["JMBG"]);
                this.rowS_OD_REKAP_POSTOTNE["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.S_OD_REKAP_POSTOTNESelect2["IDRADNIK"]);
                this.rowS_OD_REKAP_POSTOTNE["POSTOTAK"] = RuntimeHelpers.GetObjectValue(this.S_OD_REKAP_POSTOTNESelect2["POSTOTAK"]);
                this.AddRowS_od_rekap_postotne();
                num++;
                this.rowS_OD_REKAP_POSTOTNE = this.S_OD_REKAP_POSTOTNESet.S_OD_REKAP_POSTOTNE.NewS_OD_REKAP_POSTOTNERow();
                this.cmS_OD_REKAP_POSTOTNESelect2.HasMoreRows = this.S_OD_REKAP_POSTOTNESelect2.Read();
            }
            this.S_OD_REKAP_POSTOTNESelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OD_REKAP_POSTOTNEDataSet dataSet)
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
            this.S_OD_REKAP_POSTOTNESet = (S_OD_REKAP_POSTOTNEDataSet) dataSet;
            if (this.S_OD_REKAP_POSTOTNESet != null)
            {
                return this.Fill(this.S_OD_REKAP_POSTOTNESet);
            }
            this.S_OD_REKAP_POSTOTNESet = new S_OD_REKAP_POSTOTNEDataSet();
            this.Fill(this.S_OD_REKAP_POSTOTNESet);
            dataSet.Merge(this.S_OD_REKAP_POSTOTNESet);
            return 0;
        }

        public virtual int Fill(S_OD_REKAP_POSTOTNEDataSet dataSet, string iDOBRACUN)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_REKAP_POSTOTNESet = dataSet;
            this.rowS_OD_REKAP_POSTOTNE = this.S_OD_REKAP_POSTOTNESet.S_OD_REKAP_POSTOTNE.NewS_OD_REKAP_POSTOTNERow();
            this.SetFillParameters(iDOBRACUN);
            this.AV8IDOBRAC = iDOBRACUN;
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

        public virtual int FillPage(S_OD_REKAP_POSTOTNEDataSet dataSet, int startRow, int maxRows)
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
            this.S_OD_REKAP_POSTOTNESet = (S_OD_REKAP_POSTOTNEDataSet) dataSet;
            if (this.S_OD_REKAP_POSTOTNESet != null)
            {
                return this.FillPage(this.S_OD_REKAP_POSTOTNESet, startRow, maxRows);
            }
            this.S_OD_REKAP_POSTOTNESet = new S_OD_REKAP_POSTOTNEDataSet();
            this.FillPage(this.S_OD_REKAP_POSTOTNESet, startRow, maxRows);
            dataSet.Merge(this.S_OD_REKAP_POSTOTNESet);
            return 0;
        }

        public virtual int FillPage(S_OD_REKAP_POSTOTNEDataSet dataSet, string iDOBRACUN, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_REKAP_POSTOTNESet = dataSet;
            this.rowS_OD_REKAP_POSTOTNE = this.S_OD_REKAP_POSTOTNESet.S_OD_REKAP_POSTOTNE.NewS_OD_REKAP_POSTOTNERow();
            this.SetFillParameters(iDOBRACUN);
            this.AV8IDOBRAC = iDOBRACUN;
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
                parameter.ParameterName = "IDOBRACUN";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string iDOBRACUN)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_OD_REKAP_POSTOTNESelect1 = this.connDefault.GetCommand("S_PLACA_OBUSTAVE_POSTOTNE", true);
            this.cmS_OD_REKAP_POSTOTNESelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_REKAP_POSTOTNESelect1.IDbCommand.Parameters.Clear();
            this.cmS_OD_REKAP_POSTOTNESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", iDOBRACUN));
            this.cmS_OD_REKAP_POSTOTNESelect1.ErrorMask |= ErrorMask.Lock;
            this.S_OD_REKAP_POSTOTNESelect1 = this.cmS_OD_REKAP_POSTOTNESelect1.FetchData();
            if (this.S_OD_REKAP_POSTOTNESelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OD_REKAP_POSTOTNESelect1.GetInt32(0);
            }
            this.S_OD_REKAP_POSTOTNESelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string iDOBRACUN)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(iDOBRACUN);
                internalRecordCount = this.GetInternalRecordCount(iDOBRACUN);
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
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string iDOBRACUN)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = iDOBRACUN;
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

