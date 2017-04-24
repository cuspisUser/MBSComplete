namespace Placa
{
    using Deklarit;
    using Deklarit.Data;
    using Deklarit.Utils;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Threading;

    public class KONTODataAdapter : IDataAdapter, IKONTODataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmKONTOSelect1;
        private ReadWriteCommand cmKONTOSelect2;
        private ReadWriteCommand cmKONTOSelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private IDataReader KONTOSelect1;
        private IDataReader KONTOSelect2;
        private IDataReader KONTOSelect5;
        private KONTODataSet KONTOSet;
        private object m__IDAKTIVNOSTOriginal;
        private object m__NAZIVKONTOOriginal;
        private string m_KONT;
        private readonly string m_SelectString268 = "TM1.[IDKONTO], TM1.[NAZIVKONTO], T2.[NAZIVAKTIVNOST], TM1.[IDAKTIVNOST]";
        private string m_WhereString;
        private short RcdFound268;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private KONTODataSet.KONTORow rowKONTO;
        private string scmdbuf;
        private StatementType sMode268;

        public event KONTOUpdateEventHandler KONTOUpdated;

        public event KONTOUpdateEventHandler KONTOUpdating;

        private void AddRowKonto()
        {
            this.KONTOSet.KONTO.AddKONTORow(this.rowKONTO);
        }

        private void AfterConfirmKonto()
        {
            this.OnKONTOUpdating(new KONTOEventArgs(this.rowKONTO, this.Gx_mode));
        }

        private void CheckDeleteErrorsKonto()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDAMSKUPINE] FROM [AMSKUPINE] WITH (NOLOCK) WHERE [KTOIZVORAIDKONTO] = @IDKONTO ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new AMSKUPINEInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "AMSKUPINE" }));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [IDAMSKUPINE] FROM [AMSKUPINE] WITH (NOLOCK) WHERE [KTOISPRAVKAIDKONTO] = @IDKONTO ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new AMSKUPINEInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "AMSKUPINE" }));
            }
            reader2.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT TOP 1 [IDAMSKUPINE] FROM [AMSKUPINE] WITH (NOLOCK) WHERE [KTONABAVKEIDKONTO] = @IDKONTO ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                reader3.Close();
                throw new AMSKUPINEInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "AMSKUPINE" }));
            }
            reader3.Close();
            ReadWriteCommand command9 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMADD], [SHEMADDSTANDARDID] FROM [SHEMADDSHEMADDSTANDARD] WITH (NOLOCK) WHERE [KONTODDVRSTAIZNOSAIDKONTO] = @IDKONTO ", false);
            if (command9.IDbCommand.Parameters.Count == 0)
            {
                command9.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command9.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
            IDataReader reader9 = command9.FetchData();
            if (command9.HasMoreRows)
            {
                reader9.Close();
                throw new SHEMADDSHEMADDSTANDARDInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMADDSTANDARD" }));
            }
            reader9.Close();
            ReadWriteCommand command7 = this.connDefault.GetCommand("SELECT TOP 1 [IDPLAN], [PLANGODINAIDGODINE], [PLANOJIDORGJED], [PLANKONTOIDKONTO] FROM [PLANORGKON] WITH (NOLOCK) WHERE [PLANKONTOIDKONTO] = @IDKONTO ", false);
            if (command7.IDbCommand.Parameters.Count == 0)
            {
                command7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command7.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
            IDataReader reader7 = command7.FetchData();
            if (command7.HasMoreRows)
            {
                reader7.Close();
                throw new PLANORGKONInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "KON" }));
            }
            reader7.Close();
            ReadWriteCommand command13 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAPLACA], [SHEMAPLACASTANDARDID] FROM [SHEMAPLACASHEMAPLACASTANDARD] WITH (NOLOCK) WHERE [KONTOPLACAVRSTAIZNOSAIDKONTO] = @IDKONTO ", false);
            if (command13.IDbCommand.Parameters.Count == 0)
            {
                command13.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command13.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
            IDataReader reader13 = command13.FetchData();
            if (command13.HasMoreRows)
            {
                reader13.Close();
                throw new SHEMAPLACASHEMAPLACASTANDARDInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAPLACASTANDARD" }));
            }
            reader13.Close();
            ReadWriteCommand command12 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAPLACA], [SHEMAPLELEMENTIDELEMENT], [KONTOELEMENTIDKONTO], [STRANEELEMENTIDSTRANEKNJIZENJA] FROM [SHEMAPLACASHEMAPLACAELEMENT] WITH (NOLOCK) WHERE [KONTOELEMENTIDKONTO] = @IDKONTO ", false);
            if (command12.IDbCommand.Parameters.Count == 0)
            {
                command12.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command12.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
            IDataReader reader12 = command12.FetchData();
            if (command12.HasMoreRows)
            {
                reader12.Close();
                throw new SHEMAPLACASHEMAPLACAELEMENTInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAPLACAELEMENT" }));
            }
            reader12.Close();
            ReadWriteCommand command8 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMADD], [SHEMADDDOPRINOSIDDOPRINOS], [KONTODOPIDKONTO] FROM [SHEMADDSHEMADDDOPRINOS] WITH (NOLOCK) WHERE [KONTODOPIDKONTO] = @IDKONTO ", false);
            if (command8.IDbCommand.Parameters.Count == 0)
            {
                command8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command8.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
            IDataReader reader8 = command8.FetchData();
            if (command8.HasMoreRows)
            {
                reader8.Close();
                throw new SHEMADDSHEMADDDOPRINOSInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Doprinosi" }));
            }
            reader8.Close();
            ReadWriteCommand command11 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAPLACA], [SHEMAPLDOPIDDOPRINOS], [KONTODOPIDKONTO] FROM [SHEMAPLACASHEMAPLACADOP] WITH (NOLOCK) WHERE [KONTODOPIDKONTO] = @IDKONTO ", false);
            if (command11.IDbCommand.Parameters.Count == 0)
            {
                command11.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command11.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
            IDataReader reader11 = command11.FetchData();
            if (command11.HasMoreRows)
            {
                reader11.Close();
                throw new SHEMAPLACASHEMAPLACADOPInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Doprinosi" }));
            }
            reader11.Close();
            ReadWriteCommand command10 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAIRA], [SHEMAIRAKONTOIDKONTO], [SHEMAIRASTRANEIDSTRANEKNJIZENJA] FROM [SHEMAIRASHEMAIRAKONTIRANJE] WITH (NOLOCK) WHERE [SHEMAIRAKONTOIDKONTO] = @IDKONTO ", false);
            if (command10.IDbCommand.Parameters.Count == 0)
            {
                command10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command10.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
            IDataReader reader10 = command10.FetchData();
            if (command10.HasMoreRows)
            {
                reader10.Close();
                throw new SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAIRAKONTIRANJE" }));
            }
            reader10.Close();
            ReadWriteCommand command14 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAURA], [SHEMAURAKONTOIDKONTO], [SHEMAURASTRANEIDSTRANEKNJIZENJA], [IDURAVRSTAIZNOSA] FROM [SHEMAURASHEMAURAKONTIRANJE] WITH (NOLOCK) WHERE [SHEMAURAKONTOIDKONTO] = @IDKONTO ", false);
            if (command14.IDbCommand.Parameters.Count == 0)
            {
                command14.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command14.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
            IDataReader reader14 = command14.FetchData();
            if (command14.HasMoreRows)
            {
                reader14.Close();
                throw new SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAURAKONTIRANJE" }));
            }
            reader14.Close();
            ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT TOP 1 [BLGDOKIDDOKUMENT], [IDBLGVRSTEDOK], [blggodineIDGODINE], [BLGBROJDOKUMENTA], [BLGSTAVKEBLAGAJNEKONTOIDKONTO] FROM [BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje] WITH (NOLOCK) WHERE [BLGSTAVKEBLAGAJNEKONTOIDKONTO] = @IDKONTO ", false);
            if (command5.IDbCommand.Parameters.Count == 0)
            {
                command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command5.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
            IDataReader reader5 = command5.FetchData();
            if (command5.HasMoreRows)
            {
                reader5.Close();
                throw new BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "StavkeBlagajneKontiranje" }));
            }
            reader5.Close();
            ReadWriteCommand command6 = this.connDefault.GetCommand("SELECT TOP 1 [IDGKSTAVKA] FROM [GKSTAVKA] WITH (NOLOCK) WHERE [IDKONTO] = @IDKONTO ", false);
            if (command6.IDbCommand.Parameters.Count == 0)
            {
                command6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command6.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
            IDataReader reader6 = command6.FetchData();
            if (command6.HasMoreRows)
            {
                reader6.Close();
                throw new GKSTAVKAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "GKSTAVKA" }));
            }
            reader6.Close();
            ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT TOP 1 [BLGDOKIDDOKUMENT] FROM [BLAGAJNA] WITH (NOLOCK) WHERE [BLGKONTOIDKONTO] = @IDKONTO ", false);
            if (command4.IDbCommand.Parameters.Count == 0)
            {
                command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command4.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
            IDataReader reader4 = command4.FetchData();
            if (command4.HasMoreRows)
            {
                reader4.Close();
                throw new BLAGAJNAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "BLAGAJNA" }));
            }
            reader4.Close();
        }

        private void CheckExtendedTableKonto()
        {
            this.m_KONT = this.rowKONTO.IDKONTO + " | " + this.rowKONTO.NAZIVKONTO;
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVAKTIVNOST] FROM [AKTIVNOST] WITH (NOLOCK) WHERE [IDAKTIVNOST] = @IDAKTIVNOST ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKONTO["IDAKTIVNOST"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new AKTIVNOSTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("AKTIVNOST") }));
            }
            this.rowKONTO["NAZIVAKTIVNOST"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0))));
            reader.Close();
        }

        private void CheckOptimisticConcurrencyKonto()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKONTO], [NAZIVKONTO], [IDAKTIVNOST] FROM [KONTO] WITH (UPDLOCK) WHERE [IDKONTO] = @IDKONTO ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new KONTODataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("KONTO") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVKONTOOriginal), RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))))) || !this.m__IDAKTIVNOSTOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2))))
                {
                    reader.Close();
                    throw new KONTODataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("KONTO") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowKonto()
        {
            this.rowKONTO = this.KONTOSet.KONTO.NewKONTORow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyKonto();
            this.OnDeleteControlsKonto();
            this.AfterConfirmKonto();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [KONTO]  WHERE [IDKONTO] = @IDKONTO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsKonto();
            }
            this.OnKONTOUpdated(new KONTOEventArgs(this.rowKONTO, StatementType.Delete));
            this.rowKONTO.Delete();
            this.sMode268 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode268;
        }

        public virtual int Fill(KONTODataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, this.fillDataParameters[0].Value.ToString());
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.KONTOSet = dataSet;
                    this.LoadChildKonto(0, -1);
                    dataSet.AcceptChanges();
                }
                finally
                {
                    this.Cleanup();
                }
            }
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.KONTOSet = (KONTODataSet) dataSet;
            if (this.KONTOSet != null)
            {
                return this.Fill(this.KONTOSet);
            }
            this.KONTOSet = new KONTODataSet();
            this.Fill(this.KONTOSet);
            dataSet.Merge(this.KONTOSet);
            return 0;
        }

        public virtual int Fill(KONTODataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["IDKONTO"]));
        }

        public virtual int Fill(KONTODataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToString(dataRecord["IDKONTO"]));
        }

        public virtual int Fill(KONTODataSet dataSet, string iDKONTO)
        {
            if (!this.FillByIDKONTO(dataSet, iDKONTO))
            {
                throw new KONTONotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("KONTO") }));
            }
            return 0;
        }

        public virtual int FillByIDAKTIVNOST(KONTODataSet dataSet, int iDAKTIVNOST)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.KONTOSet = dataSet;
            this.rowKONTO = this.KONTOSet.KONTO.NewKONTORow();
            this.rowKONTO.IDAKTIVNOST = iDAKTIVNOST;
            try
            {
                this.LoadByIDAKTIVNOST(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByIDKONTO(KONTODataSet dataSet, string iDKONTO)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.KONTOSet = dataSet;
            this.rowKONTO = this.KONTOSet.KONTO.NewKONTORow();
            this.rowKONTO.IDKONTO = iDKONTO;
            try
            {
                this.LoadByIDKONTO(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound268 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(KONTODataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.KONTOSet = dataSet;
            try
            {
                this.LoadChildKonto(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDAKTIVNOST(KONTODataSet dataSet, int iDAKTIVNOST, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.KONTOSet = dataSet;
            this.rowKONTO = this.KONTOSet.KONTO.NewKONTORow();
            this.rowKONTO.IDAKTIVNOST = iDAKTIVNOST;
            try
            {
                this.LoadByIDAKTIVNOST(startRow, maxRows);
                dataSet.AcceptChanges();
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

        private void GetByPrimaryKey()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDKONTO], [NAZIVKONTO], [IDAKTIVNOST] FROM [KONTO] WITH (NOLOCK) WHERE [IDKONTO] = @IDKONTO ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound268 = 1;
                this.rowKONTO["IDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0))));
                this.rowKONTO["NAZIVKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))));
                this.rowKONTO["IDAKTIVNOST"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2));
                this.sMode268 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadKonto();
                this.Gx_mode = this.sMode268;
            }
            else
            {
                this.RcdFound268 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDKONTO";
                parameter.DbType = DbType.String;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmKONTOSelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [KONTO] WITH (NOLOCK) ", false);
            this.KONTOSelect2 = this.cmKONTOSelect2.FetchData();
            if (this.KONTOSelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.KONTOSelect2.GetInt32(0);
            }
            this.KONTOSelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDAKTIVNOST(int iDAKTIVNOST)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmKONTOSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [KONTO] WITH (NOLOCK) WHERE [IDAKTIVNOST] = @IDAKTIVNOST ", false);
            if (this.cmKONTOSelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmKONTOSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
            }
            this.cmKONTOSelect1.SetParameter(0, iDAKTIVNOST);
            this.KONTOSelect1 = this.cmKONTOSelect1.FetchData();
            if (this.KONTOSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.KONTOSelect1.GetInt32(0);
            }
            this.KONTOSelect1.Close();
            return this.recordCount;
        }

        public virtual int GetRecordCount()
        {
            int internalRecordCount;
            try
            {
                this.InitializeMembers();
                internalRecordCount = this.GetInternalRecordCount();
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCount;
        }

        public virtual int GetRecordCountByIDAKTIVNOST(int iDAKTIVNOST)
        {
            int internalRecordCountByIDAKTIVNOST;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDAKTIVNOST = this.GetInternalRecordCountByIDAKTIVNOST(iDAKTIVNOST);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDAKTIVNOST;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound268 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m_KONT = "";
            this.m__NAZIVKONTOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDAKTIVNOSTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.KONTOSet = new KONTODataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertKonto()
        {
            this.CheckOptimisticConcurrencyKonto();
            this.CheckExtendedTableKonto();
            this.AfterConfirmKonto();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [KONTO] ([IDKONTO], [NAZIVKONTO], [IDAKTIVNOST]) VALUES (@IDKONTO, @NAZIVKONTO, @IDAKTIVNOST)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVKONTO", DbType.String, 150));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["NAZIVKONTO"]))));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowKONTO["IDAKTIVNOST"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new KONTODuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnKONTOUpdated(new KONTOEventArgs(this.rowKONTO, StatementType.Insert));
        }

        private void LoadByIDAKTIVNOST(int startRow, int maxRows)
        {
            bool enforceConstraints = this.KONTOSet.EnforceConstraints;
            this.KONTOSet.KONTO.BeginLoadData();
            this.ScanByIDAKTIVNOST(startRow, maxRows);
            this.KONTOSet.KONTO.EndLoadData();
            this.KONTOSet.EnforceConstraints = enforceConstraints;
            if (this.KONTOSet.KONTO.Count > 0)
            {
                this.rowKONTO = this.KONTOSet.KONTO[this.KONTOSet.KONTO.Count - 1];
            }
        }

        private void LoadByIDKONTO(int startRow, int maxRows)
        {
            bool enforceConstraints = this.KONTOSet.EnforceConstraints;
            this.KONTOSet.KONTO.BeginLoadData();
            this.ScanByIDKONTO(startRow, maxRows);
            this.KONTOSet.KONTO.EndLoadData();
            this.KONTOSet.EnforceConstraints = enforceConstraints;
            if (this.KONTOSet.KONTO.Count > 0)
            {
                this.rowKONTO = this.KONTOSet.KONTO[this.KONTOSet.KONTO.Count - 1];
            }
        }

        private void LoadChildKonto(int startRow, int maxRows)
        {
            this.CreateNewRowKonto();
            bool enforceConstraints = this.KONTOSet.EnforceConstraints;
            this.KONTOSet.KONTO.BeginLoadData();
            this.ScanStartKonto(startRow, maxRows);
            try
            {
                this.KONTOSet.KONTO.EndLoadData();
            }
            catch { }
            this.KONTOSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataKonto(int maxRows)
        {
            int num = 0;
            if (this.RcdFound268 != 0)
            {
                this.ScanLoadKonto();
                while ((this.RcdFound268 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowKonto();
                    this.CreateNewRowKonto();
                    this.ScanNextKonto();
                }
            }
            if (num > 0)
            {
                this.RcdFound268 = 1;
            }
            this.ScanEndKonto();
            if (this.KONTOSet.KONTO.Count > 0)
            {
                this.rowKONTO = this.KONTOSet.KONTO[this.KONTOSet.KONTO.Count - 1];
            }
        }

        private void LoadKonto()
        {
            this.m_KONT = this.rowKONTO.IDKONTO + " | " + this.rowKONTO.NAZIVKONTO;
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVAKTIVNOST] FROM [AKTIVNOST] WITH (NOLOCK) WHERE [IDAKTIVNOST] = @IDAKTIVNOST ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKONTO["IDAKTIVNOST"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowKONTO["NAZIVAKTIVNOST"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0))));
            }
            reader.Close();
        }

        private void LoadRowKonto()
        {
            this.OnLoadActionsKonto();
            this.AddRowKonto();
        }

        private void OnDeleteControlsKonto()
        {
            this.m_KONT = this.rowKONTO.IDKONTO + " | " + this.rowKONTO.NAZIVKONTO;
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVAKTIVNOST] FROM [AKTIVNOST] WITH (NOLOCK) WHERE [IDAKTIVNOST] = @IDAKTIVNOST ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKONTO["IDAKTIVNOST"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowKONTO["NAZIVAKTIVNOST"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0))));
            }
            reader.Close();
        }

        private void OnKONTOUpdated(KONTOEventArgs e)
        {
            if (this.KONTOUpdated != null)
            {
                KONTOUpdateEventHandler kONTOUpdatedEvent = this.KONTOUpdated;
                if (kONTOUpdatedEvent != null)
                {
                    kONTOUpdatedEvent(this, e);
                }
            }
        }

        private void OnKONTOUpdating(KONTOEventArgs e)
        {
            if (this.KONTOUpdating != null)
            {
                KONTOUpdateEventHandler kONTOUpdatingEvent = this.KONTOUpdating;
                if (kONTOUpdatingEvent != null)
                {
                    kONTOUpdatingEvent(this, e);
                }
            }
        }

        private void OnLoadActionsKonto()
        {
            this.m_KONT = this.rowKONTO.IDKONTO + " | " + this.rowKONTO.NAZIVKONTO;
        }

        private void ReadRowKonto()
        {
            this.Gx_mode = Mode.FromRowState(this.rowKONTO.RowState);
            if (this.rowKONTO.RowState != DataRowState.Added)
            {
                this.m__NAZIVKONTOOriginal = RuntimeHelpers.GetObjectValue(this.rowKONTO["NAZIVKONTO", DataRowVersion.Original]);
                this.m__IDAKTIVNOSTOriginal = RuntimeHelpers.GetObjectValue(this.rowKONTO["IDAKTIVNOST", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVKONTOOriginal = RuntimeHelpers.GetObjectValue(this.rowKONTO["NAZIVKONTO"]);
                this.m__IDAKTIVNOSTOriginal = RuntimeHelpers.GetObjectValue(this.rowKONTO["IDAKTIVNOST"]);
            }
            this._Gxremove = this.rowKONTO.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowKONTO = (KONTODataSet.KONTORow) DataSetUtil.CloneOriginalDataRow(this.rowKONTO);
            }
        }

        private void ScanByIDAKTIVNOST(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDAKTIVNOST] = @IDAKTIVNOST";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString268 + "  FROM ([KONTO] TM1 WITH (NOLOCK) INNER JOIN [AKTIVNOST] T2 WITH (NOLOCK) ON T2.[IDAKTIVNOST] = TM1.[IDAKTIVNOST])" + this.m_WhereString + " ORDER BY TM1.[IDKONTO]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString268, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDKONTO] ) AS DK_PAGENUM   FROM ([KONTO] TM1 WITH (NOLOCK) INNER JOIN [AKTIVNOST] T2 WITH (NOLOCK) ON T2.[IDAKTIVNOST] = TM1.[IDAKTIVNOST]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString268 + " FROM ([KONTO] TM1 WITH (NOLOCK) INNER JOIN [AKTIVNOST] T2 WITH (NOLOCK) ON T2.[IDAKTIVNOST] = TM1.[IDAKTIVNOST])" + this.m_WhereString + " ORDER BY TM1.[IDKONTO] ";
            }
            this.cmKONTOSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmKONTOSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmKONTOSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
            }
            this.cmKONTOSelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowKONTO["IDAKTIVNOST"]));
            this.KONTOSelect5 = this.cmKONTOSelect5.FetchData();
            this.RcdFound268 = 0;
            this.ScanLoadKonto();
            this.LoadDataKonto(maxRows);
        }

        private void ScanByIDKONTO(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDKONTO] = @IDKONTO";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString268 + "  FROM ([KONTO] TM1 WITH (NOLOCK) INNER JOIN [AKTIVNOST] T2 WITH (NOLOCK) ON T2.[IDAKTIVNOST] = TM1.[IDAKTIVNOST])" + this.m_WhereString + " ORDER BY TM1.[IDKONTO]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString268, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDKONTO] ) AS DK_PAGENUM   FROM ([KONTO] TM1 WITH (NOLOCK) INNER JOIN [AKTIVNOST] T2 WITH (NOLOCK) ON T2.[IDAKTIVNOST] = TM1.[IDAKTIVNOST]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString268 + " FROM ([KONTO] TM1 WITH (NOLOCK) INNER JOIN [AKTIVNOST] T2 WITH (NOLOCK) ON T2.[IDAKTIVNOST] = TM1.[IDAKTIVNOST])" + this.m_WhereString + " ORDER BY TM1.[IDKONTO] ";
            }
            this.cmKONTOSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmKONTOSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmKONTOSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            this.cmKONTOSelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
            this.KONTOSelect5 = this.cmKONTOSelect5.FetchData();
            this.RcdFound268 = 0;
            this.ScanLoadKonto();
            this.LoadDataKonto(maxRows);
        }

        private void ScanEndKonto()
        {
            this.KONTOSelect5.Close();
        }

        private void ScanLoadKonto()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmKONTOSelect5.HasMoreRows)
            {
                this.RcdFound268 = 1;
                this.rowKONTO["IDKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KONTOSelect5, 0))));
                this.rowKONTO["NAZIVKONTO"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KONTOSelect5, 1))));
                this.rowKONTO["NAZIVAKTIVNOST"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KONTOSelect5, 2))));
                this.rowKONTO["IDAKTIVNOST"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.KONTOSelect5, 3));
                this.rowKONTO["NAZIVAKTIVNOST"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.KONTOSelect5, 2))));
            }
        }

        private void ScanNextKonto()
        {
            this.cmKONTOSelect5.HasMoreRows = this.KONTOSelect5.Read();
            this.RcdFound268 = 0;
            this.ScanLoadKonto();
        }

        private void ScanStartKonto(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString268 + "  FROM ([KONTO] TM1 WITH (NOLOCK) INNER JOIN [AKTIVNOST] T2 WITH (NOLOCK) ON T2.[IDAKTIVNOST] = TM1.[IDAKTIVNOST])" + this.m_WhereString + " ORDER BY TM1.[IDKONTO]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString268, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDKONTO] ) AS DK_PAGENUM   FROM ([KONTO] TM1 WITH (NOLOCK) INNER JOIN [AKTIVNOST] T2 WITH (NOLOCK) ON T2.[IDAKTIVNOST] = TM1.[IDAKTIVNOST]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString268 + " FROM ([KONTO] TM1 WITH (NOLOCK) INNER JOIN [AKTIVNOST] T2 WITH (NOLOCK) ON T2.[IDAKTIVNOST] = TM1.[IDAKTIVNOST])" + this.m_WhereString + " ORDER BY TM1.[IDKONTO] ";
            }
            this.cmKONTOSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.KONTOSelect5 = this.cmKONTOSelect5.FetchData();
            this.RcdFound268 = 0;
            this.ScanLoadKonto();
            this.LoadDataKonto(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.KONTOSet = (KONTODataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.KONTOSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.KONTOSet.KONTO.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        KONTODataSet.KONTORow current = (KONTODataSet.KONTORow) enumerator.Current;
                        this.rowKONTO = current;
                        if (Helpers.IsRowChanged(this.rowKONTO))
                        {
                            this.ReadRowKonto();
                            if (this.rowKONTO.RowState == DataRowState.Added)
                            {
                                this.InsertKonto();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateKonto();
                            }
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                dataSet.AcceptChanges();
                this.connDefault.Commit();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                //this.connDefault.Rollback();
                
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        private void UpdateKonto()
        {
            this.CheckOptimisticConcurrencyKonto();
            this.CheckExtendedTableKonto();
            this.AfterConfirmKonto();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [KONTO] SET [NAZIVKONTO]=@NAZIVKONTO, [IDAKTIVNOST]=@IDAKTIVNOST  WHERE [IDKONTO] = @IDKONTO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVKONTO", DbType.String, 150));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["NAZIVKONTO"]))));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowKONTO["IDAKTIVNOST"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowKONTO["IDKONTO"]))));
            command.ExecuteStmt();
            this.OnKONTOUpdated(new KONTOEventArgs(this.rowKONTO, StatementType.Update));
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

        [Serializable]
        public class AKTIVNOSTForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public AKTIVNOSTForeignKeyNotFoundException()
            {
            }

            public AKTIVNOSTForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected AKTIVNOSTForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public AKTIVNOSTForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class AMSKUPINEInvalidDeleteException : InvalidDeleteException
        {
            public AMSKUPINEInvalidDeleteException()
            {
            }

            public AMSKUPINEInvalidDeleteException(string message) : base(message)
            {
            }

            protected AMSKUPINEInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public AMSKUPINEInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BLAGAJNAInvalidDeleteException : InvalidDeleteException
        {
            public BLAGAJNAInvalidDeleteException()
            {
            }

            public BLAGAJNAInvalidDeleteException(string message) : base(message)
            {
            }

            protected BLAGAJNAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLAGAJNAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeInvalidDeleteException : InvalidDeleteException
        {
            public BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeInvalidDeleteException()
            {
            }

            public BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeInvalidDeleteException(string message) : base(message)
            {
            }

            protected BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranjeInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GKSTAVKAInvalidDeleteException : InvalidDeleteException
        {
            public GKSTAVKAInvalidDeleteException()
            {
            }

            public GKSTAVKAInvalidDeleteException(string message) : base(message)
            {
            }

            protected GKSTAVKAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GKSTAVKAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class KONTODataChangedException : DataChangedException
        {
            public KONTODataChangedException()
            {
            }

            public KONTODataChangedException(string message) : base(message)
            {
            }

            protected KONTODataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KONTODataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class KONTODataLockedException : DataLockedException
        {
            public KONTODataLockedException()
            {
            }

            public KONTODataLockedException(string message) : base(message)
            {
            }

            protected KONTODataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KONTODataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class KONTODuplicateKeyException : DuplicateKeyException
        {
            public KONTODuplicateKeyException()
            {
            }

            public KONTODuplicateKeyException(string message) : base(message)
            {
            }

            protected KONTODuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KONTODuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class KONTOEventArgs : EventArgs
        {
            private KONTODataSet.KONTORow m_dataRow;
            private System.Data.StatementType m_statementType;

            public KONTOEventArgs(KONTODataSet.KONTORow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public KONTODataSet.KONTORow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        [Serializable]
        public class KONTONotFoundException : DataNotFoundException
        {
            public KONTONotFoundException()
            {
            }

            public KONTONotFoundException(string message) : base(message)
            {
            }

            protected KONTONotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public KONTONotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void KONTOUpdateEventHandler(object sender, KONTODataAdapter.KONTOEventArgs e);

        [Serializable]
        public class PLANORGKONInvalidDeleteException : InvalidDeleteException
        {
            public PLANORGKONInvalidDeleteException()
            {
            }

            public PLANORGKONInvalidDeleteException(string message) : base(message)
            {
            }

            protected PLANORGKONInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PLANORGKONInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMADDSHEMADDDOPRINOSInvalidDeleteException : InvalidDeleteException
        {
            public SHEMADDSHEMADDDOPRINOSInvalidDeleteException()
            {
            }

            public SHEMADDSHEMADDDOPRINOSInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMADDSHEMADDDOPRINOSInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMADDSHEMADDDOPRINOSInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMADDSHEMADDSTANDARDInvalidDeleteException : InvalidDeleteException
        {
            public SHEMADDSHEMADDSTANDARDInvalidDeleteException()
            {
            }

            public SHEMADDSHEMADDSTANDARDInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMADDSHEMADDSTANDARDInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMADDSHEMADDSTANDARDInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException : InvalidDeleteException
        {
            public SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException()
            {
            }

            public SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAIRASHEMAIRAKONTIRANJEInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAPLACASHEMAPLACADOPInvalidDeleteException : InvalidDeleteException
        {
            public SHEMAPLACASHEMAPLACADOPInvalidDeleteException()
            {
            }

            public SHEMAPLACASHEMAPLACADOPInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMAPLACASHEMAPLACADOPInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACASHEMAPLACADOPInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAPLACASHEMAPLACAELEMENTInvalidDeleteException : InvalidDeleteException
        {
            public SHEMAPLACASHEMAPLACAELEMENTInvalidDeleteException()
            {
            }

            public SHEMAPLACASHEMAPLACAELEMENTInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMAPLACASHEMAPLACAELEMENTInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACASHEMAPLACAELEMENTInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAPLACASHEMAPLACASTANDARDInvalidDeleteException : InvalidDeleteException
        {
            public SHEMAPLACASHEMAPLACASTANDARDInvalidDeleteException()
            {
            }

            public SHEMAPLACASHEMAPLACASTANDARDInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMAPLACASHEMAPLACASTANDARDInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAPLACASHEMAPLACASTANDARDInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException : InvalidDeleteException
        {
            public SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException()
            {
            }

            public SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAURASHEMAURAKONTIRANJEInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

