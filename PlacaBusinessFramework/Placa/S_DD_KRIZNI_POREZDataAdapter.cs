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

    public class S_DD_KRIZNI_POREZDataAdapter : IDataAdapter, IS_DD_KRIZNI_POREZDataAdapter
    {
        private string AV10GODINA;
        private string AV8IDOBRAC;
        private string AV9MJESECI;
        private ReadWriteCommand cmS_DD_KRIZNI_POREZSelect1;
        private ReadWriteCommand cmS_DD_KRIZNI_POREZSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_DD_KRIZNI_POREZDataSet.S_DD_KRIZNI_POREZRow rowS_DD_KRIZNI_POREZ;
        private IDataReader S_DD_KRIZNI_POREZSelect1;
        private IDataReader S_DD_KRIZNI_POREZSelect2;
        private S_DD_KRIZNI_POREZDataSet S_DD_KRIZNI_POREZSet;

        private void AddRowS_dd_krizni_porez()
        {
            this.S_DD_KRIZNI_POREZSet.S_DD_KRIZNI_POREZ.AddS_DD_KRIZNI_POREZRow(this.rowS_DD_KRIZNI_POREZ);
            this.rowS_DD_KRIZNI_POREZ.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_DD_KRIZNI_POREZSelect2 = this.connDefault.GetCommand("S_DD_KRIZNI_POREZ", true);
            this.cmS_DD_KRIZNI_POREZSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_DD_KRIZNI_POREZSelect2.IDbCommand.Parameters.Clear();
            this.cmS_DD_KRIZNI_POREZSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", this.AV8IDOBRAC));
            this.cmS_DD_KRIZNI_POREZSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECISPLATE", this.AV9MJESECI));
            this.cmS_DD_KRIZNI_POREZSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAISPLATE", this.AV10GODINA));
            this.cmS_DD_KRIZNI_POREZSelect2.ErrorMask |= ErrorMask.Lock;
            this.S_DD_KRIZNI_POREZSelect2 = this.cmS_DD_KRIZNI_POREZSelect2.FetchData();
            while (this.cmS_DD_KRIZNI_POREZSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_DD_KRIZNI_POREZSelect2.HasMoreRows = this.S_DD_KRIZNI_POREZSelect2.Read();
            }
            int num = 0;
            while (this.cmS_DD_KRIZNI_POREZSelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_DD_KRIZNI_POREZ["DDIDRADNIK"] = RuntimeHelpers.GetObjectValue(this.S_DD_KRIZNI_POREZSelect2["DDIDRADNIK"]);
                this.rowS_DD_KRIZNI_POREZ["POREZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.S_DD_KRIZNI_POREZSelect2["POREZKRIZNI"]);
                this.rowS_DD_KRIZNI_POREZ["netoplaca"] = RuntimeHelpers.GetObjectValue(this.S_DD_KRIZNI_POREZSelect2["NETOPLACA"]);
                this.AddRowS_dd_krizni_porez();
                num++;
                this.rowS_DD_KRIZNI_POREZ = this.S_DD_KRIZNI_POREZSet.S_DD_KRIZNI_POREZ.NewS_DD_KRIZNI_POREZRow();
                this.cmS_DD_KRIZNI_POREZSelect2.HasMoreRows = this.S_DD_KRIZNI_POREZSelect2.Read();
            }
            this.S_DD_KRIZNI_POREZSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_DD_KRIZNI_POREZDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), this.fillDataParameters[2].Value.ToString());
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_DD_KRIZNI_POREZSet = (S_DD_KRIZNI_POREZDataSet) dataSet;
            if (this.S_DD_KRIZNI_POREZSet != null)
            {
                return this.Fill(this.S_DD_KRIZNI_POREZSet);
            }
            this.S_DD_KRIZNI_POREZSet = new S_DD_KRIZNI_POREZDataSet();
            this.Fill(this.S_DD_KRIZNI_POREZSet);
            dataSet.Merge(this.S_DD_KRIZNI_POREZSet);
            return 0;
        }

        public virtual int Fill(S_DD_KRIZNI_POREZDataSet dataSet, string iDOBRACUN, string mJESECISPLATE, string gODINAISPLATE)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_DD_KRIZNI_POREZSet = dataSet;
            this.rowS_DD_KRIZNI_POREZ = this.S_DD_KRIZNI_POREZSet.S_DD_KRIZNI_POREZ.NewS_DD_KRIZNI_POREZRow();
            this.SetFillParameters(iDOBRACUN, mJESECISPLATE, gODINAISPLATE);
            this.AV8IDOBRAC = iDOBRACUN;
            this.AV9MJESECI = mJESECISPLATE;
            this.AV10GODINA = gODINAISPLATE;
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

        public virtual int FillPage(S_DD_KRIZNI_POREZDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), this.fillDataParameters[2].Value.ToString(), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_DD_KRIZNI_POREZSet = (S_DD_KRIZNI_POREZDataSet) dataSet;
            if (this.S_DD_KRIZNI_POREZSet != null)
            {
                return this.FillPage(this.S_DD_KRIZNI_POREZSet, startRow, maxRows);
            }
            this.S_DD_KRIZNI_POREZSet = new S_DD_KRIZNI_POREZDataSet();
            this.FillPage(this.S_DD_KRIZNI_POREZSet, startRow, maxRows);
            dataSet.Merge(this.S_DD_KRIZNI_POREZSet);
            return 0;
        }

        public virtual int FillPage(S_DD_KRIZNI_POREZDataSet dataSet, string iDOBRACUN, string mJESECISPLATE, string gODINAISPLATE, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_DD_KRIZNI_POREZSet = dataSet;
            this.rowS_DD_KRIZNI_POREZ = this.S_DD_KRIZNI_POREZSet.S_DD_KRIZNI_POREZ.NewS_DD_KRIZNI_POREZRow();
            this.SetFillParameters(iDOBRACUN, mJESECISPLATE, gODINAISPLATE);
            this.AV8IDOBRAC = iDOBRACUN;
            this.AV9MJESECI = mJESECISPLATE;
            this.AV10GODINA = gODINAISPLATE;
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
                parameter.ParameterName = "IDOBRACUN";
                parameter.DbType = DbType.String;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "MJESECISPLATE";
                parameter2.DbType = DbType.String;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "GODINAISPLATE";
                parameter3.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string iDOBRACUN, string mJESECISPLATE, string gODINAISPLATE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_DD_KRIZNI_POREZSelect1 = this.connDefault.GetCommand("S_DD_KRIZNI_POREZ", true);
            this.cmS_DD_KRIZNI_POREZSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_DD_KRIZNI_POREZSelect1.IDbCommand.Parameters.Clear();
            this.cmS_DD_KRIZNI_POREZSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", iDOBRACUN));
            this.cmS_DD_KRIZNI_POREZSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECISPLATE", mJESECISPLATE));
            this.cmS_DD_KRIZNI_POREZSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAISPLATE", gODINAISPLATE));
            this.cmS_DD_KRIZNI_POREZSelect1.ErrorMask |= ErrorMask.Lock;
            this.S_DD_KRIZNI_POREZSelect1 = this.cmS_DD_KRIZNI_POREZSelect1.FetchData();
            if (this.S_DD_KRIZNI_POREZSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_DD_KRIZNI_POREZSelect1.GetInt32(0);
            }
            this.S_DD_KRIZNI_POREZSelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string iDOBRACUN, string mJESECISPLATE, string gODINAISPLATE)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(iDOBRACUN, mJESECISPLATE, gODINAISPLATE);
                num2 = this.GetInternalRecordCount(iDOBRACUN, mJESECISPLATE, gODINAISPLATE);
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
            this.AV8IDOBRAC = "";
            this.AV9MJESECI = "";
            this.AV10GODINA = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string iDOBRACUN, string mJESECISPLATE, string gODINAISPLATE)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = iDOBRACUN;
                this.fillDataParameters[1].Value = mJESECISPLATE;
                this.fillDataParameters[2].Value = gODINAISPLATE;
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

