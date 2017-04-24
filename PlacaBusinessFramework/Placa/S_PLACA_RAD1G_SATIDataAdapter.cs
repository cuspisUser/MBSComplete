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

    public class S_PLACA_RAD1G_SATIDataAdapter : IDataAdapter, IS_PLACA_RAD1G_SATIDataAdapter
    {
        private string AV8GODINAO;
        private ReadWriteCommand cmS_PLACA_RAD1G_SATISelect1;
        private ReadWriteCommand cmS_PLACA_RAD1G_SATISelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_PLACA_RAD1G_SATIDataSet.S_PLACA_RAD1G_SATIRow rowS_PLACA_RAD1G_SATI;
        private IDataReader S_PLACA_RAD1G_SATISelect1;
        private IDataReader S_PLACA_RAD1G_SATISelect2;
        private S_PLACA_RAD1G_SATIDataSet S_PLACA_RAD1G_SATISet;

        private void AddRowS_placa_rad1g_sati()
        {
            this.S_PLACA_RAD1G_SATISet.S_PLACA_RAD1G_SATI.AddS_PLACA_RAD1G_SATIRow(this.rowS_PLACA_RAD1G_SATI);
            this.rowS_PLACA_RAD1G_SATI.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_PLACA_RAD1G_SATISelect2 = this.connDefault.GetCommand("S_PLACA_RAD1G_SATI", true);
            this.cmS_PLACA_RAD1G_SATISelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_PLACA_RAD1G_SATISelect2.IDbCommand.Parameters.Clear();
            this.cmS_PLACA_RAD1G_SATISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAOBRACUNA", this.AV8GODINAO));
            this.cmS_PLACA_RAD1G_SATISelect2.ErrorMask |= ErrorMask.Lock;
            this.S_PLACA_RAD1G_SATISelect2 = this.cmS_PLACA_RAD1G_SATISelect2.FetchData();
            while (this.cmS_PLACA_RAD1G_SATISelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_PLACA_RAD1G_SATISelect2.HasMoreRows = this.S_PLACA_RAD1G_SATISelect2.Read();
            }
            int num = 0;
            while (this.cmS_PLACA_RAD1G_SATISelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_PLACA_RAD1G_SATI["IZV"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1G_SATISelect2["IZV"]);
                this.rowS_PLACA_RAD1G_SATI["NEIZV"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1G_SATISelect2["NEIZV"]);
                this.rowS_PLACA_RAD1G_SATI["NEIZVIZVAN"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1G_SATISelect2["NEIZVIZVAN"]);
                this.rowS_PLACA_RAD1G_SATI["NEPLACENI"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1G_SATISelect2["NEPLACENI"]);
                this.rowS_PLACA_RAD1G_SATI["prekovremeni"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1G_SATISelect2["PREKOVREMENI"]);
                this.rowS_PLACA_RAD1G_SATI["STRAJK"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1G_SATISelect2["STRAJK"]);
                this.AddRowS_placa_rad1g_sati();
                num++;
                this.rowS_PLACA_RAD1G_SATI = this.S_PLACA_RAD1G_SATISet.S_PLACA_RAD1G_SATI.NewS_PLACA_RAD1G_SATIRow();
                this.cmS_PLACA_RAD1G_SATISelect2.HasMoreRows = this.S_PLACA_RAD1G_SATISelect2.Read();
            }
            this.S_PLACA_RAD1G_SATISelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_PLACA_RAD1G_SATIDataSet dataSet)
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
            this.S_PLACA_RAD1G_SATISet = (S_PLACA_RAD1G_SATIDataSet) dataSet;
            if (this.S_PLACA_RAD1G_SATISet != null)
            {
                return this.Fill(this.S_PLACA_RAD1G_SATISet);
            }
            this.S_PLACA_RAD1G_SATISet = new S_PLACA_RAD1G_SATIDataSet();
            this.Fill(this.S_PLACA_RAD1G_SATISet);
            dataSet.Merge(this.S_PLACA_RAD1G_SATISet);
            return 0;
        }

        public virtual int Fill(S_PLACA_RAD1G_SATIDataSet dataSet, string gODINAOBRACUNA)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_PLACA_RAD1G_SATISet = dataSet;
            this.rowS_PLACA_RAD1G_SATI = this.S_PLACA_RAD1G_SATISet.S_PLACA_RAD1G_SATI.NewS_PLACA_RAD1G_SATIRow();
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

        public virtual int FillPage(S_PLACA_RAD1G_SATIDataSet dataSet, int startRow, int maxRows)
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
            this.S_PLACA_RAD1G_SATISet = (S_PLACA_RAD1G_SATIDataSet) dataSet;
            if (this.S_PLACA_RAD1G_SATISet != null)
            {
                return this.FillPage(this.S_PLACA_RAD1G_SATISet, startRow, maxRows);
            }
            this.S_PLACA_RAD1G_SATISet = new S_PLACA_RAD1G_SATIDataSet();
            this.FillPage(this.S_PLACA_RAD1G_SATISet, startRow, maxRows);
            dataSet.Merge(this.S_PLACA_RAD1G_SATISet);
            return 0;
        }

        public virtual int FillPage(S_PLACA_RAD1G_SATIDataSet dataSet, string gODINAOBRACUNA, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_PLACA_RAD1G_SATISet = dataSet;
            this.rowS_PLACA_RAD1G_SATI = this.S_PLACA_RAD1G_SATISet.S_PLACA_RAD1G_SATI.NewS_PLACA_RAD1G_SATIRow();
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
            this.cmS_PLACA_RAD1G_SATISelect1 = this.connDefault.GetCommand("S_PLACA_RAD1G_SATI", true);
            this.cmS_PLACA_RAD1G_SATISelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_PLACA_RAD1G_SATISelect1.IDbCommand.Parameters.Clear();
            this.cmS_PLACA_RAD1G_SATISelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAOBRACUNA", gODINAOBRACUNA));
            this.cmS_PLACA_RAD1G_SATISelect1.ErrorMask |= ErrorMask.Lock;
            this.S_PLACA_RAD1G_SATISelect1 = this.cmS_PLACA_RAD1G_SATISelect1.FetchData();
            if (this.S_PLACA_RAD1G_SATISelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_PLACA_RAD1G_SATISelect1.GetInt32(0);
            }
            this.S_PLACA_RAD1G_SATISelect1.Close();
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

