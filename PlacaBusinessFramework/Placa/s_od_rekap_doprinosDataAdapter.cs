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

    public class s_od_rekap_doprinosDataAdapter : IDataAdapter, Is_od_rekap_doprinosDataAdapter
    {
        private string AV8idobrac;
        private ReadWriteCommand cms_od_rekap_doprinosSelect1;
        private ReadWriteCommand cms_od_rekap_doprinosSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private s_od_rekap_doprinosDataSet.s_od_rekap_doprinosRow rows_od_rekap_doprinos;
        private IDataReader s_od_rekap_doprinosSelect1;
        private IDataReader s_od_rekap_doprinosSelect2;
        private s_od_rekap_doprinosDataSet s_od_rekap_doprinosSet;

        private void AddRowS_od_rekap_doprinos()
        {
            this.s_od_rekap_doprinosSet.s_od_rekap_doprinos.Adds_od_rekap_doprinosRow(this.rows_od_rekap_doprinos);
            this.rows_od_rekap_doprinos.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cms_od_rekap_doprinosSelect2 = this.connDefault.GetCommand("S_PLACA_DOPRINOS", true);
            this.cms_od_rekap_doprinosSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cms_od_rekap_doprinosSelect2.IDbCommand.Parameters.Clear();
            this.cms_od_rekap_doprinosSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idobracun", this.AV8idobrac));
            this.cms_od_rekap_doprinosSelect2.ErrorMask |= ErrorMask.Lock;
            this.s_od_rekap_doprinosSelect2 = this.cms_od_rekap_doprinosSelect2.FetchData();
            while (this.cms_od_rekap_doprinosSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cms_od_rekap_doprinosSelect2.HasMoreRows = this.s_od_rekap_doprinosSelect2.Read();
            }
            int num = 0;
            while (this.cms_od_rekap_doprinosSelect2.HasMoreRows && (num != maxRows))
            {
                this.rows_od_rekap_doprinos["IZNOS"] = RuntimeHelpers.GetObjectValue(this.s_od_rekap_doprinosSelect2["iznos"]);
                this.rows_od_rekap_doprinos["SIFRA"] = RuntimeHelpers.GetObjectValue(this.s_od_rekap_doprinosSelect2["sifra"]);
                this.rows_od_rekap_doprinos["vrsta"] = RuntimeHelpers.GetObjectValue(this.s_od_rekap_doprinosSelect2["vrsta"]);
                this.rows_od_rekap_doprinos["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(this.s_od_rekap_doprinosSelect2["nazivdoprinos"]);
                this.rows_od_rekap_doprinos["vrstasifra"] = RuntimeHelpers.GetObjectValue(this.s_od_rekap_doprinosSelect2["vrstasifra"]);
                this.AddRowS_od_rekap_doprinos();
                num++;
                this.rows_od_rekap_doprinos = this.s_od_rekap_doprinosSet.s_od_rekap_doprinos.News_od_rekap_doprinosRow();
                this.cms_od_rekap_doprinosSelect2.HasMoreRows = this.s_od_rekap_doprinosSelect2.Read();
            }
            this.s_od_rekap_doprinosSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(s_od_rekap_doprinosDataSet dataSet)
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
            this.s_od_rekap_doprinosSet = (s_od_rekap_doprinosDataSet) dataSet;
            if (this.s_od_rekap_doprinosSet != null)
            {
                return this.Fill(this.s_od_rekap_doprinosSet);
            }
            this.s_od_rekap_doprinosSet = new s_od_rekap_doprinosDataSet();
            this.Fill(this.s_od_rekap_doprinosSet);
            dataSet.Merge(this.s_od_rekap_doprinosSet);
            return 0;
        }

        public virtual int Fill(s_od_rekap_doprinosDataSet dataSet, string idobracun)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.s_od_rekap_doprinosSet = dataSet;
            this.rows_od_rekap_doprinos = this.s_od_rekap_doprinosSet.s_od_rekap_doprinos.News_od_rekap_doprinosRow();
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

        public virtual int FillPage(s_od_rekap_doprinosDataSet dataSet, int startRow, int maxRows)
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
            this.s_od_rekap_doprinosSet = (s_od_rekap_doprinosDataSet) dataSet;
            if (this.s_od_rekap_doprinosSet != null)
            {
                return this.FillPage(this.s_od_rekap_doprinosSet, startRow, maxRows);
            }
            this.s_od_rekap_doprinosSet = new s_od_rekap_doprinosDataSet();
            this.FillPage(this.s_od_rekap_doprinosSet, startRow, maxRows);
            dataSet.Merge(this.s_od_rekap_doprinosSet);
            return 0;
        }

        public virtual int FillPage(s_od_rekap_doprinosDataSet dataSet, string idobracun, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.s_od_rekap_doprinosSet = dataSet;
            this.rows_od_rekap_doprinos = this.s_od_rekap_doprinosSet.s_od_rekap_doprinos.News_od_rekap_doprinosRow();
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
            this.cms_od_rekap_doprinosSelect1 = this.connDefault.GetCommand("S_PLACA_DOPRINOS", true);
            this.cms_od_rekap_doprinosSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cms_od_rekap_doprinosSelect1.IDbCommand.Parameters.Clear();
            this.cms_od_rekap_doprinosSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idobracun", idobracun));
            this.cms_od_rekap_doprinosSelect1.ErrorMask |= ErrorMask.Lock;
            this.s_od_rekap_doprinosSelect1 = this.cms_od_rekap_doprinosSelect1.FetchData();
            if (this.s_od_rekap_doprinosSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.s_od_rekap_doprinosSelect1.GetInt32(0);
            }
            this.s_od_rekap_doprinosSelect1.Close();
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

