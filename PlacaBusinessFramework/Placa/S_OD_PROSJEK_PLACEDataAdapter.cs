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

    public class S_OD_PROSJEK_PLACEDataAdapter : IDataAdapter, IS_OD_PROSJEK_PLACEDataAdapter
    {
        private int AV10IDRADN;
        private string AV8ODD;
        private string AV9DOOO;
        private ReadWriteCommand cmS_OD_PROSJEK_PLACESelect1;
        private ReadWriteCommand cmS_OD_PROSJEK_PLACESelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OD_PROSJEK_PLACEDataSet.S_OD_PROSJEK_PLACERow rowS_OD_PROSJEK_PLACE;
        private IDataReader S_OD_PROSJEK_PLACESelect1;
        private IDataReader S_OD_PROSJEK_PLACESelect2;
        private S_OD_PROSJEK_PLACEDataSet S_OD_PROSJEK_PLACESet;

        private void AddRowS_od_prosjek_place()
        {
            this.S_OD_PROSJEK_PLACESet.S_OD_PROSJEK_PLACE.AddS_OD_PROSJEK_PLACERow(this.rowS_OD_PROSJEK_PLACE);
            this.rowS_OD_PROSJEK_PLACE.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OD_PROSJEK_PLACESelect2 = this.connDefault.GetCommand("S_PLACA_PROSJEK_PLACE", true);
            this.cmS_OD_PROSJEK_PLACESelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_PROSJEK_PLACESelect2.IDbCommand.Parameters.Clear();
            this.cmS_OD_PROSJEK_PLACESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODD", this.AV8ODD));
            this.cmS_OD_PROSJEK_PLACESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOOO", this.AV9DOOO));
            this.cmS_OD_PROSJEK_PLACESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", this.AV10IDRADN));
            this.cmS_OD_PROSJEK_PLACESelect2.ErrorMask |= ErrorMask.Lock;
            this.S_OD_PROSJEK_PLACESelect2 = this.cmS_OD_PROSJEK_PLACESelect2.FetchData();
            while (this.cmS_OD_PROSJEK_PLACESelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OD_PROSJEK_PLACESelect2.HasMoreRows = this.S_OD_PROSJEK_PLACESelect2.Read();
            }
            int num = 0;
            while (this.cmS_OD_PROSJEK_PLACESelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OD_PROSJEK_PLACE["netoplaca"] = RuntimeHelpers.GetObjectValue(this.S_OD_PROSJEK_PLACESelect2["netoplaca"]);
                this.rowS_OD_PROSJEK_PLACE["IME"] = RuntimeHelpers.GetObjectValue(this.S_OD_PROSJEK_PLACESelect2["IME"]);
                this.rowS_OD_PROSJEK_PLACE["PREZIME"] = RuntimeHelpers.GetObjectValue(this.S_OD_PROSJEK_PLACESelect2["PREZIME"]);
                this.rowS_OD_PROSJEK_PLACE["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.S_OD_PROSJEK_PLACESelect2["IDRADNIK"]);
                this.rowS_OD_PROSJEK_PLACE["ulica"] = RuntimeHelpers.GetObjectValue(this.S_OD_PROSJEK_PLACESelect2["ULICA"]);
                this.rowS_OD_PROSJEK_PLACE["kucnibroj"] = RuntimeHelpers.GetObjectValue(this.S_OD_PROSJEK_PLACESelect2["KUCNIBROJ"]);
                this.rowS_OD_PROSJEK_PLACE["mjesto"] = RuntimeHelpers.GetObjectValue(this.S_OD_PROSJEK_PLACESelect2["MJESTO"]);
                this.rowS_OD_PROSJEK_PLACE["GODINAMJESEC"] = RuntimeHelpers.GetObjectValue(this.S_OD_PROSJEK_PLACESelect2["GODINAMJESEC"]);
                this.AddRowS_od_prosjek_place();
                num++;
                this.rowS_OD_PROSJEK_PLACE = this.S_OD_PROSJEK_PLACESet.S_OD_PROSJEK_PLACE.NewS_OD_PROSJEK_PLACERow();
                this.cmS_OD_PROSJEK_PLACESelect2.HasMoreRows = this.S_OD_PROSJEK_PLACESelect2.Read();
            }
            this.S_OD_PROSJEK_PLACESelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OD_PROSJEK_PLACEDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), int.Parse(this.fillDataParameters[2].Value.ToString()));
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_OD_PROSJEK_PLACESet = (S_OD_PROSJEK_PLACEDataSet) dataSet;
            if (this.S_OD_PROSJEK_PLACESet != null)
            {
                return this.Fill(this.S_OD_PROSJEK_PLACESet);
            }
            this.S_OD_PROSJEK_PLACESet = new S_OD_PROSJEK_PLACEDataSet();
            this.Fill(this.S_OD_PROSJEK_PLACESet);
            dataSet.Merge(this.S_OD_PROSJEK_PLACESet);
            return 0;
        }

        public virtual int Fill(S_OD_PROSJEK_PLACEDataSet dataSet, string oDD, string dOOO, int iDRADNIK)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_PROSJEK_PLACESet = dataSet;
            this.rowS_OD_PROSJEK_PLACE = this.S_OD_PROSJEK_PLACESet.S_OD_PROSJEK_PLACE.NewS_OD_PROSJEK_PLACERow();
            this.SetFillParameters(oDD, dOOO, iDRADNIK);
            this.AV8ODD = oDD;
            this.AV9DOOO = dOOO;
            this.AV10IDRADN = iDRADNIK;
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

        public virtual int FillPage(S_OD_PROSJEK_PLACEDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), int.Parse(this.fillDataParameters[2].Value.ToString()), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_OD_PROSJEK_PLACESet = (S_OD_PROSJEK_PLACEDataSet) dataSet;
            if (this.S_OD_PROSJEK_PLACESet != null)
            {
                return this.FillPage(this.S_OD_PROSJEK_PLACESet, startRow, maxRows);
            }
            this.S_OD_PROSJEK_PLACESet = new S_OD_PROSJEK_PLACEDataSet();
            this.FillPage(this.S_OD_PROSJEK_PLACESet, startRow, maxRows);
            dataSet.Merge(this.S_OD_PROSJEK_PLACESet);
            return 0;
        }

        public virtual int FillPage(S_OD_PROSJEK_PLACEDataSet dataSet, string oDD, string dOOO, int iDRADNIK, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_PROSJEK_PLACESet = dataSet;
            this.rowS_OD_PROSJEK_PLACE = this.S_OD_PROSJEK_PLACESet.S_OD_PROSJEK_PLACE.NewS_OD_PROSJEK_PLACERow();
            this.SetFillParameters(oDD, dOOO, iDRADNIK);
            this.AV8ODD = oDD;
            this.AV9DOOO = dOOO;
            this.AV10IDRADN = iDRADNIK;
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
                parameter.ParameterName = "ODD";
                parameter.DbType = DbType.String;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "DOOO";
                parameter2.DbType = DbType.String;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "IDRADNIK";
                parameter3.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string oDD, string dOOO, int iDRADNIK)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_OD_PROSJEK_PLACESelect1 = this.connDefault.GetCommand("S_PLACA_PROSJEK_PLACE", true);
            this.cmS_OD_PROSJEK_PLACESelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_PROSJEK_PLACESelect1.IDbCommand.Parameters.Clear();
            this.cmS_OD_PROSJEK_PLACESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODD", oDD));
            this.cmS_OD_PROSJEK_PLACESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOOO", dOOO));
            this.cmS_OD_PROSJEK_PLACESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", iDRADNIK));
            this.cmS_OD_PROSJEK_PLACESelect1.ErrorMask |= ErrorMask.Lock;
            this.S_OD_PROSJEK_PLACESelect1 = this.cmS_OD_PROSJEK_PLACESelect1.FetchData();
            if (this.S_OD_PROSJEK_PLACESelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OD_PROSJEK_PLACESelect1.GetInt32(0);
            }
            this.S_OD_PROSJEK_PLACESelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string oDD, string dOOO, int iDRADNIK)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(oDD, dOOO, iDRADNIK);
                num2 = this.GetInternalRecordCount(oDD, dOOO, iDRADNIK);
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
            this.AV8ODD = "";
            this.AV9DOOO = "";
            this.AV10IDRADN = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string oDD, string dOOO, int iDRADNIK)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = oDD;
                this.fillDataParameters[1].Value = dOOO;
                this.fillDataParameters[2].Value = iDRADNIK;
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

