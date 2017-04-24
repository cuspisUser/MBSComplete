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

    public class S_FIN_DNEVNIKBLAGAJNEDataAdapter : IDataAdapter, IS_FIN_DNEVNIKBLAGAJNEDataAdapter
    {
        private int AV10blag;
        private DateTime AV8dat1;
        private DateTime AV9dat2;
        private ReadWriteCommand cmS_FIN_DNEVNIKBLAGAJNESelect1;
        private ReadWriteCommand cmS_FIN_DNEVNIKBLAGAJNESelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_FIN_DNEVNIKBLAGAJNEDataSet.S_FIN_DNEVNIKBLAGAJNERow rowS_FIN_DNEVNIKBLAGAJNE;
        private IDataReader S_FIN_DNEVNIKBLAGAJNESelect1;
        private IDataReader S_FIN_DNEVNIKBLAGAJNESelect2;
        private S_FIN_DNEVNIKBLAGAJNEDataSet S_FIN_DNEVNIKBLAGAJNESet;

        private void AddRowS_fin_dnevnikblagajne()
        {
            this.S_FIN_DNEVNIKBLAGAJNESet.S_FIN_DNEVNIKBLAGAJNE.AddS_FIN_DNEVNIKBLAGAJNERow(this.rowS_FIN_DNEVNIKBLAGAJNE);
            this.rowS_FIN_DNEVNIKBLAGAJNE.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_FIN_DNEVNIKBLAGAJNESelect2 = this.connDefault.GetCommand("S_FIN_DNEVNIKBLAGAJNE", true);
            this.cmS_FIN_DNEVNIKBLAGAJNESelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_DNEVNIKBLAGAJNESelect2.IDbCommand.Parameters.Clear();
            this.cmS_FIN_DNEVNIKBLAGAJNESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@dat1", this.AV8dat1));
            this.cmS_FIN_DNEVNIKBLAGAJNESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@dat2", this.AV9dat2));
            this.cmS_FIN_DNEVNIKBLAGAJNESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@blag", this.AV10blag));
            this.cmS_FIN_DNEVNIKBLAGAJNESelect2.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_DNEVNIKBLAGAJNESelect2 = this.cmS_FIN_DNEVNIKBLAGAJNESelect2.FetchData();
            while (this.cmS_FIN_DNEVNIKBLAGAJNESelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_FIN_DNEVNIKBLAGAJNESelect2.HasMoreRows = this.S_FIN_DNEVNIKBLAGAJNESelect2.Read();
            }
            int num = 0;
            while (this.cmS_FIN_DNEVNIKBLAGAJNESelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_FIN_DNEVNIKBLAGAJNE["NAZIVVRSTEDOK"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKBLAGAJNESelect2["NAZIVVRSTEDOK"]);
                this.rowS_FIN_DNEVNIKBLAGAJNE["BLGDATUMDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKBLAGAJNESelect2["BLGDATUMDOKUMENTA"]);
                this.rowS_FIN_DNEVNIKBLAGAJNE["BLGBROJDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKBLAGAJNESelect2["BLGBROJDOKUMENTA"]);
                this.rowS_FIN_DNEVNIKBLAGAJNE["IDBLGVRSTEDOK"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKBLAGAJNESelect2["IDBLGVRSTEDOK"]);
                this.rowS_FIN_DNEVNIKBLAGAJNE["BLGSVRHA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKBLAGAJNESelect2["BLGSVRHA"]);
                this.rowS_FIN_DNEVNIKBLAGAJNE["PRIMITAK"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKBLAGAJNESelect2["PRIMITAK"]);
                this.rowS_FIN_DNEVNIKBLAGAJNE["IZDATAK"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKBLAGAJNESelect2["IZDATAK"]);
                this.rowS_FIN_DNEVNIKBLAGAJNE["KONTA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKBLAGAJNESelect2["KONTA"]);
                this.AddRowS_fin_dnevnikblagajne();
                num++;
                this.rowS_FIN_DNEVNIKBLAGAJNE = this.S_FIN_DNEVNIKBLAGAJNESet.S_FIN_DNEVNIKBLAGAJNE.NewS_FIN_DNEVNIKBLAGAJNERow();
                this.cmS_FIN_DNEVNIKBLAGAJNESelect2.HasMoreRows = this.S_FIN_DNEVNIKBLAGAJNESelect2.Read();
            }
            this.S_FIN_DNEVNIKBLAGAJNESelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_FIN_DNEVNIKBLAGAJNEDataSet dataSet)
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
            this.S_FIN_DNEVNIKBLAGAJNESet = (S_FIN_DNEVNIKBLAGAJNEDataSet) dataSet;
            if (this.S_FIN_DNEVNIKBLAGAJNESet != null)
            {
                return this.Fill(this.S_FIN_DNEVNIKBLAGAJNESet);
            }
            this.S_FIN_DNEVNIKBLAGAJNESet = new S_FIN_DNEVNIKBLAGAJNEDataSet();
            this.Fill(this.S_FIN_DNEVNIKBLAGAJNESet);
            dataSet.Merge(this.S_FIN_DNEVNIKBLAGAJNESet);
            return 0;
        }

        public virtual int Fill(S_FIN_DNEVNIKBLAGAJNEDataSet dataSet, DateTime dat1, DateTime dat2, int blag)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_DNEVNIKBLAGAJNESet = dataSet;
            this.rowS_FIN_DNEVNIKBLAGAJNE = this.S_FIN_DNEVNIKBLAGAJNESet.S_FIN_DNEVNIKBLAGAJNE.NewS_FIN_DNEVNIKBLAGAJNERow();
            this.SetFillParameters(dat1, dat2, blag);
            this.AV8dat1 = DateTimeUtil.ResetTime(dat1);
            this.AV9dat2 = DateTimeUtil.ResetTime(dat2);
            this.AV10blag = blag;
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

        public virtual int FillPage(S_FIN_DNEVNIKBLAGAJNEDataSet dataSet, int startRow, int maxRows)
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
            this.S_FIN_DNEVNIKBLAGAJNESet = (S_FIN_DNEVNIKBLAGAJNEDataSet) dataSet;
            if (this.S_FIN_DNEVNIKBLAGAJNESet != null)
            {
                return this.FillPage(this.S_FIN_DNEVNIKBLAGAJNESet, startRow, maxRows);
            }
            this.S_FIN_DNEVNIKBLAGAJNESet = new S_FIN_DNEVNIKBLAGAJNEDataSet();
            this.FillPage(this.S_FIN_DNEVNIKBLAGAJNESet, startRow, maxRows);
            dataSet.Merge(this.S_FIN_DNEVNIKBLAGAJNESet);
            return 0;
        }

        public virtual int FillPage(S_FIN_DNEVNIKBLAGAJNEDataSet dataSet, DateTime dat1, DateTime dat2, int blag, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_DNEVNIKBLAGAJNESet = dataSet;
            this.rowS_FIN_DNEVNIKBLAGAJNE = this.S_FIN_DNEVNIKBLAGAJNESet.S_FIN_DNEVNIKBLAGAJNE.NewS_FIN_DNEVNIKBLAGAJNERow();
            this.SetFillParameters(dat1, dat2, blag);
            this.AV8dat1 = DateTimeUtil.ResetTime(dat1);
            this.AV9dat2 = DateTimeUtil.ResetTime(dat2);
            this.AV10blag = blag;
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
                parameter.ParameterName = "dat1";
                parameter.DbType = DbType.Date;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "dat2";
                parameter2.DbType = DbType.Date;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "blag";
                parameter3.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(DateTime dat1, DateTime dat2, int blag)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_FIN_DNEVNIKBLAGAJNESelect1 = this.connDefault.GetCommand("S_FIN_DNEVNIKBLAGAJNE", true);
            this.cmS_FIN_DNEVNIKBLAGAJNESelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_DNEVNIKBLAGAJNESelect1.IDbCommand.Parameters.Clear();
            this.cmS_FIN_DNEVNIKBLAGAJNESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@dat1", dat1));
            this.cmS_FIN_DNEVNIKBLAGAJNESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@dat2", dat2));
            this.cmS_FIN_DNEVNIKBLAGAJNESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@blag", blag));
            this.cmS_FIN_DNEVNIKBLAGAJNESelect1.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_DNEVNIKBLAGAJNESelect1 = this.cmS_FIN_DNEVNIKBLAGAJNESelect1.FetchData();
            if (this.S_FIN_DNEVNIKBLAGAJNESelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_FIN_DNEVNIKBLAGAJNESelect1.GetInt32(0);
            }
            this.S_FIN_DNEVNIKBLAGAJNESelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(DateTime dat1, DateTime dat2, int blag)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(dat1, dat2, blag);
                num2 = this.GetInternalRecordCount(dat1, dat2, blag);
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
            this.AV8dat1 = DateTime.MinValue;
            this.AV9dat2 = DateTime.MinValue;
            this.AV10blag = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(DateTime dat1, DateTime dat2, int blag)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = dat1;
                this.fillDataParameters[1].Value = dat2;
                this.fillDataParameters[2].Value = blag;
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

