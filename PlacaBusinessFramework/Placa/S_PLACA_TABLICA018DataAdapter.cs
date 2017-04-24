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

    public class S_PLACA_TABLICA018DataAdapter : IDataAdapter, IS_PLACA_TABLICA018DataAdapter
    {
        private string AV8GODINAO;
        private ReadWriteCommand cmS_PLACA_TABLICA018Select1;
        private ReadWriteCommand cmS_PLACA_TABLICA018Select2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_PLACA_TABLICA018DataSet.S_PLACA_TABLICA018Row rowS_PLACA_TABLICA018;
        private IDataReader S_PLACA_TABLICA018Select1;
        private IDataReader S_PLACA_TABLICA018Select2;
        private S_PLACA_TABLICA018DataSet S_PLACA_TABLICA018Set;

        private void AddRowS_placa_tablica018()
        {
            this.S_PLACA_TABLICA018Set.S_PLACA_TABLICA018.AddS_PLACA_TABLICA018Row(this.rowS_PLACA_TABLICA018);
            this.rowS_PLACA_TABLICA018.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_PLACA_TABLICA018Select2 = this.connDefault.GetCommand("S_PLACA_TABLICA018", true);
            this.cmS_PLACA_TABLICA018Select2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_PLACA_TABLICA018Select2.IDbCommand.Parameters.Clear();
            this.cmS_PLACA_TABLICA018Select2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAOBRACUNA", this.AV8GODINAO));
            this.cmS_PLACA_TABLICA018Select2.ErrorMask |= ErrorMask.Lock;
            this.S_PLACA_TABLICA018Select2 = this.cmS_PLACA_TABLICA018Select2.FetchData();
            while (this.cmS_PLACA_TABLICA018Select2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_PLACA_TABLICA018Select2.HasMoreRows = this.S_PLACA_TABLICA018Select2.Read();
            }
            int num = 0;
            while (this.cmS_PLACA_TABLICA018Select2.HasMoreRows && (num != maxRows))
            {
                this.rowS_PLACA_TABLICA018["DATUMISPLATE"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_TABLICA018Select2["DATUMISPLATE"]);
                this.rowS_PLACA_TABLICA018["GODINAOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_TABLICA018Select2["GODINAOBRACUNA"]);
                this.rowS_PLACA_TABLICA018["MJESECOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_TABLICA018Select2["MJESECOBRACUNA"]);
                this.rowS_PLACA_TABLICA018["SAMOPRVISTUPOSNOVICA"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_TABLICA018Select2["SAMOPRVISTUPOSNOVICA"]);
                this.rowS_PLACA_TABLICA018["SAMOPRVISTUPOBRACUNATI"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_TABLICA018Select2["SAMOPRVISTUPOBRACUNATI"]);
                this.rowS_PLACA_TABLICA018["STUPOSNOVICA"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_TABLICA018Select2["STUPOSNOVICA"]);
                this.rowS_PLACA_TABLICA018["STUPOBRACUNATI"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_TABLICA018Select2["STUPOBRACUNATI"]);
                this.AddRowS_placa_tablica018();
                num++;
                this.rowS_PLACA_TABLICA018 = this.S_PLACA_TABLICA018Set.S_PLACA_TABLICA018.NewS_PLACA_TABLICA018Row();
                this.cmS_PLACA_TABLICA018Select2.HasMoreRows = this.S_PLACA_TABLICA018Select2.Read();
            }
            this.S_PLACA_TABLICA018Select2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_PLACA_TABLICA018DataSet dataSet)
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
            this.S_PLACA_TABLICA018Set = (S_PLACA_TABLICA018DataSet) dataSet;
            if (this.S_PLACA_TABLICA018Set != null)
            {
                return this.Fill(this.S_PLACA_TABLICA018Set);
            }
            this.S_PLACA_TABLICA018Set = new S_PLACA_TABLICA018DataSet();
            this.Fill(this.S_PLACA_TABLICA018Set);
            dataSet.Merge(this.S_PLACA_TABLICA018Set);
            return 0;
        }

        public virtual int Fill(S_PLACA_TABLICA018DataSet dataSet, string gODINAOBRACUNA)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_PLACA_TABLICA018Set = dataSet;
            this.rowS_PLACA_TABLICA018 = this.S_PLACA_TABLICA018Set.S_PLACA_TABLICA018.NewS_PLACA_TABLICA018Row();
            this.SetFillParameters(gODINAOBRACUNA);
            this.AV8GODINAO = gODINAOBRACUNA;
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

        public virtual int FillPage(S_PLACA_TABLICA018DataSet dataSet, int startRow, int maxRows)
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
            this.S_PLACA_TABLICA018Set = (S_PLACA_TABLICA018DataSet) dataSet;
            if (this.S_PLACA_TABLICA018Set != null)
            {
                return this.FillPage(this.S_PLACA_TABLICA018Set, startRow, maxRows);
            }
            this.S_PLACA_TABLICA018Set = new S_PLACA_TABLICA018DataSet();
            this.FillPage(this.S_PLACA_TABLICA018Set, startRow, maxRows);
            dataSet.Merge(this.S_PLACA_TABLICA018Set);
            return 0;
        }

        public virtual int FillPage(S_PLACA_TABLICA018DataSet dataSet, string gODINAOBRACUNA, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_PLACA_TABLICA018Set = dataSet;
            this.rowS_PLACA_TABLICA018 = this.S_PLACA_TABLICA018Set.S_PLACA_TABLICA018.NewS_PLACA_TABLICA018Row();
            this.SetFillParameters(gODINAOBRACUNA);
            this.AV8GODINAO = gODINAOBRACUNA;
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
                parameter.ParameterName = "GODINAOBRACUNA";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string gODINAOBRACUNA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_PLACA_TABLICA018Select1 = this.connDefault.GetCommand("S_PLACA_TABLICA018", true);
            this.cmS_PLACA_TABLICA018Select1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_PLACA_TABLICA018Select1.IDbCommand.Parameters.Clear();
            this.cmS_PLACA_TABLICA018Select1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAOBRACUNA", gODINAOBRACUNA));
            this.cmS_PLACA_TABLICA018Select1.ErrorMask |= ErrorMask.Lock;
            this.S_PLACA_TABLICA018Select1 = this.cmS_PLACA_TABLICA018Select1.FetchData();
            if (this.S_PLACA_TABLICA018Select1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_PLACA_TABLICA018Select1.GetInt32(0);
            }
            this.S_PLACA_TABLICA018Select1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string gODINAOBRACUNA)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(gODINAOBRACUNA);
                internalRecordCount = this.GetInternalRecordCount(gODINAOBRACUNA);
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
            this.AV8GODINAO = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string gODINAOBRACUNA)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = gODINAOBRACUNA;
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

