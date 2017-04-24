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

    public class sp_id_zaglavljeDataAdapter : IDataAdapter, Isp_id_zaglavljeDataAdapter
    {
        private string AV10GODINA;
        private short AV11VOLONT;
        private string AV8IDOBRAC;
        private string AV9MJESECI;
        private ReadWriteCommand cmsp_id_zaglavljeSelect1;
        private ReadWriteCommand cmsp_id_zaglavljeSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private sp_id_zaglavljeDataSet.sp_id_zaglavljeRow rowsp_id_zaglavlje;
        private IDataReader sp_id_zaglavljeSelect1;
        private IDataReader sp_id_zaglavljeSelect2;
        private sp_id_zaglavljeDataSet sp_id_zaglavljeSet;

        private void AddRowSp_id_zaglavlje()
        {
            this.sp_id_zaglavljeSet.sp_id_zaglavlje.Addsp_id_zaglavljeRow(this.rowsp_id_zaglavlje);
            this.rowsp_id_zaglavlje.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmsp_id_zaglavljeSelect2 = this.connDefault.GetCommand("S_PLACA_ID", true);
            this.cmsp_id_zaglavljeSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_id_zaglavljeSelect2.IDbCommand.Parameters.Clear();
            this.cmsp_id_zaglavljeSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", this.AV8IDOBRAC));
            this.cmsp_id_zaglavljeSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECISPLATE", this.AV9MJESECI));
            this.cmsp_id_zaglavljeSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAISPLATE", this.AV10GODINA));
            this.cmsp_id_zaglavljeSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VOLONTERI", this.AV11VOLONT));
            this.cmsp_id_zaglavljeSelect2.ErrorMask |= ErrorMask.Lock;
            this.sp_id_zaglavljeSelect2 = this.cmsp_id_zaglavljeSelect2.FetchData();
            while (this.cmsp_id_zaglavljeSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmsp_id_zaglavljeSelect2.HasMoreRows = this.sp_id_zaglavljeSelect2.Read();
            }
            int num = 0;
            while (this.cmsp_id_zaglavljeSelect2.HasMoreRows && (num != maxRows))
            {
                this.rowsp_id_zaglavlje["ididobrasca"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["ididobrasca"]);
                this.rowsp_id_zaglavlje["nazivfirme"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["nazivfirme"]);
                this.rowsp_id_zaglavlje["punaadresa"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["punaadresa"]);
                this.rowsp_id_zaglavlje["maticnibroj"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["maticnibroj"]);
                this.rowsp_id_zaglavlje["idenTIFIKATOR"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["idenTIFIKATOR"]);
                this.rowsp_id_zaglavlje["REDAK_II_1"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_II_1"]);
                this.rowsp_id_zaglavlje["REDAK_II_2"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_II_2"]);
                this.rowsp_id_zaglavlje["REDAK_II_2_1"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_II_2_1"]);
                this.rowsp_id_zaglavlje["REDAK_II_2_1_1"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_II_2_1_1"]);
                this.rowsp_id_zaglavlje["REDAK_II_2_1_2"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_II_2_1_2"]);
                this.rowsp_id_zaglavlje["REDAK_II_2_1_3"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_II_2_1_3"]);
                this.rowsp_id_zaglavlje["REDAK_II_2_2"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_II_2_2"]);
                this.rowsp_id_zaglavlje["REDAK_II_2_2_1"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_II_2_2_1"]);
                this.rowsp_id_zaglavlje["REDAK_II_2_2_2"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_II_2_2_2"]);
                this.rowsp_id_zaglavlje["REDAK_II_2_2_3"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_II_2_2_3"]);
                this.rowsp_id_zaglavlje["REDAK_II_3"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_II_3"]);
                this.rowsp_id_zaglavlje["REDAK_II_4"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_II_4"]);
                this.rowsp_id_zaglavlje["REDAK_II_5"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_II_5"]);
                this.rowsp_id_zaglavlje["REDAK_II_6"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_II_6"]);
                this.rowsp_id_zaglavlje["REDAK_II_6_1"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_II_6_1"]);
                this.rowsp_id_zaglavlje["REDAK_II_6_2"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_II_6_2"]);
                this.rowsp_id_zaglavlje["REDAK_II_7"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_II_7"]);
                this.rowsp_id_zaglavlje["REDAK_II_8"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_II_8"]);
                this.rowsp_id_zaglavlje["REDAK_III_1_1"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_III_1_1"]);
                this.rowsp_id_zaglavlje["REDAK_III_1_2"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_III_1_2"]);
                this.rowsp_id_zaglavlje["REDAK_III_2_1"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_III_2_1"]);
                this.rowsp_id_zaglavlje["REDAK_III_2_2"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_III_2_2"]);
                this.rowsp_id_zaglavlje["REDAK_III_3_1"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_III_3_1"]);
                this.rowsp_id_zaglavlje["REDAK_III_3_2"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_III_3_2"]);
                this.rowsp_id_zaglavlje["REDAK_III_3_3"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_III_3_3"]);
                this.rowsp_id_zaglavlje["REDAK_III_4_1"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_III_4_1"]);
                this.rowsp_id_zaglavlje["REDAK_III_4_2"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_III_4_2"]);
                this.rowsp_id_zaglavlje["REDAK_III_5"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["REDAK_III_5"]);
                this.rowsp_id_zaglavlje["DATUMSASTAVLJANJA"] = RuntimeHelpers.GetObjectValue(this.sp_id_zaglavljeSelect2["DATUMSASTAVLJANJA"]);
                this.AddRowSp_id_zaglavlje();
                num++;
                this.rowsp_id_zaglavlje = this.sp_id_zaglavljeSet.sp_id_zaglavlje.Newsp_id_zaglavljeRow();
                this.cmsp_id_zaglavljeSelect2.HasMoreRows = this.sp_id_zaglavljeSelect2.Read();
            }
            this.sp_id_zaglavljeSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(sp_id_zaglavljeDataSet dataSet)
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
            this.sp_id_zaglavljeSet = (sp_id_zaglavljeDataSet) dataSet;
            if (this.sp_id_zaglavljeSet != null)
            {
                return this.Fill(this.sp_id_zaglavljeSet);
            }
            this.sp_id_zaglavljeSet = new sp_id_zaglavljeDataSet();
            this.Fill(this.sp_id_zaglavljeSet);
            dataSet.Merge(this.sp_id_zaglavljeSet);
            return 0;
        }

        public virtual int Fill(sp_id_zaglavljeDataSet dataSet, string iDOBRACUN, string mJESECISPLATE, string gODINAISPLATE, short vOLONTERI)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.sp_id_zaglavljeSet = dataSet;
            this.rowsp_id_zaglavlje = this.sp_id_zaglavljeSet.sp_id_zaglavlje.Newsp_id_zaglavljeRow();
            this.SetFillParameters(iDOBRACUN, mJESECISPLATE, gODINAISPLATE, vOLONTERI);
            this.AV8IDOBRAC = iDOBRACUN;
            this.AV9MJESECI = mJESECISPLATE;
            this.AV10GODINA = gODINAISPLATE;
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

        public virtual int FillPage(sp_id_zaglavljeDataSet dataSet, int startRow, int maxRows)
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
            this.sp_id_zaglavljeSet = (sp_id_zaglavljeDataSet) dataSet;
            if (this.sp_id_zaglavljeSet != null)
            {
                return this.FillPage(this.sp_id_zaglavljeSet, startRow, maxRows);
            }
            this.sp_id_zaglavljeSet = new sp_id_zaglavljeDataSet();
            this.FillPage(this.sp_id_zaglavljeSet, startRow, maxRows);
            dataSet.Merge(this.sp_id_zaglavljeSet);
            return 0;
        }

        public virtual int FillPage(sp_id_zaglavljeDataSet dataSet, string iDOBRACUN, string mJESECISPLATE, string gODINAISPLATE, short vOLONTERI, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.sp_id_zaglavljeSet = dataSet;
            this.rowsp_id_zaglavlje = this.sp_id_zaglavljeSet.sp_id_zaglavlje.Newsp_id_zaglavljeRow();
            this.SetFillParameters(iDOBRACUN, mJESECISPLATE, gODINAISPLATE, vOLONTERI);
            this.AV8IDOBRAC = iDOBRACUN;
            this.AV9MJESECI = mJESECISPLATE;
            this.AV10GODINA = gODINAISPLATE;
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
                parameter.ParameterName = "IDOBRACUN";
                parameter.DbType = DbType.String;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "MJESECISPLATE";
                parameter2.DbType = DbType.String;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "GODINAISPLATE";
                parameter3.DbType = DbType.String;
                DbParameter parameter4 = factory.CreateParameter();
                parameter4.ParameterName = "VOLONTERI";
                parameter4.DbType = DbType.Int16;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3, parameter4 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string iDOBRACUN, string mJESECISPLATE, string gODINAISPLATE, short vOLONTERI)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmsp_id_zaglavljeSelect1 = this.connDefault.GetCommand("S_PLACA_ID", true);
            this.cmsp_id_zaglavljeSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_id_zaglavljeSelect1.IDbCommand.Parameters.Clear();
            this.cmsp_id_zaglavljeSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", iDOBRACUN));
            this.cmsp_id_zaglavljeSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECISPLATE", mJESECISPLATE));
            this.cmsp_id_zaglavljeSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAISPLATE", gODINAISPLATE));
            this.cmsp_id_zaglavljeSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VOLONTERI", vOLONTERI));
            this.cmsp_id_zaglavljeSelect1.ErrorMask |= ErrorMask.Lock;
            this.sp_id_zaglavljeSelect1 = this.cmsp_id_zaglavljeSelect1.FetchData();
            if (this.sp_id_zaglavljeSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.sp_id_zaglavljeSelect1.GetInt32(0);
            }
            this.sp_id_zaglavljeSelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string iDOBRACUN, string mJESECISPLATE, string gODINAISPLATE, short vOLONTERI)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(iDOBRACUN, mJESECISPLATE, gODINAISPLATE, vOLONTERI);
                num2 = this.GetInternalRecordCount(iDOBRACUN, mJESECISPLATE, gODINAISPLATE, vOLONTERI);
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
            this.AV9MJESECI = "";
            this.AV10GODINA = "";
            this.AV11VOLONT = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string iDOBRACUN, string mJESECISPLATE, string gODINAISPLATE, short vOLONTERI)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = iDOBRACUN;
                this.fillDataParameters[1].Value = mJESECISPLATE;
                this.fillDataParameters[2].Value = gODINAISPLATE;
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

