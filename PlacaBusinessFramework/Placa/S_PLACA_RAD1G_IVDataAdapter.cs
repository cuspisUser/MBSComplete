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

    public class S_PLACA_RAD1G_IVDataAdapter : IDataAdapter, IS_PLACA_RAD1G_IVDataAdapter
    {
        private string AV8GODINAO;
        private ReadWriteCommand cmS_PLACA_RAD1G_IVSelect1;
        private ReadWriteCommand cmS_PLACA_RAD1G_IVSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_PLACA_RAD1G_IVDataSet.S_PLACA_RAD1G_IVRow rowS_PLACA_RAD1G_IV;
        private IDataReader S_PLACA_RAD1G_IVSelect1;
        private IDataReader S_PLACA_RAD1G_IVSelect2;
        private S_PLACA_RAD1G_IVDataSet S_PLACA_RAD1G_IVSet;

        private void AddRowS_placa_rad1g_iv()
        {
            this.S_PLACA_RAD1G_IVSet.S_PLACA_RAD1G_IV.AddS_PLACA_RAD1G_IVRow(this.rowS_PLACA_RAD1G_IV);
            this.rowS_PLACA_RAD1G_IV.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_PLACA_RAD1G_IVSelect2 = this.connDefault.GetCommand("S_PLACA_RAD1G_IV", true);
            this.cmS_PLACA_RAD1G_IVSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_PLACA_RAD1G_IVSelect2.IDbCommand.Parameters.Clear();
            this.cmS_PLACA_RAD1G_IVSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAOBRACUNA", this.AV8GODINAO));
            this.cmS_PLACA_RAD1G_IVSelect2.ErrorMask |= ErrorMask.Lock;
            this.S_PLACA_RAD1G_IVSelect2 = this.cmS_PLACA_RAD1G_IVSelect2.FetchData();
            while (this.cmS_PLACA_RAD1G_IVSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_PLACA_RAD1G_IVSelect2.HasMoreRows = this.S_PLACA_RAD1G_IVSelect2.Read();
            }
            int num = 0;
            while (this.cmS_PLACA_RAD1G_IVSelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_PLACA_RAD1G_IV["BRUTOPLACA"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1G_IVSelect2["BRUTOPLACA"]);
                this.rowS_PLACA_RAD1G_IV["netoplaca"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1G_IVSelect2["NETOPLACA"]);
                this.rowS_PLACA_RAD1G_IV["SPREMA"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1G_IVSelect2["SPREMA"]);
                this.rowS_PLACA_RAD1G_IV["SPOL"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1G_IVSelect2["spol"]);
                this.AddRowS_placa_rad1g_iv();
                num++;
                this.rowS_PLACA_RAD1G_IV = this.S_PLACA_RAD1G_IVSet.S_PLACA_RAD1G_IV.NewS_PLACA_RAD1G_IVRow();
                this.cmS_PLACA_RAD1G_IVSelect2.HasMoreRows = this.S_PLACA_RAD1G_IVSelect2.Read();
            }
            this.S_PLACA_RAD1G_IVSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_PLACA_RAD1G_IVDataSet dataSet)
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
            this.S_PLACA_RAD1G_IVSet = (S_PLACA_RAD1G_IVDataSet) dataSet;
            if (this.S_PLACA_RAD1G_IVSet != null)
            {
                return this.Fill(this.S_PLACA_RAD1G_IVSet);
            }
            this.S_PLACA_RAD1G_IVSet = new S_PLACA_RAD1G_IVDataSet();
            this.Fill(this.S_PLACA_RAD1G_IVSet);
            dataSet.Merge(this.S_PLACA_RAD1G_IVSet);
            return 0;
        }

        public virtual int Fill(S_PLACA_RAD1G_IVDataSet dataSet, string gODINAOBRACUNA)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_PLACA_RAD1G_IVSet = dataSet;
            this.rowS_PLACA_RAD1G_IV = this.S_PLACA_RAD1G_IVSet.S_PLACA_RAD1G_IV.NewS_PLACA_RAD1G_IVRow();
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

        public virtual int FillPage(S_PLACA_RAD1G_IVDataSet dataSet, int startRow, int maxRows)
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
            this.S_PLACA_RAD1G_IVSet = (S_PLACA_RAD1G_IVDataSet) dataSet;
            if (this.S_PLACA_RAD1G_IVSet != null)
            {
                return this.FillPage(this.S_PLACA_RAD1G_IVSet, startRow, maxRows);
            }
            this.S_PLACA_RAD1G_IVSet = new S_PLACA_RAD1G_IVDataSet();
            this.FillPage(this.S_PLACA_RAD1G_IVSet, startRow, maxRows);
            dataSet.Merge(this.S_PLACA_RAD1G_IVSet);
            return 0;
        }

        public virtual int FillPage(S_PLACA_RAD1G_IVDataSet dataSet, string gODINAOBRACUNA, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_PLACA_RAD1G_IVSet = dataSet;
            this.rowS_PLACA_RAD1G_IV = this.S_PLACA_RAD1G_IVSet.S_PLACA_RAD1G_IV.NewS_PLACA_RAD1G_IVRow();
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
            this.cmS_PLACA_RAD1G_IVSelect1 = this.connDefault.GetCommand("S_PLACA_RAD1G_IV", true);
            this.cmS_PLACA_RAD1G_IVSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_PLACA_RAD1G_IVSelect1.IDbCommand.Parameters.Clear();
            this.cmS_PLACA_RAD1G_IVSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAOBRACUNA", gODINAOBRACUNA));
            this.cmS_PLACA_RAD1G_IVSelect1.ErrorMask |= ErrorMask.Lock;
            this.S_PLACA_RAD1G_IVSelect1 = this.cmS_PLACA_RAD1G_IVSelect1.FetchData();
            if (this.S_PLACA_RAD1G_IVSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_PLACA_RAD1G_IVSelect1.GetInt32(0);
            }
            this.S_PLACA_RAD1G_IVSelect1.Close();
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

