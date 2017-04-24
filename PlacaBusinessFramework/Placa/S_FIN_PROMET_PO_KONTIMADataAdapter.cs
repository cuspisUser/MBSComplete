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

    public class S_FIN_PROMET_PO_KONTIMADataAdapter : IDataAdapter, IS_FIN_PROMET_PO_KONTIMADataAdapter
    {
        private int AV10DOK;
        private DateTime AV11RAZDOB;
        private DateTime AV12RAZDOB;
        private string AV13POCETN;
        private string AV14ZAVRSN;
        private int AV8ORG;
        private int AV9MT;
        private ReadWriteCommand cmS_FIN_PROMET_PO_KONTIMASelect1;
        private ReadWriteCommand cmS_FIN_PROMET_PO_KONTIMASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_FIN_PROMET_PO_KONTIMADataSet.S_FIN_PROMET_PO_KONTIMARow rowS_FIN_PROMET_PO_KONTIMA;
        private IDataReader S_FIN_PROMET_PO_KONTIMASelect1;
        private IDataReader S_FIN_PROMET_PO_KONTIMASelect2;
        private S_FIN_PROMET_PO_KONTIMADataSet S_FIN_PROMET_PO_KONTIMASet;

        private void AddRowS_fin_promet_po_kontima()
        {
            this.S_FIN_PROMET_PO_KONTIMASet.S_FIN_PROMET_PO_KONTIMA.AddS_FIN_PROMET_PO_KONTIMARow(this.rowS_FIN_PROMET_PO_KONTIMA);
            this.rowS_FIN_PROMET_PO_KONTIMA.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_FIN_PROMET_PO_KONTIMASelect2 = this.connDefault.GetCommand("S_FIN_PROMET_PO_KONTIMA", true);
            this.cmS_FIN_PROMET_PO_KONTIMASelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_PROMET_PO_KONTIMASelect2.IDbCommand.Parameters.Clear();
            this.cmS_FIN_PROMET_PO_KONTIMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ORG", this.AV8ORG));
            this.cmS_FIN_PROMET_PO_KONTIMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MT", this.AV9MT));
            this.cmS_FIN_PROMET_PO_KONTIMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOK", this.AV10DOK));
            this.cmS_FIN_PROMET_PO_KONTIMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEOD", this.AV11RAZDOB));
            this.cmS_FIN_PROMET_PO_KONTIMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEDO", this.AV12RAZDOB));
            this.cmS_FIN_PROMET_PO_KONTIMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POCETNIKONTO", this.AV13POCETN));
            this.cmS_FIN_PROMET_PO_KONTIMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAVRSNIKONTO", this.AV14ZAVRSN));
            this.cmS_FIN_PROMET_PO_KONTIMASelect2.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_PROMET_PO_KONTIMASelect2 = this.cmS_FIN_PROMET_PO_KONTIMASelect2.FetchData();
            while (this.cmS_FIN_PROMET_PO_KONTIMASelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_FIN_PROMET_PO_KONTIMASelect2.HasMoreRows = this.S_FIN_PROMET_PO_KONTIMASelect2.Read();
            }
            int num = 0;
            while (this.cmS_FIN_PROMET_PO_KONTIMASelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_FIN_PROMET_PO_KONTIMA["konto"] = RuntimeHelpers.GetObjectValue(this.S_FIN_PROMET_PO_KONTIMASelect2["KONTO"]);
                this.rowS_FIN_PROMET_PO_KONTIMA["NAZIVKONTO"] = RuntimeHelpers.GetObjectValue(this.S_FIN_PROMET_PO_KONTIMASelect2["NAZIVKONTO"]);
                this.rowS_FIN_PROMET_PO_KONTIMA["duguje"] = RuntimeHelpers.GetObjectValue(this.S_FIN_PROMET_PO_KONTIMASelect2["DUGUJE"]);
                this.rowS_FIN_PROMET_PO_KONTIMA["POTRAZUJE"] = RuntimeHelpers.GetObjectValue(this.S_FIN_PROMET_PO_KONTIMASelect2["POTRAZUJE"]);
                this.rowS_FIN_PROMET_PO_KONTIMA["BROJSTAVAKA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_PROMET_PO_KONTIMASelect2["BROJSTAVAKA"]);
                this.AddRowS_fin_promet_po_kontima();
                num++;
                this.rowS_FIN_PROMET_PO_KONTIMA = this.S_FIN_PROMET_PO_KONTIMASet.S_FIN_PROMET_PO_KONTIMA.NewS_FIN_PROMET_PO_KONTIMARow();
                this.cmS_FIN_PROMET_PO_KONTIMASelect2.HasMoreRows = this.S_FIN_PROMET_PO_KONTIMASelect2.Read();
            }
            this.S_FIN_PROMET_PO_KONTIMASelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_FIN_PROMET_PO_KONTIMADataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), int.Parse(this.fillDataParameters[1].Value.ToString()), int.Parse(this.fillDataParameters[2].Value.ToString()), DateTime.Parse(this.fillDataParameters[3].Value.ToString()), DateTime.Parse(this.fillDataParameters[4].Value.ToString()), this.fillDataParameters[5].Value.ToString(), this.fillDataParameters[6].Value.ToString());
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_FIN_PROMET_PO_KONTIMASet = (S_FIN_PROMET_PO_KONTIMADataSet) dataSet;
            if (this.S_FIN_PROMET_PO_KONTIMASet != null)
            {
                return this.Fill(this.S_FIN_PROMET_PO_KONTIMASet);
            }
            this.S_FIN_PROMET_PO_KONTIMASet = new S_FIN_PROMET_PO_KONTIMADataSet();
            this.Fill(this.S_FIN_PROMET_PO_KONTIMASet);
            dataSet.Merge(this.S_FIN_PROMET_PO_KONTIMASet);
            return 0;
        }

        public virtual int Fill(S_FIN_PROMET_PO_KONTIMADataSet dataSet, int oRG, int mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_PROMET_PO_KONTIMASet = dataSet;
            this.rowS_FIN_PROMET_PO_KONTIMA = this.S_FIN_PROMET_PO_KONTIMASet.S_FIN_PROMET_PO_KONTIMA.NewS_FIN_PROMET_PO_KONTIMARow();
            this.SetFillParameters(oRG, mT, dOK, rAZDOBLJEOD, rAZDOBLJEDO, pOCETNIKONTO, zAVRSNIKONTO);
            this.AV8ORG = oRG;
            this.AV9MT = mT;
            this.AV10DOK = dOK;
            this.AV11RAZDOB = DateTimeUtil.ResetTime(rAZDOBLJEOD);
            this.AV12RAZDOB = DateTimeUtil.ResetTime(rAZDOBLJEDO);
            this.AV13POCETN = pOCETNIKONTO;
            this.AV14ZAVRSN = zAVRSNIKONTO;
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

        public virtual int FillPage(S_FIN_PROMET_PO_KONTIMADataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), int.Parse(this.fillDataParameters[1].Value.ToString()), int.Parse(this.fillDataParameters[2].Value.ToString()), DateTime.Parse(this.fillDataParameters[3].Value.ToString()), DateTime.Parse(this.fillDataParameters[4].Value.ToString()), this.fillDataParameters[5].Value.ToString(), this.fillDataParameters[6].Value.ToString(), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_FIN_PROMET_PO_KONTIMASet = (S_FIN_PROMET_PO_KONTIMADataSet) dataSet;
            if (this.S_FIN_PROMET_PO_KONTIMASet != null)
            {
                return this.FillPage(this.S_FIN_PROMET_PO_KONTIMASet, startRow, maxRows);
            }
            this.S_FIN_PROMET_PO_KONTIMASet = new S_FIN_PROMET_PO_KONTIMADataSet();
            this.FillPage(this.S_FIN_PROMET_PO_KONTIMASet, startRow, maxRows);
            dataSet.Merge(this.S_FIN_PROMET_PO_KONTIMASet);
            return 0;
        }

        public virtual int FillPage(S_FIN_PROMET_PO_KONTIMADataSet dataSet, int oRG, int mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_PROMET_PO_KONTIMASet = dataSet;
            this.rowS_FIN_PROMET_PO_KONTIMA = this.S_FIN_PROMET_PO_KONTIMASet.S_FIN_PROMET_PO_KONTIMA.NewS_FIN_PROMET_PO_KONTIMARow();
            this.SetFillParameters(oRG, mT, dOK, rAZDOBLJEOD, rAZDOBLJEDO, pOCETNIKONTO, zAVRSNIKONTO);
            this.AV8ORG = oRG;
            this.AV9MT = mT;
            this.AV10DOK = dOK;
            this.AV11RAZDOB = DateTimeUtil.ResetTime(rAZDOBLJEOD);
            this.AV12RAZDOB = DateTimeUtil.ResetTime(rAZDOBLJEDO);
            this.AV13POCETN = pOCETNIKONTO;
            this.AV14ZAVRSN = zAVRSNIKONTO;
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
                parameter.ParameterName = "ORG";
                parameter.DbType = DbType.Int32;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "MT";
                parameter2.DbType = DbType.Int32;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "DOK";
                parameter3.DbType = DbType.Int32;
                DbParameter parameter4 = factory.CreateParameter();
                parameter4.ParameterName = "RAZDOBLJEOD";
                parameter4.DbType = DbType.Date;
                DbParameter parameter5 = factory.CreateParameter();
                parameter5.ParameterName = "RAZDOBLJEDO";
                parameter5.DbType = DbType.Date;
                DbParameter parameter6 = factory.CreateParameter();
                parameter6.ParameterName = "POCETNIKONTO";
                parameter6.DbType = DbType.String;
                DbParameter parameter7 = factory.CreateParameter();
                parameter7.ParameterName = "ZAVRSNIKONTO";
                parameter7.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(int oRG, int mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_FIN_PROMET_PO_KONTIMASelect1 = this.connDefault.GetCommand("S_FIN_PROMET_PO_KONTIMA", true);
            this.cmS_FIN_PROMET_PO_KONTIMASelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_PROMET_PO_KONTIMASelect1.IDbCommand.Parameters.Clear();
            this.cmS_FIN_PROMET_PO_KONTIMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ORG", oRG));
            this.cmS_FIN_PROMET_PO_KONTIMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MT", mT));
            this.cmS_FIN_PROMET_PO_KONTIMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOK", dOK));
            this.cmS_FIN_PROMET_PO_KONTIMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEOD", rAZDOBLJEOD));
            this.cmS_FIN_PROMET_PO_KONTIMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEDO", rAZDOBLJEDO));
            this.cmS_FIN_PROMET_PO_KONTIMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POCETNIKONTO", pOCETNIKONTO));
            this.cmS_FIN_PROMET_PO_KONTIMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAVRSNIKONTO", zAVRSNIKONTO));
            this.cmS_FIN_PROMET_PO_KONTIMASelect1.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_PROMET_PO_KONTIMASelect1 = this.cmS_FIN_PROMET_PO_KONTIMASelect1.FetchData();
            if (this.S_FIN_PROMET_PO_KONTIMASelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_FIN_PROMET_PO_KONTIMASelect1.GetInt32(0);
            }
            this.S_FIN_PROMET_PO_KONTIMASelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(int oRG, int mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(oRG, mT, dOK, rAZDOBLJEOD, rAZDOBLJEDO, pOCETNIKONTO, zAVRSNIKONTO);
                num2 = this.GetInternalRecordCount(oRG, mT, dOK, rAZDOBLJEOD, rAZDOBLJEDO, pOCETNIKONTO, zAVRSNIKONTO);
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
            this.AV8ORG = 0;
            this.AV9MT = 0;
            this.AV10DOK = 0;
            this.AV11RAZDOB = DateTime.MinValue;
            this.AV12RAZDOB = DateTime.MinValue;
            this.AV13POCETN = "";
            this.AV14ZAVRSN = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(int oRG, int mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = oRG;
                this.fillDataParameters[1].Value = mT;
                this.fillDataParameters[2].Value = dOK;
                this.fillDataParameters[3].Value = rAZDOBLJEOD;
                this.fillDataParameters[4].Value = rAZDOBLJEDO;
                this.fillDataParameters[5].Value = pOCETNIKONTO;
                this.fillDataParameters[6].Value = zAVRSNIKONTO;
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

