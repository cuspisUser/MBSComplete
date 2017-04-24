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

    public class UCENIKDataAdapter : IDataAdapter, IUCENIKDataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private ReadWriteCommand cmUCENIKSelect1;
        private ReadWriteCommand cmUCENIKSelect2;
        private ReadWriteCommand cmUCENIKSelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__DATUMRODJENJAUCENIKAOriginal;
        private object m__IMERODITELJAOriginal;
        private object m__IMEUCENIKOriginal;
        private object m__JMBGUCENIKAOriginal;
        private object m__NASELJEOriginal;
        private object m__ODJELJENJEOriginal;
        private object m__OIBUCENIKOriginal;
        private object m__POSTANSKIBROJOriginal;
        private object m__ID_OpcinaOriginal;
        private object m__PrezimeRoditeljOriginal;
        private object m__OIBRoditeljOriginal;
        private object m__IBANRoditeljOriginal;

        private object m__PREZIMEUCENIKOriginal;
        private object m__RAZREDOriginal;
        private object m__SPOLUCENIKAOriginal;
        private object m__ULICAIBROJOriginal;
        private readonly string m_SelectString295 = "TM1.[IDUCENIK], TM1.[PREZIMEUCENIK], TM1.[IMEUCENIK], TM1.[OIBUCENIK], TM1.[RAZRED], TM1.[ODJELJENJE], TM1.[SPOLUCENIKA], TM1.[ULICAIBROJ], TM1.[NASELJE], TM1.[JMBGUCENIKA], TM1.[DATUMRODJENJAUCENIKA], TM1.[IMERODITELJA], T2.[NAZIVPOSTE], TM1.[POSTANSKIBROJ], TM1.[ID_Opcina], TM1.[PrezimeRoditelj], TM1.[OIBRoditelj], TM1.[IBANRoditelj]";
        private string m_WhereString;
        private short RcdFound295;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private UCENIKDataSet.UCENIKRow rowUCENIK;
        private string scmdbuf;
        private StatementType sMode295;
        private IDataReader UCENIKSelect1;
        private IDataReader UCENIKSelect2;
        private IDataReader UCENIKSelect5;
        private UCENIKDataSet UCENIKSet;

        public event UCENIKUpdateEventHandler UCENIKUpdated;

        public event UCENIKUpdateEventHandler UCENIKUpdating;

        private void AddRowUcenik()
        {
            this.UCENIKSet.UCENIK.AddUCENIKRow(this.rowUCENIK);
        }

        private void AfterConfirmUcenik()
        {
            this.OnUCENIKUpdating(new UCENIKEventArgs(this.rowUCENIK, this.Gx_mode));
        }

        private void CheckDeleteErrorsUcenik()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [UCOBRMJESEC], [UCOBRGODINA], [IDUCENIK] FROM [UCENIKOBRACUNUCENIKOBRACUNDETAIL] WITH (NOLOCK) WHERE [IDUCENIK] = @IDUCENIK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUCENIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIK["IDUCENIK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new UCENIKOBRACUNUCENIKOBRACUNDETAILInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Učenici u obračunu" }));
            }
            reader.Close();
        }

        private void CheckExtendedTableUcenik()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVPOSTE] FROM [POSTANSKIBROJEVI] WITH (NOLOCK) WHERE [POSTANSKIBROJ] = @POSTANSKIBROJ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTANSKIBROJ", DbType.String, 5));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIK["POSTANSKIBROJ"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new POSTANSKIBROJEVIForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("POSTANSKIBROJEVI") }));
            }
            this.rowUCENIK["NAZIVPOSTE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            reader.Close();
        }

        private void CheckOptimisticConcurrencyUcenik()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDUCENIK], [PREZIMEUCENIK], [IMEUCENIK], [OIBUCENIK], [RAZRED], [ODJELJENJE], [SPOLUCENIKA], [ULICAIBROJ], [NASELJE], [JMBGUCENIKA], [DATUMRODJENJAUCENIKA], [IMERODITELJA], [POSTANSKIBROJ], [ID_Opcina], [PrezimeRoditelj], [OIBRoditelj], [IBANRoditelj] FROM [UCENIK] WITH (UPDLOCK) WHERE [IDUCENIK] = @IDUCENIK ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUCENIK", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIK["IDUCENIK"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new UCENIKDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("UCENIK") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PREZIMEUCENIKOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__IMEUCENIKOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OIBUCENIKOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))) || (!this.m__RAZREDOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ODJELJENJEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__SPOLUCENIKAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ULICAIBROJOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NASELJEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__JMBGUCENIKAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9)))) || !DateTimeUtil.ObjectDateEquals(RuntimeHelpers.GetObjectValue(this.m__DATUMRODJENJAUCENIKAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 10))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__IMERODITELJAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__POSTANSKIBROJOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12))))
                {
                    reader.Close();
                    throw new UCENIKDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("UCENIK") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowUcenik()
        {
            this.rowUCENIK = this.UCENIKSet.UCENIK.NewUCENIKRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyUcenik();
            this.OnDeleteControlsUcenik();
            this.AfterConfirmUcenik();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [UCENIK]  WHERE [IDUCENIK] = @IDUCENIK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUCENIK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIK["IDUCENIK"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsUcenik();
            }
            this.OnUCENIKUpdated(new UCENIKEventArgs(this.rowUCENIK, StatementType.Delete));
            this.rowUCENIK.Delete();
            this.sMode295 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode295;
        }

        public virtual int Fill(UCENIKDataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()));
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.UCENIKSet = dataSet;
                    this.LoadChildUcenik(0, -1);
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
            this.UCENIKSet = (UCENIKDataSet) dataSet;
            if (this.UCENIKSet != null)
            {
                return this.Fill(this.UCENIKSet);
            }
            this.UCENIKSet = new UCENIKDataSet();
            this.Fill(this.UCENIKSet);
            dataSet.Merge(this.UCENIKSet);
            return 0;
        }

        public virtual int Fill(UCENIKDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDUCENIK"]));
        }

        public virtual int Fill(UCENIKDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDUCENIK"]));
        }

        public virtual int Fill(UCENIKDataSet dataSet, int iDUCENIK)
        {
            if (!this.FillByIDUCENIK(dataSet, iDUCENIK))
            {
                throw new UCENIKNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("UCENIK") }));
            }
            return 0;
        }

        public virtual bool FillByIDUCENIK(UCENIKDataSet dataSet, int iDUCENIK)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.UCENIKSet = dataSet;
            this.rowUCENIK = this.UCENIKSet.UCENIK.NewUCENIKRow();
            this.rowUCENIK.IDUCENIK = iDUCENIK;
            try
            {
                this.LoadByIDUCENIK(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound295 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByPOSTANSKIBROJ(UCENIKDataSet dataSet, string pOSTANSKIBROJ)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.UCENIKSet = dataSet;
            this.rowUCENIK = this.UCENIKSet.UCENIK.NewUCENIKRow();
            this.rowUCENIK.POSTANSKIBROJ = pOSTANSKIBROJ;
            try
            {
                this.LoadByPOSTANSKIBROJ(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(UCENIKDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.UCENIKSet = dataSet;
            try
            {
                this.LoadChildUcenik(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByPOSTANSKIBROJ(UCENIKDataSet dataSet, string pOSTANSKIBROJ, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.UCENIKSet = dataSet;
            this.rowUCENIK = this.UCENIKSet.UCENIK.NewUCENIKRow();
            this.rowUCENIK.POSTANSKIBROJ = pOSTANSKIBROJ;
            try
            {
                this.LoadByPOSTANSKIBROJ(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDUCENIK], [PREZIMEUCENIK], [IMEUCENIK], [OIBUCENIK], [RAZRED], [ODJELJENJE], [SPOLUCENIKA], [ULICAIBROJ], [NASELJE], [JMBGUCENIKA], [DATUMRODJENJAUCENIKA], [IMERODITELJA], [POSTANSKIBROJ], [ID_Opcina], [PrezimeRoditelj], [OIBRoditelj], [IBANRoditelj] FROM [UCENIK] WITH (NOLOCK) WHERE [IDUCENIK] = @IDUCENIK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUCENIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIK["IDUCENIK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound295 = 1;
                this.rowUCENIK["IDUCENIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowUCENIK["PREZIMEUCENIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowUCENIK["IMEUCENIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowUCENIK["OIBUCENIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowUCENIK["RAZRED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 4));
                this.rowUCENIK["ODJELJENJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowUCENIK["SPOLUCENIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowUCENIK["ULICAIBROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowUCENIK["NASELJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowUCENIK["JMBGUCENIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowUCENIK["DATUMRODJENJAUCENIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 10));
                this.rowUCENIK["IMERODITELJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
                this.rowUCENIK["POSTANSKIBROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12));
                this.rowUCENIK["ID_Opcina"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 13));
                this.rowUCENIK["PrezimeRoditelj"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 14));
                this.rowUCENIK["OIBRoditelj"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 15));
                this.rowUCENIK["IBANRoditelj"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 16));
                this.sMode295 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadUcenik();
                this.Gx_mode = this.sMode295;
            }
            else
            {
                this.RcdFound295 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDUCENIK";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmUCENIKSelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [UCENIK] WITH (NOLOCK) ", false);
            this.UCENIKSelect2 = this.cmUCENIKSelect2.FetchData();
            if (this.UCENIKSelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.UCENIKSelect2.GetInt32(0);
            }
            this.UCENIKSelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByPOSTANSKIBROJ(string pOSTANSKIBROJ)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmUCENIKSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [UCENIK] WITH (NOLOCK) WHERE [POSTANSKIBROJ] = @POSTANSKIBROJ ", false);
            if (this.cmUCENIKSelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmUCENIKSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTANSKIBROJ", DbType.String, 5));
            }
            this.cmUCENIKSelect1.SetParameter(0, pOSTANSKIBROJ);
            this.UCENIKSelect1 = this.cmUCENIKSelect1.FetchData();
            if (this.UCENIKSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.UCENIKSelect1.GetInt32(0);
            }
            this.UCENIKSelect1.Close();
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

        public virtual int GetRecordCountByPOSTANSKIBROJ(string pOSTANSKIBROJ)
        {
            int internalRecordCountByPOSTANSKIBROJ;
            try
            {
                this.InitializeMembers();
                internalRecordCountByPOSTANSKIBROJ = this.GetInternalRecordCountByPOSTANSKIBROJ(pOSTANSKIBROJ);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByPOSTANSKIBROJ;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound295 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__PREZIMEUCENIKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IMEUCENIKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OIBUCENIKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__RAZREDOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ODJELJENJEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SPOLUCENIKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ULICAIBROJOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NASELJEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__JMBGUCENIKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DATUMRODJENJAUCENIKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IMERODITELJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POSTANSKIBROJOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ID_OpcinaOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PrezimeRoditeljOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OIBRoditeljOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IBANRoditeljOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Condition = false;
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.UCENIKSet = new UCENIKDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertUcenik()
        {
            this.CheckOptimisticConcurrencyUcenik();
            this.CheckExtendedTableUcenik();
            this.AfterConfirmUcenik();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [UCENIK] ([IDUCENIK], [PREZIMEUCENIK], [IMEUCENIK], [OIBUCENIK], [RAZRED], [ODJELJENJE], [SPOLUCENIKA], [ULICAIBROJ], [NASELJE], [JMBGUCENIKA], [DATUMRODJENJAUCENIKA], [IMERODITELJA], [POSTANSKIBROJ]) VALUES (@IDUCENIK, @PREZIMEUCENIK, @IMEUCENIK, @OIBUCENIK, @RAZRED, @ODJELJENJE, @SPOLUCENIKA, @ULICAIBROJ, @NASELJE, @JMBGUCENIKA, @DATUMRODJENJAUCENIKA, @IMERODITELJA, @POSTANSKIBROJ)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUCENIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PREZIMEUCENIK", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IMEUCENIK", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OIBUCENIK", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZRED", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODJELJENJE", DbType.String, 5));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SPOLUCENIKA", DbType.String, 1));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ULICAIBROJ", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NASELJE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@JMBGUCENIKA", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMRODJENJAUCENIKA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IMERODITELJA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTANSKIBROJ", DbType.String, 5));
                //command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ID_Opcina", DbType.String, 4));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIK["IDUCENIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowUCENIK["PREZIMEUCENIK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowUCENIK["IMEUCENIK"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowUCENIK["OIBUCENIK"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowUCENIK["RAZRED"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowUCENIK["ODJELJENJE"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowUCENIK["SPOLUCENIKA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowUCENIK["ULICAIBROJ"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowUCENIK["NASELJE"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowUCENIK["JMBGUCENIKA"]));
            command.SetParameterDateObject(10, RuntimeHelpers.GetObjectValue(this.rowUCENIK["DATUMRODJENJAUCENIKA"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowUCENIK["IMERODITELJA"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowUCENIK["POSTANSKIBROJ"]));
            //command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowUCENIK["ID_Opcina"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                //throw new UCENIKDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnUCENIKUpdated(new UCENIKEventArgs(this.rowUCENIK, StatementType.Insert));
         }

        private void LoadByIDUCENIK(int startRow, int maxRows)
        {
            bool enforceConstraints = this.UCENIKSet.EnforceConstraints;
            this.UCENIKSet.UCENIK.BeginLoadData();
            this.ScanByIDUCENIK(startRow, maxRows);
            this.UCENIKSet.UCENIK.EndLoadData();
            this.UCENIKSet.EnforceConstraints = enforceConstraints;
            if (this.UCENIKSet.UCENIK.Count > 0)
            {
                this.rowUCENIK = this.UCENIKSet.UCENIK[this.UCENIKSet.UCENIK.Count - 1];
            }
        }

        private void LoadByPOSTANSKIBROJ(int startRow, int maxRows)
        {
            bool enforceConstraints = this.UCENIKSet.EnforceConstraints;
            this.UCENIKSet.UCENIK.BeginLoadData();
            this.ScanByPOSTANSKIBROJ(startRow, maxRows);
            this.UCENIKSet.UCENIK.EndLoadData();
            this.UCENIKSet.EnforceConstraints = enforceConstraints;
            if (this.UCENIKSet.UCENIK.Count > 0)
            {
                this.rowUCENIK = this.UCENIKSet.UCENIK[this.UCENIKSet.UCENIK.Count - 1];
            }
        }

        private void LoadChildUcenik(int startRow, int maxRows)
        {
            this.CreateNewRowUcenik();
            bool enforceConstraints = this.UCENIKSet.EnforceConstraints;
            this.UCENIKSet.UCENIK.BeginLoadData();
            this.ScanStartUcenik(startRow, maxRows);
            this.UCENIKSet.UCENIK.EndLoadData();
            this.UCENIKSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataUcenik(int maxRows)
        {
            int num = 0;
            if (this.RcdFound295 != 0)
            {
                this.ScanLoadUcenik();
                while ((this.RcdFound295 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowUcenik();
                    this.CreateNewRowUcenik();
                    this.ScanNextUcenik();
                }
            }
            if (num > 0)
            {
                this.RcdFound295 = 1;
            }
            this.ScanEndUcenik();
            if (this.UCENIKSet.UCENIK.Count > 0)
            {
                this.rowUCENIK = this.UCENIKSet.UCENIK[this.UCENIKSet.UCENIK.Count - 1];
            }
        }

        private void LoadRowUcenik()
        {
            this.AddRowUcenik();
        }

        private void LoadUcenik()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVPOSTE] FROM [POSTANSKIBROJEVI] WITH (NOLOCK) WHERE [POSTANSKIBROJ] = @POSTANSKIBROJ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTANSKIBROJ", DbType.String, 5));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIK["POSTANSKIBROJ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowUCENIK["NAZIVPOSTE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void OnDeleteControlsUcenik()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVPOSTE] FROM [POSTANSKIBROJEVI] WITH (NOLOCK) WHERE [POSTANSKIBROJ] = @POSTANSKIBROJ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTANSKIBROJ", DbType.String, 5));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIK["POSTANSKIBROJ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowUCENIK["NAZIVPOSTE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void OnUCENIKUpdated(UCENIKEventArgs e)
        {
            if (this.UCENIKUpdated != null)
            {
                UCENIKUpdateEventHandler uCENIKUpdatedEvent = this.UCENIKUpdated;
                if (uCENIKUpdatedEvent != null)
                {
                    uCENIKUpdatedEvent(this, e);
                }
            }
        }

        private void OnUCENIKUpdating(UCENIKEventArgs e)
        {
            if (this.UCENIKUpdating != null)
            {
                UCENIKUpdateEventHandler uCENIKUpdatingEvent = this.UCENIKUpdating;
                if (uCENIKUpdatingEvent != null)
                {
                    uCENIKUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowUcenik()
        {
            this.Gx_mode = Mode.FromRowState(this.rowUCENIK.RowState);
            if (this.rowUCENIK.RowState != DataRowState.Deleted)
            {
                this.rowUCENIK["DATUMRODJENJAUCENIKA"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowUCENIK["DATUMRODJENJAUCENIKA"])));
            }
            if (this.rowUCENIK.RowState != DataRowState.Added)
            {
                this.m__PREZIMEUCENIKOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["PREZIMEUCENIK", DataRowVersion.Original]);
                this.m__IMEUCENIKOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["IMEUCENIK", DataRowVersion.Original]);
                this.m__OIBUCENIKOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["OIBUCENIK", DataRowVersion.Original]);
                this.m__RAZREDOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["RAZRED", DataRowVersion.Original]);
                this.m__ODJELJENJEOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["ODJELJENJE", DataRowVersion.Original]);
                this.m__SPOLUCENIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["SPOLUCENIKA", DataRowVersion.Original]);
                this.m__ULICAIBROJOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["ULICAIBROJ", DataRowVersion.Original]);
                this.m__NASELJEOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["NASELJE", DataRowVersion.Original]);
                this.m__JMBGUCENIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["JMBGUCENIKA", DataRowVersion.Original]);
                this.m__DATUMRODJENJAUCENIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["DATUMRODJENJAUCENIKA", DataRowVersion.Original]);
                this.m__IMERODITELJAOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["IMERODITELJA", DataRowVersion.Original]);
                this.m__POSTANSKIBROJOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["POSTANSKIBROJ", DataRowVersion.Original]);
                this.m__ID_OpcinaOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["ID_Opcina", DataRowVersion.Original]);
            }
            else
            {
                this.m__PREZIMEUCENIKOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["PREZIMEUCENIK"]);
                this.m__IMEUCENIKOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["IMEUCENIK"]);
                this.m__OIBUCENIKOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["OIBUCENIK"]);
                this.m__RAZREDOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["RAZRED"]);
                this.m__ODJELJENJEOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["ODJELJENJE"]);
                this.m__SPOLUCENIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["SPOLUCENIKA"]);
                this.m__ULICAIBROJOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["ULICAIBROJ"]);
                this.m__NASELJEOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["NASELJE"]);
                this.m__JMBGUCENIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["JMBGUCENIKA"]);
                this.m__DATUMRODJENJAUCENIKAOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["DATUMRODJENJAUCENIKA"]);
                this.m__IMERODITELJAOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["IMERODITELJA"]);
                this.m__POSTANSKIBROJOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["POSTANSKIBROJ"]);
                this.m__ID_OpcinaOriginal = RuntimeHelpers.GetObjectValue(this.rowUCENIK["ID_Opcina"]);
            }
            this._Gxremove = this.rowUCENIK.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowUCENIK = (UCENIKDataSet.UCENIKRow) DataSetUtil.CloneOriginalDataRow(this.rowUCENIK);
            }
        }

        private void ScanByIDUCENIK(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDUCENIK] = @IDUCENIK";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString295 + "  FROM ([UCENIK] TM1 WITH (NOLOCK) INNER JOIN [POSTANSKIBROJEVI] T2 WITH (NOLOCK) ON T2.[POSTANSKIBROJ] = TM1.[POSTANSKIBROJ])" + this.m_WhereString + " ORDER BY TM1.[IDUCENIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString295, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDUCENIK] ) AS DK_PAGENUM   FROM ([UCENIK] TM1 WITH (NOLOCK) INNER JOIN [POSTANSKIBROJEVI] T2 WITH (NOLOCK) ON T2.[POSTANSKIBROJ] = TM1.[POSTANSKIBROJ]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString295 + " FROM ([UCENIK] TM1 WITH (NOLOCK) INNER JOIN [POSTANSKIBROJEVI] T2 WITH (NOLOCK) ON T2.[POSTANSKIBROJ] = TM1.[POSTANSKIBROJ])" + this.m_WhereString + " ORDER BY TM1.[IDUCENIK] ";
            }
            this.cmUCENIKSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmUCENIKSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmUCENIKSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUCENIK", DbType.Int32));
            }
            this.cmUCENIKSelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIK["IDUCENIK"]));
            this.UCENIKSelect5 = this.cmUCENIKSelect5.FetchData();
            this.RcdFound295 = 0;
            this.ScanLoadUcenik();
            this.LoadDataUcenik(maxRows);
        }

        private void ScanByPOSTANSKIBROJ(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[POSTANSKIBROJ] = @POSTANSKIBROJ";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString295 + "  FROM ([UCENIK] TM1 WITH (NOLOCK) INNER JOIN [POSTANSKIBROJEVI] T2 WITH (NOLOCK) ON T2.[POSTANSKIBROJ] = TM1.[POSTANSKIBROJ])" + this.m_WhereString + " ORDER BY TM1.[IDUCENIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString295, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDUCENIK] ) AS DK_PAGENUM   FROM ([UCENIK] TM1 WITH (NOLOCK) INNER JOIN [POSTANSKIBROJEVI] T2 WITH (NOLOCK) ON T2.[POSTANSKIBROJ] = TM1.[POSTANSKIBROJ]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString295 + " FROM ([UCENIK] TM1 WITH (NOLOCK) INNER JOIN [POSTANSKIBROJEVI] T2 WITH (NOLOCK) ON T2.[POSTANSKIBROJ] = TM1.[POSTANSKIBROJ])" + this.m_WhereString + " ORDER BY TM1.[IDUCENIK] ";
            }
            this.cmUCENIKSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmUCENIKSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmUCENIKSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTANSKIBROJ", DbType.String, 5));
            }
            this.cmUCENIKSelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIK["POSTANSKIBROJ"]));
            this.UCENIKSelect5 = this.cmUCENIKSelect5.FetchData();
            this.RcdFound295 = 0;
            this.ScanLoadUcenik();
            this.LoadDataUcenik(maxRows);
        }

        private void ScanEndUcenik()
        {
            this.UCENIKSelect5.Close();
        }

        private void ScanLoadUcenik()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmUCENIKSelect5.HasMoreRows)
            {
                this.RcdFound295 = 1;
                this.rowUCENIK["IDUCENIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.UCENIKSelect5, 0));
                this.rowUCENIK["PREZIMEUCENIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKSelect5, 1));
                this.rowUCENIK["IMEUCENIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKSelect5, 2));
                this.rowUCENIK["OIBUCENIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKSelect5, 3));
                this.rowUCENIK["RAZRED"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.UCENIKSelect5, 4));
                this.rowUCENIK["ODJELJENJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKSelect5, 5));
                this.rowUCENIK["SPOLUCENIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKSelect5, 6));
                this.rowUCENIK["ULICAIBROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKSelect5, 7));
                this.rowUCENIK["NASELJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKSelect5, 8));
                this.rowUCENIK["JMBGUCENIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKSelect5, 9));
                this.rowUCENIK["DATUMRODJENJAUCENIKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.UCENIKSelect5, 10));
                this.rowUCENIK["IMERODITELJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKSelect5, 11));
                this.rowUCENIK["NAZIVPOSTE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKSelect5, 12));
                this.rowUCENIK["POSTANSKIBROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKSelect5, 13));
                this.rowUCENIK["NAZIVPOSTE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKSelect5, 12));
                this.rowUCENIK["ID_Opcina"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKSelect5, 14));
                this.rowUCENIK["PrezimeRoditelj"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKSelect5, 15));
                this.rowUCENIK["OIBRoditelj"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKSelect5, 16));
                this.rowUCENIK["IBANRoditelj"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.UCENIKSelect5, 17));
            }
        }

        private void ScanNextUcenik()
        {
            this.cmUCENIKSelect5.HasMoreRows = this.UCENIKSelect5.Read();
            this.RcdFound295 = 0;
            this.ScanLoadUcenik();
        }

        private void ScanStartUcenik(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString295 + "  FROM ([UCENIK] TM1 WITH (NOLOCK) INNER JOIN [POSTANSKIBROJEVI] T2 WITH (NOLOCK) ON T2.[POSTANSKIBROJ] = TM1.[POSTANSKIBROJ])" + this.m_WhereString + " ORDER BY TM1.[IDUCENIK]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString295, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDUCENIK] ) AS DK_PAGENUM   FROM ([UCENIK] TM1 WITH (NOLOCK) INNER JOIN [POSTANSKIBROJEVI] T2 WITH (NOLOCK) ON T2.[POSTANSKIBROJ] = TM1.[POSTANSKIBROJ]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                //micanje starih ucenika
                m_WhereString = " WHERE TM1.[RAZRED] < 20";

                this.scmdbuf = "SELECT " + this.m_SelectString295 + " FROM ([UCENIK] TM1 WITH (NOLOCK) INNER JOIN [POSTANSKIBROJEVI] T2 WITH (NOLOCK) ON T2.[POSTANSKIBROJ] = TM1.[POSTANSKIBROJ])" + this.m_WhereString + " ORDER BY TM1.[IDUCENIK] ";
            }
            this.cmUCENIKSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.UCENIKSelect5 = this.cmUCENIKSelect5.FetchData();
            this.RcdFound295 = 0;
            this.ScanLoadUcenik();
            this.LoadDataUcenik(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.UCENIKSet = (UCENIKDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.UCENIKSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.UCENIKSet.UCENIK.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        UCENIKDataSet.UCENIKRow current = (UCENIKDataSet.UCENIKRow) enumerator.Current;
                        this.rowUCENIK = current;
                        if (Helpers.IsRowChanged(this.rowUCENIK))
                        {
                            this.ReadRowUcenik();
                            if (this.rowUCENIK.RowState == DataRowState.Added)
                            {
                                this.InsertUcenik();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateUcenik();
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

        private void UpdateUcenik()
        {
            this.CheckOptimisticConcurrencyUcenik();
            this.CheckExtendedTableUcenik();
            this.AfterConfirmUcenik();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [UCENIK] SET [PREZIMEUCENIK]=@PREZIMEUCENIK, [IMEUCENIK]=@IMEUCENIK, [OIBUCENIK]=@OIBUCENIK, [RAZRED]=@RAZRED, [ODJELJENJE]=@ODJELJENJE, [SPOLUCENIKA]=@SPOLUCENIKA, [ULICAIBROJ]=@ULICAIBROJ, [NASELJE]=@NASELJE, [JMBGUCENIKA]=@JMBGUCENIKA, [DATUMRODJENJAUCENIKA]=@DATUMRODJENJAUCENIKA, [IMERODITELJA]=@IMERODITELJA, [POSTANSKIBROJ]=@POSTANSKIBROJ WHERE [IDUCENIK] = @IDUCENIK", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PREZIMEUCENIK", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IMEUCENIK", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OIBUCENIK", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZRED", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODJELJENJE", DbType.String, 5));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SPOLUCENIKA", DbType.String, 1));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ULICAIBROJ", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NASELJE", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@JMBGUCENIKA", DbType.String, 13));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMRODJENJAUCENIKA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IMERODITELJA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTANSKIBROJ", DbType.String, 5));
                //command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ID_Opcina", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUCENIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowUCENIK["PREZIMEUCENIK"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowUCENIK["IMEUCENIK"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowUCENIK["OIBUCENIK"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowUCENIK["RAZRED"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowUCENIK["ODJELJENJE"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowUCENIK["SPOLUCENIKA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowUCENIK["ULICAIBROJ"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowUCENIK["NASELJE"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowUCENIK["JMBGUCENIKA"]));
            command.SetParameterDateObject(9, RuntimeHelpers.GetObjectValue(this.rowUCENIK["DATUMRODJENJAUCENIKA"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowUCENIK["IMERODITELJA"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowUCENIK["POSTANSKIBROJ"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowUCENIK["IDUCENIK"]));
            //command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowUCENIK["ID_Opcina"]));
            command.ExecuteStmt();
            this.OnUCENIKUpdated(new UCENIKEventArgs(this.rowUCENIK, StatementType.Update));
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
        public class POSTANSKIBROJEVIForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public POSTANSKIBROJEVIForeignKeyNotFoundException()
            {
            }

            public POSTANSKIBROJEVIForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected POSTANSKIBROJEVIForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public POSTANSKIBROJEVIForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class UCENIKDataChangedException : DataChangedException
        {
            public UCENIKDataChangedException()
            {
            }

            public UCENIKDataChangedException(string message) : base(message)
            {
            }

            protected UCENIKDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UCENIKDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class UCENIKDataLockedException : DataLockedException
        {
            public UCENIKDataLockedException()
            {
            }

            public UCENIKDataLockedException(string message) : base(message)
            {
            }

            protected UCENIKDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UCENIKDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class UCENIKDuplicateKeyException : DuplicateKeyException
        {
            public UCENIKDuplicateKeyException()
            {
            }

            public UCENIKDuplicateKeyException(string message) : base(message)
            {
            }

            protected UCENIKDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UCENIKDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class UCENIKEventArgs : EventArgs
        {
            private UCENIKDataSet.UCENIKRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public UCENIKEventArgs(UCENIKDataSet.UCENIKRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public UCENIKDataSet.UCENIKRow Row
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
        public class UCENIKNotFoundException : DataNotFoundException
        {
            public UCENIKNotFoundException()
            {
            }

            public UCENIKNotFoundException(string message) : base(message)
            {
            }

            protected UCENIKNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UCENIKNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class UCENIKOBRACUNUCENIKOBRACUNDETAILInvalidDeleteException : InvalidDeleteException
        {
            public UCENIKOBRACUNUCENIKOBRACUNDETAILInvalidDeleteException()
            {
            }

            public UCENIKOBRACUNUCENIKOBRACUNDETAILInvalidDeleteException(string message) : base(message)
            {
            }

            protected UCENIKOBRACUNUCENIKOBRACUNDETAILInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public UCENIKOBRACUNUCENIKOBRACUNDETAILInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void UCENIKUpdateEventHandler(object sender, UCENIKDataAdapter.UCENIKEventArgs e);
    }
}

