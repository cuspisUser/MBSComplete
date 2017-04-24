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

    public class S_FIN_IRA_PLACANJEDataAdapter : IDataAdapter, IS_FIN_IRA_PLACANJEDataAdapter
    {
        private int AV8IDDOKUM;
        private ReadWriteCommand cmS_FIN_IRA_PLACANJESelect1;
        private ReadWriteCommand cmS_FIN_IRA_PLACANJESelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_FIN_IRA_PLACANJEDataSet.S_FIN_IRA_PLACANJERow rowS_FIN_IRA_PLACANJE;
        private IDataReader S_FIN_IRA_PLACANJESelect1;
        private IDataReader S_FIN_IRA_PLACANJESelect2;
        private S_FIN_IRA_PLACANJEDataSet S_FIN_IRA_PLACANJESet;

        private void AddRowS_fin_ira_placanje()
        {
            this.S_FIN_IRA_PLACANJESet.S_FIN_IRA_PLACANJE.AddS_FIN_IRA_PLACANJERow(this.rowS_FIN_IRA_PLACANJE);
            this.rowS_FIN_IRA_PLACANJE.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_FIN_IRA_PLACANJESelect2 = this.connDefault.GetCommand("S_FIN_IRA_PLACANJE", true);
            this.cmS_FIN_IRA_PLACANJESelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_IRA_PLACANJESelect2.IDbCommand.Parameters.Clear();
            this.cmS_FIN_IRA_PLACANJESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", this.AV8IDDOKUM));
            this.cmS_FIN_IRA_PLACANJESelect2.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_IRA_PLACANJESelect2 = this.cmS_FIN_IRA_PLACANJESelect2.FetchData();
            while (this.cmS_FIN_IRA_PLACANJESelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_FIN_IRA_PLACANJESelect2.HasMoreRows = this.S_FIN_IRA_PLACANJESelect2.Read();
            }
            int num = 0;
            while (this.cmS_FIN_IRA_PLACANJESelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_FIN_IRA_PLACANJE["ZATVARANJE_IZNOS"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["ZATVARANJE_IZNOS"]);
                this.rowS_FIN_IRA_PLACANJE["ZATVARANJE_DATUM"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["ZATVARANJE_DATUM"]);
                this.rowS_FIN_IRA_PLACANJE["IRABROJ"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["IRABROJ"]);
                this.rowS_FIN_IRA_PLACANJE["IDTIPIRA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["IDTIPIRA"]);
                this.rowS_FIN_IRA_PLACANJE["IRAPARTNERIDPARTNER"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["IRAPARTNERIDPARTNER"]);
                this.rowS_FIN_IRA_PLACANJE["IRAUKUPNO"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["IRAUKUPNO"]);
                this.rowS_FIN_IRA_PLACANJE["IRAVALUTA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["IRAVALUTA"]);
                this.rowS_FIN_IRA_PLACANJE["IRANAPOMENA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["IRANAPOMENA"]);
                this.rowS_FIN_IRA_PLACANJE["IRADATUM"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["IRADATUM"]);
                this.rowS_FIN_IRA_PLACANJE["IRAGODIDGODINE"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["IRAGODIDGODINE"]);
                this.rowS_FIN_IRA_PLACANJE["IRADOKIDDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["IRADOKIDDOKUMENT"]);
                this.rowS_FIN_IRA_PLACANJE["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["NAZIVPARTNER"]);
                this.rowS_FIN_IRA_PLACANJE["PARTNEROIB"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["PARTNEROIB"]);
                this.rowS_FIN_IRA_PLACANJE["Status"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["Status"]);
                this.rowS_FIN_IRA_PLACANJE["NEPODLEZE"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["NEPODLEZE"]);
                this.rowS_FIN_IRA_PLACANJE["IZVOZ"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["IZVOZ"]);
                this.rowS_FIN_IRA_PLACANJE["MEDJTRANS"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["MEDJTRANS"]);
                this.rowS_FIN_IRA_PLACANJE["TUZEMSTVO"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["TUZEMSTVO"]);
                this.rowS_FIN_IRA_PLACANJE["OSTALO"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["OSTALO"]);
                this.rowS_FIN_IRA_PLACANJE["NULA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["NULA"]);
                this.rowS_FIN_IRA_PLACANJE["OSN10"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["OSN10"]);
                this.rowS_FIN_IRA_PLACANJE["OSN22"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["OSN22"]);
                this.rowS_FIN_IRA_PLACANJE["OSN23"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["OSN23"]);
                this.rowS_FIN_IRA_PLACANJE["OSN25"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["OSN25"]);
                this.rowS_FIN_IRA_PLACANJE["PDV10"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["PDV10"]);
                this.rowS_FIN_IRA_PLACANJE["PDV22"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["PDV22"]);
                this.rowS_FIN_IRA_PLACANJE["PDV23"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["PDV23"]);
                this.rowS_FIN_IRA_PLACANJE["PDV25"] = RuntimeHelpers.GetObjectValue(this.S_FIN_IRA_PLACANJESelect2["PDV25"]);
                this.AddRowS_fin_ira_placanje();
                num++;
                this.rowS_FIN_IRA_PLACANJE = this.S_FIN_IRA_PLACANJESet.S_FIN_IRA_PLACANJE.NewS_FIN_IRA_PLACANJERow();
                this.cmS_FIN_IRA_PLACANJESelect2.HasMoreRows = this.S_FIN_IRA_PLACANJESelect2.Read();
            }
            this.S_FIN_IRA_PLACANJESelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_FIN_IRA_PLACANJEDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()));
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_FIN_IRA_PLACANJESet = (S_FIN_IRA_PLACANJEDataSet) dataSet;
            if (this.S_FIN_IRA_PLACANJESet != null)
            {
                return this.Fill(this.S_FIN_IRA_PLACANJESet);
            }
            this.S_FIN_IRA_PLACANJESet = new S_FIN_IRA_PLACANJEDataSet();
            this.Fill(this.S_FIN_IRA_PLACANJESet);
            dataSet.Merge(this.S_FIN_IRA_PLACANJESet);
            return 0;
        }

        public virtual int Fill(S_FIN_IRA_PLACANJEDataSet dataSet, int iDDOKUMENT)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_IRA_PLACANJESet = dataSet;
            this.rowS_FIN_IRA_PLACANJE = this.S_FIN_IRA_PLACANJESet.S_FIN_IRA_PLACANJE.NewS_FIN_IRA_PLACANJERow();
            this.SetFillParameters(iDDOKUMENT);
            this.AV8IDDOKUM = iDDOKUMENT;
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

        public virtual int FillPage(S_FIN_IRA_PLACANJEDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_FIN_IRA_PLACANJESet = (S_FIN_IRA_PLACANJEDataSet) dataSet;
            if (this.S_FIN_IRA_PLACANJESet != null)
            {
                return this.FillPage(this.S_FIN_IRA_PLACANJESet, startRow, maxRows);
            }
            this.S_FIN_IRA_PLACANJESet = new S_FIN_IRA_PLACANJEDataSet();
            this.FillPage(this.S_FIN_IRA_PLACANJESet, startRow, maxRows);
            dataSet.Merge(this.S_FIN_IRA_PLACANJESet);
            return 0;
        }

        public virtual int FillPage(S_FIN_IRA_PLACANJEDataSet dataSet, int iDDOKUMENT, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_IRA_PLACANJESet = dataSet;
            this.rowS_FIN_IRA_PLACANJE = this.S_FIN_IRA_PLACANJESet.S_FIN_IRA_PLACANJE.NewS_FIN_IRA_PLACANJERow();
            this.SetFillParameters(iDDOKUMENT);
            this.AV8IDDOKUM = iDDOKUMENT;
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
                parameter.ParameterName = "IDDOKUMENT";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(int iDDOKUMENT)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_FIN_IRA_PLACANJESelect1 = this.connDefault.GetCommand("S_FIN_IRA_PLACANJE", true);
            this.cmS_FIN_IRA_PLACANJESelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_IRA_PLACANJESelect1.IDbCommand.Parameters.Clear();
            this.cmS_FIN_IRA_PLACANJESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", iDDOKUMENT));
            this.cmS_FIN_IRA_PLACANJESelect1.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_IRA_PLACANJESelect1 = this.cmS_FIN_IRA_PLACANJESelect1.FetchData();
            if (this.S_FIN_IRA_PLACANJESelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_FIN_IRA_PLACANJESelect1.GetInt32(0);
            }
            this.S_FIN_IRA_PLACANJESelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(int iDDOKUMENT)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(iDDOKUMENT);
                internalRecordCount = this.GetInternalRecordCount(iDDOKUMENT);
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
            this.AV8IDDOKUM = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(int iDDOKUMENT)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = iDDOKUMENT;
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

