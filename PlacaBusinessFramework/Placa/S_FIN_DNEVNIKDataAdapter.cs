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

    public class S_FIN_DNEVNIKDataAdapter : IDataAdapter, IS_FIN_DNEVNIKDataAdapter
    {
        private int AV10DOK;
        private int AV11BROJDO;
        private DateTime AV12RAZDOB;
        private DateTime AV13RAZDOB;
        private string AV14POCETN;
        private string AV15ZAVRSN;
        private bool AV16STATUS;
        private int AV8ORG;
        private int AV9MT;
        private ReadWriteCommand cmS_FIN_DNEVNIKSelect1;
        private ReadWriteCommand cmS_FIN_DNEVNIKSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_FIN_DNEVNIKDataSet.S_FIN_DNEVNIKRow rowS_FIN_DNEVNIK;
        private IDataReader S_FIN_DNEVNIKSelect1;
        private IDataReader S_FIN_DNEVNIKSelect2;
        private S_FIN_DNEVNIKDataSet S_FIN_DNEVNIKSet;

        private void AddRowS_fin_dnevnik()
        {
            this.S_FIN_DNEVNIKSet.S_FIN_DNEVNIK.AddS_FIN_DNEVNIKRow(this.rowS_FIN_DNEVNIK);
            this.rowS_FIN_DNEVNIK.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_FIN_DNEVNIKSelect2 = this.connDefault.GetCommand("S_FIN_DNEVNIK", true);
            this.cmS_FIN_DNEVNIKSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_DNEVNIKSelect2.IDbCommand.Parameters.Clear();
            this.cmS_FIN_DNEVNIKSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ORG", this.AV8ORG));
            this.cmS_FIN_DNEVNIKSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MT", this.AV9MT));
            this.cmS_FIN_DNEVNIKSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOK", this.AV10DOK));
            this.cmS_FIN_DNEVNIKSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJDOK", this.AV11BROJDO));
            this.cmS_FIN_DNEVNIKSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEOD", this.AV12RAZDOB));
            this.cmS_FIN_DNEVNIKSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEDO", this.AV13RAZDOB));
            this.cmS_FIN_DNEVNIKSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POCETNIKONTO", this.AV14POCETN));
            this.cmS_FIN_DNEVNIKSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAVRSNIKONTO", this.AV15ZAVRSN));
            this.cmS_FIN_DNEVNIKSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STATUS", this.AV16STATUS));
            this.cmS_FIN_DNEVNIKSelect2.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_DNEVNIKSelect2 = this.cmS_FIN_DNEVNIKSelect2.FetchData();
            while (this.cmS_FIN_DNEVNIKSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_FIN_DNEVNIKSelect2.HasMoreRows = this.S_FIN_DNEVNIKSelect2.Read();
            }
            int num = 0;
            while (this.cmS_FIN_DNEVNIKSelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_FIN_DNEVNIK["duguje"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKSelect2["DUGUJE"]);
                this.rowS_FIN_DNEVNIK["POTRAZUJE"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKSelect2["POTRAZUJE"]);
                this.rowS_FIN_DNEVNIK["konto"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKSelect2["KONTO"]);
                this.rowS_FIN_DNEVNIK["DATUMDOK"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKSelect2["DATUMDOK"]);
                this.rowS_FIN_DNEVNIK["SKRACENI"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKSelect2["SKRACENI"]);
                this.rowS_FIN_DNEVNIK["BROJDOK"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKSelect2["BROJDOK"]);
                this.rowS_FIN_DNEVNIK["BROJSTAVKE"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKSelect2["BROJSTAVKE"]);
                this.rowS_FIN_DNEVNIK["OPISKNJIZENJA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKSelect2["OPISKNJIZENJA"]);
                this.rowS_FIN_DNEVNIK["NAZIVKONTO"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKSelect2["NAZIVKONTO"]);
                this.rowS_FIN_DNEVNIK["IDDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKSelect2["IDDOKUMENT"]);
                this.rowS_FIN_DNEVNIK["IDORGJED"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKSelect2["IDORGJED"]);
                this.rowS_FIN_DNEVNIK["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKSelect2["IDMJESTOTROSKA"]);
                this.rowS_FIN_DNEVNIK["IDPARTNER"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKSelect2["IDPARTNER"]);
                this.rowS_FIN_DNEVNIK["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKSelect2["NAZIVPARTNER"]);
                this.rowS_FIN_DNEVNIK["ORIGINALNIDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.S_FIN_DNEVNIKSelect2["ORIGINALNIDOKUMENT"]);
                this.AddRowS_fin_dnevnik();
                num++;
                this.rowS_FIN_DNEVNIK = this.S_FIN_DNEVNIKSet.S_FIN_DNEVNIK.NewS_FIN_DNEVNIKRow();
                this.cmS_FIN_DNEVNIKSelect2.HasMoreRows = this.S_FIN_DNEVNIKSelect2.Read();
            }
            this.S_FIN_DNEVNIKSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_FIN_DNEVNIKDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), int.Parse(this.fillDataParameters[1].Value.ToString()), int.Parse(this.fillDataParameters[2].Value.ToString()), int.Parse(this.fillDataParameters[3].Value.ToString()), DateTime.Parse(this.fillDataParameters[4].Value.ToString()), DateTime.Parse(this.fillDataParameters[5].Value.ToString()), this.fillDataParameters[6].Value.ToString(), this.fillDataParameters[7].Value.ToString(), bool.Parse(this.fillDataParameters[8].Value.ToString()));
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_FIN_DNEVNIKSet = (S_FIN_DNEVNIKDataSet) dataSet;
            if (this.S_FIN_DNEVNIKSet != null)
            {
                return this.Fill(this.S_FIN_DNEVNIKSet);
            }
            this.S_FIN_DNEVNIKSet = new S_FIN_DNEVNIKDataSet();
            this.Fill(this.S_FIN_DNEVNIKSet);
            dataSet.Merge(this.S_FIN_DNEVNIKSet);
            return 0;
        }

        public virtual int Fill(S_FIN_DNEVNIKDataSet dataSet, int oRG, int mT, int dOK, int bROJDOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, bool sTATUS)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_DNEVNIKSet = dataSet;
            this.rowS_FIN_DNEVNIK = this.S_FIN_DNEVNIKSet.S_FIN_DNEVNIK.NewS_FIN_DNEVNIKRow();
            this.SetFillParameters(oRG, mT, dOK, bROJDOK, rAZDOBLJEOD, rAZDOBLJEDO, pOCETNIKONTO, zAVRSNIKONTO, sTATUS);
            this.AV8ORG = oRG;
            this.AV9MT = mT;
            this.AV10DOK = dOK;
            this.AV11BROJDO = bROJDOK;
            this.AV12RAZDOB = DateTimeUtil.ResetTime(rAZDOBLJEOD);
            this.AV13RAZDOB = DateTimeUtil.ResetTime(rAZDOBLJEDO);
            this.AV14POCETN = pOCETNIKONTO;
            this.AV15ZAVRSN = zAVRSNIKONTO;
            this.AV16STATUS = sTATUS;
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

        public virtual int FillPage(S_FIN_DNEVNIKDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), int.Parse(this.fillDataParameters[1].Value.ToString()), int.Parse(this.fillDataParameters[2].Value.ToString()), int.Parse(this.fillDataParameters[3].Value.ToString()), DateTime.Parse(this.fillDataParameters[4].Value.ToString()), DateTime.Parse(this.fillDataParameters[5].Value.ToString()), this.fillDataParameters[6].Value.ToString(), this.fillDataParameters[7].Value.ToString(), bool.Parse(this.fillDataParameters[8].Value.ToString()), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_FIN_DNEVNIKSet = (S_FIN_DNEVNIKDataSet) dataSet;
            if (this.S_FIN_DNEVNIKSet != null)
            {
                return this.FillPage(this.S_FIN_DNEVNIKSet, startRow, maxRows);
            }
            this.S_FIN_DNEVNIKSet = new S_FIN_DNEVNIKDataSet();
            this.FillPage(this.S_FIN_DNEVNIKSet, startRow, maxRows);
            dataSet.Merge(this.S_FIN_DNEVNIKSet);
            return 0;
        }

        public virtual int FillPage(S_FIN_DNEVNIKDataSet dataSet, int oRG, int mT, int dOK, int bROJDOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, bool sTATUS, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_DNEVNIKSet = dataSet;
            this.rowS_FIN_DNEVNIK = this.S_FIN_DNEVNIKSet.S_FIN_DNEVNIK.NewS_FIN_DNEVNIKRow();
            this.SetFillParameters(oRG, mT, dOK, bROJDOK, rAZDOBLJEOD, rAZDOBLJEDO, pOCETNIKONTO, zAVRSNIKONTO, sTATUS);
            this.AV8ORG = oRG;
            this.AV9MT = mT;
            this.AV10DOK = dOK;
            this.AV11BROJDO = bROJDOK;
            this.AV12RAZDOB = DateTimeUtil.ResetTime(rAZDOBLJEOD);
            this.AV13RAZDOB = DateTimeUtil.ResetTime(rAZDOBLJEDO);
            this.AV14POCETN = pOCETNIKONTO;
            this.AV15ZAVRSN = zAVRSNIKONTO;
            this.AV16STATUS = sTATUS;
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
                parameter4.ParameterName = "BROJDOK";
                parameter4.DbType = DbType.Int32;
                DbParameter parameter5 = factory.CreateParameter();
                parameter5.ParameterName = "RAZDOBLJEOD";
                parameter5.DbType = DbType.Date;
                DbParameter parameter6 = factory.CreateParameter();
                parameter6.ParameterName = "RAZDOBLJEDO";
                parameter6.DbType = DbType.Date;
                DbParameter parameter7 = factory.CreateParameter();
                parameter7.ParameterName = "POCETNIKONTO";
                parameter7.DbType = DbType.String;
                DbParameter parameter8 = factory.CreateParameter();
                parameter8.ParameterName = "ZAVRSNIKONTO";
                parameter8.DbType = DbType.String;
                DbParameter parameter9 = factory.CreateParameter();
                parameter9.ParameterName = "STATUS";
                parameter9.DbType = DbType.Boolean;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, parameter8, parameter9 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(int oRG, int mT, int dOK, int bROJDOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, bool sTATUS)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_FIN_DNEVNIKSelect1 = this.connDefault.GetCommand("S_FIN_DNEVNIK", true);
            this.cmS_FIN_DNEVNIKSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_DNEVNIKSelect1.IDbCommand.Parameters.Clear();
            this.cmS_FIN_DNEVNIKSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ORG", oRG));
            this.cmS_FIN_DNEVNIKSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MT", mT));
            this.cmS_FIN_DNEVNIKSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOK", dOK));
            this.cmS_FIN_DNEVNIKSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJDOK", bROJDOK));
            this.cmS_FIN_DNEVNIKSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEOD", rAZDOBLJEOD));
            this.cmS_FIN_DNEVNIKSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEDO", rAZDOBLJEDO));
            this.cmS_FIN_DNEVNIKSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POCETNIKONTO", pOCETNIKONTO));
            this.cmS_FIN_DNEVNIKSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAVRSNIKONTO", zAVRSNIKONTO));
            this.cmS_FIN_DNEVNIKSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STATUS", sTATUS));
            this.cmS_FIN_DNEVNIKSelect1.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_DNEVNIKSelect1 = this.cmS_FIN_DNEVNIKSelect1.FetchData();
            if (this.S_FIN_DNEVNIKSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_FIN_DNEVNIKSelect1.GetInt32(0);
            }
            this.S_FIN_DNEVNIKSelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(int oRG, int mT, int dOK, int bROJDOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, bool sTATUS)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(oRG, mT, dOK, bROJDOK, rAZDOBLJEOD, rAZDOBLJEDO, pOCETNIKONTO, zAVRSNIKONTO, sTATUS);
                num2 = this.GetInternalRecordCount(oRG, mT, dOK, bROJDOK, rAZDOBLJEOD, rAZDOBLJEDO, pOCETNIKONTO, zAVRSNIKONTO, sTATUS);
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
            this.AV11BROJDO = 0;
            this.AV12RAZDOB = DateTime.MinValue;
            this.AV13RAZDOB = DateTime.MinValue;
            this.AV14POCETN = "";
            this.AV15ZAVRSN = "";
            this.AV16STATUS = false;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(int oRG, int mT, int dOK, int bROJDOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, bool sTATUS)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = oRG;
                this.fillDataParameters[1].Value = mT;
                this.fillDataParameters[2].Value = dOK;
                this.fillDataParameters[3].Value = bROJDOK;
                this.fillDataParameters[4].Value = rAZDOBLJEOD;
                this.fillDataParameters[5].Value = rAZDOBLJEDO;
                this.fillDataParameters[6].Value = pOCETNIKONTO;
                this.fillDataParameters[7].Value = zAVRSNIKONTO;
                this.fillDataParameters[8].Value = sTATUS;
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

