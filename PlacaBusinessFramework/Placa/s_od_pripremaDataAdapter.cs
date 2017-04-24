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

    public class s_od_pripremaDataAdapter : IDataAdapter, Is_od_pripremaDataAdapter
    {
        private int AV10mjesec;
        private string AV11vrsta;
        private int AV8godina;
        private int AV9id;
        private ReadWriteCommand cms_od_pripremaSelect1;
        private ReadWriteCommand cms_od_pripremaSelect2;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        private DbParameter[] fillDataParameters;
        private int m_RecordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private s_od_pripremaDataSet.s_od_pripremaRow rows_od_priprema;
        private IDataReader s_od_pripremaSelect1;
        private IDataReader s_od_pripremaSelect2;
        private s_od_pripremaDataSet s_od_pripremaSet;

        private void AddRowS_od_priprema()
        {
            this.s_od_pripremaSet.s_od_priprema.Adds_od_pripremaRow(this.rows_od_priprema);
            this.rows_od_priprema.AcceptChanges();
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void executePrivate(int startRow, int maxRows)
        {
            this.cms_od_pripremaSelect2 = this.connDefault.GetCommand("S_PLACA_PRIPREMA", true);
            this.cms_od_pripremaSelect2.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cms_od_pripremaSelect2.IDbCommand.Parameters.Clear();
            this.cms_od_pripremaSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godina", this.AV8godina));
            this.cms_od_pripremaSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@id", this.AV9id));
            this.cms_od_pripremaSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@mjesec", this.AV10mjesec));
            this.cms_od_pripremaSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@vrsta", this.AV11vrsta));
            this.cms_od_pripremaSelect2.ErrorMask |= ErrorMask.Lock;
            this.s_od_pripremaSelect2 = this.cms_od_pripremaSelect2.FetchData();
            while (this.cms_od_pripremaSelect2.HasMoreRows && (startRow > 0))
            {
                startRow--;
                this.cms_od_pripremaSelect2.HasMoreRows = this.s_od_pripremaSelect2.Read();
            }
            int num = 0;
            while (this.cms_od_pripremaSelect2.HasMoreRows && (num != maxRows))
            {
                this.rows_od_priprema["imeprezime"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["imeprezime"]);
                this.rows_od_priprema["NAZIVRADNOMJESTO"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["nazivradnomjesto"]);
                this.rows_od_priprema["osnovnaplaca"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["osnovnaplaca"]);
                this.rows_od_priprema["smjenskiiznos"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["smjenskiiznos"]);
                this.rows_od_priprema["smjenskisatnica"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["smjenskisatnica"]);
                this.rows_od_priprema["smjenskisati"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["smjenskisati"]);
                this.rows_od_priprema["posebni1iznos"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["posebni1iznos"]);
                this.rows_od_priprema["posebni1satnica"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["posebni1satnica"]);
                this.rows_od_priprema["posebni1sati"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["posebni1sati"]);
                this.rows_od_priprema["posebni2iznos"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["posebni2iznos"]);
                this.rows_od_priprema["posebni2satnica"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["posebni2satnica"]);
                this.rows_od_priprema["posebni2sati"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["posebni2sati"]);
                this.rows_od_priprema["posebni3iznos"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["posebni3iznos"]);
                this.rows_od_priprema["posebni3satnica"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["posebni3satnica"]);
                this.rows_od_priprema["posebni3sati"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["posebni3sati"]);
                this.rows_od_priprema["nocnisatnica"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["nocnisatnica"]);
                this.rows_od_priprema["nocniuvecani"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["nocniuvecani"]);
                this.rows_od_priprema["nocni"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["nocni"]);
                this.rows_od_priprema["prekovremenisatnica"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["prekovremenisatnica"]);
                this.rows_od_priprema["prekovremeniuvecani"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["prekovremeniuvecani"]);
                this.rows_od_priprema["prekovremeni"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["prekovremeni"]);
                this.rows_od_priprema["subotomsatnica"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["subotomsatnica"]);
                this.rows_od_priprema["subotomuvecani"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["subotomuvecani"]);
                this.rows_od_priprema["subotom"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["subotom"]);
                this.rows_od_priprema["nedjeljomsatnica"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["nedjeljomsatnica"]);
                this.rows_od_priprema["nedjeljomuvecani"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["nedjeljomuvecani"]);
                this.rows_od_priprema["nedjeljom"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["nedjeljom"]);
                this.rows_od_priprema["blagdansatnica"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["blagdansatnica"]);
                this.rows_od_priprema["blagdanuvecani"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["blagdanuvecani"]);
                this.rows_od_priprema["blagdan"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["blagdan"]);
                this.rows_od_priprema["dvokratnisatnica"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["dvokratnisatnica"]);
                this.rows_od_priprema["dvokratniuvecani"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["dvokratniuvecani"]);
                this.rows_od_priprema["dvokratni"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["dvokratni"]);
                this.rows_od_priprema["DODATNIKOEFICIJENT"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["DODATNIKOEFICIJENT"]);
                this.rows_od_priprema["KOMBINACIJAIZNOS"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["KOMBINACIJAIZNOS"]);
                this.rows_od_priprema["KOMBINACIJAPOSTOTAK"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["KOMBINACIJAPOSTOTAK"]);
                this.rows_od_priprema["KOMBINACIJAIZNOS2"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["KOMBINACIJAIZNOS2"]);
                this.rows_od_priprema["KOMBINACIJAPOSTOTAK2"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["KOMBINACIJAPOSTOTAK2"]);
                this.rows_od_priprema["sposebni1iznos"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["sposebni1iznos"]);
                this.rows_od_priprema["sposebni1satnica"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["sposebni1satnica"]);
                this.rows_od_priprema["sposebni1sati"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["sposebni1sati"]);
                this.rows_od_priprema["sposebni2iznos"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["sposebni2iznos"]);
                this.rows_od_priprema["sposebni2satnica"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["sposebni2satnica"]);
                this.rows_od_priprema["sposebni2sati"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["sposebni2sati"]);
                this.rows_od_priprema["sposebni3iznos"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["sposebni3iznos"]);
                this.rows_od_priprema["sposebni3satnica"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["sposebni3satnica"]);
                this.rows_od_priprema["sposebni3sati"] = RuntimeHelpers.GetObjectValue(this.s_od_pripremaSelect2["sposebni3sati"]);
                this.AddRowS_od_priprema();
                num++;
                this.rows_od_priprema = this.s_od_pripremaSet.s_od_priprema.News_od_pripremaRow();
                this.cms_od_pripremaSelect2.HasMoreRows = this.s_od_pripremaSelect2.Read();
            }
            this.s_od_pripremaSelect2.Close();
            this.Cleanup();
        }

        public virtual int Fill(s_od_pripremaDataSet dataSet)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), int.Parse(this.fillDataParameters[1].Value.ToString()), int.Parse(this.fillDataParameters[2].Value.ToString()), this.fillDataParameters[3].Value.ToString());
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.s_od_pripremaSet = (s_od_pripremaDataSet) dataSet;
            if (this.s_od_pripremaSet != null)
            {
                return this.Fill(this.s_od_pripremaSet);
            }
            this.s_od_pripremaSet = new s_od_pripremaDataSet();
            this.Fill(this.s_od_pripremaSet);
            dataSet.Merge(this.s_od_pripremaSet);
            return 0;
        }

        public virtual int Fill(s_od_pripremaDataSet dataSet, int godina, int id, int mjesec, string vrsta)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.s_od_pripremaSet = dataSet;
            this.rows_od_priprema = this.s_od_pripremaSet.s_od_priprema.News_od_pripremaRow();
            this.SetFillParameters(godina, id, mjesec, vrsta);
            this.AV8godina = godina;
            this.AV9id = id;
            this.AV10mjesec = mjesec;
            this.AV11vrsta = vrsta;
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

        public virtual int FillPage(s_od_pripremaDataSet dataSet, int startRow, int maxRows)
        {
            if (this.fillDataParameters == null)
            {
                throw new ArgumentException();
            }
            this.FillPage(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()), int.Parse(this.fillDataParameters[1].Value.ToString()), int.Parse(this.fillDataParameters[2].Value.ToString()), this.fillDataParameters[3].Value.ToString(), startRow, maxRows);
            return 0;
        }

        public virtual int FillPage(DataSet dataSet, int startRow, int maxRows)
        {
            this.s_od_pripremaSet = (s_od_pripremaDataSet) dataSet;
            if (this.s_od_pripremaSet != null)
            {
                return this.FillPage(this.s_od_pripremaSet, startRow, maxRows);
            }
            this.s_od_pripremaSet = new s_od_pripremaDataSet();
            this.FillPage(this.s_od_pripremaSet, startRow, maxRows);
            dataSet.Merge(this.s_od_pripremaSet);
            return 0;
        }

        public virtual int FillPage(s_od_pripremaDataSet dataSet, int godina, int id, int mjesec, string vrsta, int startRow, int maxRows)
        {
            this.Initialize();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.s_od_pripremaSet = dataSet;
            this.rows_od_priprema = this.s_od_pripremaSet.s_od_priprema.News_od_pripremaRow();
            this.SetFillParameters(godina, id, mjesec, vrsta);
            this.AV8godina = godina;
            this.AV9id = id;
            this.AV10mjesec = mjesec;
            this.AV11vrsta = vrsta;
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
                parameter.DbType = DbType.Int32;
                DbParameter parameter2 = factory.CreateParameter();
                parameter2.ParameterName = "id";
                parameter2.DbType = DbType.Int32;
                DbParameter parameter3 = factory.CreateParameter();
                parameter3.ParameterName = "mjesec";
                parameter3.DbType = DbType.Int32;
                DbParameter parameter4 = factory.CreateParameter();
                parameter4.ParameterName = "vrsta";
                parameter4.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter, parameter2, parameter3, parameter4 };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount(int godina, int id, int mjesec, string vrsta)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cms_od_pripremaSelect1 = this.connDefault.GetCommand("S_PLACA_PRIPREMA", true);
            this.cms_od_pripremaSelect1.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cms_od_pripremaSelect1.IDbCommand.Parameters.Clear();
            this.cms_od_pripremaSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godina", godina));
            this.cms_od_pripremaSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@id", id));
            this.cms_od_pripremaSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@mjesec", mjesec));
            this.cms_od_pripremaSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@vrsta", vrsta));
            this.cms_od_pripremaSelect1.ErrorMask |= ErrorMask.Lock;
            this.s_od_pripremaSelect1 = this.cms_od_pripremaSelect1.FetchData();
            if (this.s_od_pripremaSelect1.IsDBNull(0))
            {
                this.m_RecordCount = 0;
            }
            else
            {
                this.m_RecordCount = this.s_od_pripremaSelect1.GetInt32(0);
            }
            this.s_od_pripremaSelect1.Close();
            return this.m_RecordCount;
        }

        public virtual int GetRecordCount(int godina, int id, int mjesec, string vrsta)
        {
            int num2 = 0;
            try
            {
                this.SetFillParameters(godina, id, mjesec, vrsta);
                num2 = this.GetInternalRecordCount(godina, id, mjesec, vrsta);
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
            this.AV8godina = 0;
            this.AV9id = 0;
            this.AV10mjesec = 0;
            this.AV11vrsta = "";
            this.m_RecordCount = 0;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void SetFillParameters(int godina, int id, int mjesec, string vrsta)
        {
            if (this.fillDataParameters == null)
            {
                this.GetFillParameters();
                this.fillDataParameters[0].Value = godina;
                this.fillDataParameters[1].Value = id;
                this.fillDataParameters[2].Value = mjesec;
                this.fillDataParameters[3].Value = vrsta;
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

