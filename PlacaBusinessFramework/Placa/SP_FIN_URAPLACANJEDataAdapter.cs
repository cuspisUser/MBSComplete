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

    public class SP_FIN_URAPLACANJEDataAdapter : IDataAdapter, ISP_FIN_URAPLACANJEDataAdapter
    {
        private int AV8IDDOKUM;
        private ReadWriteCommand cmSP_FIN_URAPLACANJESelect1;
        private ReadWriteCommand cmSP_FIN_URAPLACANJESelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private SP_FIN_URAPLACANJEDataSet.SP_FIN_URAPLACANJERow rowSP_FIN_URAPLACANJE;
        private IDataReader SP_FIN_URAPLACANJESelect1;
        private IDataReader SP_FIN_URAPLACANJESelect2;
        private SP_FIN_URAPLACANJEDataSet SP_FIN_URAPLACANJESet;

        private void AddRowSp_fin_uraplacanje()
        {
            this.SP_FIN_URAPLACANJESet.SP_FIN_URAPLACANJE.AddSP_FIN_URAPLACANJERow(this.rowSP_FIN_URAPLACANJE);
            this.rowSP_FIN_URAPLACANJE.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmSP_FIN_URAPLACANJESelect2 = this.connDefault.GetCommand("S_FIN_URA_PLACANJE", true);
            this.cmSP_FIN_URAPLACANJESelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmSP_FIN_URAPLACANJESelect2.IDbCommand.Parameters.Clear();
            this.cmSP_FIN_URAPLACANJESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", this.AV8IDDOKUM));
            this.cmSP_FIN_URAPLACANJESelect2.ErrorMask |= ErrorMask.Lock;
            this.SP_FIN_URAPLACANJESelect2 = this.cmSP_FIN_URAPLACANJESelect2.FetchData();
            while (this.cmSP_FIN_URAPLACANJESelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmSP_FIN_URAPLACANJESelect2.HasMoreRows = this.SP_FIN_URAPLACANJESelect2.Read();
            }
            int num = 0;
            while (this.cmSP_FIN_URAPLACANJESelect2.HasMoreRows && (num != maxRows))
            {
                this.rowSP_FIN_URAPLACANJE["ZATVARANJE_IZNOS"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["ZATVARANJE_IZNOS"]);
                this.rowSP_FIN_URAPLACANJE["ZATVARANJE_DATUM"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["ZATVARANJE_DATUM"]);
                this.rowSP_FIN_URAPLACANJE["URABROJ"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["URABROJ"]);
                this.rowSP_FIN_URAPLACANJE["IDTIPURA"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["IDTIPURA"]);
                this.rowSP_FIN_URAPLACANJE["URABROJRACUNADOBAVLJACA"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["URABROJRACUNADOBAVLJACA"]);
                this.rowSP_FIN_URAPLACANJE["urapartnerIDPARTNER"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["URAPARTNERIDPARTNER"]);
                this.rowSP_FIN_URAPLACANJE["URANAPOMENA"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["URANAPOMENA"]);
                this.rowSP_FIN_URAPLACANJE["URAVALUTA"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["URAVALUTA"]);
                this.rowSP_FIN_URAPLACANJE["URAUKUPNO"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["URAUKUPNO"]);
                this.rowSP_FIN_URAPLACANJE["URADATUM"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["URADATUM"]);
                this.rowSP_FIN_URAPLACANJE["URAGODIDGODINE"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["URAGODIDGODINE"]);
                this.rowSP_FIN_URAPLACANJE["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["NAZIVPARTNER"]);
                this.rowSP_FIN_URAPLACANJE["MB"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["MB"]);
                this.rowSP_FIN_URAPLACANJE["URADOKIDDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["URADOKIDDOKUMENT"]);
                this.rowSP_FIN_URAPLACANJE["PARTNEROIB"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["PARTNEROIB"]);
                this.rowSP_FIN_URAPLACANJE["Status"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["Status"]);
                this.rowSP_FIN_URAPLACANJE["URAMODEL"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["URAMODEL"]);
                this.rowSP_FIN_URAPLACANJE["URAPOZIVNABROJ"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["URAPOZIVNABROJ"]);
                this.rowSP_FIN_URAPLACANJE["OSNOVICA0"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["OSNOVICA0"]);
                this.rowSP_FIN_URAPLACANJE["OSNOVICA5"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["OSNOVICA5"]);
                this.rowSP_FIN_URAPLACANJE["OSNOVICA10"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["OSNOVICA10"]);
                this.rowSP_FIN_URAPLACANJE["OSNOVICA22"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["OSNOVICA22"]);
                this.rowSP_FIN_URAPLACANJE["OSNOVICA23"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["OSNOVICA23"]);
                this.rowSP_FIN_URAPLACANJE["PDV5DA"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["PDV5DA"]);
                this.rowSP_FIN_URAPLACANJE["PDV5NE"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["PDV5NE"]);
                this.rowSP_FIN_URAPLACANJE["PDV10DA"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["PDV10DA"]);
                this.rowSP_FIN_URAPLACANJE["PDV10NE"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["PDV10NE"]);
                this.rowSP_FIN_URAPLACANJE["PDV22DA"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["PDV22DA"]);
                this.rowSP_FIN_URAPLACANJE["PDV22NE"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["PDV22NE"]);
                this.rowSP_FIN_URAPLACANJE["PDV23DA"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["PDV23DA"]);
                this.rowSP_FIN_URAPLACANJE["PDV23NE"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["PDV23NE"]);
                this.rowSP_FIN_URAPLACANJE["OSNOVICA5NE"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["OSNOVICA5NE"]);
                this.rowSP_FIN_URAPLACANJE["OSNOVICA10NE"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["OSNOVICA10NE"]);
                this.rowSP_FIN_URAPLACANJE["OSNOVICA23NE"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["OSNOVICA23NE"]);
                this.rowSP_FIN_URAPLACANJE["OSNOVICA22NE"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["OSNOVICA22NE"]);
                this.rowSP_FIN_URAPLACANJE["R2"] = RuntimeHelpers.GetObjectValue(this.SP_FIN_URAPLACANJESelect2["R2"]);
                this.AddRowSp_fin_uraplacanje();
                num++;
                this.rowSP_FIN_URAPLACANJE = this.SP_FIN_URAPLACANJESet.SP_FIN_URAPLACANJE.NewSP_FIN_URAPLACANJERow();
                this.cmSP_FIN_URAPLACANJESelect2.HasMoreRows = this.SP_FIN_URAPLACANJESelect2.Read();
            }
            this.SP_FIN_URAPLACANJESelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(SP_FIN_URAPLACANJEDataSet dataSet)
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
            this.SP_FIN_URAPLACANJESet = (SP_FIN_URAPLACANJEDataSet) dataSet;
            if (this.SP_FIN_URAPLACANJESet != null)
            {
                return this.Fill(this.SP_FIN_URAPLACANJESet);
            }
            this.SP_FIN_URAPLACANJESet = new SP_FIN_URAPLACANJEDataSet();
            this.Fill(this.SP_FIN_URAPLACANJESet);
            dataSet.Merge(this.SP_FIN_URAPLACANJESet);
            return 0;
        }

        public virtual int Fill(SP_FIN_URAPLACANJEDataSet dataSet, int iDDOKUMENT)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SP_FIN_URAPLACANJESet = dataSet;
            this.rowSP_FIN_URAPLACANJE = this.SP_FIN_URAPLACANJESet.SP_FIN_URAPLACANJE.NewSP_FIN_URAPLACANJERow();
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

        public virtual int FillPage(SP_FIN_URAPLACANJEDataSet dataSet, int startRow, int maxRows)
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
            this.SP_FIN_URAPLACANJESet = (SP_FIN_URAPLACANJEDataSet) dataSet;
            if (this.SP_FIN_URAPLACANJESet != null)
            {
                return this.FillPage(this.SP_FIN_URAPLACANJESet, startRow, maxRows);
            }
            this.SP_FIN_URAPLACANJESet = new SP_FIN_URAPLACANJEDataSet();
            this.FillPage(this.SP_FIN_URAPLACANJESet, startRow, maxRows);
            dataSet.Merge(this.SP_FIN_URAPLACANJESet);
            return 0;
        }

        public virtual int FillPage(SP_FIN_URAPLACANJEDataSet dataSet, int iDDOKUMENT, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SP_FIN_URAPLACANJESet = dataSet;
            this.rowSP_FIN_URAPLACANJE = this.SP_FIN_URAPLACANJESet.SP_FIN_URAPLACANJE.NewSP_FIN_URAPLACANJERow();
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
            this.cmSP_FIN_URAPLACANJESelect1 = this.connDefault.GetCommand("S_FIN_URA_PLACANJE", true);
            this.cmSP_FIN_URAPLACANJESelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmSP_FIN_URAPLACANJESelect1.IDbCommand.Parameters.Clear();
            this.cmSP_FIN_URAPLACANJESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", iDDOKUMENT));
            this.cmSP_FIN_URAPLACANJESelect1.ErrorMask |= ErrorMask.Lock;
            this.SP_FIN_URAPLACANJESelect1 = this.cmSP_FIN_URAPLACANJESelect1.FetchData();
            if (this.SP_FIN_URAPLACANJESelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.SP_FIN_URAPLACANJESelect1.GetInt32(0);
            }
            this.SP_FIN_URAPLACANJESelect1.Close();
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

