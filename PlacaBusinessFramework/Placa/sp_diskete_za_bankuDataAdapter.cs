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

    public class sp_diskete_za_bankuDataAdapter : IDataAdapter, Isp_diskete_za_bankuDataAdapter
    {
        private string AV8idobrac;
        private string AV9vbdiban;
        private ReadWriteCommand cmsp_diskete_za_bankuSelect1;
        private ReadWriteCommand cmsp_diskete_za_bankuSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private sp_diskete_za_bankuDataSet.sp_diskete_za_bankuRow rowsp_diskete_za_banku;
        private IDataReader sp_diskete_za_bankuSelect1;
        private IDataReader sp_diskete_za_bankuSelect2;
        private sp_diskete_za_bankuDataSet sp_diskete_za_bankuSet;

        private void AddRowSp_diskete_za_banku()
        {
            this.sp_diskete_za_bankuSet.sp_diskete_za_banku.Addsp_diskete_za_bankuRow(this.rowsp_diskete_za_banku);
            this.rowsp_diskete_za_banku.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmsp_diskete_za_bankuSelect2 = this.connDefault.GetCommand("S_PLACA_ISPLATE_ZA_BANKU", true);
            this.cmsp_diskete_za_bankuSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_diskete_za_bankuSelect2.IDbCommand.Parameters.Clear();
            this.cmsp_diskete_za_bankuSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idobracun", this.AV8idobrac));
            this.cmsp_diskete_za_bankuSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@vbdibanke", this.AV9vbdiban));
            this.cmsp_diskete_za_bankuSelect2.ErrorMask |= ErrorMask.Lock;
            this.sp_diskete_za_bankuSelect2 = this.cmsp_diskete_za_bankuSelect2.FetchData();
            while (this.cmsp_diskete_za_bankuSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmsp_diskete_za_bankuSelect2.HasMoreRows = this.sp_diskete_za_bankuSelect2.Read();
            }
            int num = 0;
            while (this.cmsp_diskete_za_bankuSelect2.HasMoreRows && (num != maxRows))
            {
                this.rowsp_diskete_za_banku["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.sp_diskete_za_bankuSelect2["idradnik"]);
                this.rowsp_diskete_za_banku["PREZIME"] = RuntimeHelpers.GetObjectValue(this.sp_diskete_za_bankuSelect2["prezime"]);
                this.rowsp_diskete_za_banku["IME"] = RuntimeHelpers.GetObjectValue(this.sp_diskete_za_bankuSelect2["ime"]);
                this.rowsp_diskete_za_banku["JMBG"] = RuntimeHelpers.GetObjectValue(this.sp_diskete_za_bankuSelect2["jmbg"]);
                this.rowsp_diskete_za_banku["TEKUCI"] = RuntimeHelpers.GetObjectValue(this.sp_diskete_za_bankuSelect2["tekuci"]);
                this.rowsp_diskete_za_banku["SIFRAOPISAPLACANJANETO"] = RuntimeHelpers.GetObjectValue(this.sp_diskete_za_bankuSelect2["sifraopisaplacanjaneto"]);
                this.rowsp_diskete_za_banku["OPISPLACANJANETO"] = RuntimeHelpers.GetObjectValue(this.sp_diskete_za_bankuSelect2["opisplacanjaneto"]);
                this.rowsp_diskete_za_banku["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.sp_diskete_za_bankuSelect2["vbdibanke"]);
                this.rowsp_diskete_za_banku["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.sp_diskete_za_bankuSelect2["zrnbanke"]);
                this.rowsp_diskete_za_banku["UKUPNOZAISPLATU"] = RuntimeHelpers.GetObjectValue(this.sp_diskete_za_bankuSelect2["ukupnozaisplatu"]);
                this.rowsp_diskete_za_banku["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.sp_diskete_za_bankuSelect2["nazivbanke1"]);
                this.AddRowSp_diskete_za_banku();
                num++;
                this.rowsp_diskete_za_banku = this.sp_diskete_za_bankuSet.sp_diskete_za_banku.Newsp_diskete_za_bankuRow();
                this.cmsp_diskete_za_bankuSelect2.HasMoreRows = this.sp_diskete_za_bankuSelect2.Read();
            }
            this.sp_diskete_za_bankuSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(sp_diskete_za_bankuDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString());
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.sp_diskete_za_bankuSet = (sp_diskete_za_bankuDataSet) dataSet;
            if (this.sp_diskete_za_bankuSet != null)
            {
                return this.Fill(this.sp_diskete_za_bankuSet);
            }
            this.sp_diskete_za_bankuSet = new sp_diskete_za_bankuDataSet();
            this.Fill(this.sp_diskete_za_bankuSet);
            dataSet.Merge(this.sp_diskete_za_bankuSet);
            return 0;
        }

        public virtual int Fill(sp_diskete_za_bankuDataSet dataSet, string idobracun, string vbdibanke)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.sp_diskete_za_bankuSet = dataSet;
            this.rowsp_diskete_za_banku = this.sp_diskete_za_bankuSet.sp_diskete_za_banku.Newsp_diskete_za_bankuRow();
            this.SetFillParameters(idobracun, vbdibanke);
            this.AV8idobrac = idobracun;
            this.AV9vbdiban = vbdibanke;
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

        public virtual int FillPage(sp_diskete_za_bankuDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.sp_diskete_za_bankuSet = (sp_diskete_za_bankuDataSet) dataSet;
            if (this.sp_diskete_za_bankuSet != null)
            {
                return this.FillPage(this.sp_diskete_za_bankuSet, startRow, maxRows);
            }
            this.sp_diskete_za_bankuSet = new sp_diskete_za_bankuDataSet();
            this.FillPage(this.sp_diskete_za_bankuSet, startRow, maxRows);
            dataSet.Merge(this.sp_diskete_za_bankuSet);
            return 0;
        }

        public virtual int FillPage(sp_diskete_za_bankuDataSet dataSet, string idobracun, string vbdibanke, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.sp_diskete_za_bankuSet = dataSet;
            this.rowsp_diskete_za_banku = this.sp_diskete_za_bankuSet.sp_diskete_za_banku.Newsp_diskete_za_bankuRow();
            this.SetFillParameters(idobracun, vbdibanke);
            this.AV8idobrac = idobracun;
            this.AV9vbdiban = vbdibanke;
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
                parameter.ParameterName = "idobracun";
                parameter.DbType = DbType.String;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "vbdibanke";
                parameter2.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string idobracun, string vbdibanke)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmsp_diskete_za_bankuSelect1 = this.connDefault.GetCommand("S_PLACA_ISPLATE_ZA_BANKU", true);
            this.cmsp_diskete_za_bankuSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_diskete_za_bankuSelect1.IDbCommand.Parameters.Clear();
            this.cmsp_diskete_za_bankuSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idobracun", idobracun));
            this.cmsp_diskete_za_bankuSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@vbdibanke", vbdibanke));
            this.cmsp_diskete_za_bankuSelect1.ErrorMask |= ErrorMask.Lock;
            this.sp_diskete_za_bankuSelect1 = this.cmsp_diskete_za_bankuSelect1.FetchData();
            if (this.sp_diskete_za_bankuSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.sp_diskete_za_bankuSelect1.GetInt32(0);
            }
            this.sp_diskete_za_bankuSelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string idobracun, string vbdibanke)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(idobracun, vbdibanke);
                internalRecordCount = this.GetInternalRecordCount(idobracun, vbdibanke);
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
            this.AV9vbdiban = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string idobracun, string vbdibanke)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = idobracun;
                this.fillDataParameters[1].Value = vbdibanke;
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

