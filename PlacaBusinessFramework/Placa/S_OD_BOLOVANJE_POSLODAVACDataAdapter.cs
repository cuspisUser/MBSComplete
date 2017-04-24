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

    public class S_OD_BOLOVANJE_POSLODAVACDataAdapter : IDataAdapter, IS_OD_BOLOVANJE_POSLODAVACDataAdapter
    {
        private int AV10IDRADN;
        private string AV8odd;
        private string AV9dooo;
        private ReadWriteCommand cmS_OD_BOLOVANJE_POSLODAVACSelect1;
        private ReadWriteCommand cmS_OD_BOLOVANJE_POSLODAVACSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private S_OD_BOLOVANJE_POSLODAVACDataSet.S_OD_BOLOVANJE_POSLODAVACRow rowS_OD_BOLOVANJE_POSLODAVAC;
        private IDataReader S_OD_BOLOVANJE_POSLODAVACSelect1;
        private IDataReader S_OD_BOLOVANJE_POSLODAVACSelect2;
        private S_OD_BOLOVANJE_POSLODAVACDataSet S_OD_BOLOVANJE_POSLODAVACSet;

        private void AddRowS_od_bolovanje_poslodavac()
        {
            this.S_OD_BOLOVANJE_POSLODAVACSet.S_OD_BOLOVANJE_POSLODAVAC.AddS_OD_BOLOVANJE_POSLODAVACRow(this.rowS_OD_BOLOVANJE_POSLODAVAC);
            this.rowS_OD_BOLOVANJE_POSLODAVAC.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cmS_OD_BOLOVANJE_POSLODAVACSelect2 = this.connDefault.GetCommand("S_PLACA_BOLOVANJE_POSLODAVAC", true);
            this.cmS_OD_BOLOVANJE_POSLODAVACSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_BOLOVANJE_POSLODAVACSelect2.IDbCommand.Parameters.Clear();
            this.cmS_OD_BOLOVANJE_POSLODAVACSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@odd", this.AV8odd));
            this.cmS_OD_BOLOVANJE_POSLODAVACSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@dooo", this.AV9dooo));
            this.cmS_OD_BOLOVANJE_POSLODAVACSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", this.AV10IDRADN));
            this.cmS_OD_BOLOVANJE_POSLODAVACSelect2.ErrorMask |= ErrorMask.Lock;
            this.S_OD_BOLOVANJE_POSLODAVACSelect2 = this.cmS_OD_BOLOVANJE_POSLODAVACSelect2.FetchData();
            while (this.cmS_OD_BOLOVANJE_POSLODAVACSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cmS_OD_BOLOVANJE_POSLODAVACSelect2.HasMoreRows = this.S_OD_BOLOVANJE_POSLODAVACSelect2.Read();
            }
            int num = 0;
            while (this.cmS_OD_BOLOVANJE_POSLODAVACSelect2.HasMoreRows && (num != maxRows))
            {
                this.rowS_OD_BOLOVANJE_POSLODAVAC["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_POSLODAVACSelect2["IDRADNIK"]);
                this.rowS_OD_BOLOVANJE_POSLODAVAC["PREZIME"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_POSLODAVACSelect2["PREZIME"]);
                this.rowS_OD_BOLOVANJE_POSLODAVAC["IME"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_POSLODAVACSelect2["IME"]);
                this.rowS_OD_BOLOVANJE_POSLODAVAC["IZNOSBRUTO"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_POSLODAVACSelect2["IZNOSBRUTO"]);
                this.rowS_OD_BOLOVANJE_POSLODAVAC["SATIUKUPNO"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_POSLODAVACSelect2["SATIUKUPNO"]);
                this.rowS_OD_BOLOVANJE_POSLODAVAC["GODINAMJESEC"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_POSLODAVACSelect2["GODINAMJESEC"]);
                this.rowS_OD_BOLOVANJE_POSLODAVAC["PROSJECNASATNICA"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_POSLODAVACSelect2["PROSJECNASATNICA"]);
                this.rowS_OD_BOLOVANJE_POSLODAVAC["PROSJECNASATNICA_85POSTO"] = RuntimeHelpers.GetObjectValue(this.S_OD_BOLOVANJE_POSLODAVACSelect2["PROSJECNASATNICA_85POSTO"]);
                this.AddRowS_od_bolovanje_poslodavac();
                num++;
                this.rowS_OD_BOLOVANJE_POSLODAVAC = this.S_OD_BOLOVANJE_POSLODAVACSet.S_OD_BOLOVANJE_POSLODAVAC.NewS_OD_BOLOVANJE_POSLODAVACRow();
                this.cmS_OD_BOLOVANJE_POSLODAVACSelect2.HasMoreRows = this.S_OD_BOLOVANJE_POSLODAVACSelect2.Read();
            }
            this.S_OD_BOLOVANJE_POSLODAVACSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(S_OD_BOLOVANJE_POSLODAVACDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), int.Parse(this.fillDataParameters[2].Value.ToString()));
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.S_OD_BOLOVANJE_POSLODAVACSet = (S_OD_BOLOVANJE_POSLODAVACDataSet) dataSet;
            if (this.S_OD_BOLOVANJE_POSLODAVACSet != null)
            {
                return this.Fill(this.S_OD_BOLOVANJE_POSLODAVACSet);
            }
            this.S_OD_BOLOVANJE_POSLODAVACSet = new S_OD_BOLOVANJE_POSLODAVACDataSet();
            this.Fill(this.S_OD_BOLOVANJE_POSLODAVACSet);
            dataSet.Merge(this.S_OD_BOLOVANJE_POSLODAVACSet);
            return 0;
        }

        public virtual int Fill(S_OD_BOLOVANJE_POSLODAVACDataSet dataSet, string odd, string dooo, int iDRADNIK)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_BOLOVANJE_POSLODAVACSet = dataSet;
            this.rowS_OD_BOLOVANJE_POSLODAVAC = this.S_OD_BOLOVANJE_POSLODAVACSet.S_OD_BOLOVANJE_POSLODAVAC.NewS_OD_BOLOVANJE_POSLODAVACRow();
            this.SetFillParameters(odd, dooo, iDRADNIK);
            this.AV8odd = odd;
            this.AV9dooo = dooo;
            this.AV10IDRADN = iDRADNIK;
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

        public virtual int FillPage(S_OD_BOLOVANJE_POSLODAVACDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, this.fillDataParameters[0].Value.ToString(), this.fillDataParameters[1].Value.ToString(), int.Parse(this.fillDataParameters[2].Value.ToString()), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.S_OD_BOLOVANJE_POSLODAVACSet = (S_OD_BOLOVANJE_POSLODAVACDataSet) dataSet;
            if (this.S_OD_BOLOVANJE_POSLODAVACSet != null)
            {
                return this.FillPage(this.S_OD_BOLOVANJE_POSLODAVACSet, startRow, maxRows);
            }
            this.S_OD_BOLOVANJE_POSLODAVACSet = new S_OD_BOLOVANJE_POSLODAVACDataSet();
            this.FillPage(this.S_OD_BOLOVANJE_POSLODAVACSet, startRow, maxRows);
            dataSet.Merge(this.S_OD_BOLOVANJE_POSLODAVACSet);
            return 0;
        }

        public virtual int FillPage(S_OD_BOLOVANJE_POSLODAVACDataSet dataSet, string odd, string dooo, int iDRADNIK, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.S_OD_BOLOVANJE_POSLODAVACSet = dataSet;
            this.rowS_OD_BOLOVANJE_POSLODAVAC = this.S_OD_BOLOVANJE_POSLODAVACSet.S_OD_BOLOVANJE_POSLODAVAC.NewS_OD_BOLOVANJE_POSLODAVACRow();
            this.SetFillParameters(odd, dooo, iDRADNIK);
            this.AV8odd = odd;
            this.AV9dooo = dooo;
            this.AV10IDRADN = iDRADNIK;
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
                parameter.ParameterName = "odd";
                parameter.DbType = DbType.String;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "dooo";
                parameter2.DbType = DbType.String;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "IDRADNIK";
                parameter3.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(string odd, string dooo, int iDRADNIK)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_OD_BOLOVANJE_POSLODAVACSelect1 = this.connDefault.GetCommand("S_PLACA_BOLOVANJE_POSLODAVAC", true);
            this.cmS_OD_BOLOVANJE_POSLODAVACSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_OD_BOLOVANJE_POSLODAVACSelect1.IDbCommand.Parameters.Clear();
            this.cmS_OD_BOLOVANJE_POSLODAVACSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@odd", odd));
            this.cmS_OD_BOLOVANJE_POSLODAVACSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@dooo", dooo));
            this.cmS_OD_BOLOVANJE_POSLODAVACSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", iDRADNIK));
            this.cmS_OD_BOLOVANJE_POSLODAVACSelect1.ErrorMask |= ErrorMask.Lock;
            this.S_OD_BOLOVANJE_POSLODAVACSelect1 = this.cmS_OD_BOLOVANJE_POSLODAVACSelect1.FetchData();
            if (this.S_OD_BOLOVANJE_POSLODAVACSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.S_OD_BOLOVANJE_POSLODAVACSelect1.GetInt32(0);
            }
            this.S_OD_BOLOVANJE_POSLODAVACSelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(string odd, string dooo, int iDRADNIK)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(odd, dooo, iDRADNIK);
                num2 = this.GetInternalRecordCount(odd, dooo, iDRADNIK);
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
            this.AV8odd = "";
            this.AV9dooo = "";
            this.AV10IDRADN = 0;
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(string odd, string dooo, int iDRADNIK)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = odd;
                this.fillDataParameters[1].Value = dooo;
                this.fillDataParameters[2].Value = iDRADNIK;
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

