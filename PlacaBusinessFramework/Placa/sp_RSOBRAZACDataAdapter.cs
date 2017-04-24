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

    public class sp_RSOBRAZACDataAdapter : IDataAdapter, Isp_RSOBRAZACDataAdapter
    {
        private string AV8IDOBRAC;
        private short AV9dd;
        private ReadWriteCommand cmsp_RSOBRAZACSelect1;
        private ReadWriteCommand cmsp_RSOBRAZACSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private sp_RSOBRAZACDataSet.sp_RSOBRAZACRow rowsp_RSOBRAZAC;
        private IDataReader sp_RSOBRAZACSelect1;
        private IDataReader sp_RSOBRAZACSelect2;
        private sp_RSOBRAZACDataSet sp_RSOBRAZACSet;

        private void AddRowSp_rsobrazac()
        {
            this.sp_RSOBRAZACSet.sp_RSOBRAZAC.Addsp_RSOBRAZACRow(this.rowsp_RSOBRAZAC);
            this.rowsp_RSOBRAZAC.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmsp_RSOBRAZACSelect2 = this.connDefault.GetCommand("S_RSM_OBRAZAC", true);
            this.cmsp_RSOBRAZACSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_RSOBRAZACSelect2.IDbCommand.Parameters.Clear();
            this.cmsp_RSOBRAZACSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", this.AV8IDOBRAC));
            this.cmsp_RSOBRAZACSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@dd", this.AV9dd));
            this.cmsp_RSOBRAZACSelect2.ErrorMask |= ErrorMask.Lock;
            this.sp_RSOBRAZACSelect2 = this.cmsp_RSOBRAZACSelect2.FetchData();
            while (this.cmsp_RSOBRAZACSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmsp_RSOBRAZACSelect2.HasMoreRows = this.sp_RSOBRAZACSelect2.Read();
            }
            int num = 0;
            while (this.cmsp_RSOBRAZACSelect2.HasMoreRows && (num != maxRows))
            {
                this.rowsp_RSOBRAZAC["REDNIBROJ"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["REDNIBROJ"]);
                this.rowsp_RSOBRAZAC["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["IDRADNIK"]);
                this.rowsp_RSOBRAZAC["PREZIMEIIME"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["PREZIMEIIME"]);
                this.rowsp_RSOBRAZAC["MBGOSIGURANIKA"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["MBGOSIGURANIKA"]);
                this.rowsp_RSOBRAZAC["SIFRAGRADARADA"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["SIFRAGRADARADA"]);
                this.rowsp_RSOBRAZAC["OO"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["OO"]);
                this.rowsp_RSOBRAZAC["B"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["B"]);
                this.rowsp_RSOBRAZAC["OD"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["OD"]);
                this.rowsp_RSOBRAZAC["DOO"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["DOO"]);
                this.rowsp_RSOBRAZAC["IZNOSOBRACUNANEPLACERSMB"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["IZNOSOBRACUNANEPLACERSMB"]);
                this.rowsp_RSOBRAZAC["IZNOSOSNOVICEZADOPRINOSERSMB"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["IZNOSOSNOVICEZADOPRINOSERSMB"]);
                this.rowsp_RSOBRAZAC["IDDOPRINOSMIO1"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["IDDOPRINOSMIO1"]);
                this.rowsp_RSOBRAZAC["STOPAMIO1"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["STOPAMIO1"]);
                this.rowsp_RSOBRAZAC["MIO1RSMB"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["MIO1RSMB"]);
                this.rowsp_RSOBRAZAC["IDDOPRINOSMIO2"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["IDDOPRINOSMIO2"]);
                this.rowsp_RSOBRAZAC["STOPAMIO2"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["STOPAMIO2"]);
                this.rowsp_RSOBRAZAC["MIO2RSMB"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["MIO2RSMB"]);
                this.rowsp_RSOBRAZAC["POREZIPRIREZ"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["POREZIPRIREZ"]);
                this.rowsp_RSOBRAZAC["IZNOSISPLACENEPLACERSMB"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["IZNOSISPLACENEPLACERSMB"]);
                this.rowsp_RSOBRAZAC["OIB"] = RuntimeHelpers.GetObjectValue(this.sp_RSOBRAZACSelect2["OIB"]);
                this.AddRowSp_rsobrazac();
                num++;
                this.rowsp_RSOBRAZAC = this.sp_RSOBRAZACSet.sp_RSOBRAZAC.Newsp_RSOBRAZACRow();
                this.cmsp_RSOBRAZACSelect2.HasMoreRows = this.sp_RSOBRAZACSelect2.Read();
            }
            this.sp_RSOBRAZACSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(sp_RSOBRAZACDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, this.fillDataParameters[0].Value.ToString(), short.Parse(this.fillDataParameters[1].Value.ToString()));
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.sp_RSOBRAZACSet = (sp_RSOBRAZACDataSet) dataSet;
            if (this.sp_RSOBRAZACSet != null)
            {
                return this.Fill(this.sp_RSOBRAZACSet);
            }
            this.sp_RSOBRAZACSet = new sp_RSOBRAZACDataSet();
            this.Fill(this.sp_RSOBRAZACSet);
            dataSet.Merge(this.sp_RSOBRAZACSet);
            return 0;
        }

        public virtual int Fill(sp_RSOBRAZACDataSet dataSet, string iDOBRACUN, short dd)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.sp_RSOBRAZACSet = dataSet;
            this.rowsp_RSOBRAZAC = this.sp_RSOBRAZACSet.sp_RSOBRAZAC.Newsp_RSOBRAZACRow();
            this.SetFillParameters(iDOBRACUN, dd);
            this.AV8IDOBRAC = iDOBRACUN;
            this.AV9dd = dd;
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

        public virtual int FillPage(sp_RSOBRAZACDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, this.fillDataParameters[0].Value.ToString(), short.Parse(this.fillDataParameters[1].Value.ToString()), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.sp_RSOBRAZACSet = (sp_RSOBRAZACDataSet) dataSet;
            if (this.sp_RSOBRAZACSet != null)
            {
                return this.FillPage(this.sp_RSOBRAZACSet, startRow, maxRows);
            }
            this.sp_RSOBRAZACSet = new sp_RSOBRAZACDataSet();
            this.FillPage(this.sp_RSOBRAZACSet, startRow, maxRows);
            dataSet.Merge(this.sp_RSOBRAZACSet);
            return 0;
        }

        public virtual int FillPage(sp_RSOBRAZACDataSet dataSet, string iDOBRACUN, short dd, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.sp_RSOBRAZACSet = dataSet;
            this.rowsp_RSOBRAZAC = this.sp_RSOBRAZACSet.sp_RSOBRAZAC.Newsp_RSOBRAZACRow();
            this.SetFillParameters(iDOBRACUN, dd);
            this.AV8IDOBRAC = iDOBRACUN;
            this.AV9dd = dd;
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
                parameter2.ParameterName = "dd";
                parameter2.DbType = DbType.Int16;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string iDOBRACUN, short dd)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmsp_RSOBRAZACSelect1 = this.connDefault.GetCommand("S_RSM_OBRAZAC", true);
            this.cmsp_RSOBRAZACSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_RSOBRAZACSelect1.IDbCommand.Parameters.Clear();
            this.cmsp_RSOBRAZACSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", iDOBRACUN));
            this.cmsp_RSOBRAZACSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@dd", dd));
            this.cmsp_RSOBRAZACSelect1.ErrorMask |= ErrorMask.Lock;
            this.sp_RSOBRAZACSelect1 = this.cmsp_RSOBRAZACSelect1.FetchData();
            if (this.sp_RSOBRAZACSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.sp_RSOBRAZACSelect1.GetInt32(0);
            }
            this.sp_RSOBRAZACSelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string iDOBRACUN, short dd)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(iDOBRACUN, dd);
                internalRecordCount = this.GetInternalRecordCount(iDOBRACUN, dd);
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
            this.AV9dd = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string iDOBRACUN, short dd)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = iDOBRACUN;
                this.fillDataParameters[1].Value = dd;
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

