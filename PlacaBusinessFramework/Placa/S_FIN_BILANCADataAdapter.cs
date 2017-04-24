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

    public class S_FIN_BILANCADataAdapter : IDataAdapter, IS_FIN_BILANCADataAdapter
    {
        private string AV10ORG;
        private string AV11MT;
        private string AV12DOK;
        private short AV13ANA;
        private short AV14SKR;
        private string AV15KLASA;
        private short AV16VRSTAB;
        private DateTime AV8RAZDOBL;
        private DateTime AV9RAZDOBL;
        private ReadWriteCommand cmS_FIN_BILANCASelect1;
        private ReadWriteCommand cmS_FIN_BILANCASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_FIN_BILANCADataSet.S_FIN_BILANCARow rowS_FIN_BILANCA;
        private IDataReader S_FIN_BILANCASelect1;
        private IDataReader S_FIN_BILANCASelect2;
        private S_FIN_BILANCADataSet S_FIN_BILANCASet;

        private void AddRowS_fin_bilanca()
        {
            this.S_FIN_BILANCASet.S_FIN_BILANCA.AddS_FIN_BILANCARow(this.rowS_FIN_BILANCA);
            this.rowS_FIN_BILANCA.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_FIN_BILANCASelect2 = this.connDefault.GetCommand("S_FIN_BILANCA", true);
            this.cmS_FIN_BILANCASelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_BILANCASelect2.IDbCommand.Parameters.Clear();
            this.cmS_FIN_BILANCASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEOD", this.AV8RAZDOBL));
            this.cmS_FIN_BILANCASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEDO", this.AV9RAZDOBL));
            this.cmS_FIN_BILANCASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ORG", this.AV10ORG));
            this.cmS_FIN_BILANCASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MT", this.AV11MT));
            this.cmS_FIN_BILANCASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOK", this.AV12DOK));
            this.cmS_FIN_BILANCASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ANA", this.AV13ANA));
            this.cmS_FIN_BILANCASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SKR", this.AV14SKR));
            this.cmS_FIN_BILANCASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KLASA", this.AV15KLASA));
            this.cmS_FIN_BILANCASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTABILANCE", this.AV16VRSTAB));
            this.cmS_FIN_BILANCASelect2.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_BILANCASelect2 = this.cmS_FIN_BILANCASelect2.FetchData();
            while (this.cmS_FIN_BILANCASelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_FIN_BILANCASelect2.HasMoreRows = this.S_FIN_BILANCASelect2.Read();
            }
            int num = 0;
            while (this.cmS_FIN_BILANCASelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_FIN_BILANCA["duguje"] = RuntimeHelpers.GetObjectValue(this.S_FIN_BILANCASelect2["DUGUJE"]);
                this.rowS_FIN_BILANCA["POTRAZUJE"] = RuntimeHelpers.GetObjectValue(this.S_FIN_BILANCASelect2["POTRAZUJE"]);
                this.rowS_FIN_BILANCA["konto"] = RuntimeHelpers.GetObjectValue(this.S_FIN_BILANCASelect2["KONTO"]);
                this.rowS_FIN_BILANCA["POCETNODUGUJE"] = RuntimeHelpers.GetObjectValue(this.S_FIN_BILANCASelect2["POcetnoduguje"]);
                this.rowS_FIN_BILANCA["POCETNOPOTRAZUJE"] = RuntimeHelpers.GetObjectValue(this.S_FIN_BILANCASelect2["pocetnopotrazuje"]);
                this.rowS_FIN_BILANCA["NAZIV"] = RuntimeHelpers.GetObjectValue(this.S_FIN_BILANCASelect2["NAZIV"]);
                this.AddRowS_fin_bilanca();
                num++;
                this.rowS_FIN_BILANCA = this.S_FIN_BILANCASet.S_FIN_BILANCA.NewS_FIN_BILANCARow();
                this.cmS_FIN_BILANCASelect2.HasMoreRows = this.S_FIN_BILANCASelect2.Read();
            }
            this.S_FIN_BILANCASelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_FIN_BILANCADataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, DateTime.Parse(this.fillDataParameters[0].Value.ToString()), DateTime.Parse(this.fillDataParameters[1].Value.ToString()), this.fillDataParameters[2].Value.ToString(), this.fillDataParameters[3].Value.ToString(), this.fillDataParameters[4].Value.ToString(), short.Parse(this.fillDataParameters[5].Value.ToString()), short.Parse(this.fillDataParameters[6].Value.ToString()), this.fillDataParameters[7].Value.ToString(), short.Parse(this.fillDataParameters[8].Value.ToString()));
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_FIN_BILANCASet = (S_FIN_BILANCADataSet) dataSet;
            if (this.S_FIN_BILANCASet != null)
            {
                return this.Fill(this.S_FIN_BILANCASet);
            }
            this.S_FIN_BILANCASet = new S_FIN_BILANCADataSet();
            this.Fill(this.S_FIN_BILANCASet);
            dataSet.Merge(this.S_FIN_BILANCASet);
            return 0;
        }

        public virtual int Fill(S_FIN_BILANCADataSet dataSet, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string oRG, string mT, string dOK, short aNA, short sKR, string kLASA, short vRSTABILANCE)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_BILANCASet = dataSet;
            this.rowS_FIN_BILANCA = this.S_FIN_BILANCASet.S_FIN_BILANCA.NewS_FIN_BILANCARow();
            this.SetFillParameters(rAZDOBLJEOD, rAZDOBLJEDO, oRG, mT, dOK, aNA, sKR, kLASA, vRSTABILANCE);
            this.AV8RAZDOBL = DateTimeUtil.ResetTime(rAZDOBLJEOD);
            this.AV9RAZDOBL = DateTimeUtil.ResetTime(rAZDOBLJEDO);
            this.AV10ORG = oRG;
            this.AV11MT = mT;
            this.AV12DOK = dOK;
            this.AV13ANA = aNA;
            this.AV14SKR = sKR;
            this.AV15KLASA = kLASA;
            this.AV16VRSTAB = vRSTABILANCE;
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

        public virtual int FillPage(S_FIN_BILANCADataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, DateTime.Parse(this.fillDataParameters[0].Value.ToString()), DateTime.Parse(this.fillDataParameters[1].Value.ToString()), this.fillDataParameters[2].Value.ToString(), this.fillDataParameters[3].Value.ToString(), this.fillDataParameters[4].Value.ToString(), short.Parse(this.fillDataParameters[5].Value.ToString()), short.Parse(this.fillDataParameters[6].Value.ToString()), this.fillDataParameters[7].Value.ToString(), short.Parse(this.fillDataParameters[8].Value.ToString()), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_FIN_BILANCASet = (S_FIN_BILANCADataSet) dataSet;
            if (this.S_FIN_BILANCASet != null)
            {
                return this.FillPage(this.S_FIN_BILANCASet, startRow, maxRows);
            }
            this.S_FIN_BILANCASet = new S_FIN_BILANCADataSet();
            this.FillPage(this.S_FIN_BILANCASet, startRow, maxRows);
            dataSet.Merge(this.S_FIN_BILANCASet);
            return 0;
        }

        public virtual int FillPage(S_FIN_BILANCADataSet dataSet, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string oRG, string mT, string dOK, short aNA, short sKR, string kLASA, short vRSTABILANCE, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_BILANCASet = dataSet;
            this.rowS_FIN_BILANCA = this.S_FIN_BILANCASet.S_FIN_BILANCA.NewS_FIN_BILANCARow();
            this.SetFillParameters(rAZDOBLJEOD, rAZDOBLJEDO, oRG, mT, dOK, aNA, sKR, kLASA, vRSTABILANCE);
            this.AV8RAZDOBL = DateTimeUtil.ResetTime(rAZDOBLJEOD);
            this.AV9RAZDOBL = DateTimeUtil.ResetTime(rAZDOBLJEDO);
            this.AV10ORG = oRG;
            this.AV11MT = mT;
            this.AV12DOK = dOK;
            this.AV13ANA = aNA;
            this.AV14SKR = sKR;
            this.AV15KLASA = kLASA;
            this.AV16VRSTAB = vRSTABILANCE;
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
                parameter.ParameterName = "RAZDOBLJEOD";
                parameter.DbType = DbType.Date;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "RAZDOBLJEDO";
                parameter2.DbType = DbType.Date;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "ORG";
                parameter3.DbType = DbType.String;
                DbParameter parameter4 = factory.CreateParameter();
                parameter4.ParameterName = "MT";
                parameter4.DbType = DbType.String;
                DbParameter parameter5 = factory.CreateParameter();
                parameter5.ParameterName = "DOK";
                parameter5.DbType = DbType.String;
                DbParameter parameter6 = factory.CreateParameter();
                parameter6.ParameterName = "ANA";
                parameter6.DbType = DbType.Int16;
                DbParameter parameter7 = factory.CreateParameter();
                parameter7.ParameterName = "SKR";
                parameter7.DbType = DbType.Int16;
                DbParameter parameter8 = factory.CreateParameter();
                parameter8.ParameterName = "KLASA";
                parameter8.DbType = DbType.String;
                DbParameter parameter9 = factory.CreateParameter();
                parameter9.ParameterName = "VRSTABILANCE";
                parameter9.DbType = DbType.Int16;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, parameter8, parameter9 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string oRG, string mT, string dOK, short aNA, short sKR, string kLASA, short vRSTABILANCE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_FIN_BILANCASelect1 = this.connDefault.GetCommand("S_FIN_BILANCA", true);
            this.cmS_FIN_BILANCASelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_BILANCASelect1.IDbCommand.Parameters.Clear();
            this.cmS_FIN_BILANCASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEOD", rAZDOBLJEOD));
            this.cmS_FIN_BILANCASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEDO", rAZDOBLJEDO));
            this.cmS_FIN_BILANCASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ORG", oRG));
            this.cmS_FIN_BILANCASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MT", mT));
            this.cmS_FIN_BILANCASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOK", dOK));
            this.cmS_FIN_BILANCASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ANA", aNA));
            this.cmS_FIN_BILANCASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SKR", sKR));
            this.cmS_FIN_BILANCASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KLASA", kLASA));
            this.cmS_FIN_BILANCASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTABILANCE", vRSTABILANCE));
            this.cmS_FIN_BILANCASelect1.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_BILANCASelect1 = this.cmS_FIN_BILANCASelect1.FetchData();
            if (this.S_FIN_BILANCASelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_FIN_BILANCASelect1.GetInt32(0);
            }
            this.S_FIN_BILANCASelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string oRG, string mT, string dOK, short aNA, short sKR, string kLASA, short vRSTABILANCE)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(rAZDOBLJEOD, rAZDOBLJEDO, oRG, mT, dOK, aNA, sKR, kLASA, vRSTABILANCE);
                num2 = this.GetInternalRecordCount(rAZDOBLJEOD, rAZDOBLJEDO, oRG, mT, dOK, aNA, sKR, kLASA, vRSTABILANCE);
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
            this.AV8RAZDOBL = DateTime.MinValue;
            this.AV9RAZDOBL = DateTime.MinValue;
            this.AV10ORG = "";
            this.AV11MT = "";
            this.AV12DOK = "";
            this.AV13ANA = 0;
            this.AV14SKR = 0;
            this.AV15KLASA = "";
            this.AV16VRSTAB = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string oRG, string mT, string dOK, short aNA, short sKR, string kLASA, short vRSTABILANCE)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = rAZDOBLJEOD;
                this.fillDataParameters[1].Value = rAZDOBLJEDO;
                this.fillDataParameters[2].Value = oRG;
                this.fillDataParameters[3].Value = mT;
                this.fillDataParameters[4].Value = dOK;
                this.fillDataParameters[5].Value = aNA;
                this.fillDataParameters[6].Value = sKR;
                this.fillDataParameters[7].Value = kLASA;
                this.fillDataParameters[8].Value = vRSTABILANCE;
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

