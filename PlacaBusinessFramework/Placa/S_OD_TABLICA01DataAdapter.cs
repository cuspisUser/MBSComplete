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

    public class S_OD_TABLICA01DataAdapter : IDataAdapter, IS_OD_TABLICA01DataAdapter
    {
        private string AV8GODINA;
        private ReadWriteCommand cmS_OD_TABLICA01Select1;
        private ReadWriteCommand cmS_OD_TABLICA01Select2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OD_TABLICA01DataSet.S_OD_TABLICA01Row rowS_OD_TABLICA01;
        private IDataReader S_OD_TABLICA01Select1;
        private IDataReader S_OD_TABLICA01Select2;
        private S_OD_TABLICA01DataSet S_OD_TABLICA01Set;

        private void AddRowS_od_tablica01()
        {
            this.S_OD_TABLICA01Set.S_OD_TABLICA01.AddS_OD_TABLICA01Row(this.rowS_OD_TABLICA01);
            this.rowS_OD_TABLICA01.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OD_TABLICA01Select2 = this.connDefault.GetCommand("S_PLACA_TABLICA01", true);
            this.cmS_OD_TABLICA01Select2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_TABLICA01Select2.IDbCommand.Parameters.Clear();
            this.cmS_OD_TABLICA01Select2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINA", this.AV8GODINA));
            this.cmS_OD_TABLICA01Select2.ErrorMask |= ErrorMask.Lock;
            this.S_OD_TABLICA01Select2 = this.cmS_OD_TABLICA01Select2.FetchData();
            while (this.cmS_OD_TABLICA01Select2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OD_TABLICA01Select2.HasMoreRows = this.S_OD_TABLICA01Select2.Read();
            }
            int num = 0;
            while (this.cmS_OD_TABLICA01Select2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OD_TABLICA01["IZNOS"] = RuntimeHelpers.GetObjectValue(this.S_OD_TABLICA01Select2["IZNOS"]);
                this.rowS_OD_TABLICA01["MJESECOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.S_OD_TABLICA01Select2["MJESECOBRACUNA"]);
                this.rowS_OD_TABLICA01["GODINAOBRACUNA"] = RuntimeHelpers.GetObjectValue(this.S_OD_TABLICA01Select2["GODINAOBRACUNA"]);
                this.rowS_OD_TABLICA01["NARADU"] = RuntimeHelpers.GetObjectValue(this.S_OD_TABLICA01Select2["NARADU"]);
                this.rowS_OD_TABLICA01["NAKNADA"] = RuntimeHelpers.GetObjectValue(this.S_OD_TABLICA01Select2["NAKNADA"]);
                this.AddRowS_od_tablica01();
                num++;
                this.rowS_OD_TABLICA01 = this.S_OD_TABLICA01Set.S_OD_TABLICA01.NewS_OD_TABLICA01Row();
                this.cmS_OD_TABLICA01Select2.HasMoreRows = this.S_OD_TABLICA01Select2.Read();
            }
            this.S_OD_TABLICA01Select2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OD_TABLICA01DataSet dataSet)
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
            this.S_OD_TABLICA01Set = (S_OD_TABLICA01DataSet) dataSet;
            if (this.S_OD_TABLICA01Set != null)
            {
                return this.Fill(this.S_OD_TABLICA01Set);
            }
            this.S_OD_TABLICA01Set = new S_OD_TABLICA01DataSet();
            this.Fill(this.S_OD_TABLICA01Set);
            dataSet.Merge(this.S_OD_TABLICA01Set);
            return 0;
        }

        public virtual int Fill(S_OD_TABLICA01DataSet dataSet, string gODINA)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_TABLICA01Set = dataSet;
            this.rowS_OD_TABLICA01 = this.S_OD_TABLICA01Set.S_OD_TABLICA01.NewS_OD_TABLICA01Row();
            this.SetFillParameters(gODINA);
            this.AV8GODINA = gODINA;
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

        public virtual int FillPage(S_OD_TABLICA01DataSet dataSet, int startRow, int maxRows)
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
            this.S_OD_TABLICA01Set = (S_OD_TABLICA01DataSet) dataSet;
            if (this.S_OD_TABLICA01Set != null)
            {
                return this.FillPage(this.S_OD_TABLICA01Set, startRow, maxRows);
            }
            this.S_OD_TABLICA01Set = new S_OD_TABLICA01DataSet();
            this.FillPage(this.S_OD_TABLICA01Set, startRow, maxRows);
            dataSet.Merge(this.S_OD_TABLICA01Set);
            return 0;
        }

        public virtual int FillPage(S_OD_TABLICA01DataSet dataSet, string gODINA, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_TABLICA01Set = dataSet;
            this.rowS_OD_TABLICA01 = this.S_OD_TABLICA01Set.S_OD_TABLICA01.NewS_OD_TABLICA01Row();
            this.SetFillParameters(gODINA);
            this.AV8GODINA = gODINA;
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
                parameter.ParameterName = "GODINA";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string gODINA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_OD_TABLICA01Select1 = this.connDefault.GetCommand("S_PLACA_TABLICA01", true);
            this.cmS_OD_TABLICA01Select1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_TABLICA01Select1.IDbCommand.Parameters.Clear();
            this.cmS_OD_TABLICA01Select1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINA", gODINA));
            this.cmS_OD_TABLICA01Select1.ErrorMask |= ErrorMask.Lock;
            this.S_OD_TABLICA01Select1 = this.cmS_OD_TABLICA01Select1.FetchData();
            if (this.S_OD_TABLICA01Select1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OD_TABLICA01Select1.GetInt32(0);
            }
            this.S_OD_TABLICA01Select1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string gODINA)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(gODINA);
                internalRecordCount = this.GetInternalRecordCount(gODINA);
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
            this.AV8GODINA = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string gODINA)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = gODINA;
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

