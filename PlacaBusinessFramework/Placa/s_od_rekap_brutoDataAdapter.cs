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

    public class s_od_rekap_brutoDataAdapter : IDataAdapter, Is_od_rekap_brutoDataAdapter
    {
        private string AV8idobrac;
        private ReadWriteCommand cms_od_rekap_brutoSelect1;
        private ReadWriteCommand cms_od_rekap_brutoSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private s_od_rekap_brutoDataSet.s_od_rekap_brutoRow rows_od_rekap_bruto;
        private IDataReader s_od_rekap_brutoSelect1;
        private IDataReader s_od_rekap_brutoSelect2;
        private s_od_rekap_brutoDataSet s_od_rekap_brutoSet;

        private void AddRowS_od_rekap_bruto()
        {
            this.s_od_rekap_brutoSet.s_od_rekap_bruto.Adds_od_rekap_brutoRow(this.rows_od_rekap_bruto);
            this.rows_od_rekap_bruto.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cms_od_rekap_brutoSelect2 = this.connDefault.GetCommand("S_PLACA_BRUTO", true);
            this.cms_od_rekap_brutoSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cms_od_rekap_brutoSelect2.IDbCommand.Parameters.Clear();
            this.cms_od_rekap_brutoSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idobracun", this.AV8idobrac));
            this.cms_od_rekap_brutoSelect2.ErrorMask |= ErrorMask.Lock;
            this.s_od_rekap_brutoSelect2 = this.cms_od_rekap_brutoSelect2.FetchData();
            while (this.cms_od_rekap_brutoSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cms_od_rekap_brutoSelect2.HasMoreRows = this.s_od_rekap_brutoSelect2.Read();
            }
            int num = 0;
            while (this.cms_od_rekap_brutoSelect2.HasMoreRows && (num != maxRows))
            {
                this.rows_od_rekap_bruto["sati"] = RuntimeHelpers.GetObjectValue(this.s_od_rekap_brutoSelect2["sati"]);
                this.rows_od_rekap_bruto["IZNOS"] = RuntimeHelpers.GetObjectValue(this.s_od_rekap_brutoSelect2["iznos"]);
                this.rows_od_rekap_bruto["PREZIME"] = RuntimeHelpers.GetObjectValue(this.s_od_rekap_brutoSelect2["prezime"]);
                this.rows_od_rekap_bruto["IME"] = RuntimeHelpers.GetObjectValue(this.s_od_rekap_brutoSelect2["ime"]);
                this.rows_od_rekap_bruto["JMBG"] = RuntimeHelpers.GetObjectValue(this.s_od_rekap_brutoSelect2["jmbg"]);
                this.rows_od_rekap_bruto["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.s_od_rekap_brutoSelect2["idradnik"]);
                this.rows_od_rekap_bruto["IDVRSTAELEMENTA"] = RuntimeHelpers.GetObjectValue(this.s_od_rekap_brutoSelect2["idvrstaelementa"]);
                this.rows_od_rekap_bruto["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.s_od_rekap_brutoSelect2["nazivelement"]);
                this.rows_od_rekap_bruto["NAZIVVRSTAELEMENT"] = RuntimeHelpers.GetObjectValue(this.s_od_rekap_brutoSelect2["nazivvrstaelement"]);
                this.AddRowS_od_rekap_bruto();
                num++;
                this.rows_od_rekap_bruto = this.s_od_rekap_brutoSet.s_od_rekap_bruto.News_od_rekap_brutoRow();
                this.cms_od_rekap_brutoSelect2.HasMoreRows = this.s_od_rekap_brutoSelect2.Read();
            }
            this.s_od_rekap_brutoSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(s_od_rekap_brutoDataSet dataSet)
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
            this.s_od_rekap_brutoSet = (s_od_rekap_brutoDataSet) dataSet;
            if (this.s_od_rekap_brutoSet != null)
            {
                return this.Fill(this.s_od_rekap_brutoSet);
            }
            this.s_od_rekap_brutoSet = new s_od_rekap_brutoDataSet();
            this.Fill(this.s_od_rekap_brutoSet);
            dataSet.Merge(this.s_od_rekap_brutoSet);
            return 0;
        }

        public virtual int Fill(s_od_rekap_brutoDataSet dataSet, string idobracun)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.s_od_rekap_brutoSet = dataSet;
            this.rows_od_rekap_bruto = this.s_od_rekap_brutoSet.s_od_rekap_bruto.News_od_rekap_brutoRow();
            this.SetFillParameters(idobracun);
            this.AV8idobrac = idobracun;
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

        public virtual int FillPage(s_od_rekap_brutoDataSet dataSet, int startRow, int maxRows)
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
            this.s_od_rekap_brutoSet = (s_od_rekap_brutoDataSet) dataSet;
            if (this.s_od_rekap_brutoSet != null)
            {
                return this.FillPage(this.s_od_rekap_brutoSet, startRow, maxRows);
            }
            this.s_od_rekap_brutoSet = new s_od_rekap_brutoDataSet();
            this.FillPage(this.s_od_rekap_brutoSet, startRow, maxRows);
            dataSet.Merge(this.s_od_rekap_brutoSet);
            return 0;
        }

        public virtual int FillPage(s_od_rekap_brutoDataSet dataSet, string idobracun, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.s_od_rekap_brutoSet = dataSet;
            this.rows_od_rekap_bruto = this.s_od_rekap_brutoSet.s_od_rekap_bruto.News_od_rekap_brutoRow();
            this.SetFillParameters(idobracun);
            this.AV8idobrac = idobracun;
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
                parameter.ParameterName = "idobracun";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string idobracun)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cms_od_rekap_brutoSelect1 = this.connDefault.GetCommand("S_PLACA_BRUTO", true);
            this.cms_od_rekap_brutoSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cms_od_rekap_brutoSelect1.IDbCommand.Parameters.Clear();
            this.cms_od_rekap_brutoSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idobracun", idobracun));
            this.cms_od_rekap_brutoSelect1.ErrorMask |= ErrorMask.Lock;
            this.s_od_rekap_brutoSelect1 = this.cms_od_rekap_brutoSelect1.FetchData();
            if (this.s_od_rekap_brutoSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.s_od_rekap_brutoSelect1.GetInt32(0);
            }
            this.s_od_rekap_brutoSelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string idobracun)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(idobracun);
                internalRecordCount = this.GetInternalRecordCount(idobracun);
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
            this.AV8idobrac = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string idobracun)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = idobracun;
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

