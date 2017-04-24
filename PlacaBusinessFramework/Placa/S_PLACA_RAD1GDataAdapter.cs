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

    public class S_PLACA_RAD1GDataAdapter : IDataAdapter, IS_PLACA_RAD1GDataAdapter
    {
        private DateTime AV10DATUMN;
        private string AV11MJESEC;
        private string AV8GODINAI;
        private string AV9MJESECI;
        private ReadWriteCommand cmS_PLACA_RAD1GSelect1;
        private ReadWriteCommand cmS_PLACA_RAD1GSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_PLACA_RAD1GDataSet.S_PLACA_RAD1GRow rowS_PLACA_RAD1G;
        private IDataReader S_PLACA_RAD1GSelect1;
        private IDataReader S_PLACA_RAD1GSelect2;
        private S_PLACA_RAD1GDataSet S_PLACA_RAD1GSet;

        private void AddRowS_placa_rad1g()
        {
            this.S_PLACA_RAD1GSet.S_PLACA_RAD1G.AddS_PLACA_RAD1GRow(this.rowS_PLACA_RAD1G);
            this.rowS_PLACA_RAD1G.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_PLACA_RAD1GSelect2 = this.connDefault.GetCommand("S_PLACA_RAD1G", true);
            this.cmS_PLACA_RAD1GSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_PLACA_RAD1GSelect2.IDbCommand.Parameters.Clear();
            this.cmS_PLACA_RAD1GSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAISPLATE", this.AV8GODINAI));
            this.cmS_PLACA_RAD1GSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECISPLATE", this.AV9MJESECI));
            this.cmS_PLACA_RAD1GSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMNAKOJIRACUNAMSTAROST", this.AV10DATUMN));
            this.cmS_PLACA_RAD1GSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECODLASKA", this.AV11MJESEC));
            this.cmS_PLACA_RAD1GSelect2.ErrorMask |= ErrorMask.Lock;
            this.S_PLACA_RAD1GSelect2 = this.cmS_PLACA_RAD1GSelect2.FetchData();
            while (this.cmS_PLACA_RAD1GSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_PLACA_RAD1GSelect2.HasMoreRows = this.S_PLACA_RAD1GSelect2.Read();
            }
            int num = 0;
            while (this.cmS_PLACA_RAD1GSelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_PLACA_RAD1G["BROJRADNIKA"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1GSelect2["BROJRADNIKA"]);
                this.rowS_PLACA_RAD1G["BROJRADNIKAZENA"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1GSelect2["BROJRADNIKAZENA"]);
                this.rowS_PLACA_RAD1G["GODINASTAROSTI"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1GSelect2["GODINASTAROSTI"]);
                this.rowS_PLACA_RAD1G["RADNOVRIJEME"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1GSelect2["RADNOVRIJEME"]);
                this.rowS_PLACA_RAD1G["VRSTARADNOGODNOSA"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1GSelect2["VRSTARADNOGODNOSA"]);
                this.rowS_PLACA_RAD1G["SPREMA"] = RuntimeHelpers.GetObjectValue(this.S_PLACA_RAD1GSelect2["SPREMA"]);
                this.AddRowS_placa_rad1g();
                num++;
                this.rowS_PLACA_RAD1G = this.S_PLACA_RAD1GSet.S_PLACA_RAD1G.NewS_PLACA_RAD1GRow();
                this.cmS_PLACA_RAD1GSelect2.HasMoreRows = this.S_PLACA_RAD1GSelect2.Read();
            }
            this.S_PLACA_RAD1GSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_PLACA_RAD1GDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), DateTime.Parse(this.fillDataParameters[2].Value.ToString()), this.fillDataParameters[3].Value.ToString());
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_PLACA_RAD1GSet = (S_PLACA_RAD1GDataSet) dataSet;
            if (this.S_PLACA_RAD1GSet != null)
            {
                return this.Fill(this.S_PLACA_RAD1GSet);
            }
            this.S_PLACA_RAD1GSet = new S_PLACA_RAD1GDataSet();
            this.Fill(this.S_PLACA_RAD1GSet);
            dataSet.Merge(this.S_PLACA_RAD1GSet);
            return 0;
        }

        public virtual int Fill(S_PLACA_RAD1GDataSet dataSet, string gODINAISPLATE, string mJESECISPLATE, DateTime dATUMNAKOJIRACUNAMSTAROST, string mJESECODLASKA)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_PLACA_RAD1GSet = dataSet;
            this.rowS_PLACA_RAD1G = this.S_PLACA_RAD1GSet.S_PLACA_RAD1G.NewS_PLACA_RAD1GRow();
            this.SetFillParameters(gODINAISPLATE, mJESECISPLATE, dATUMNAKOJIRACUNAMSTAROST, mJESECODLASKA);
            this.AV8GODINAI = gODINAISPLATE;
            this.AV9MJESECI = mJESECISPLATE;
            this.AV10DATUMN = DateTimeUtil.ResetTime(dATUMNAKOJIRACUNAMSTAROST);
            this.AV11MJESEC = mJESECODLASKA;
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

        public virtual int FillPage(S_PLACA_RAD1GDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), DateTime.Parse(this.fillDataParameters[2].Value.ToString()), this.fillDataParameters[3].Value.ToString(), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_PLACA_RAD1GSet = (S_PLACA_RAD1GDataSet) dataSet;
            if (this.S_PLACA_RAD1GSet != null)
            {
                return this.FillPage(this.S_PLACA_RAD1GSet, startRow, maxRows);
            }
            this.S_PLACA_RAD1GSet = new S_PLACA_RAD1GDataSet();
            this.FillPage(this.S_PLACA_RAD1GSet, startRow, maxRows);
            dataSet.Merge(this.S_PLACA_RAD1GSet);
            return 0;
        }

        public virtual int FillPage(S_PLACA_RAD1GDataSet dataSet, string gODINAISPLATE, string mJESECISPLATE, DateTime dATUMNAKOJIRACUNAMSTAROST, string mJESECODLASKA, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_PLACA_RAD1GSet = dataSet;
            this.rowS_PLACA_RAD1G = this.S_PLACA_RAD1GSet.S_PLACA_RAD1G.NewS_PLACA_RAD1GRow();
            this.SetFillParameters(gODINAISPLATE, mJESECISPLATE, dATUMNAKOJIRACUNAMSTAROST, mJESECODLASKA);
            this.AV8GODINAI = gODINAISPLATE;
            this.AV9MJESECI = mJESECISPLATE;
            this.AV10DATUMN = DateTimeUtil.ResetTime(dATUMNAKOJIRACUNAMSTAROST);
            this.AV11MJESEC = mJESECODLASKA;
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
                parameter.ParameterName = "GODINAISPLATE";
                parameter.DbType = DbType.String;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "MJESECISPLATE";
                parameter2.DbType = DbType.String;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "DATUMNAKOJIRACUNAMSTAROST";
                parameter3.DbType = DbType.Date;
                DbParameter parameter4 = factory.CreateParameter();
                parameter4.ParameterName = "MJESECODLASKA";
                parameter4.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3, parameter4 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string gODINAISPLATE, string mJESECISPLATE, DateTime dATUMNAKOJIRACUNAMSTAROST, string mJESECODLASKA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_PLACA_RAD1GSelect1 = this.connDefault.GetCommand("S_PLACA_RAD1G", true);
            this.cmS_PLACA_RAD1GSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_PLACA_RAD1GSelect1.IDbCommand.Parameters.Clear();
            this.cmS_PLACA_RAD1GSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAISPLATE", gODINAISPLATE));
            this.cmS_PLACA_RAD1GSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECISPLATE", mJESECISPLATE));
            this.cmS_PLACA_RAD1GSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMNAKOJIRACUNAMSTAROST", dATUMNAKOJIRACUNAMSTAROST));
            this.cmS_PLACA_RAD1GSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECODLASKA", mJESECODLASKA));
            this.cmS_PLACA_RAD1GSelect1.ErrorMask |= ErrorMask.Lock;
            this.S_PLACA_RAD1GSelect1 = this.cmS_PLACA_RAD1GSelect1.FetchData();
            if (this.S_PLACA_RAD1GSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_PLACA_RAD1GSelect1.GetInt32(0);
            }
            this.S_PLACA_RAD1GSelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string gODINAISPLATE, string mJESECISPLATE, DateTime dATUMNAKOJIRACUNAMSTAROST, string mJESECODLASKA)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(gODINAISPLATE, mJESECISPLATE, dATUMNAKOJIRACUNAMSTAROST, mJESECODLASKA);
                num2 = this.GetInternalRecordCount(gODINAISPLATE, mJESECISPLATE, dATUMNAKOJIRACUNAMSTAROST, mJESECODLASKA);
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
            this.AV8GODINAI = "";
            this.AV9MJESECI = "";
            this.AV10DATUMN = DateTime.MinValue;
            this.AV11MJESEC = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string gODINAISPLATE, string mJESECISPLATE, DateTime dATUMNAKOJIRACUNAMSTAROST, string mJESECODLASKA)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = gODINAISPLATE;
                this.fillDataParameters[1].Value = mJESECISPLATE;
                this.fillDataParameters[2].Value = dATUMNAKOJIRACUNAMSTAROST;
                this.fillDataParameters[3].Value = mJESECODLASKA;
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

