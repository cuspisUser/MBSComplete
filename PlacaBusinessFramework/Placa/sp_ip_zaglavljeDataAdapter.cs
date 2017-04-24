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

    public class sp_ip_zaglavljeDataAdapter : IDataAdapter, Isp_ip_zaglavljeDataAdapter
    {
        private string AV8godina;
        private ReadWriteCommand cmsp_ip_zaglavljeSelect1;
        private ReadWriteCommand cmsp_ip_zaglavljeSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private sp_ip_zaglavljeDataSet.sp_ip_zaglavljeRow rowsp_ip_zaglavlje;
        private IDataReader sp_ip_zaglavljeSelect1;
        private IDataReader sp_ip_zaglavljeSelect2;
        private sp_ip_zaglavljeDataSet sp_ip_zaglavljeSet;

        private void AddRowSp_ip_zaglavlje()
        {
            this.sp_ip_zaglavljeSet.sp_ip_zaglavlje.Addsp_ip_zaglavljeRow(this.rowsp_ip_zaglavlje);
            this.rowsp_ip_zaglavlje.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmsp_ip_zaglavljeSelect2 = this.connDefault.GetCommand("S_PLACA_IP", true);
            this.cmsp_ip_zaglavljeSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_ip_zaglavljeSelect2.IDbCommand.Parameters.Clear();
            this.cmsp_ip_zaglavljeSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godina", this.AV8godina));
            this.cmsp_ip_zaglavljeSelect2.ErrorMask |= ErrorMask.Lock;
            this.sp_ip_zaglavljeSelect2 = this.cmsp_ip_zaglavljeSelect2.FetchData();
            while (this.cmsp_ip_zaglavljeSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmsp_ip_zaglavljeSelect2.HasMoreRows = this.sp_ip_zaglavljeSelect2.Read();
            }
            int num = 0;
            while (this.cmsp_ip_zaglavljeSelect2.HasMoreRows && (num != maxRows))
            {
                this.rowsp_ip_zaglavlje["OZNACEN"] = RuntimeHelpers.GetObjectValue(this.sp_ip_zaglavljeSelect2["oznacen"]);
                this.rowsp_ip_zaglavlje["IDIPIDENT"] = RuntimeHelpers.GetObjectValue(this.sp_ip_zaglavljeSelect2["idipident"]);
                this.rowsp_ip_zaglavlje["JMBG"] = RuntimeHelpers.GetObjectValue(this.sp_ip_zaglavljeSelect2["jmbg"]);
                this.rowsp_ip_zaglavlje["PREZIME"] = RuntimeHelpers.GetObjectValue(this.sp_ip_zaglavljeSelect2["prezime"]);
                this.rowsp_ip_zaglavlje["IME"] = RuntimeHelpers.GetObjectValue(this.sp_ip_zaglavljeSelect2["ime"]);
                this.rowsp_ip_zaglavlje["ADRESA"] = RuntimeHelpers.GetObjectValue(this.sp_ip_zaglavljeSelect2["adresa"]);
                this.rowsp_ip_zaglavlje["isplataugodini"] = RuntimeHelpers.GetObjectValue(this.sp_ip_zaglavljeSelect2["isplataugodini"]);
                this.rowsp_ip_zaglavlje["isplatazagodinu"] = RuntimeHelpers.GetObjectValue(this.sp_ip_zaglavljeSelect2["isplatazagodinu"]);
                this.rowsp_ip_zaglavlje["OIB"] = RuntimeHelpers.GetObjectValue(this.sp_ip_zaglavljeSelect2["OIB"]);
                this.AddRowSp_ip_zaglavlje();
                num++;
                this.rowsp_ip_zaglavlje = this.sp_ip_zaglavljeSet.sp_ip_zaglavlje.Newsp_ip_zaglavljeRow();
                this.cmsp_ip_zaglavljeSelect2.HasMoreRows = this.sp_ip_zaglavljeSelect2.Read();
            }
            this.sp_ip_zaglavljeSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(sp_ip_zaglavljeDataSet dataSet)
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
            this.sp_ip_zaglavljeSet = (sp_ip_zaglavljeDataSet) dataSet;
            if (this.sp_ip_zaglavljeSet != null)
            {
                return this.Fill(this.sp_ip_zaglavljeSet);
            }
            this.sp_ip_zaglavljeSet = new sp_ip_zaglavljeDataSet();
            this.Fill(this.sp_ip_zaglavljeSet);
            dataSet.Merge(this.sp_ip_zaglavljeSet);
            return 0;
        }

        public virtual int Fill(sp_ip_zaglavljeDataSet dataSet, string godina)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.sp_ip_zaglavljeSet = dataSet;
            this.rowsp_ip_zaglavlje = this.sp_ip_zaglavljeSet.sp_ip_zaglavlje.Newsp_ip_zaglavljeRow();
            this.SetFillParameters(godina);
            this.AV8godina = godina;
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

        public virtual int FillPage(sp_ip_zaglavljeDataSet dataSet, int startRow, int maxRows)
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
            this.sp_ip_zaglavljeSet = (sp_ip_zaglavljeDataSet) dataSet;
            if (this.sp_ip_zaglavljeSet != null)
            {
                return this.FillPage(this.sp_ip_zaglavljeSet, startRow, maxRows);
            }
            this.sp_ip_zaglavljeSet = new sp_ip_zaglavljeDataSet();
            this.FillPage(this.sp_ip_zaglavljeSet, startRow, maxRows);
            dataSet.Merge(this.sp_ip_zaglavljeSet);
            return 0;
        }

        public virtual int FillPage(sp_ip_zaglavljeDataSet dataSet, string godina, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.sp_ip_zaglavljeSet = dataSet;
            this.rowsp_ip_zaglavlje = this.sp_ip_zaglavljeSet.sp_ip_zaglavlje.Newsp_ip_zaglavljeRow();
            this.SetFillParameters(godina);
            this.AV8godina = godina;
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
                parameter.ParameterName = "godina";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string godina)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmsp_ip_zaglavljeSelect1 = this.connDefault.GetCommand("S_PLACA_IP", true);
            this.cmsp_ip_zaglavljeSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_ip_zaglavljeSelect1.IDbCommand.Parameters.Clear();
            this.cmsp_ip_zaglavljeSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godina", godina));
            this.cmsp_ip_zaglavljeSelect1.ErrorMask |= ErrorMask.Lock;
            this.sp_ip_zaglavljeSelect1 = this.cmsp_ip_zaglavljeSelect1.FetchData();
            if (this.sp_ip_zaglavljeSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.sp_ip_zaglavljeSelect1.GetInt32(0);
            }
            this.sp_ip_zaglavljeSelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string godina)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(godina);
                internalRecordCount = this.GetInternalRecordCount(godina);
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
            this.AV8godina = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string godina)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = godina;
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

