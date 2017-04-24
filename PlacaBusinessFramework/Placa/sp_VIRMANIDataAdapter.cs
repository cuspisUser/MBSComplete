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

    public class sp_VIRMANIDataAdapter : IDataAdapter, Isp_VIRMANIDataAdapter
    {
        private string AV10porezi;
        private string AV11pl1;
        private string AV12pl2;
        private string AV13pl3;
        private string AV14vbd;
        private string AV15zrn;
        private string AV16mb;
        private string AV17dd;
        private string AV8IDOBRAC;
        private string AV9zaduzen;
        private ReadWriteCommand cmsp_VIRMANISelect1;
        private ReadWriteCommand cmsp_VIRMANISelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private sp_VIRMANIDataSet.sp_VIRMANIRow rowsp_VIRMANI;
        private IDataReader sp_VIRMANISelect1;
        private IDataReader sp_VIRMANISelect2;
        private sp_VIRMANIDataSet sp_VIRMANISet;

        private void AddRowSp_virmani()
        {
            this.sp_VIRMANISet.sp_VIRMANI.Addsp_VIRMANIRow(this.rowsp_VIRMANI);
            this.rowsp_VIRMANI.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmsp_VIRMANISelect2 = this.connDefault.GetCommand("S_VIRMANI", true);
            this.cmsp_VIRMANISelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_VIRMANISelect2.IDbCommand.Parameters.Clear();
            this.cmsp_VIRMANISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", this.AV8IDOBRAC));
            this.cmsp_VIRMANISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@zaduzenje", this.AV9zaduzen));
            this.cmsp_VIRMANISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@poreziprirezodvojeno", this.AV10porezi));
            this.cmsp_VIRMANISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@pl1", this.AV11pl1));
            this.cmsp_VIRMANISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@pl2", this.AV12pl2));
            this.cmsp_VIRMANISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@pl3", this.AV13pl3));
            this.cmsp_VIRMANISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@vbd", this.AV14vbd));
            this.cmsp_VIRMANISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@zrn", this.AV15zrn));
            this.cmsp_VIRMANISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@mb", this.AV16mb));
            this.cmsp_VIRMANISelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@dd", this.AV17dd));
            this.cmsp_VIRMANISelect2.ErrorMask |= ErrorMask.Lock;
            this.sp_VIRMANISelect2 = this.cmsp_VIRMANISelect2.FetchData();
            while (this.cmsp_VIRMANISelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmsp_VIRMANISelect2.HasMoreRows = this.sp_VIRMANISelect2.Read();
            }
            int num = 0;
            while (this.cmsp_VIRMANISelect2.HasMoreRows && (num != maxRows))
            {
                this.rowsp_VIRMANI["SIFRAOBRACUNAVIRMAN"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["SIFRAOBRACUNAVIRMAN"]);
                this.rowsp_VIRMANI["PLA1"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["PLA1"]);
                this.rowsp_VIRMANI["PLA2"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["PLA2"]);
                this.rowsp_VIRMANI["PLA3"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["PLA3"]);
                this.rowsp_VIRMANI["BROJRACUNAPLA"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["BROJRACUNAPLA"]);
                this.rowsp_VIRMANI["MODELZADUZENJA"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["MODELZADUZENJA"]);
                this.rowsp_VIRMANI["POZIVZADUZENJA"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["POZIVZADUZENJA"]);
                this.rowsp_VIRMANI["PRI1"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["PRI1"]);
                this.rowsp_VIRMANI["PRI2"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["PRI2"]);
                this.rowsp_VIRMANI["PRI3"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["PRI3"]);
                this.rowsp_VIRMANI["BROJRACUNAPRI"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["BROJRACUNAPRI"]);
                this.rowsp_VIRMANI["MODELODOBRENJA"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["MODELODOBRENJA"]);
                this.rowsp_VIRMANI["POZIVODOBRENJA"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["POZIVODOBRENJA"]);
                this.rowsp_VIRMANI["SIFRAOPISAPLACANJAVIRMAN"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["SIFRAOPISAPLACANJAVIRMAN"]);
                this.rowsp_VIRMANI["OPISPLACANJAVIRMAN"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["OPISPLACANJAVIRMAN"]);
                this.rowsp_VIRMANI["DATUMVALUTE"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["DATUMVALUTE"]);
                this.rowsp_VIRMANI["DATUMPODNOSENJA"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["DATUMPODNOSENJA"]);
                this.rowsp_VIRMANI["IZVORDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["IZVORDOKUMENTA"]);
                this.rowsp_VIRMANI["OZNACEN"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["OZNACEN"]);
                this.rowsp_VIRMANI["IZNOS"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["IZNOS"]);
                this.rowsp_VIRMANI["NAMJENA"] = RuntimeHelpers.GetObjectValue(this.sp_VIRMANISelect2["NAMJENA"]);
                this.AddRowSp_virmani();
                num++;
                this.rowsp_VIRMANI = this.sp_VIRMANISet.sp_VIRMANI.Newsp_VIRMANIRow();
                this.cmsp_VIRMANISelect2.HasMoreRows = this.sp_VIRMANISelect2.Read();
            }
            this.sp_VIRMANISelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(sp_VIRMANIDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), this.fillDataParameters[2].Value.ToString(), this.fillDataParameters[3].Value.ToString(), this.fillDataParameters[4].Value.ToString(), this.fillDataParameters[5].Value.ToString(), this.fillDataParameters[6].Value.ToString(), this.fillDataParameters[7].Value.ToString(), this.fillDataParameters[8].Value.ToString(), this.fillDataParameters[9].Value.ToString());
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.sp_VIRMANISet = (sp_VIRMANIDataSet) dataSet;
            if (this.sp_VIRMANISet != null)
            {
                return this.Fill(this.sp_VIRMANISet);
            }
            this.sp_VIRMANISet = new sp_VIRMANIDataSet();
            this.Fill(this.sp_VIRMANISet);
            dataSet.Merge(this.sp_VIRMANISet);
            return 0;
        }

        public virtual int Fill(sp_VIRMANIDataSet dataSet, string iDOBRACUN, string zaduzenje, string poreziprirezodvojeno, string pl1, string pl2, string pl3, string vbd, string zrn, string mb, string dd)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.sp_VIRMANISet = dataSet;
            this.rowsp_VIRMANI = this.sp_VIRMANISet.sp_VIRMANI.Newsp_VIRMANIRow();
            this.SetFillParameters(iDOBRACUN, zaduzenje, poreziprirezodvojeno, pl1, pl2, pl3, vbd, zrn, mb, dd);
            this.AV8IDOBRAC = iDOBRACUN;
            this.AV9zaduzen = zaduzenje;
            this.AV10porezi = poreziprirezodvojeno;
            this.AV11pl1 = pl1;
            this.AV12pl2 = pl2;
            this.AV13pl3 = pl3;
            this.AV14vbd = vbd;
            this.AV15zrn = zrn;
            this.AV16mb = mb;
            this.AV17dd = dd;
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

        public virtual int FillPage(sp_VIRMANIDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), this.fillDataParameters[2].Value.ToString(), this.fillDataParameters[3].Value.ToString(), this.fillDataParameters[4].Value.ToString(), this.fillDataParameters[5].Value.ToString(), this.fillDataParameters[6].Value.ToString(), this.fillDataParameters[7].Value.ToString(), this.fillDataParameters[8].Value.ToString(), this.fillDataParameters[9].Value.ToString(), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.sp_VIRMANISet = (sp_VIRMANIDataSet) dataSet;
            if (this.sp_VIRMANISet != null)
            {
                return this.FillPage(this.sp_VIRMANISet, startRow, maxRows);
            }
            this.sp_VIRMANISet = new sp_VIRMANIDataSet();
            this.FillPage(this.sp_VIRMANISet, startRow, maxRows);
            dataSet.Merge(this.sp_VIRMANISet);
            return 0;
        }

        public virtual int FillPage(sp_VIRMANIDataSet dataSet, string iDOBRACUN, string zaduzenje, string poreziprirezodvojeno, string pl1, string pl2, string pl3, string vbd, string zrn, string mb, string dd, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.sp_VIRMANISet = dataSet;
            this.rowsp_VIRMANI = this.sp_VIRMANISet.sp_VIRMANI.Newsp_VIRMANIRow();
            this.SetFillParameters(iDOBRACUN, zaduzenje, poreziprirezodvojeno, pl1, pl2, pl3, vbd, zrn, mb, dd);
            this.AV8IDOBRAC = iDOBRACUN;
            this.AV9zaduzen = zaduzenje;
            this.AV10porezi = poreziprirezodvojeno;
            this.AV11pl1 = pl1;
            this.AV12pl2 = pl2;
            this.AV13pl3 = pl3;
            this.AV14vbd = vbd;
            this.AV15zrn = zrn;
            this.AV16mb = mb;
            this.AV17dd = dd;
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
                parameter2.ParameterName = "zaduzenje";
                parameter2.DbType = DbType.String;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "poreziprirezodvojeno";
                parameter3.DbType = DbType.String;
                DbParameter parameter4 = factory.CreateParameter();
                parameter4.ParameterName = "pl1";
                parameter4.DbType = DbType.String;
                DbParameter parameter5 = factory.CreateParameter();
                parameter5.ParameterName = "pl2";
                parameter5.DbType = DbType.String;
                DbParameter parameter6 = factory.CreateParameter();
                parameter6.ParameterName = "pl3";
                parameter6.DbType = DbType.String;
                DbParameter parameter7 = factory.CreateParameter();
                parameter7.ParameterName = "vbd";
                parameter7.DbType = DbType.String;
                DbParameter parameter8 = factory.CreateParameter();
                parameter8.ParameterName = "zrn";
                parameter8.DbType = DbType.String;
                DbParameter parameter9 = factory.CreateParameter();
                parameter9.ParameterName = "mb";
                parameter9.DbType = DbType.String;
                DbParameter parameter10 = factory.CreateParameter();
                parameter10.ParameterName = "dd";
                parameter10.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, parameter8, parameter9, parameter10 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string iDOBRACUN, string zaduzenje, string poreziprirezodvojeno, string pl1, string pl2, string pl3, string vbd, string zrn, string mb, string dd)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmsp_VIRMANISelect1 = this.connDefault.GetCommand("S_VIRMANI", true);
            this.cmsp_VIRMANISelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_VIRMANISelect1.IDbCommand.Parameters.Clear();
            this.cmsp_VIRMANISelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", iDOBRACUN));
            this.cmsp_VIRMANISelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@zaduzenje", zaduzenje));
            this.cmsp_VIRMANISelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@poreziprirezodvojeno", poreziprirezodvojeno));
            this.cmsp_VIRMANISelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@pl1", pl1));
            this.cmsp_VIRMANISelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@pl2", pl2));
            this.cmsp_VIRMANISelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@pl3", pl3));
            this.cmsp_VIRMANISelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@vbd", vbd));
            this.cmsp_VIRMANISelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@zrn", zrn));
            this.cmsp_VIRMANISelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@mb", mb));
            this.cmsp_VIRMANISelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@dd", dd));
            this.cmsp_VIRMANISelect1.ErrorMask |= ErrorMask.Lock;
            this.sp_VIRMANISelect1 = this.cmsp_VIRMANISelect1.FetchData();
            if (this.sp_VIRMANISelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.sp_VIRMANISelect1.GetInt32(0);
            }
            this.sp_VIRMANISelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string iDOBRACUN, string zaduzenje, string poreziprirezodvojeno, string pl1, string pl2, string pl3, string vbd, string zrn, string mb, string dd)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(iDOBRACUN, zaduzenje, poreziprirezodvojeno, pl1, pl2, pl3, vbd, zrn, mb, dd);
                num2 = this.GetInternalRecordCount(iDOBRACUN, zaduzenje, poreziprirezodvojeno, pl1, pl2, pl3, vbd, zrn, mb, dd);
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
            this.AV9zaduzen = "";
            this.AV10porezi = "";
            this.AV11pl1 = "";
            this.AV12pl2 = "";
            this.AV13pl3 = "";
            this.AV14vbd = "";
            this.AV15zrn = "";
            this.AV16mb = "";
            this.AV17dd = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string iDOBRACUN, string zaduzenje, string poreziprirezodvojeno, string pl1, string pl2, string pl3, string vbd, string zrn, string mb, string dd)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = iDOBRACUN;
                this.fillDataParameters[1].Value = zaduzenje;
                this.fillDataParameters[2].Value = poreziprirezodvojeno;
                this.fillDataParameters[3].Value = pl1;
                this.fillDataParameters[4].Value = pl2;
                this.fillDataParameters[5].Value = pl3;
                this.fillDataParameters[6].Value = vbd;
                this.fillDataParameters[7].Value = zrn;
                this.fillDataParameters[8].Value = mb;
                this.fillDataParameters[9].Value = dd;
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

