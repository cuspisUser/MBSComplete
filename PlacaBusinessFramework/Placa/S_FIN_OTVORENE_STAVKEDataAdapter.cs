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

    public class S_FIN_OTVORENE_STAVKEDataAdapter : IDataAdapter, IS_FIN_OTVORENE_STAVKEDataAdapter
    {
        private int AV10DOK;
        private DateTime AV11RAZDOB;
        private DateTime AV12RAZDOB;
        private string AV13POCETN;
        private string AV14ZAVRSN;
        private int AV15IDAKTI;
        private int AV16IDPART;
        private string AV16PARTNEROIB;
        private string AV17DODATN;
        private short AV18GODINA;
        private int AV8ORG;
        private int AV9MT;
        private ReadWriteCommand cmS_FIN_OTVORENE_STAVKESelect1;
        private ReadWriteCommand cmS_FIN_OTVORENE_STAVKESelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_FIN_OTVORENE_STAVKEDataSet.S_FIN_OTVORENE_STAVKERow rowS_FIN_OTVORENE_STAVKE;
        private IDataReader S_FIN_OTVORENE_STAVKESelect1;
        private IDataReader S_FIN_OTVORENE_STAVKESelect2;
        private S_FIN_OTVORENE_STAVKEDataSet S_FIN_OTVORENE_STAVKESet;

        private void AddRowS_fin_otvorene_stavke()
        {
            this.S_FIN_OTVORENE_STAVKESet.S_FIN_OTVORENE_STAVKE.AddS_FIN_OTVORENE_STAVKERow(this.rowS_FIN_OTVORENE_STAVKE);
            this.rowS_FIN_OTVORENE_STAVKE.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_FIN_OTVORENE_STAVKESelect2 = this.connDefault.GetCommand("S_FIN_OTVORENE_STAVKE", true); //PROCEDURA
            this.cmS_FIN_OTVORENE_STAVKESelect2.IDbCommand.CommandType = CommandType.StoredProcedure;

            this.cmS_FIN_OTVORENE_STAVKESelect2.IDbCommand.Parameters.Clear();
            this.cmS_FIN_OTVORENE_STAVKESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ORG", this.AV8ORG));
            this.cmS_FIN_OTVORENE_STAVKESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MT", this.AV9MT));
            this.cmS_FIN_OTVORENE_STAVKESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOK", this.AV10DOK));
            this.cmS_FIN_OTVORENE_STAVKESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEOD", this.AV11RAZDOB));
            this.cmS_FIN_OTVORENE_STAVKESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEDO", this.AV12RAZDOB));
            this.cmS_FIN_OTVORENE_STAVKESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POCETNIKONTO", this.AV13POCETN));
            this.cmS_FIN_OTVORENE_STAVKESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAVRSNIKONTO", this.AV14ZAVRSN));
            this.cmS_FIN_OTVORENE_STAVKESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", this.AV15IDAKTI));
            this.cmS_FIN_OTVORENE_STAVKESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", this.AV16IDPART));
            this.cmS_FIN_OTVORENE_STAVKESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PARTNEROIB", this.AV16PARTNEROIB));
            this.cmS_FIN_OTVORENE_STAVKESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DODATNIUVJET", this.AV17DODATN));
            this.cmS_FIN_OTVORENE_STAVKESelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINA", this.AV18GODINA));
            
            this.cmS_FIN_OTVORENE_STAVKESelect2.ErrorMask |= ErrorMask.Lock;           
            this.S_FIN_OTVORENE_STAVKESelect2 = this.cmS_FIN_OTVORENE_STAVKESelect2.FetchData();
            while (this.cmS_FIN_OTVORENE_STAVKESelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_FIN_OTVORENE_STAVKESelect2.HasMoreRows = this.S_FIN_OTVORENE_STAVKESelect2.Read();
            }
            int num = 0;
            while (this.cmS_FIN_OTVORENE_STAVKESelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_FIN_OTVORENE_STAVKE["duguje"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["DUGUJE"]);
                this.rowS_FIN_OTVORENE_STAVKE["POTRAZUJE"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["POTRAZUJE"]);
                this.rowS_FIN_OTVORENE_STAVKE["konto"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["KONTO"]);
                this.rowS_FIN_OTVORENE_STAVKE["DATUMDVO"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["DATUMDVO"]);
                this.rowS_FIN_OTVORENE_STAVKE["DATUMVALUTE"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["DATUMVALUTE"]);
                this.rowS_FIN_OTVORENE_STAVKE["DATUMDOK"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["DATUMDOK"]);
                this.rowS_FIN_OTVORENE_STAVKE["SKRACENI"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["SKRACENI"]);
                this.rowS_FIN_OTVORENE_STAVKE["BROJDOK"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["BROJDOK"]);
                this.rowS_FIN_OTVORENE_STAVKE["BROJSTAVKE"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["BROJSTAVKE"]);
                this.rowS_FIN_OTVORENE_STAVKE["OPISKNJIZENJA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["OPISKNJIZENJA"]);
                this.rowS_FIN_OTVORENE_STAVKE["IDPARTNER"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["IDPARTNER"]);
                this.rowS_FIN_OTVORENE_STAVKE["OTVORENO"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["OTVORENO"]);
                this.rowS_FIN_OTVORENE_STAVKE["NAZIV"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["NAZIV"]);
                this.rowS_FIN_OTVORENE_STAVKE["IDDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["IDDOKUMENT"]);
                this.rowS_FIN_OTVORENE_STAVKE["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["NAZIVPARTNER"]);
                try
                {
                    this.rowS_FIN_OTVORENE_STAVKE["PARTNEROIB"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["PARTNEROIB"]);
                }
                catch { }

                this.rowS_FIN_OTVORENE_STAVKE["IDORGJED"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["IDORGJED"]);
                this.rowS_FIN_OTVORENE_STAVKE["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["IDMJESTOTROSKA"]);
                this.rowS_FIN_OTVORENE_STAVKE["MB"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["MB"]);
                this.rowS_FIN_OTVORENE_STAVKE["PARTNERMJESTO"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["PARTNERMJESTO"]);
                this.rowS_FIN_OTVORENE_STAVKE["PARTNERULICA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["PARTNERULICA"]);
                this.rowS_FIN_OTVORENE_STAVKE["IDGKSTAVKA"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["IDGKSTAVKA"]);
                this.rowS_FIN_OTVORENE_STAVKE["ORIGINALNIDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["ORIGINALNIDOKUMENT"]);
                this.rowS_FIN_OTVORENE_STAVKE["NAZIVOJ"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["NAZIVOJ"]);
                this.rowS_FIN_OTVORENE_STAVKE["NAZIVMT"] = RuntimeHelpers.GetObjectValue(this.S_FIN_OTVORENE_STAVKESelect2["NAZIVMT"]);
                this.AddRowS_fin_otvorene_stavke();
                num++;
                this.rowS_FIN_OTVORENE_STAVKE = this.S_FIN_OTVORENE_STAVKESet.S_FIN_OTVORENE_STAVKE.NewS_FIN_OTVORENE_STAVKERow();
                this.cmS_FIN_OTVORENE_STAVKESelect2.HasMoreRows = this.S_FIN_OTVORENE_STAVKESelect2.Read();
            }
            this.S_FIN_OTVORENE_STAVKESelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_FIN_OTVORENE_STAVKEDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), int.Parse(this.fillDataParameters[1].Value.ToString()), int.Parse(this.fillDataParameters[2].Value.ToString()), DateTime.Parse(this.fillDataParameters[3].Value.ToString()), DateTime.Parse(this.fillDataParameters[4].Value.ToString()), this.fillDataParameters[5].Value.ToString(), this.fillDataParameters[6].Value.ToString(), int.Parse(this.fillDataParameters[7].Value.ToString()), int.Parse(this.fillDataParameters[8].Value.ToString()), this.fillDataParameters[9].Value.ToString(), short.Parse(this.fillDataParameters[10].Value.ToString()));
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_FIN_OTVORENE_STAVKESet = (S_FIN_OTVORENE_STAVKEDataSet) dataSet;
            if (this.S_FIN_OTVORENE_STAVKESet != null)
            {
                return this.Fill(this.S_FIN_OTVORENE_STAVKESet);
            }
            this.S_FIN_OTVORENE_STAVKESet = new S_FIN_OTVORENE_STAVKEDataSet();
            this.Fill(this.S_FIN_OTVORENE_STAVKESet);
            dataSet.Merge(this.S_FIN_OTVORENE_STAVKESet);
            return 0;
        }

        public virtual int Fill(S_FIN_OTVORENE_STAVKEDataSet dataSet, int oRG, int mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, int iDAKTIVNOST, int iDPARTNER, string dODATNIUVJET, short gODINA)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_OTVORENE_STAVKESet = dataSet;
            this.rowS_FIN_OTVORENE_STAVKE = this.S_FIN_OTVORENE_STAVKESet.S_FIN_OTVORENE_STAVKE.NewS_FIN_OTVORENE_STAVKERow();
            this.SetFillParameters(oRG, mT, dOK, rAZDOBLJEOD, rAZDOBLJEDO, pOCETNIKONTO, zAVRSNIKONTO, iDAKTIVNOST, iDPARTNER, dODATNIUVJET, gODINA);
            this.AV8ORG = oRG;
            this.AV9MT = mT;
            this.AV10DOK = dOK;
            this.AV11RAZDOB = DateTimeUtil.ResetTime(rAZDOBLJEOD);
            this.AV12RAZDOB = DateTimeUtil.ResetTime(rAZDOBLJEDO);
            this.AV13POCETN = pOCETNIKONTO;
            this.AV14ZAVRSN = zAVRSNIKONTO;
            this.AV15IDAKTI = iDAKTIVNOST;
            this.AV16IDPART = iDPARTNER;
            this.AV16PARTNEROIB = "";
            this.AV17DODATN = dODATNIUVJET;
            this.AV18GODINA = gODINA;
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

        public virtual int FillPage(S_FIN_OTVORENE_STAVKEDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), int.Parse(this.fillDataParameters[1].Value.ToString()), int.Parse(this.fillDataParameters[2].Value.ToString()), DateTime.Parse(this.fillDataParameters[3].Value.ToString()), DateTime.Parse(this.fillDataParameters[4].Value.ToString()), this.fillDataParameters[5].Value.ToString(), this.fillDataParameters[6].Value.ToString(), int.Parse(this.fillDataParameters[7].Value.ToString()), int.Parse(this.fillDataParameters[8].Value.ToString()), this.fillDataParameters[9].Value.ToString(), short.Parse(this.fillDataParameters[10].Value.ToString()), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_FIN_OTVORENE_STAVKESet = (S_FIN_OTVORENE_STAVKEDataSet) dataSet;
            if (this.S_FIN_OTVORENE_STAVKESet != null)
            {
                return this.FillPage(this.S_FIN_OTVORENE_STAVKESet, startRow, maxRows);
            }
            this.S_FIN_OTVORENE_STAVKESet = new S_FIN_OTVORENE_STAVKEDataSet();
            this.FillPage(this.S_FIN_OTVORENE_STAVKESet, startRow, maxRows);
            dataSet.Merge(this.S_FIN_OTVORENE_STAVKESet);
            return 0;
        }

        public virtual int FillPage(S_FIN_OTVORENE_STAVKEDataSet dataSet, int oRG, int mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, int iDAKTIVNOST, int iDPARTNER, string dODATNIUVJET, short gODINA, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_FIN_OTVORENE_STAVKESet = dataSet;
            this.rowS_FIN_OTVORENE_STAVKE = this.S_FIN_OTVORENE_STAVKESet.S_FIN_OTVORENE_STAVKE.NewS_FIN_OTVORENE_STAVKERow();
            this.SetFillParameters(oRG, mT, dOK, rAZDOBLJEOD, rAZDOBLJEDO, pOCETNIKONTO, zAVRSNIKONTO, iDAKTIVNOST, iDPARTNER, dODATNIUVJET, gODINA);
            this.AV8ORG = oRG;
            this.AV9MT = mT;
            this.AV10DOK = dOK;
            this.AV11RAZDOB = DateTimeUtil.ResetTime(rAZDOBLJEOD);
            this.AV12RAZDOB = DateTimeUtil.ResetTime(rAZDOBLJEDO);
            this.AV13POCETN = pOCETNIKONTO;
            this.AV14ZAVRSN = zAVRSNIKONTO;
            this.AV15IDAKTI = iDAKTIVNOST;
            this.AV16IDPART = iDPARTNER;
            this.AV16PARTNEROIB = "";
            this.AV17DODATN = dODATNIUVJET;
            this.AV18GODINA = gODINA;
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
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "MT";
                parameter3.DbType = DbType.Int32;
                DbParameter parameter4 = factory.CreateParameter();
                parameter4.ParameterName = "DOK";
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
                parameter9.ParameterName = "IDAKTIVNOST";
                parameter9.DbType = DbType.Int32;
                
                DbParameter parameter10 = factory.CreateParameter();
                parameter10.ParameterName = "IDPARTNER";
                parameter10.DbType = DbType.Int32;

                DbParameter parameter12 = factory.CreateParameter();
                parameter12.ParameterName = "PARTNEROIB";
                parameter12.DbType = DbType.String;


                DbParameter parameter11 = factory.CreateParameter();
                parameter11.ParameterName = "DODATNIUVJET";
                parameter11.DbType = DbType.String;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "GODINA";
                parameter2.DbType = DbType.Int16;
                this.fillDataParameters = new DbParameter[] { parameter, parameter3, parameter4, parameter5, parameter6, parameter7, parameter8, parameter9, parameter10, parameter11, parameter2, parameter12 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(int oRG, int mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, int iDAKTIVNOST, int iDPARTNER, string dODATNIUVJET, short gODINA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_FIN_OTVORENE_STAVKESelect1 = this.connDefault.GetCommand("S_FIN_OTVORENE_STAVKE", true);
            this.cmS_FIN_OTVORENE_STAVKESelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_OTVORENE_STAVKESelect1.IDbCommand.Parameters.Clear();
            this.cmS_FIN_OTVORENE_STAVKESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ORG", oRG));
            this.cmS_FIN_OTVORENE_STAVKESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MT", mT));
            this.cmS_FIN_OTVORENE_STAVKESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOK", dOK));
            this.cmS_FIN_OTVORENE_STAVKESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEOD", rAZDOBLJEOD));
            this.cmS_FIN_OTVORENE_STAVKESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEDO", rAZDOBLJEDO));
            this.cmS_FIN_OTVORENE_STAVKESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POCETNIKONTO", pOCETNIKONTO));
            this.cmS_FIN_OTVORENE_STAVKESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAVRSNIKONTO", zAVRSNIKONTO));
            this.cmS_FIN_OTVORENE_STAVKESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", iDAKTIVNOST));
            this.cmS_FIN_OTVORENE_STAVKESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPARTNER", iDPARTNER));
            this.cmS_FIN_OTVORENE_STAVKESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DODATNIUVJET", dODATNIUVJET));
            this.cmS_FIN_OTVORENE_STAVKESelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINA", gODINA));
            this.cmS_FIN_OTVORENE_STAVKESelect1.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_OTVORENE_STAVKESelect1 = this.cmS_FIN_OTVORENE_STAVKESelect1.FetchData();
            if (this.S_FIN_OTVORENE_STAVKESelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_FIN_OTVORENE_STAVKESelect1.GetInt32(0);
            }
            this.S_FIN_OTVORENE_STAVKESelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(int oRG, int mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, int iDAKTIVNOST, int iDPARTNER, string dODATNIUVJET, short gODINA)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(oRG, mT, dOK, rAZDOBLJEOD, rAZDOBLJEDO, pOCETNIKONTO, zAVRSNIKONTO, iDAKTIVNOST, iDPARTNER, dODATNIUVJET, gODINA);
                num2 = this.GetInternalRecordCount(oRG, mT, dOK, rAZDOBLJEOD, rAZDOBLJEDO, pOCETNIKONTO, zAVRSNIKONTO, iDAKTIVNOST, iDPARTNER, dODATNIUVJET, gODINA);
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
            this.AV15IDAKTI = 0;
            this.AV16IDPART = 0;
            this.AV17DODATN = "";
            this.AV16PARTNEROIB = "";
            this.AV18GODINA = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(int oRG, int mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, int iDAKTIVNOST, int iDPARTNER, string dODATNIUVJET, short gODINA)
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
                this.fillDataParameters[7].Value = iDAKTIVNOST;
                this.fillDataParameters[8].Value = iDPARTNER;
                this.fillDataParameters[9].Value = dODATNIUVJET;
                this.fillDataParameters[10].Value = gODINA;
                this.fillDataParameters[11].Value = " ";
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

