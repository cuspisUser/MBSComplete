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

    public class S_FIN_BLAGAJNA_U_GKDataAdapter : IDataAdapter, IS_FIN_BLAGAJNA_U_GKDataAdapter
    {
        private int AV10BLAG;
        private DateTime AV8DAT1;
        private DateTime AV9DAT2;
        private ReadWriteCommand cmS_FIN_BLAGAJNA_U_GKSelect1;
        private ReadWriteCommand cmS_FIN_BLAGAJNA_U_GKSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_FIN_BLAGAJNA_U_GKDataSet.S_FIN_BLAGAJNA_U_GKRow rowS_FIN_BLAGAJNA_U_GK;
        private IDataReader S_FIN_BLAGAJNA_U_GKSelect1;
        private IDataReader S_FIN_BLAGAJNA_U_GKSelect2;
        private S_FIN_BLAGAJNA_U_GKDataSet S_FIN_BLAGAJNA_U_GKSet;

        private void AddRowS_fin_blagajna_u_gk()
        {
            this.S_FIN_BLAGAJNA_U_GKSet.S_FIN_BLAGAJNA_U_GK.AddS_FIN_BLAGAJNA_U_GKRow(this.rowS_FIN_BLAGAJNA_U_GK);
            this.rowS_FIN_BLAGAJNA_U_GK.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_FIN_BLAGAJNA_U_GKSelect2 = this.connDefault.GetCommand("S_FIN_BLAGAJNA_U_GK", true);
            this.cmS_FIN_BLAGAJNA_U_GKSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_BLAGAJNA_U_GKSelect2.IDbCommand.Parameters.Clear();
            this.cmS_FIN_BLAGAJNA_U_GKSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DAT1", this.AV8DAT1));
            this.cmS_FIN_BLAGAJNA_U_GKSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DAT2", this.AV9DAT2));
            this.cmS_FIN_BLAGAJNA_U_GKSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLAG", this.AV10BLAG));
            this.cmS_FIN_BLAGAJNA_U_GKSelect2.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_BLAGAJNA_U_GKSelect2 = this.cmS_FIN_BLAGAJNA_U_GKSelect2.FetchData();
            while (this.cmS_FIN_BLAGAJNA_U_GKSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_FIN_BLAGAJNA_U_GKSelect2.HasMoreRows = this.S_FIN_BLAGAJNA_U_GKSelect2.Read();
            }
            int num = 0;
            while (this.cmS_FIN_BLAGAJNA_U_GKSelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_FIN_BLAGAJNA_U_GK["NAZIVVRSTEDOK"] = RuntimeHelpers.GetObjectValue(this.S_FIN_BLAGAJNA_U_GKSelect2["NAZIVVRSTEDOK"]);
                this.rowS_FIN_BLAGAJNA_U_GK["BLGDATUMDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_BLAGAJNA_U_GKSelect2["BLGDATUMDOKUMENTA"]);
                this.rowS_FIN_BLAGAJNA_U_GK["IDBLGVRSTEDOK"] = RuntimeHelpers.GetObjectValue(this.S_FIN_BLAGAJNA_U_GKSelect2["IDBLGVRSTEDOK"]);
                this.rowS_FIN_BLAGAJNA_U_GK["OPIS"] = RuntimeHelpers.GetObjectValue(this.S_FIN_BLAGAJNA_U_GKSelect2["OPIS"]);
                this.rowS_FIN_BLAGAJNA_U_GK["BLGSTAVKEBLAGAJNEKONTOIDKONTO"] = RuntimeHelpers.GetObjectValue(this.S_FIN_BLAGAJNA_U_GKSelect2["BLGSTAVKEBLAGAJNEKONTOIDKONTO"]);
                this.rowS_FIN_BLAGAJNA_U_GK["BLGMTIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_BLAGAJNA_U_GKSelect2["BLGMTIDMJESTOTROSKA"]);
                this.rowS_FIN_BLAGAJNA_U_GK["BLGORGJEDIDORGJED"] = RuntimeHelpers.GetObjectValue(this.S_FIN_BLAGAJNA_U_GKSelect2["BLGORGJEDIDORGJED"]);
                this.rowS_FIN_BLAGAJNA_U_GK["IZDATAK"] = RuntimeHelpers.GetObjectValue(this.S_FIN_BLAGAJNA_U_GKSelect2["IZDATAK"]);
                this.rowS_FIN_BLAGAJNA_U_GK["PRIMITAK"] = RuntimeHelpers.GetObjectValue(this.S_FIN_BLAGAJNA_U_GKSelect2["PRIMITAK"]);
                this.AddRowS_fin_blagajna_u_gk();
                num++;
                this.rowS_FIN_BLAGAJNA_U_GK = this.S_FIN_BLAGAJNA_U_GKSet.S_FIN_BLAGAJNA_U_GK.NewS_FIN_BLAGAJNA_U_GKRow();
                this.cmS_FIN_BLAGAJNA_U_GKSelect2.HasMoreRows = this.S_FIN_BLAGAJNA_U_GKSelect2.Read();
            }
            this.S_FIN_BLAGAJNA_U_GKSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_FIN_BLAGAJNA_U_GKDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, DateTime.Parse(this.fillDataParameters[0].Value.ToString()), DateTime.Parse(this.fillDataParameters[1].Value.ToString()), int.Parse(this.fillDataParameters[2].Value.ToString()));
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_FIN_BLAGAJNA_U_GKSet = (S_FIN_BLAGAJNA_U_GKDataSet) dataSet;
            if (this.S_FIN_BLAGAJNA_U_GKSet != null)
            {
                return this.Fill(this.S_FIN_BLAGAJNA_U_GKSet);
            }
            this.S_FIN_BLAGAJNA_U_GKSet = new S_FIN_BLAGAJNA_U_GKDataSet();
            this.Fill(this.S_FIN_BLAGAJNA_U_GKSet);
            dataSet.Merge(this.S_FIN_BLAGAJNA_U_GKSet);
            return 0;
        }

        public virtual int Fill(S_FIN_BLAGAJNA_U_GKDataSet dataSet, DateTime dAT1, DateTime dAT2, int bLAG)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_BLAGAJNA_U_GKSet = dataSet;
            this.rowS_FIN_BLAGAJNA_U_GK = this.S_FIN_BLAGAJNA_U_GKSet.S_FIN_BLAGAJNA_U_GK.NewS_FIN_BLAGAJNA_U_GKRow();
            this.SetFillParameters(dAT1, dAT2, bLAG);
            this.AV8DAT1 = DateTimeUtil.ResetTime(dAT1);
            this.AV9DAT2 = DateTimeUtil.ResetTime(dAT2);
            this.AV10BLAG = bLAG;
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

        public virtual int FillPage(S_FIN_BLAGAJNA_U_GKDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, DateTime.Parse(this.fillDataParameters[0].Value.ToString()), DateTime.Parse(this.fillDataParameters[1].Value.ToString()), int.Parse(this.fillDataParameters[2].Value.ToString()), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_FIN_BLAGAJNA_U_GKSet = (S_FIN_BLAGAJNA_U_GKDataSet) dataSet;
            if (this.S_FIN_BLAGAJNA_U_GKSet != null)
            {
                return this.FillPage(this.S_FIN_BLAGAJNA_U_GKSet, startRow, maxRows);
            }
            this.S_FIN_BLAGAJNA_U_GKSet = new S_FIN_BLAGAJNA_U_GKDataSet();
            this.FillPage(this.S_FIN_BLAGAJNA_U_GKSet, startRow, maxRows);
            dataSet.Merge(this.S_FIN_BLAGAJNA_U_GKSet);
            return 0;
        }

        public virtual int FillPage(S_FIN_BLAGAJNA_U_GKDataSet dataSet, DateTime dAT1, DateTime dAT2, int bLAG, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_BLAGAJNA_U_GKSet = dataSet;
            this.rowS_FIN_BLAGAJNA_U_GK = this.S_FIN_BLAGAJNA_U_GKSet.S_FIN_BLAGAJNA_U_GK.NewS_FIN_BLAGAJNA_U_GKRow();
            this.SetFillParameters(dAT1, dAT2, bLAG);
            this.AV8DAT1 = DateTimeUtil.ResetTime(dAT1);
            this.AV9DAT2 = DateTimeUtil.ResetTime(dAT2);
            this.AV10BLAG = bLAG;
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
                parameter.ParameterName = "DAT1";
                parameter.DbType = DbType.Date;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "DAT2";
                parameter2.DbType = DbType.Date;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "BLAG";
                parameter3.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(DateTime dAT1, DateTime dAT2, int bLAG)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_FIN_BLAGAJNA_U_GKSelect1 = this.connDefault.GetCommand("S_FIN_BLAGAJNA_U_GK", true);
            this.cmS_FIN_BLAGAJNA_U_GKSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_BLAGAJNA_U_GKSelect1.IDbCommand.Parameters.Clear();
            this.cmS_FIN_BLAGAJNA_U_GKSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DAT1", dAT1));
            this.cmS_FIN_BLAGAJNA_U_GKSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DAT2", dAT2));
            this.cmS_FIN_BLAGAJNA_U_GKSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BLAG", bLAG));
            this.cmS_FIN_BLAGAJNA_U_GKSelect1.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_BLAGAJNA_U_GKSelect1 = this.cmS_FIN_BLAGAJNA_U_GKSelect1.FetchData();
            if (this.S_FIN_BLAGAJNA_U_GKSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_FIN_BLAGAJNA_U_GKSelect1.GetInt32(0);
            }
            this.S_FIN_BLAGAJNA_U_GKSelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(DateTime dAT1, DateTime dAT2, int bLAG)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(dAT1, dAT2, bLAG);
                num2 = this.GetInternalRecordCount(dAT1, dAT2, bLAG);
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
            this.AV8DAT1 = DateTime.MinValue;
            this.AV9DAT2 = DateTime.MinValue;
            this.AV10BLAG = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(DateTime dAT1, DateTime dAT2, int bLAG)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = dAT1;
                this.fillDataParameters[1].Value = dAT2;
                this.fillDataParameters[2].Value = bLAG;
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

