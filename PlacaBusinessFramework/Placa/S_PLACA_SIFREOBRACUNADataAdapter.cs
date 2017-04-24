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

    public class S_PLACA_SIFREOBRACUNADataAdapter : IDataAdapter, IS_PLACA_SIFREOBRACUNADataAdapter
    {
        private string AV10DOGODI;
        private string AV11DOMJES;
        private string AV8ODGODIN;
        private string AV9ODMJESE;
        private ReadWriteCommand cmS_PLACA_SIFREOBRACUNASelect1;
        private ReadWriteCommand cmS_PLACA_SIFREOBRACUNASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_PLACA_SIFREOBRACUNADataSet.S_PLACA_SIFREOBRACUNARow rowS_PLACA_SIFREOBRACUNA;
        private IDataReader S_PLACA_SIFREOBRACUNASelect1;
        private IDataReader S_PLACA_SIFREOBRACUNASelect2;
        private S_PLACA_SIFREOBRACUNADataSet S_PLACA_SIFREOBRACUNASet;

        private void AddRowS_placa_sifreobracuna()
        {
            this.S_PLACA_SIFREOBRACUNASet.S_PLACA_SIFREOBRACUNA.AddS_PLACA_SIFREOBRACUNARow(this.rowS_PLACA_SIFREOBRACUNA);
            this.rowS_PLACA_SIFREOBRACUNA.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_PLACA_SIFREOBRACUNASelect2 = this.connDefault.GetCommand("S_PLACA_SIFREOBRACUNA", true);
            this.cmS_PLACA_SIFREOBRACUNASelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_PLACA_SIFREOBRACUNASelect2.IDbCommand.Parameters.Clear();
            this.cmS_PLACA_SIFREOBRACUNASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODGODINE", this.AV8ODGODIN));
            this.cmS_PLACA_SIFREOBRACUNASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODMJESECA", this.AV9ODMJESE));
            this.cmS_PLACA_SIFREOBRACUNASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOGODINE", this.AV10DOGODI));
            this.cmS_PLACA_SIFREOBRACUNASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOMJESECA", this.AV11DOMJES));
            this.cmS_PLACA_SIFREOBRACUNASelect2.ErrorMask |= ErrorMask.Lock;
            this.S_PLACA_SIFREOBRACUNASelect2 = this.cmS_PLACA_SIFREOBRACUNASelect2.FetchData();
            while (this.cmS_PLACA_SIFREOBRACUNASelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_PLACA_SIFREOBRACUNASelect2.HasMoreRows = this.S_PLACA_SIFREOBRACUNASelect2.Read();
            }
            int num = 0;
            while (this.cmS_PLACA_SIFREOBRACUNASelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_PLACA_SIFREOBRACUNA["IDOBRACUN"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_SIFREOBRACUNASelect2["IDOBRACUN"]);
                this.AddRowS_placa_sifreobracuna();
                num++;
                this.rowS_PLACA_SIFREOBRACUNA = this.S_PLACA_SIFREOBRACUNASet.S_PLACA_SIFREOBRACUNA.NewS_PLACA_SIFREOBRACUNARow();
                this.cmS_PLACA_SIFREOBRACUNASelect2.HasMoreRows = this.S_PLACA_SIFREOBRACUNASelect2.Read();
            }
            this.S_PLACA_SIFREOBRACUNASelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_PLACA_SIFREOBRACUNADataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), this.fillDataParameters[2].Value.ToString(), this.fillDataParameters[3].Value.ToString());
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_PLACA_SIFREOBRACUNASet = (S_PLACA_SIFREOBRACUNADataSet) dataSet;
            if (this.S_PLACA_SIFREOBRACUNASet != null)
            {
                return this.Fill(this.S_PLACA_SIFREOBRACUNASet);
            }
            this.S_PLACA_SIFREOBRACUNASet = new S_PLACA_SIFREOBRACUNADataSet();
            this.Fill(this.S_PLACA_SIFREOBRACUNASet);
            dataSet.Merge(this.S_PLACA_SIFREOBRACUNASet);
            return 0;
        }

        public virtual int Fill(S_PLACA_SIFREOBRACUNADataSet dataSet, string oDGODINE, string oDMJESECA, string dOGODINE, string dOMJESECA)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_PLACA_SIFREOBRACUNASet = dataSet;
            this.rowS_PLACA_SIFREOBRACUNA = this.S_PLACA_SIFREOBRACUNASet.S_PLACA_SIFREOBRACUNA.NewS_PLACA_SIFREOBRACUNARow();
            this.SetFillParameters(oDGODINE, oDMJESECA, dOGODINE, dOMJESECA);
            this.AV8ODGODIN = oDGODINE;
            this.AV9ODMJESE = oDMJESECA;
            this.AV10DOGODI = dOGODINE;
            this.AV11DOMJES = dOMJESECA;
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

        public virtual int FillPage(S_PLACA_SIFREOBRACUNADataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), this.fillDataParameters[2].Value.ToString(), this.fillDataParameters[3].Value.ToString(), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_PLACA_SIFREOBRACUNASet = (S_PLACA_SIFREOBRACUNADataSet) dataSet;
            if (this.S_PLACA_SIFREOBRACUNASet != null)
            {
                return this.FillPage(this.S_PLACA_SIFREOBRACUNASet, startRow, maxRows);
            }
            this.S_PLACA_SIFREOBRACUNASet = new S_PLACA_SIFREOBRACUNADataSet();
            this.FillPage(this.S_PLACA_SIFREOBRACUNASet, startRow, maxRows);
            dataSet.Merge(this.S_PLACA_SIFREOBRACUNASet);
            return 0;
        }

        public virtual int FillPage(S_PLACA_SIFREOBRACUNADataSet dataSet, string oDGODINE, string oDMJESECA, string dOGODINE, string dOMJESECA, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_PLACA_SIFREOBRACUNASet = dataSet;
            this.rowS_PLACA_SIFREOBRACUNA = this.S_PLACA_SIFREOBRACUNASet.S_PLACA_SIFREOBRACUNA.NewS_PLACA_SIFREOBRACUNARow();
            this.SetFillParameters(oDGODINE, oDMJESECA, dOGODINE, dOMJESECA);
            this.AV8ODGODIN = oDGODINE;
            this.AV9ODMJESE = oDMJESECA;
            this.AV10DOGODI = dOGODINE;
            this.AV11DOMJES = dOMJESECA;
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
                parameter.ParameterName = "ODGODINE";
                parameter.DbType = DbType.String;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "ODMJESECA";
                parameter2.DbType = DbType.String;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "DOGODINE";
                parameter3.DbType = DbType.String;
                DbParameter parameter4 = factory.CreateParameter();
                parameter4.ParameterName = "DOMJESECA";
                parameter4.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3, parameter4 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string oDGODINE, string oDMJESECA, string dOGODINE, string dOMJESECA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_PLACA_SIFREOBRACUNASelect1 = this.connDefault.GetCommand("S_PLACA_SIFREOBRACUNA", true);
            this.cmS_PLACA_SIFREOBRACUNASelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_PLACA_SIFREOBRACUNASelect1.IDbCommand.Parameters.Clear();
            this.cmS_PLACA_SIFREOBRACUNASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODGODINE", oDGODINE));
            this.cmS_PLACA_SIFREOBRACUNASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODMJESECA", oDMJESECA));
            this.cmS_PLACA_SIFREOBRACUNASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOGODINE", dOGODINE));
            this.cmS_PLACA_SIFREOBRACUNASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOMJESECA", dOMJESECA));
            this.cmS_PLACA_SIFREOBRACUNASelect1.ErrorMask |= ErrorMask.Lock;
            this.S_PLACA_SIFREOBRACUNASelect1 = this.cmS_PLACA_SIFREOBRACUNASelect1.FetchData();
            if (this.S_PLACA_SIFREOBRACUNASelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_PLACA_SIFREOBRACUNASelect1.GetInt32(0);
            }
            this.S_PLACA_SIFREOBRACUNASelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string oDGODINE, string oDMJESECA, string dOGODINE, string dOMJESECA)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(oDGODINE, oDMJESECA, dOGODINE, dOMJESECA);
                num2 = this.GetInternalRecordCount(oDGODINE, oDMJESECA, dOGODINE, dOMJESECA);
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
            this.AV8ODGODIN = "";
            this.AV9ODMJESE = "";
            this.AV10DOGODI = "";
            this.AV11DOMJES = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string oDGODINE, string oDMJESECA, string dOGODINE, string dOMJESECA)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = oDGODINE;
                this.fillDataParameters[1].Value = oDMJESECA;
                this.fillDataParameters[2].Value = dOGODINE;
                this.fillDataParameters[3].Value = dOMJESECA;
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

