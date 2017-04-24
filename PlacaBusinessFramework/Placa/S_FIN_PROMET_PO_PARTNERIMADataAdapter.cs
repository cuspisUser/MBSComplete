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

    public class S_FIN_PROMET_PO_PARTNERIMADataAdapter : IDataAdapter, IS_FIN_PROMET_PO_PARTNERIMADataAdapter
    {
        private int AV10MT;
        private int AV11ORG;
        private int AV12IDAKTI;
        private DateTime AV13RAZDOB;
        private DateTime AV14RAZDOB;
        private string AV15DODATN;
        private string AV16POCETN;
        private string AV17ZAVRSN;
        private int AV8ODPARTN;
        private int AV9DOPARTN;
        private ReadWriteCommand cmS_FIN_PROMET_PO_PARTNERIMASelect1;
        private ReadWriteCommand cmS_FIN_PROMET_PO_PARTNERIMASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_FIN_PROMET_PO_PARTNERIMADataSet.S_FIN_PROMET_PO_PARTNERIMARow rowS_FIN_PROMET_PO_PARTNERIMA;
        private IDataReader S_FIN_PROMET_PO_PARTNERIMASelect1;
        private IDataReader S_FIN_PROMET_PO_PARTNERIMASelect2;
        private S_FIN_PROMET_PO_PARTNERIMADataSet S_FIN_PROMET_PO_PARTNERIMASet;

        private void AddRowS_fin_promet_po_partnerima()
        {
            this.S_FIN_PROMET_PO_PARTNERIMASet.S_FIN_PROMET_PO_PARTNERIMA.AddS_FIN_PROMET_PO_PARTNERIMARow(this.rowS_FIN_PROMET_PO_PARTNERIMA);
            this.rowS_FIN_PROMET_PO_PARTNERIMA.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect2 = this.connDefault.GetCommand("S_FIN_PROMET_PO_PARTNERIMA", true);
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect2.IDbCommand.Parameters.Clear();
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODPARTNERA", this.AV8ODPARTN));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOPARTNERA", this.AV9DOPARTN));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MT", this.AV10MT));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ORG", this.AV11ORG));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", this.AV12IDAKTI));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEOD", this.AV13RAZDOB));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEDO", this.AV14RAZDOB));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DODATNIUVJET", this.AV15DODATN));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POCETNIKONTO", this.AV16POCETN));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAVRSNIKONTO", this.AV17ZAVRSN));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect2.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_PROMET_PO_PARTNERIMASelect2 = this.cmS_FIN_PROMET_PO_PARTNERIMASelect2.FetchData();
            while (this.cmS_FIN_PROMET_PO_PARTNERIMASelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_FIN_PROMET_PO_PARTNERIMASelect2.HasMoreRows = this.S_FIN_PROMET_PO_PARTNERIMASelect2.Read();
            }
            int num = 0;
            while (this.cmS_FIN_PROMET_PO_PARTNERIMASelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_FIN_PROMET_PO_PARTNERIMA["IDPARTNER"] = RuntimeHelpers.GetObjectValue(this.S_FIN_PROMET_PO_PARTNERIMASelect2["IDPARTNER"]);
                this.rowS_FIN_PROMET_PO_PARTNERIMA["duguje"] = RuntimeHelpers.GetObjectValue(this.S_FIN_PROMET_PO_PARTNERIMASelect2["DUGUJE"]);
                this.rowS_FIN_PROMET_PO_PARTNERIMA["POTRAZUJE"] = RuntimeHelpers.GetObjectValue(this.S_FIN_PROMET_PO_PARTNERIMASelect2["POTRAZUJE"]);
                this.rowS_FIN_PROMET_PO_PARTNERIMA["NAZIV"] = RuntimeHelpers.GetObjectValue(this.S_FIN_PROMET_PO_PARTNERIMASelect2["NAZIV"]);
                this.rowS_FIN_PROMET_PO_PARTNERIMA["AKTIVNOST"] = RuntimeHelpers.GetObjectValue(this.S_FIN_PROMET_PO_PARTNERIMASelect2["AKTIVNOST"]);
                this.rowS_FIN_PROMET_PO_PARTNERIMA["PARTNERMJESTO"] = RuntimeHelpers.GetObjectValue(this.S_FIN_PROMET_PO_PARTNERIMASelect2["PARTNERMJESTO"]);
                this.AddRowS_fin_promet_po_partnerima();
                num++;
                this.rowS_FIN_PROMET_PO_PARTNERIMA = this.S_FIN_PROMET_PO_PARTNERIMASet.S_FIN_PROMET_PO_PARTNERIMA.NewS_FIN_PROMET_PO_PARTNERIMARow();
                this.cmS_FIN_PROMET_PO_PARTNERIMASelect2.HasMoreRows = this.S_FIN_PROMET_PO_PARTNERIMASelect2.Read();
            }
            this.S_FIN_PROMET_PO_PARTNERIMASelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_FIN_PROMET_PO_PARTNERIMADataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), int.Parse(this.fillDataParameters[1].Value.ToString()), int.Parse(this.fillDataParameters[2].Value.ToString()), int.Parse(this.fillDataParameters[3].Value.ToString()), int.Parse(this.fillDataParameters[4].Value.ToString()), DateTime.Parse(this.fillDataParameters[5].Value.ToString()), DateTime.Parse(this.fillDataParameters[6].Value.ToString()), this.fillDataParameters[7].Value.ToString(), this.fillDataParameters[8].Value.ToString(), this.fillDataParameters[9].Value.ToString());
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_FIN_PROMET_PO_PARTNERIMASet = (S_FIN_PROMET_PO_PARTNERIMADataSet) dataSet;
            if (this.S_FIN_PROMET_PO_PARTNERIMASet != null)
            {
                return this.Fill(this.S_FIN_PROMET_PO_PARTNERIMASet);
            }
            this.S_FIN_PROMET_PO_PARTNERIMASet = new S_FIN_PROMET_PO_PARTNERIMADataSet();
            this.Fill(this.S_FIN_PROMET_PO_PARTNERIMASet);
            dataSet.Merge(this.S_FIN_PROMET_PO_PARTNERIMASet);
            return 0;
        }

        public virtual int Fill(S_FIN_PROMET_PO_PARTNERIMADataSet dataSet, int oDPARTNERA, int dOPARTNERA, int mT, int oRG, int iDAKTIVNOST, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string dODATNIUVJET, string pOCETNIKONTO, string zAVRSNIKONTO)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_PROMET_PO_PARTNERIMASet = dataSet;
            this.rowS_FIN_PROMET_PO_PARTNERIMA = this.S_FIN_PROMET_PO_PARTNERIMASet.S_FIN_PROMET_PO_PARTNERIMA.NewS_FIN_PROMET_PO_PARTNERIMARow();
            this.SetFillParameters(oDPARTNERA, dOPARTNERA, mT, oRG, iDAKTIVNOST, rAZDOBLJEOD, rAZDOBLJEDO, dODATNIUVJET, pOCETNIKONTO, zAVRSNIKONTO);
            this.AV8ODPARTN = oDPARTNERA;
            this.AV9DOPARTN = dOPARTNERA;
            this.AV10MT = mT;
            this.AV11ORG = oRG;
            this.AV12IDAKTI = iDAKTIVNOST;
            this.AV13RAZDOB = DateTimeUtil.ResetTime(rAZDOBLJEOD);
            this.AV14RAZDOB = DateTimeUtil.ResetTime(rAZDOBLJEDO);
            this.AV15DODATN = dODATNIUVJET;
            this.AV16POCETN = pOCETNIKONTO;
            this.AV17ZAVRSN = zAVRSNIKONTO;
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

        public virtual int FillPage(S_FIN_PROMET_PO_PARTNERIMADataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), int.Parse(this.fillDataParameters[1].Value.ToString()), int.Parse(this.fillDataParameters[2].Value.ToString()), int.Parse(this.fillDataParameters[3].Value.ToString()), int.Parse(this.fillDataParameters[4].Value.ToString()), DateTime.Parse(this.fillDataParameters[5].Value.ToString()), DateTime.Parse(this.fillDataParameters[6].Value.ToString()), this.fillDataParameters[7].Value.ToString(), this.fillDataParameters[8].Value.ToString(), this.fillDataParameters[9].Value.ToString(), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_FIN_PROMET_PO_PARTNERIMASet = (S_FIN_PROMET_PO_PARTNERIMADataSet) dataSet;
            if (this.S_FIN_PROMET_PO_PARTNERIMASet != null)
            {
                return this.FillPage(this.S_FIN_PROMET_PO_PARTNERIMASet, startRow, maxRows);
            }
            this.S_FIN_PROMET_PO_PARTNERIMASet = new S_FIN_PROMET_PO_PARTNERIMADataSet();
            this.FillPage(this.S_FIN_PROMET_PO_PARTNERIMASet, startRow, maxRows);
            dataSet.Merge(this.S_FIN_PROMET_PO_PARTNERIMASet);
            return 0;
        }

        public virtual int FillPage(S_FIN_PROMET_PO_PARTNERIMADataSet dataSet, int oDPARTNERA, int dOPARTNERA, int mT, int oRG, int iDAKTIVNOST, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string dODATNIUVJET, string pOCETNIKONTO, string zAVRSNIKONTO, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_PROMET_PO_PARTNERIMASet = dataSet;
            this.rowS_FIN_PROMET_PO_PARTNERIMA = this.S_FIN_PROMET_PO_PARTNERIMASet.S_FIN_PROMET_PO_PARTNERIMA.NewS_FIN_PROMET_PO_PARTNERIMARow();
            this.SetFillParameters(oDPARTNERA, dOPARTNERA, mT, oRG, iDAKTIVNOST, rAZDOBLJEOD, rAZDOBLJEDO, dODATNIUVJET, pOCETNIKONTO, zAVRSNIKONTO);
            this.AV8ODPARTN = oDPARTNERA;
            this.AV9DOPARTN = dOPARTNERA;
            this.AV10MT = mT;
            this.AV11ORG = oRG;
            this.AV12IDAKTI = iDAKTIVNOST;
            this.AV13RAZDOB = DateTimeUtil.ResetTime(rAZDOBLJEOD);
            this.AV14RAZDOB = DateTimeUtil.ResetTime(rAZDOBLJEDO);
            this.AV15DODATN = dODATNIUVJET;
            this.AV16POCETN = pOCETNIKONTO;
            this.AV17ZAVRSN = zAVRSNIKONTO;
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
                parameter.ParameterName = "ODPARTNERA";
                parameter.DbType = DbType.Int32;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "DOPARTNERA";
                parameter2.DbType = DbType.Int32;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "MT";
                parameter3.DbType = DbType.Int32;
                DbParameter parameter4 = factory.CreateParameter();
                parameter4.ParameterName = "ORG";
                parameter4.DbType = DbType.Int32;
                DbParameter parameter5 = factory.CreateParameter();
                parameter5.ParameterName = "IDAKTIVNOST";
                parameter5.DbType = DbType.Int32;
                DbParameter parameter6 = factory.CreateParameter();
                parameter6.ParameterName = "RAZDOBLJEOD";
                parameter6.DbType = DbType.Date;
                DbParameter parameter7 = factory.CreateParameter();
                parameter7.ParameterName = "RAZDOBLJEDO";
                parameter7.DbType = DbType.Date;
                DbParameter parameter8 = factory.CreateParameter();
                parameter8.ParameterName = "DODATNIUVJET";
                parameter8.DbType = DbType.String;
                DbParameter parameter9 = factory.CreateParameter();
                parameter9.ParameterName = "POCETNIKONTO";
                parameter9.DbType = DbType.String;
                DbParameter parameter10 = factory.CreateParameter();
                parameter10.ParameterName = "ZAVRSNIKONTO";
                parameter10.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, parameter8, parameter9, parameter10 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(int oDPARTNERA, int dOPARTNERA, int mT, int oRG, int iDAKTIVNOST, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string dODATNIUVJET, string pOCETNIKONTO, string zAVRSNIKONTO)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect1 = this.connDefault.GetCommand("S_FIN_PROMET_PO_PARTNERIMA", true);
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect1.IDbCommand.Parameters.Clear();
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODPARTNERA", oDPARTNERA));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOPARTNERA", dOPARTNERA));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MT", mT));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ORG", oRG));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", iDAKTIVNOST));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEOD", rAZDOBLJEOD));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEDO", rAZDOBLJEDO));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DODATNIUVJET", dODATNIUVJET));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POCETNIKONTO", pOCETNIKONTO));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAVRSNIKONTO", zAVRSNIKONTO));
            this.cmS_FIN_PROMET_PO_PARTNERIMASelect1.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_PROMET_PO_PARTNERIMASelect1 = this.cmS_FIN_PROMET_PO_PARTNERIMASelect1.FetchData();
            if (this.S_FIN_PROMET_PO_PARTNERIMASelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_FIN_PROMET_PO_PARTNERIMASelect1.GetInt32(0);
            }
            this.S_FIN_PROMET_PO_PARTNERIMASelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(int oDPARTNERA, int dOPARTNERA, int mT, int oRG, int iDAKTIVNOST, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string dODATNIUVJET, string pOCETNIKONTO, string zAVRSNIKONTO)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(oDPARTNERA, dOPARTNERA, mT, oRG, iDAKTIVNOST, rAZDOBLJEOD, rAZDOBLJEDO, dODATNIUVJET, pOCETNIKONTO, zAVRSNIKONTO);
                num2 = this.GetInternalRecordCount(oDPARTNERA, dOPARTNERA, mT, oRG, iDAKTIVNOST, rAZDOBLJEOD, rAZDOBLJEDO, dODATNIUVJET, pOCETNIKONTO, zAVRSNIKONTO);
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
            this.AV8ODPARTN = 0;
            this.AV9DOPARTN = 0;
            this.AV10MT = 0;
            this.AV11ORG = 0;
            this.AV12IDAKTI = 0;
            this.AV13RAZDOB = DateTime.MinValue;
            this.AV14RAZDOB = DateTime.MinValue;
            this.AV15DODATN = "";
            this.AV16POCETN = "";
            this.AV17ZAVRSN = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(int oDPARTNERA, int dOPARTNERA, int mT, int oRG, int iDAKTIVNOST, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string dODATNIUVJET, string pOCETNIKONTO, string zAVRSNIKONTO)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = oDPARTNERA;
                this.fillDataParameters[1].Value = dOPARTNERA;
                this.fillDataParameters[2].Value = mT;
                this.fillDataParameters[3].Value = oRG;
                this.fillDataParameters[4].Value = iDAKTIVNOST;
                this.fillDataParameters[5].Value = rAZDOBLJEOD;
                this.fillDataParameters[6].Value = rAZDOBLJEDO;
                this.fillDataParameters[7].Value = dODATNIUVJET;
                this.fillDataParameters[8].Value = pOCETNIKONTO;
                this.fillDataParameters[9].Value = zAVRSNIKONTO;
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

