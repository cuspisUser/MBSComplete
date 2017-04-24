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

    public class sp_maticni_kartonDataAdapter : IDataAdapter, Isp_maticni_kartonDataAdapter
    {
        private int AV10idradn;
        private bool AV11zbirni;
        private bool AV12ukljuc;
        private bool AV13ukljuc;
        private bool AV14ukljuc;
        private bool AV15ukljuc;
        private bool AV16ukljuc;
        private bool AV17ukljuc;
        private bool AV18ukljuc;
        private bool AV19ukljuc;
        private bool AV20ukljuc;
        private bool AV21ukljuc;
        private string AV8godina;
        private int AV9idradni;
        private ReadWriteCommand cmsp_maticni_kartonSelect1;
        private ReadWriteCommand cmsp_maticni_kartonSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private sp_maticni_kartonDataSet.sp_maticni_kartonRow rowsp_maticni_karton;
        private IDataReader sp_maticni_kartonSelect1;
        private IDataReader sp_maticni_kartonSelect2;
        private sp_maticni_kartonDataSet sp_maticni_kartonSet;

        private void AddRowSp_maticni_karton()
        {
            this.sp_maticni_kartonSet.sp_maticni_karton.Addsp_maticni_kartonRow(this.rowsp_maticni_karton);
            this.rowsp_maticni_karton.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmsp_maticni_kartonSelect2 = this.connDefault.GetCommand("S_PLACA_MATICNI_KARTON_ZAPOSLENIKA_ILI_USTANOVE", true);
            this.cmsp_maticni_kartonSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_maticni_kartonSelect2.IDbCommand.Parameters.Clear();
            this.cmsp_maticni_kartonSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godina", this.AV8godina));
            this.cmsp_maticni_kartonSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idradnik_od", this.AV9idradni));
            this.cmsp_maticni_kartonSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idradnik_do", this.AV10idradn));
            this.cmsp_maticni_kartonSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@zbirni", this.AV11zbirni));
            this.cmsp_maticni_kartonSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenobruto", this.AV12ukljuc));
            this.cmsp_maticni_kartonSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenodoprinosiiz", this.AV13ukljuc));
            this.cmsp_maticni_kartonSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenodoprinosina", this.AV14ukljuc));
            this.cmsp_maticni_kartonSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenoporezi", this.AV15ukljuc));
            this.cmsp_maticni_kartonSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenooo", this.AV16ukljuc));
            this.cmsp_maticni_kartonSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenoobustave", this.AV17ukljuc));
            this.cmsp_maticni_kartonSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenoolaksice", this.AV18ukljuc));
            this.cmsp_maticni_kartonSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenonetoplaca", this.AV19ukljuc));
            this.cmsp_maticni_kartonSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenonetonaknade", this.AV20ukljuc));
            this.cmsp_maticni_kartonSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenoisplata", this.AV21ukljuc));
            this.cmsp_maticni_kartonSelect2.ErrorMask |= ErrorMask.Lock;
            this.sp_maticni_kartonSelect2 = this.cmsp_maticni_kartonSelect2.FetchData();
            while (this.cmsp_maticni_kartonSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmsp_maticni_kartonSelect2.HasMoreRows = this.sp_maticni_kartonSelect2.Read();
            }
            int num = 0;
            while (this.cmsp_maticni_kartonSelect2.HasMoreRows && (num != maxRows))
            {
                this.rowsp_maticni_karton["tip"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["tip"]);
                this.rowsp_maticni_karton["opistip"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["opistip"]);
                this.rowsp_maticni_karton["vrstavrij"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["vrstavrij"]);
                this.rowsp_maticni_karton["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["idradnik"]);
                this.rowsp_maticni_karton["PREZIME"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["prezime"]);
                this.rowsp_maticni_karton["IME"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["ime"]);
                this.rowsp_maticni_karton["JMBG"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["jmbg"]);
                this.rowsp_maticni_karton["idpodatka"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["idpodatka"]);
                this.rowsp_maticni_karton["nazivpodatka"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["nazivpodatka"]);
                this.rowsp_maticni_karton["mj01"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["mj01"]);
                this.rowsp_maticni_karton["mj02"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["mj02"]);
                this.rowsp_maticni_karton["mj03"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["mj03"]);
                this.rowsp_maticni_karton["mj04"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["mj04"]);
                this.rowsp_maticni_karton["mj05"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["mj05"]);
                this.rowsp_maticni_karton["mj06"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["mj06"]);
                this.rowsp_maticni_karton["mj07"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["mj07"]);
                this.rowsp_maticni_karton["mj08"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["mj08"]);
                this.rowsp_maticni_karton["mj09"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["mj09"]);
                this.rowsp_maticni_karton["mj10"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["mj10"]);
                this.rowsp_maticni_karton["mj11"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["mj11"]);
                this.rowsp_maticni_karton["mj12"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["mj12"]);
                this.rowsp_maticni_karton["UKUPNO"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["ukupno"]);
                this.rowsp_maticni_karton["sati01"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["sati01"]);
                this.rowsp_maticni_karton["sati02"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["sati02"]);
                this.rowsp_maticni_karton["sati03"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["sati03"]);
                this.rowsp_maticni_karton["sati04"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["sati04"]);
                this.rowsp_maticni_karton["sati05"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["sati05"]);
                this.rowsp_maticni_karton["sati06"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["sati06"]);
                this.rowsp_maticni_karton["sati07"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["sati07"]);
                this.rowsp_maticni_karton["sati08"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["sati08"]);
                this.rowsp_maticni_karton["sati09"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["sati09"]);
                this.rowsp_maticni_karton["sati10"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["sati10"]);
                this.rowsp_maticni_karton["sati11"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["sati11"]);
                this.rowsp_maticni_karton["sati12"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["sati12"]);
                this.rowsp_maticni_karton["ukupnosati"] = RuntimeHelpers.GetObjectValue(this.sp_maticni_kartonSelect2["ukupnosati"]);
                this.AddRowSp_maticni_karton();
                num++;
                this.rowsp_maticni_karton = this.sp_maticni_kartonSet.sp_maticni_karton.Newsp_maticni_kartonRow();
                this.cmsp_maticni_kartonSelect2.HasMoreRows = this.sp_maticni_kartonSelect2.Read();
            }
            this.sp_maticni_kartonSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(sp_maticni_kartonDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, this.fillDataParameters[0].Value.ToString(), int.Parse(this.fillDataParameters[1].Value.ToString()), int.Parse(this.fillDataParameters[2].Value.ToString()), bool.Parse(this.fillDataParameters[3].Value.ToString()), bool.Parse(this.fillDataParameters[4].Value.ToString()), bool.Parse(this.fillDataParameters[5].Value.ToString()), bool.Parse(this.fillDataParameters[6].Value.ToString()), bool.Parse(this.fillDataParameters[7].Value.ToString()), bool.Parse(this.fillDataParameters[8].Value.ToString()), bool.Parse(this.fillDataParameters[9].Value.ToString()), bool.Parse(this.fillDataParameters[10].Value.ToString()), bool.Parse(this.fillDataParameters[11].Value.ToString()), bool.Parse(this.fillDataParameters[12].Value.ToString()), bool.Parse(this.fillDataParameters[13].Value.ToString()));
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.sp_maticni_kartonSet = (sp_maticni_kartonDataSet) dataSet;
            if (this.sp_maticni_kartonSet != null)
            {
                return this.Fill(this.sp_maticni_kartonSet);
            }
            this.sp_maticni_kartonSet = new sp_maticni_kartonDataSet();
            this.Fill(this.sp_maticni_kartonSet);
            dataSet.Merge(this.sp_maticni_kartonSet);
            return 0;
        }

        public virtual int Fill(sp_maticni_kartonDataSet dataSet, string godina, int idradnik_od, int idradnik_do, bool zbirni, bool ukljucenobruto, bool ukljucenodoprinosiiz, bool ukljucenodoprinosina, bool ukljucenoporezi, bool ukljucenooo, bool ukljucenoobustave, bool ukljucenoolaksice, bool ukljucenonetoplaca, bool ukljucenonetonaknade, bool ukljucenoisplata)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.sp_maticni_kartonSet = dataSet;
            this.rowsp_maticni_karton = this.sp_maticni_kartonSet.sp_maticni_karton.Newsp_maticni_kartonRow();
            this.SetFillParameters(godina, idradnik_od, idradnik_do, zbirni, ukljucenobruto, ukljucenodoprinosiiz, ukljucenodoprinosina, ukljucenoporezi, ukljucenooo, ukljucenoobustave, ukljucenoolaksice, ukljucenonetoplaca, ukljucenonetonaknade, ukljucenoisplata);
            this.AV8godina = godina;
            this.AV9idradni = idradnik_od;
            this.AV10idradn = idradnik_do;
            this.AV11zbirni = zbirni;
            this.AV12ukljuc = ukljucenobruto;
            this.AV13ukljuc = ukljucenodoprinosiiz;
            this.AV14ukljuc = ukljucenodoprinosina;
            this.AV15ukljuc = ukljucenoporezi;
            this.AV16ukljuc = ukljucenooo;
            this.AV17ukljuc = ukljucenoobustave;
            this.AV18ukljuc = ukljucenoolaksice;
            this.AV19ukljuc = ukljucenonetoplaca;
            this.AV20ukljuc = ukljucenonetonaknade;
            this.AV21ukljuc = ukljucenoisplata;
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

        public virtual int FillPage(sp_maticni_kartonDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, this.fillDataParameters[0].Value.ToString(), int.Parse(this.fillDataParameters[1].Value.ToString()), int.Parse(this.fillDataParameters[2].Value.ToString()), bool.Parse(this.fillDataParameters[3].Value.ToString()), bool.Parse(this.fillDataParameters[4].Value.ToString()), bool.Parse(this.fillDataParameters[5].Value.ToString()), bool.Parse(this.fillDataParameters[6].Value.ToString()), bool.Parse(this.fillDataParameters[7].Value.ToString()), bool.Parse(this.fillDataParameters[8].Value.ToString()), bool.Parse(this.fillDataParameters[9].Value.ToString()), bool.Parse(this.fillDataParameters[10].Value.ToString()), bool.Parse(this.fillDataParameters[11].Value.ToString()), bool.Parse(this.fillDataParameters[12].Value.ToString()), bool.Parse(this.fillDataParameters[13].Value.ToString()), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.sp_maticni_kartonSet = (sp_maticni_kartonDataSet) dataSet;
            if (this.sp_maticni_kartonSet != null)
            {
                return this.FillPage(this.sp_maticni_kartonSet, startRow, maxRows);
            }
            this.sp_maticni_kartonSet = new sp_maticni_kartonDataSet();
            this.FillPage(this.sp_maticni_kartonSet, startRow, maxRows);
            dataSet.Merge(this.sp_maticni_kartonSet);
            return 0;
        }

        public virtual int FillPage(sp_maticni_kartonDataSet dataSet, string godina, int idradnik_od, int idradnik_do, bool zbirni, bool ukljucenobruto, bool ukljucenodoprinosiiz, bool ukljucenodoprinosina, bool ukljucenoporezi, bool ukljucenooo, bool ukljucenoobustave, bool ukljucenoolaksice, bool ukljucenonetoplaca, bool ukljucenonetonaknade, bool ukljucenoisplata, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.sp_maticni_kartonSet = dataSet;
            this.rowsp_maticni_karton = this.sp_maticni_kartonSet.sp_maticni_karton.Newsp_maticni_kartonRow();
            this.SetFillParameters(godina, idradnik_od, idradnik_do, zbirni, ukljucenobruto, ukljucenodoprinosiiz, ukljucenodoprinosina, ukljucenoporezi, ukljucenooo, ukljucenoobustave, ukljucenoolaksice, ukljucenonetoplaca, ukljucenonetonaknade, ukljucenoisplata);
            this.AV8godina = godina;
            this.AV9idradni = idradnik_od;
            this.AV10idradn = idradnik_do;
            this.AV11zbirni = zbirni;
            this.AV12ukljuc = ukljucenobruto;
            this.AV13ukljuc = ukljucenodoprinosiiz;
            this.AV14ukljuc = ukljucenodoprinosina;
            this.AV15ukljuc = ukljucenoporezi;
            this.AV16ukljuc = ukljucenooo;
            this.AV17ukljuc = ukljucenoobustave;
            this.AV18ukljuc = ukljucenoolaksice;
            this.AV19ukljuc = ukljucenonetoplaca;
            this.AV20ukljuc = ukljucenonetonaknade;
            this.AV21ukljuc = ukljucenoisplata;
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
                parameter.ParameterName = "godina";
                parameter.DbType = DbType.String;
                DbParameter parameter6 = factory.CreateParameter();
                parameter6.ParameterName = "idradnik_od";
                parameter6.DbType = DbType.Int32;
                DbParameter parameter7 = factory.CreateParameter();
                parameter7.ParameterName = "idradnik_do";
                parameter7.DbType = DbType.Int32;
                DbParameter parameter8 = factory.CreateParameter();
                parameter8.ParameterName = "zbirni";
                parameter8.DbType = DbType.Boolean;
                DbParameter parameter9 = factory.CreateParameter();
                parameter9.ParameterName = "ukljucenobruto";
                parameter9.DbType = DbType.Boolean;
                DbParameter parameter10 = factory.CreateParameter();
                parameter10.ParameterName = "ukljucenodoprinosiiz";
                parameter10.DbType = DbType.Boolean;
                DbParameter parameter11 = factory.CreateParameter();
                parameter11.ParameterName = "ukljucenodoprinosina";
                parameter11.DbType = DbType.Boolean;
                DbParameter parameter12 = factory.CreateParameter();
                parameter12.ParameterName = "ukljucenoporezi";
                parameter12.DbType = DbType.Boolean;
                DbParameter parameter13 = factory.CreateParameter();
                parameter13.ParameterName = "ukljucenooo";
                parameter13.DbType = DbType.Boolean;
                DbParameter parameter14 = factory.CreateParameter();
                parameter14.ParameterName = "ukljucenoobustave";
                parameter14.DbType = DbType.Boolean;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "ukljucenoolaksice";
                parameter2.DbType = DbType.Boolean;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "ukljucenonetoplaca";
                parameter3.DbType = DbType.Boolean;
                DbParameter parameter4 = factory.CreateParameter();
                parameter4.ParameterName = "ukljucenonetonaknade";
                parameter4.DbType = DbType.Boolean;
                DbParameter parameter5 = factory.CreateParameter();
                parameter5.ParameterName = "ukljucenoisplata";
                parameter5.DbType = DbType.Boolean;
                this.fillDataParameters = new DbParameter[] { parameter, parameter6, parameter7, parameter8, parameter9, parameter10, parameter11, parameter12, parameter13, parameter14, parameter2, parameter3, parameter4, parameter5 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string godina, int idradnik_od, int idradnik_do, bool zbirni, bool ukljucenobruto, bool ukljucenodoprinosiiz, bool ukljucenodoprinosina, bool ukljucenoporezi, bool ukljucenooo, bool ukljucenoobustave, bool ukljucenoolaksice, bool ukljucenonetoplaca, bool ukljucenonetonaknade, bool ukljucenoisplata)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmsp_maticni_kartonSelect1 = this.connDefault.GetCommand("S_PLACA_MATICNI_KARTON_ZAPOSLENIKA_ILI_USTANOVE", true);
            this.cmsp_maticni_kartonSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_maticni_kartonSelect1.IDbCommand.Parameters.Clear();
            this.cmsp_maticni_kartonSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godina", godina));
            this.cmsp_maticni_kartonSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idradnik_od", idradnik_od));
            this.cmsp_maticni_kartonSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idradnik_do", idradnik_do));
            this.cmsp_maticni_kartonSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@zbirni", zbirni));
            this.cmsp_maticni_kartonSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenobruto", ukljucenobruto));
            this.cmsp_maticni_kartonSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenodoprinosiiz", ukljucenodoprinosiiz));
            this.cmsp_maticni_kartonSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenodoprinosina", ukljucenodoprinosina));
            this.cmsp_maticni_kartonSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenoporezi", ukljucenoporezi));
            this.cmsp_maticni_kartonSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenooo", ukljucenooo));
            this.cmsp_maticni_kartonSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenoobustave", ukljucenoobustave));
            this.cmsp_maticni_kartonSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenoolaksice", ukljucenoolaksice));
            this.cmsp_maticni_kartonSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenonetoplaca", ukljucenonetoplaca));
            this.cmsp_maticni_kartonSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenonetonaknade", ukljucenonetonaknade));
            this.cmsp_maticni_kartonSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenoisplata", ukljucenoisplata));
            this.cmsp_maticni_kartonSelect1.ErrorMask |= ErrorMask.Lock;
            this.sp_maticni_kartonSelect1 = this.cmsp_maticni_kartonSelect1.FetchData();
            if (this.sp_maticni_kartonSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.sp_maticni_kartonSelect1.GetInt32(0);
            }
            this.sp_maticni_kartonSelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string godina, int idradnik_od, int idradnik_do, bool zbirni, bool ukljucenobruto, bool ukljucenodoprinosiiz, bool ukljucenodoprinosina, bool ukljucenoporezi, bool ukljucenooo, bool ukljucenoobustave, bool ukljucenoolaksice, bool ukljucenonetoplaca, bool ukljucenonetonaknade, bool ukljucenoisplata)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(godina, idradnik_od, idradnik_do, zbirni, ukljucenobruto, ukljucenodoprinosiiz, ukljucenodoprinosina, ukljucenoporezi, ukljucenooo, ukljucenoobustave, ukljucenoolaksice, ukljucenonetoplaca, ukljucenonetonaknade, ukljucenoisplata);
                num2 = this.GetInternalRecordCount(godina, idradnik_od, idradnik_do, zbirni, ukljucenobruto, ukljucenodoprinosiiz, ukljucenodoprinosina, ukljucenoporezi, ukljucenooo, ukljucenoobustave, ukljucenoolaksice, ukljucenonetoplaca, ukljucenonetonaknade, ukljucenoisplata);
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
            this.AV8godina = "";
            this.AV9idradni = 0;
            this.AV10idradn = 0;
            this.AV11zbirni = false;
            this.AV12ukljuc = false;
            this.AV13ukljuc = false;
            this.AV14ukljuc = false;
            this.AV15ukljuc = false;
            this.AV16ukljuc = false;
            this.AV17ukljuc = false;
            this.AV18ukljuc = false;
            this.AV19ukljuc = false;
            this.AV20ukljuc = false;
            this.AV21ukljuc = false;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string godina, int idradnik_od, int idradnik_do, bool zbirni, bool ukljucenobruto, bool ukljucenodoprinosiiz, bool ukljucenodoprinosina, bool ukljucenoporezi, bool ukljucenooo, bool ukljucenoobustave, bool ukljucenoolaksice, bool ukljucenonetoplaca, bool ukljucenonetonaknade, bool ukljucenoisplata)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = godina;
                this.fillDataParameters[1].Value = idradnik_od;
                this.fillDataParameters[2].Value = idradnik_do;
                this.fillDataParameters[3].Value = zbirni;
                this.fillDataParameters[4].Value = ukljucenobruto;
                this.fillDataParameters[5].Value = ukljucenodoprinosiiz;
                this.fillDataParameters[6].Value = ukljucenodoprinosina;
                this.fillDataParameters[7].Value = ukljucenoporezi;
                this.fillDataParameters[8].Value = ukljucenooo;
                this.fillDataParameters[9].Value = ukljucenoobustave;
                this.fillDataParameters[10].Value = ukljucenoolaksice;
                this.fillDataParameters[11].Value = ukljucenonetoplaca;
                this.fillDataParameters[12].Value = ukljucenonetonaknade;
                this.fillDataParameters[13].Value = ukljucenoisplata;
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

