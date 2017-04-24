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

    public class sp_REKAP_ISPLATADataAdapter : IDataAdapter, Isp_REKAP_ISPLATADataAdapter
    {
        private string AV8IDOBRAC;
        private string AV9VBDIBAN;
        private ReadWriteCommand cmsp_REKAP_ISPLATASelect1;
        private ReadWriteCommand cmsp_REKAP_ISPLATASelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private sp_REKAP_ISPLATADataSet.sp_REKAP_ISPLATARow rowsp_REKAP_ISPLATA;
        private IDataReader sp_REKAP_ISPLATASelect1;
        private IDataReader sp_REKAP_ISPLATASelect2;
        private sp_REKAP_ISPLATADataSet sp_REKAP_ISPLATASet;

        private void AddRowSp_rekap_isplata()
        {
            this.sp_REKAP_ISPLATASet.sp_REKAP_ISPLATA.Addsp_REKAP_ISPLATARow(this.rowsp_REKAP_ISPLATA);
            this.rowsp_REKAP_ISPLATA.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmsp_REKAP_ISPLATASelect2 = this.connDefault.GetCommand("S_PLACA_NA_RUKE_ISPLATA", true);
            this.cmsp_REKAP_ISPLATASelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_REKAP_ISPLATASelect2.IDbCommand.Parameters.Clear();
            this.cmsp_REKAP_ISPLATASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", this.AV8IDOBRAC));
            this.cmsp_REKAP_ISPLATASelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIBANKE", this.AV9VBDIBAN));
            this.cmsp_REKAP_ISPLATASelect2.ErrorMask |= ErrorMask.Lock;
            this.sp_REKAP_ISPLATASelect2 = this.cmsp_REKAP_ISPLATASelect2.FetchData();
            while (this.cmsp_REKAP_ISPLATASelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmsp_REKAP_ISPLATASelect2.HasMoreRows = this.sp_REKAP_ISPLATASelect2.Read();
            }
            int num = 0;
            while (this.cmsp_REKAP_ISPLATASelect2.HasMoreRows && (num != maxRows))
            {
                this.rowsp_REKAP_ISPLATA["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.sp_REKAP_ISPLATASelect2["IDRADNIK"]);
                this.rowsp_REKAP_ISPLATA["PREZIME"] = RuntimeHelpers.GetObjectValue(this.sp_REKAP_ISPLATASelect2["PREZIME"]);
                this.rowsp_REKAP_ISPLATA["IME"] = RuntimeHelpers.GetObjectValue(this.sp_REKAP_ISPLATASelect2["IME"]);
                this.rowsp_REKAP_ISPLATA["JMBG"] = RuntimeHelpers.GetObjectValue(this.sp_REKAP_ISPLATASelect2["JMBG"]);
                this.rowsp_REKAP_ISPLATA["TEKUCI"] = RuntimeHelpers.GetObjectValue(this.sp_REKAP_ISPLATASelect2["TEKUCI"]);
                this.rowsp_REKAP_ISPLATA["ZBIRNINETO"] = RuntimeHelpers.GetObjectValue(this.sp_REKAP_ISPLATASelect2["ZBIRNINETO"]);
                this.rowsp_REKAP_ISPLATA["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.sp_REKAP_ISPLATASelect2["VBDIBANKE"]);
                this.rowsp_REKAP_ISPLATA["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.sp_REKAP_ISPLATASelect2["ZRNBANKE"]);
                this.rowsp_REKAP_ISPLATA["IDBANKE"] = RuntimeHelpers.GetObjectValue(this.sp_REKAP_ISPLATASelect2["IDBANKE"]);
                this.rowsp_REKAP_ISPLATA["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.sp_REKAP_ISPLATASelect2["NAZIVBANKE1"]);
                this.rowsp_REKAP_ISPLATA["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.sp_REKAP_ISPLATASelect2["NAZIVBANKE2"]);
                this.rowsp_REKAP_ISPLATA["UKUPNOZAISPLATU"] = RuntimeHelpers.GetObjectValue(this.sp_REKAP_ISPLATASelect2["UKUPNOZAISPLATU"]);
                this.AddRowSp_rekap_isplata();
                num++;
                this.rowsp_REKAP_ISPLATA = this.sp_REKAP_ISPLATASet.sp_REKAP_ISPLATA.Newsp_REKAP_ISPLATARow();
                this.cmsp_REKAP_ISPLATASelect2.HasMoreRows = this.sp_REKAP_ISPLATASelect2.Read();
            }
            this.sp_REKAP_ISPLATASelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(sp_REKAP_ISPLATADataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString());
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.sp_REKAP_ISPLATASet = (sp_REKAP_ISPLATADataSet) dataSet;
            if (this.sp_REKAP_ISPLATASet != null)
            {
                return this.Fill(this.sp_REKAP_ISPLATASet);
            }
            this.sp_REKAP_ISPLATASet = new sp_REKAP_ISPLATADataSet();
            this.Fill(this.sp_REKAP_ISPLATASet);
            dataSet.Merge(this.sp_REKAP_ISPLATASet);
            return 0;
        }

        public virtual int Fill(sp_REKAP_ISPLATADataSet dataSet, string iDOBRACUN, string vBDIBANKE)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.sp_REKAP_ISPLATASet = dataSet;
            this.rowsp_REKAP_ISPLATA = this.sp_REKAP_ISPLATASet.sp_REKAP_ISPLATA.Newsp_REKAP_ISPLATARow();
            this.SetFillParameters(iDOBRACUN, vBDIBANKE);
            this.AV8IDOBRAC = iDOBRACUN;
            this.AV9VBDIBAN = vBDIBANKE;
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

        public virtual int FillPage(sp_REKAP_ISPLATADataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.sp_REKAP_ISPLATASet = (sp_REKAP_ISPLATADataSet) dataSet;
            if (this.sp_REKAP_ISPLATASet != null)
            {
                return this.FillPage(this.sp_REKAP_ISPLATASet, startRow, maxRows);
            }
            this.sp_REKAP_ISPLATASet = new sp_REKAP_ISPLATADataSet();
            this.FillPage(this.sp_REKAP_ISPLATASet, startRow, maxRows);
            dataSet.Merge(this.sp_REKAP_ISPLATASet);
            return 0;
        }

        public virtual int FillPage(sp_REKAP_ISPLATADataSet dataSet, string iDOBRACUN, string vBDIBANKE, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.sp_REKAP_ISPLATASet = dataSet;
            this.rowsp_REKAP_ISPLATA = this.sp_REKAP_ISPLATASet.sp_REKAP_ISPLATA.Newsp_REKAP_ISPLATARow();
            this.SetFillParameters(iDOBRACUN, vBDIBANKE);
            this.AV8IDOBRAC = iDOBRACUN;
            this.AV9VBDIBAN = vBDIBANKE;
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
                parameter2.ParameterName = "VBDIBANKE";
                parameter2.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string iDOBRACUN, string vBDIBANKE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmsp_REKAP_ISPLATASelect1 = this.connDefault.GetCommand("S_PLACA_NA_RUKE_ISPLATA", true);
            this.cmsp_REKAP_ISPLATASelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_REKAP_ISPLATASelect1.IDbCommand.Parameters.Clear();
            this.cmsp_REKAP_ISPLATASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", iDOBRACUN));
            this.cmsp_REKAP_ISPLATASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIBANKE", vBDIBANKE));
            this.cmsp_REKAP_ISPLATASelect1.ErrorMask |= ErrorMask.Lock;
            this.sp_REKAP_ISPLATASelect1 = this.cmsp_REKAP_ISPLATASelect1.FetchData();
            if (this.sp_REKAP_ISPLATASelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.sp_REKAP_ISPLATASelect1.GetInt32(0);
            }
            this.sp_REKAP_ISPLATASelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string iDOBRACUN, string vBDIBANKE)
        {
            int internalRecordCount;
            try
            {
                this.SetFillParameters(iDOBRACUN, vBDIBANKE);
                internalRecordCount = this.GetInternalRecordCount(iDOBRACUN, vBDIBANKE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCount;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.AV8IDOBRAC = "";
            this.AV9VBDIBAN = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string iDOBRACUN, string vBDIBANKE)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = iDOBRACUN;
                this.fillDataParameters[1].Value = vBDIBANKE;
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

