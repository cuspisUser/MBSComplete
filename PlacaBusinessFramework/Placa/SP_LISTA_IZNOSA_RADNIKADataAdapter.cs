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

    public class SP_LISTA_IZNOSA_RADNIKADataAdapter : IDataAdapter, ISP_LISTA_IZNOSA_RADNIKADataAdapter
    {
        private string AV10GODINA;
        private int AV11SORT;
        private string AV8IDOBRAC;
        private string AV9MJESECO;
        private ReadWriteCommand cmSP_LISTA_IZNOSA_RADNIKASelect1;
        private ReadWriteCommand cmSP_LISTA_IZNOSA_RADNIKASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private SP_LISTA_IZNOSA_RADNIKADataSet.SP_LISTA_IZNOSA_RADNIKARow rowSP_LISTA_IZNOSA_RADNIKA;
        private IDataReader SP_LISTA_IZNOSA_RADNIKASelect1;
        private IDataReader SP_LISTA_IZNOSA_RADNIKASelect2;
        private SP_LISTA_IZNOSA_RADNIKADataSet SP_LISTA_IZNOSA_RADNIKASet;

        private void AddRowSp_lista_iznosa_radnika()
        {
            this.SP_LISTA_IZNOSA_RADNIKASet.SP_LISTA_IZNOSA_RADNIKA.AddSP_LISTA_IZNOSA_RADNIKARow(this.rowSP_LISTA_IZNOSA_RADNIKA);
            this.rowSP_LISTA_IZNOSA_RADNIKA.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmSP_LISTA_IZNOSA_RADNIKASelect2 = this.connDefault.GetCommand("S_PLACA_IZNOSI_PO_ZAPOSLENIKU", true);
            this.cmSP_LISTA_IZNOSA_RADNIKASelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmSP_LISTA_IZNOSA_RADNIKASelect2.IDbCommand.Parameters.Clear();
            this.cmSP_LISTA_IZNOSA_RADNIKASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", this.AV8IDOBRAC));
            this.cmSP_LISTA_IZNOSA_RADNIKASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECOBRACUNA", this.AV9MJESECO));
            this.cmSP_LISTA_IZNOSA_RADNIKASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAOBRACUNA", this.AV10GODINA));
            this.cmSP_LISTA_IZNOSA_RADNIKASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SORT", this.AV11SORT));
            this.cmSP_LISTA_IZNOSA_RADNIKASelect2.ErrorMask |= ErrorMask.Lock;
            this.SP_LISTA_IZNOSA_RADNIKASelect2 = this.cmSP_LISTA_IZNOSA_RADNIKASelect2.FetchData();
            while (this.cmSP_LISTA_IZNOSA_RADNIKASelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmSP_LISTA_IZNOSA_RADNIKASelect2.HasMoreRows = this.SP_LISTA_IZNOSA_RADNIKASelect2.Read();
            }
            int num = 0;
            while (this.cmSP_LISTA_IZNOSA_RADNIKASelect2.HasMoreRows && (num != maxRows))
            {
                this.rowSP_LISTA_IZNOSA_RADNIKA["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.SP_LISTA_IZNOSA_RADNIKASelect2["IDRADNIK"]);
                this.rowSP_LISTA_IZNOSA_RADNIKA["PREZIME"] = RuntimeHelpers.GetObjectValue(this.SP_LISTA_IZNOSA_RADNIKASelect2["PREZIME"]);
                this.rowSP_LISTA_IZNOSA_RADNIKA["IME"] = RuntimeHelpers.GetObjectValue(this.SP_LISTA_IZNOSA_RADNIKASelect2["IME"]);
                this.rowSP_LISTA_IZNOSA_RADNIKA["satibruto"] = RuntimeHelpers.GetObjectValue(this.SP_LISTA_IZNOSA_RADNIKASelect2["SATIBRUTO"]);
                this.rowSP_LISTA_IZNOSA_RADNIKA["ukupnobruto"] = RuntimeHelpers.GetObjectValue(this.SP_LISTA_IZNOSA_RADNIKASelect2["UKUPNOBRUTO"]);
                this.rowSP_LISTA_IZNOSA_RADNIKA["KOEFICIJENT"] = RuntimeHelpers.GetObjectValue(this.SP_LISTA_IZNOSA_RADNIKASelect2["KOEFICIJENT"]);
                this.rowSP_LISTA_IZNOSA_RADNIKA["ukupnodoprinosi"] = RuntimeHelpers.GetObjectValue(this.SP_LISTA_IZNOSA_RADNIKASelect2["UKUPNODOPRINOSI"]);
                this.rowSP_LISTA_IZNOSA_RADNIKA["ukupnoporeziprirez"] = RuntimeHelpers.GetObjectValue(this.SP_LISTA_IZNOSA_RADNIKASelect2["ukupnoporeziprirez"]);
                this.rowSP_LISTA_IZNOSA_RADNIKA["netoplaca"] = RuntimeHelpers.GetObjectValue(this.SP_LISTA_IZNOSA_RADNIKASelect2["NETOPLACA"]);
                this.rowSP_LISTA_IZNOSA_RADNIKA["ukupnonetonaknade"] = RuntimeHelpers.GetObjectValue(this.SP_LISTA_IZNOSA_RADNIKASelect2["UKUPNONETONAKNADE"]);
                this.rowSP_LISTA_IZNOSA_RADNIKA["netoprimanja"] = RuntimeHelpers.GetObjectValue(this.SP_LISTA_IZNOSA_RADNIKASelect2["NETOPRIMANJA"]);
                this.rowSP_LISTA_IZNOSA_RADNIKA["ukupnoobustave"] = RuntimeHelpers.GetObjectValue(this.SP_LISTA_IZNOSA_RADNIKASelect2["UKUPNOOBUSTAVE"]);
                this.rowSP_LISTA_IZNOSA_RADNIKA["UKUPNOZAISPLATU"] = RuntimeHelpers.GetObjectValue(this.SP_LISTA_IZNOSA_RADNIKASelect2["UKUPNOZAISPLATU"]);
                this.rowSP_LISTA_IZNOSA_RADNIKA["ukupnoolaksice"] = RuntimeHelpers.GetObjectValue(this.SP_LISTA_IZNOSA_RADNIKASelect2["UKUPNOOLAKSICE"]);
                this.rowSP_LISTA_IZNOSA_RADNIKA["UKUPNODOPRINOSINA"] = RuntimeHelpers.GetObjectValue(this.SP_LISTA_IZNOSA_RADNIKASelect2["UKUPNODOPRINOSINA"]);
                this.rowSP_LISTA_IZNOSA_RADNIKA["POREZKRIZNI"] = RuntimeHelpers.GetObjectValue(this.SP_LISTA_IZNOSA_RADNIKASelect2["porezkrizni"]);
                this.rowSP_LISTA_IZNOSA_RADNIKA["netoplacamanjekrizni"] = RuntimeHelpers.GetObjectValue(this.SP_LISTA_IZNOSA_RADNIKASelect2["netoplacamanjekrizni"]);
                this.AddRowSp_lista_iznosa_radnika();
                num++;
                this.rowSP_LISTA_IZNOSA_RADNIKA = this.SP_LISTA_IZNOSA_RADNIKASet.SP_LISTA_IZNOSA_RADNIKA.NewSP_LISTA_IZNOSA_RADNIKARow();
                this.cmSP_LISTA_IZNOSA_RADNIKASelect2.HasMoreRows = this.SP_LISTA_IZNOSA_RADNIKASelect2.Read();
            }
            this.SP_LISTA_IZNOSA_RADNIKASelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(SP_LISTA_IZNOSA_RADNIKADataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), this.fillDataParameters[2].Value.ToString(), int.Parse(this.fillDataParameters[3].Value.ToString()));
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.SP_LISTA_IZNOSA_RADNIKASet = (SP_LISTA_IZNOSA_RADNIKADataSet) dataSet;
            if (this.SP_LISTA_IZNOSA_RADNIKASet != null)
            {
                return this.Fill(this.SP_LISTA_IZNOSA_RADNIKASet);
            }
            this.SP_LISTA_IZNOSA_RADNIKASet = new SP_LISTA_IZNOSA_RADNIKADataSet();
            this.Fill(this.SP_LISTA_IZNOSA_RADNIKASet);
            dataSet.Merge(this.SP_LISTA_IZNOSA_RADNIKASet);
            return 0;
        }

        public virtual int Fill(SP_LISTA_IZNOSA_RADNIKADataSet dataSet, string iDOBRACUN, string mJESECOBRACUNA, string gODINAOBRACUNA, int sORT)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SP_LISTA_IZNOSA_RADNIKASet = dataSet;
            this.rowSP_LISTA_IZNOSA_RADNIKA = this.SP_LISTA_IZNOSA_RADNIKASet.SP_LISTA_IZNOSA_RADNIKA.NewSP_LISTA_IZNOSA_RADNIKARow();
            this.SetFillParameters(iDOBRACUN, mJESECOBRACUNA, gODINAOBRACUNA, sORT);
            this.AV8IDOBRAC = iDOBRACUN;
            this.AV9MJESECO = mJESECOBRACUNA;
            this.AV10GODINA = gODINAOBRACUNA;
            this.AV11SORT = sORT;
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

        public virtual int FillPage(SP_LISTA_IZNOSA_RADNIKADataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), this.fillDataParameters[2].Value.ToString(), int.Parse(this.fillDataParameters[3].Value.ToString()), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.SP_LISTA_IZNOSA_RADNIKASet = (SP_LISTA_IZNOSA_RADNIKADataSet) dataSet;
            if (this.SP_LISTA_IZNOSA_RADNIKASet != null)
            {
                return this.FillPage(this.SP_LISTA_IZNOSA_RADNIKASet, startRow, maxRows);
            }
            this.SP_LISTA_IZNOSA_RADNIKASet = new SP_LISTA_IZNOSA_RADNIKADataSet();
            this.FillPage(this.SP_LISTA_IZNOSA_RADNIKASet, startRow, maxRows);
            dataSet.Merge(this.SP_LISTA_IZNOSA_RADNIKASet);
            return 0;
        }

        public virtual int FillPage(SP_LISTA_IZNOSA_RADNIKADataSet dataSet, string iDOBRACUN, string mJESECOBRACUNA, string gODINAOBRACUNA, int sORT, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SP_LISTA_IZNOSA_RADNIKASet = dataSet;
            this.rowSP_LISTA_IZNOSA_RADNIKA = this.SP_LISTA_IZNOSA_RADNIKASet.SP_LISTA_IZNOSA_RADNIKA.NewSP_LISTA_IZNOSA_RADNIKARow();
            this.SetFillParameters(iDOBRACUN, mJESECOBRACUNA, gODINAOBRACUNA, sORT);
            this.AV8IDOBRAC = iDOBRACUN;
            this.AV9MJESECO = mJESECOBRACUNA;
            this.AV10GODINA = gODINAOBRACUNA;
            this.AV11SORT = sORT;
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
                parameter2.ParameterName = "MJESECOBRACUNA";
                parameter2.DbType = DbType.String;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "GODINAOBRACUNA";
                parameter3.DbType = DbType.String;
                DbParameter parameter4 = factory.CreateParameter();
                parameter4.ParameterName = "SORT";
                parameter4.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3, parameter4 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string iDOBRACUN, string mJESECOBRACUNA, string gODINAOBRACUNA, int sORT)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSP_LISTA_IZNOSA_RADNIKASelect1 = this.connDefault.GetCommand("S_PLACA_IZNOSI_PO_ZAPOSLENIKU", true);
            this.cmSP_LISTA_IZNOSA_RADNIKASelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmSP_LISTA_IZNOSA_RADNIKASelect1.IDbCommand.Parameters.Clear();
            this.cmSP_LISTA_IZNOSA_RADNIKASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", iDOBRACUN));
            this.cmSP_LISTA_IZNOSA_RADNIKASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECOBRACUNA", mJESECOBRACUNA));
            this.cmSP_LISTA_IZNOSA_RADNIKASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAOBRACUNA", gODINAOBRACUNA));
            this.cmSP_LISTA_IZNOSA_RADNIKASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SORT", sORT));
            this.cmSP_LISTA_IZNOSA_RADNIKASelect1.ErrorMask |= ErrorMask.Lock;
            this.SP_LISTA_IZNOSA_RADNIKASelect1 = this.cmSP_LISTA_IZNOSA_RADNIKASelect1.FetchData();
            if (this.SP_LISTA_IZNOSA_RADNIKASelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.SP_LISTA_IZNOSA_RADNIKASelect1.GetInt32(0);
            }
            this.SP_LISTA_IZNOSA_RADNIKASelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string iDOBRACUN, string mJESECOBRACUNA, string gODINAOBRACUNA, int sORT)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(iDOBRACUN, mJESECOBRACUNA, gODINAOBRACUNA, sORT);
                num2 = this.GetInternalRecordCount(iDOBRACUN, mJESECOBRACUNA, gODINAOBRACUNA, sORT);
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
            this.AV9MJESECO = "";
            this.AV10GODINA = "";
            this.AV11SORT = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string iDOBRACUN, string mJESECOBRACUNA, string gODINAOBRACUNA, int sORT)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = iDOBRACUN;
                this.fillDataParameters[1].Value = mJESECOBRACUNA;
                this.fillDataParameters[2].Value = gODINAOBRACUNA;
                this.fillDataParameters[3].Value = sORT;
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

