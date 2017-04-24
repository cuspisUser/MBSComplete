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

    public class sp_id_detaljiDataAdapter : IDataAdapter, Isp_id_detaljiDataAdapter
    {
        private string AV10godina;
        private short AV11VOLONT;
        private string AV8idobrac;
        private string AV9mjeseCI;
        private ReadWriteCommand cmsp_id_detaljiSelect1;
        private ReadWriteCommand cmsp_id_detaljiSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private sp_id_detaljiDataSet.sp_id_detaljiRow rowsp_id_detalji;
        private IDataReader sp_id_detaljiSelect1;
        private IDataReader sp_id_detaljiSelect2;
        private sp_id_detaljiDataSet sp_id_detaljiSet;

        private void AddRowSp_id_detalji()
        {
            this.sp_id_detaljiSet.sp_id_detalji.Addsp_id_detaljiRow(this.rowsp_id_detalji);
            this.rowsp_id_detalji.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmsp_id_detaljiSelect2 = this.connDefault.GetCommand("S_PLACA_ID_REDOVI", true);
            this.cmsp_id_detaljiSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_id_detaljiSelect2.IDbCommand.Parameters.Clear();
            this.cmsp_id_detaljiSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idobracun", this.AV8idobrac));
            this.cmsp_id_detaljiSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@mjeseCISPLATE", this.AV9mjeseCI));
            this.cmsp_id_detaljiSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godinaISPLATE", this.AV10godina));
            this.cmsp_id_detaljiSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VOLONTERI", this.AV11VOLONT));
            this.cmsp_id_detaljiSelect2.ErrorMask |= ErrorMask.Lock;
            this.sp_id_detaljiSelect2 = this.cmsp_id_detaljiSelect2.FetchData();
            while (this.cmsp_id_detaljiSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmsp_id_detaljiSelect2.HasMoreRows = this.sp_id_detaljiSelect2.Read();
            }
            int num = 0;
            while (this.cmsp_id_detaljiSelect2.HasMoreRows && (num != maxRows))
            {
                this.rowsp_id_detalji["ididobrasca"] = RuntimeHelpers.GetObjectValue(this.sp_id_detaljiSelect2["ididobrasca"]);
                this.rowsp_id_detalji["REDNIBROJ"] = RuntimeHelpers.GetObjectValue(this.sp_id_detaljiSelect2["rednibroj"]);
                this.rowsp_id_detalji["IDOPCINE"] = RuntimeHelpers.GetObjectValue(this.sp_id_detaljiSelect2["idopcine"]);
                this.rowsp_id_detalji["NAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(this.sp_id_detaljiSelect2["nazivopcine"]);
                this.rowsp_id_detalji["obracunaniporez"] = RuntimeHelpers.GetObjectValue(this.sp_id_detaljiSelect2["obracunaniporez"]);
                this.rowsp_id_detalji["obracunaniprirez"] = RuntimeHelpers.GetObjectValue(this.sp_id_detaljiSelect2["obracunaniprirez"]);
                this.rowsp_id_detalji["obracunanoukupno"] = RuntimeHelpers.GetObjectValue(this.sp_id_detaljiSelect2["obracunanoukupno"]);
                this.AddRowSp_id_detalji();
                num++;
                this.rowsp_id_detalji = this.sp_id_detaljiSet.sp_id_detalji.Newsp_id_detaljiRow();
                this.cmsp_id_detaljiSelect2.HasMoreRows = this.sp_id_detaljiSelect2.Read();
            }
            this.sp_id_detaljiSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(sp_id_detaljiDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), this.fillDataParameters[2].Value.ToString(), short.Parse(this.fillDataParameters[3].Value.ToString()));
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.sp_id_detaljiSet = (sp_id_detaljiDataSet) dataSet;
            if (this.sp_id_detaljiSet != null)
            {
                return this.Fill(this.sp_id_detaljiSet);
            }
            this.sp_id_detaljiSet = new sp_id_detaljiDataSet();
            this.Fill(this.sp_id_detaljiSet);
            dataSet.Merge(this.sp_id_detaljiSet);
            return 0;
        }

        public virtual int Fill(sp_id_detaljiDataSet dataSet, string idobracun, string mjeseCISPLATE, string godinaISPLATE, short vOLONTERI)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.sp_id_detaljiSet = dataSet;
            this.rowsp_id_detalji = this.sp_id_detaljiSet.sp_id_detalji.Newsp_id_detaljiRow();
            this.SetFillParameters(idobracun, mjeseCISPLATE, godinaISPLATE, vOLONTERI);
            this.AV8idobrac = idobracun;
            this.AV9mjeseCI = mjeseCISPLATE;
            this.AV10godina = godinaISPLATE;
            this.AV11VOLONT = vOLONTERI;
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

        public virtual int FillPage(sp_id_detaljiDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), this.fillDataParameters[2].Value.ToString(), short.Parse(this.fillDataParameters[3].Value.ToString()), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.sp_id_detaljiSet = (sp_id_detaljiDataSet) dataSet;
            if (this.sp_id_detaljiSet != null)
            {
                return this.FillPage(this.sp_id_detaljiSet, startRow, maxRows);
            }
            this.sp_id_detaljiSet = new sp_id_detaljiDataSet();
            this.FillPage(this.sp_id_detaljiSet, startRow, maxRows);
            dataSet.Merge(this.sp_id_detaljiSet);
            return 0;
        }

        public virtual int FillPage(sp_id_detaljiDataSet dataSet, string idobracun, string mjeseCISPLATE, string godinaISPLATE, short vOLONTERI, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.sp_id_detaljiSet = dataSet;
            this.rowsp_id_detalji = this.sp_id_detaljiSet.sp_id_detalji.Newsp_id_detaljiRow();
            this.SetFillParameters(idobracun, mjeseCISPLATE, godinaISPLATE, vOLONTERI);
            this.AV8idobrac = idobracun;
            this.AV9mjeseCI = mjeseCISPLATE;
            this.AV10godina = godinaISPLATE;
            this.AV11VOLONT = vOLONTERI;
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
                parameter.ParameterName = "idobracun";
                parameter.DbType = DbType.String;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "mjeseCISPLATE";
                parameter2.DbType = DbType.String;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "godinaISPLATE";
                parameter3.DbType = DbType.String;
                DbParameter parameter4 = factory.CreateParameter();
                parameter4.ParameterName = "VOLONTERI";
                parameter4.DbType = DbType.Int16;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3, parameter4 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string idobracun, string mjeseCISPLATE, string godinaISPLATE, short vOLONTERI)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmsp_id_detaljiSelect1 = this.connDefault.GetCommand("S_PLACA_ID_REDOVI", true);
            this.cmsp_id_detaljiSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_id_detaljiSelect1.IDbCommand.Parameters.Clear();
            this.cmsp_id_detaljiSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idobracun", idobracun));
            this.cmsp_id_detaljiSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@mjeseCISPLATE", mjeseCISPLATE));
            this.cmsp_id_detaljiSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godinaISPLATE", godinaISPLATE));
            this.cmsp_id_detaljiSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VOLONTERI", vOLONTERI));
            this.cmsp_id_detaljiSelect1.ErrorMask |= ErrorMask.Lock;
            this.sp_id_detaljiSelect1 = this.cmsp_id_detaljiSelect1.FetchData();
            if (this.sp_id_detaljiSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.sp_id_detaljiSelect1.GetInt32(0);
            }
            this.sp_id_detaljiSelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string idobracun, string mjeseCISPLATE, string godinaISPLATE, short vOLONTERI)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(idobracun, mjeseCISPLATE, godinaISPLATE, vOLONTERI);
                num2 = this.GetInternalRecordCount(idobracun, mjeseCISPLATE, godinaISPLATE, vOLONTERI);
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
            this.AV8idobrac = "";
            this.AV9mjeseCI = "";
            this.AV10godina = "";
            this.AV11VOLONT = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string idobracun, string mjeseCISPLATE, string godinaISPLATE, short vOLONTERI)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = idobracun;
                this.fillDataParameters[1].Value = mjeseCISPLATE;
                this.fillDataParameters[2].Value = godinaISPLATE;
                this.fillDataParameters[3].Value = vOLONTERI;
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

