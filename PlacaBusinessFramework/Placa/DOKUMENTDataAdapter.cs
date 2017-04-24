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

    public class DOKUMENTDataAdapter : IDataAdapter, IDOKUMENTDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmDOKUMENTSelect1;
        private ReadWriteCommand cmDOKUMENTSelect2;
        private ReadWriteCommand cmDOKUMENTSelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DOKUMENTSelect1;
        private IDataReader DOKUMENTSelect2;
        private IDataReader DOKUMENTSelect5;
        private DOKUMENTDataSet DOKUMENTSet;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__IDTIPDOKUMENTAOriginal;
        private object m__NAZIVDOKUMENTOriginal;
        private object m__PSOriginal;
        private readonly string m_SelectString184 = "TM1.[IDDOKUMENT], TM1.[NAZIVDOKUMENT], T2.[NAZIVTIPDOKUMENTA], TM1.[PS], TM1.[IDTIPDOKUMENTA]";
        private string m_WhereString;
        private short RcdFound184;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private DOKUMENTDataSet.DOKUMENTRow rowDOKUMENT;
        private string scmdbuf;
        private StatementType sMode184;

        public event DOKUMENTUpdateEventHandler DOKUMENTUpdated;

        public event DOKUMENTUpdateEventHandler DOKUMENTUpdating;

        private void AddRowDokument()
        {
            this.DOKUMENTSet.DOKUMENT.AddDOKUMENTRow(this.rowDOKUMENT);
        }

        private void AfterConfirmDokument()
        {
            this.OnDOKUMENTUpdating(new DOKUMENTEventArgs(this.rowDOKUMENT, this.Gx_mode));
        }

        private void CheckDeleteErrorsDokument()
        {
            ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMAIRA] FROM [SHEMAIRA] WITH (NOLOCK) WHERE [SHEMAIRADOKIDDOKUMENT] = @IDDOKUMENT ", false);
            if (command4.IDbCommand.Parameters.Count == 0)
            {
                command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["IDDOKUMENT"]));
            IDataReader reader4 = command4.FetchData();
            if (command4.HasMoreRows)
            {
                reader4.Close();
                throw new SHEMAIRAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMAIRA" }));
            }
            reader4.Close();
            ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT TOP 1 [URAGODIDGODINE], [URADOKIDDOKUMENT], [URABROJ] FROM [URA] WITH (NOLOCK) WHERE [URADOKIDDOKUMENT] = @IDDOKUMENT ", false);
            if (command5.IDbCommand.Parameters.Count == 0)
            {
                command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["IDDOKUMENT"]));
            IDataReader reader5 = command5.FetchData();
            if (command5.HasMoreRows)
            {
                reader5.Close();
                throw new URAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "URA" }));
            }
            reader5.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT TOP 1 [IRAGODIDGODINE], [IRADOKIDDOKUMENT], [IRABROJ] FROM [IRA] WITH (NOLOCK) WHERE [IRADOKIDDOKUMENT] = @IDDOKUMENT ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["IDDOKUMENT"]));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                reader3.Close();
                throw new IRAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "IRA" }));
            }
            reader3.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [IDGKSTAVKA] FROM [GKSTAVKA] WITH (NOLOCK) WHERE [IDDOKUMENT] = @IDDOKUMENT ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["IDDOKUMENT"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new GKSTAVKAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "GKSTAVKA" }));
            }
            reader2.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [BLGDOKIDDOKUMENT] FROM [BLAGAJNA] WITH (NOLOCK) WHERE [BLGDOKIDDOKUMENT] = @IDDOKUMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["IDDOKUMENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new BLAGAJNAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "BLAGAJNA" }));
            }
            reader.Close();
        }

        private void CheckExtendedTableDokument()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVTIPDOKUMENTA] FROM [TIPDOKUMENTA] WITH (NOLOCK) WHERE [IDTIPDOKUMENTA] = @IDTIPDOKUMENTA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPDOKUMENTA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["IDTIPDOKUMENTA"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new TIPDOKUMENTAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("TIPDOKUMENTA") }));
            }
            this.rowDOKUMENT["NAZIVTIPDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            reader.Close();
        }

        private void CheckOptimisticConcurrencyDokument()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDDOKUMENT], [NAZIVDOKUMENT], [PS], [IDTIPDOKUMENTA] FROM [DOKUMENT] WITH (UPDLOCK) WHERE [IDDOKUMENT] = @IDDOKUMENT ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["IDDOKUMENT"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DOKUMENTDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DOKUMENT") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVDOKUMENTOriginal), RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))))) || (!this.m__PSOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 2))) || !this.m__IDTIPDOKUMENTAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 3)))))
                {
                    reader.Close();
                    throw new DOKUMENTDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DOKUMENT") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowDokument()
        {
            this.rowDOKUMENT = this.DOKUMENTSet.DOKUMENT.NewDOKUMENTRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDokument();
            this.OnDeleteControlsDokument();
            this.AfterConfirmDokument();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DOKUMENT]  WHERE [IDDOKUMENT] = @IDDOKUMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["IDDOKUMENT"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsDokument();
            }
            this.OnDOKUMENTUpdated(new DOKUMENTEventArgs(this.rowDOKUMENT, StatementType.Delete));
            this.rowDOKUMENT.Delete();
            this.sMode184 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode184;
        }

        public virtual int Fill(DOKUMENTDataSet dataSet)
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
                    this.DOKUMENTSet = dataSet;
                    this.LoadChildDokument(0, -1);
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
            this.DOKUMENTSet = (DOKUMENTDataSet) dataSet;
            if (this.DOKUMENTSet != null)
            {
                return this.Fill(this.DOKUMENTSet);
            }
            this.DOKUMENTSet = new DOKUMENTDataSet();
            this.Fill(this.DOKUMENTSet);
            dataSet.Merge(this.DOKUMENTSet);
            return 0;
        }

        public virtual int Fill(DOKUMENTDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDDOKUMENT"]));
        }

        public virtual int Fill(DOKUMENTDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDDOKUMENT"]));
        }

        public virtual int Fill(DOKUMENTDataSet dataSet, int iDDOKUMENT)
        {
            if (!this.FillByIDDOKUMENT(dataSet, iDDOKUMENT))
            {
                throw new DOKUMENTNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DOKUMENT") }));
            }
            return 0;
        }

        public virtual bool FillByIDDOKUMENT(DOKUMENTDataSet dataSet, int iDDOKUMENT)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DOKUMENTSet = dataSet;
            this.rowDOKUMENT = this.DOKUMENTSet.DOKUMENT.NewDOKUMENTRow();
            this.rowDOKUMENT.IDDOKUMENT = iDDOKUMENT;
            try
            {
                this.LoadByIDDOKUMENT(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound184 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByIDTIPDOKUMENTA(DOKUMENTDataSet dataSet, int iDTIPDOKUMENTA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DOKUMENTSet = dataSet;
            this.rowDOKUMENT = this.DOKUMENTSet.DOKUMENT.NewDOKUMENTRow();
            this.rowDOKUMENT.IDTIPDOKUMENTA = iDTIPDOKUMENTA;
            try
            {
                this.LoadByIDTIPDOKUMENTA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(DOKUMENTDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DOKUMENTSet = dataSet;
            try
            {
                this.LoadChildDokument(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDTIPDOKUMENTA(DOKUMENTDataSet dataSet, int iDTIPDOKUMENTA, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DOKUMENTSet = dataSet;
            this.rowDOKUMENT = this.DOKUMENTSet.DOKUMENT.NewDOKUMENTRow();
            this.rowDOKUMENT.IDTIPDOKUMENTA = iDTIPDOKUMENTA;
            try
            {
                this.LoadByIDTIPDOKUMENTA(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDDOKUMENT], [NAZIVDOKUMENT], [PS], [IDTIPDOKUMENTA] FROM [DOKUMENT] WITH (NOLOCK) WHERE [IDDOKUMENT] = @IDDOKUMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["IDDOKUMENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound184 = 1;
                this.rowDOKUMENT["IDDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowDOKUMENT["NAZIVDOKUMENT"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))));
                this.rowDOKUMENT["PS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 2));
                this.rowDOKUMENT["IDTIPDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 3));
                this.sMode184 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadDokument();
                this.Gx_mode = this.sMode184;
            }
            else
            {
                this.RcdFound184 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDDOKUMENT";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDOKUMENTSelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [DOKUMENT] WITH (NOLOCK) ", false);
            this.DOKUMENTSelect2 = this.cmDOKUMENTSelect2.FetchData();
            if (this.DOKUMENTSelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.DOKUMENTSelect2.GetInt32(0);
            }
            this.DOKUMENTSelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDTIPDOKUMENTA(int iDTIPDOKUMENTA)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDOKUMENTSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [DOKUMENT] WITH (NOLOCK) WHERE [IDTIPDOKUMENTA] = @IDTIPDOKUMENTA ", false);
            if (this.cmDOKUMENTSelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOKUMENTSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPDOKUMENTA", DbType.Int32));
            }
            this.cmDOKUMENTSelect1.SetParameter(0, iDTIPDOKUMENTA);
            this.DOKUMENTSelect1 = this.cmDOKUMENTSelect1.FetchData();
            if (this.DOKUMENTSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.DOKUMENTSelect1.GetInt32(0);
            }
            this.DOKUMENTSelect1.Close();
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

        public virtual int GetRecordCountByIDTIPDOKUMENTA(int iDTIPDOKUMENTA)
        {
            int internalRecordCountByIDTIPDOKUMENTA;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDTIPDOKUMENTA = this.GetInternalRecordCountByIDTIPDOKUMENTA(iDTIPDOKUMENTA);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDTIPDOKUMENTA;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound184 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVDOKUMENTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDTIPDOKUMENTAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.DOKUMENTSet = new DOKUMENTDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertDokument()
        {
            this.CheckOptimisticConcurrencyDokument();
            this.CheckExtendedTableDokument();
            this.AfterConfirmDokument();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DOKUMENT] ([IDDOKUMENT], [NAZIVDOKUMENT], [PS], [IDTIPDOKUMENTA]) VALUES (@IDDOKUMENT, @NAZIVDOKUMENT, @PS, @IDTIPDOKUMENTA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVDOKUMENT", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PS", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPDOKUMENTA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["IDDOKUMENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["NAZIVDOKUMENT"]))));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["PS"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["IDTIPDOKUMENTA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DOKUMENTDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDOKUMENTUpdated(new DOKUMENTEventArgs(this.rowDOKUMENT, StatementType.Insert));
        }

        private void LoadByIDDOKUMENT(int startRow, int maxRows)
        {
            bool enforceConstraints = this.DOKUMENTSet.EnforceConstraints;
            this.DOKUMENTSet.DOKUMENT.BeginLoadData();
            this.ScanByIDDOKUMENT(startRow, maxRows);
            this.DOKUMENTSet.DOKUMENT.EndLoadData();
            this.DOKUMENTSet.EnforceConstraints = enforceConstraints;
            if (this.DOKUMENTSet.DOKUMENT.Count > 0)
            {
                this.rowDOKUMENT = this.DOKUMENTSet.DOKUMENT[this.DOKUMENTSet.DOKUMENT.Count - 1];
            }
        }

        private void LoadByIDTIPDOKUMENTA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.DOKUMENTSet.EnforceConstraints;
            this.DOKUMENTSet.DOKUMENT.BeginLoadData();
            this.ScanByIDTIPDOKUMENTA(startRow, maxRows);
            this.DOKUMENTSet.DOKUMENT.EndLoadData();
            this.DOKUMENTSet.EnforceConstraints = enforceConstraints;
            if (this.DOKUMENTSet.DOKUMENT.Count > 0)
            {
                this.rowDOKUMENT = this.DOKUMENTSet.DOKUMENT[this.DOKUMENTSet.DOKUMENT.Count - 1];
            }
        }

        private void LoadChildDokument(int startRow, int maxRows)
        {
            this.CreateNewRowDokument();
            bool enforceConstraints = this.DOKUMENTSet.EnforceConstraints;
            this.DOKUMENTSet.DOKUMENT.BeginLoadData();
            this.ScanStartDokument(startRow, maxRows);
            this.DOKUMENTSet.DOKUMENT.EndLoadData();
            this.DOKUMENTSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataDokument(int maxRows)
        {
            int num = 0;
            if (this.RcdFound184 != 0)
            {
                this.ScanLoadDokument();
                while ((this.RcdFound184 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowDokument();
                    this.CreateNewRowDokument();
                    this.ScanNextDokument();
                }
            }
            if (num > 0)
            {
                this.RcdFound184 = 1;
            }
            this.ScanEndDokument();
            if (this.DOKUMENTSet.DOKUMENT.Count > 0)
            {
                this.rowDOKUMENT = this.DOKUMENTSet.DOKUMENT[this.DOKUMENTSet.DOKUMENT.Count - 1];
            }
        }

        private void LoadDokument()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVTIPDOKUMENTA] FROM [TIPDOKUMENTA] WITH (NOLOCK) WHERE [IDTIPDOKUMENTA] = @IDTIPDOKUMENTA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPDOKUMENTA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["IDTIPDOKUMENTA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowDOKUMENT["NAZIVTIPDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void LoadRowDokument()
        {
            this.AddRowDokument();
        }

        private void OnDeleteControlsDokument()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVTIPDOKUMENTA] FROM [TIPDOKUMENTA] WITH (NOLOCK) WHERE [IDTIPDOKUMENTA] = @IDTIPDOKUMENTA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPDOKUMENTA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["IDTIPDOKUMENTA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowDOKUMENT["NAZIVTIPDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void OnDOKUMENTUpdated(DOKUMENTEventArgs e)
        {
            if (this.DOKUMENTUpdated != null)
            {
                DOKUMENTUpdateEventHandler dOKUMENTUpdatedEvent = this.DOKUMENTUpdated;
                if (dOKUMENTUpdatedEvent != null)
                {
                    dOKUMENTUpdatedEvent(this, e);
                }
            }
        }

        private void OnDOKUMENTUpdating(DOKUMENTEventArgs e)
        {
            if (this.DOKUMENTUpdating != null)
            {
                DOKUMENTUpdateEventHandler dOKUMENTUpdatingEvent = this.DOKUMENTUpdating;
                if (dOKUMENTUpdatingEvent != null)
                {
                    dOKUMENTUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowDokument()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDOKUMENT.RowState);
            if (this.rowDOKUMENT.RowState != DataRowState.Added)
            {
                this.m__NAZIVDOKUMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["NAZIVDOKUMENT", DataRowVersion.Original]);
                this.m__PSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["PS", DataRowVersion.Original]);
                this.m__IDTIPDOKUMENTAOriginal = RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["IDTIPDOKUMENTA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVDOKUMENTOriginal = RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["NAZIVDOKUMENT"]);
                this.m__PSOriginal = RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["PS"]);
                this.m__IDTIPDOKUMENTAOriginal = RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["IDTIPDOKUMENTA"]);
            }
            this._Gxremove = this.rowDOKUMENT.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowDOKUMENT = (DOKUMENTDataSet.DOKUMENTRow) DataSetUtil.CloneOriginalDataRow(this.rowDOKUMENT);
            }
        }

        private void ScanByIDDOKUMENT(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDDOKUMENT] = @IDDOKUMENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString184 + "  FROM ([DOKUMENT] TM1 WITH (NOLOCK) INNER JOIN [TIPDOKUMENTA] T2 WITH (NOLOCK) ON T2.[IDTIPDOKUMENTA] = TM1.[IDTIPDOKUMENTA])" + this.m_WhereString + " ORDER BY TM1.[IDDOKUMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString184, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDDOKUMENT] ) AS DK_PAGENUM   FROM ([DOKUMENT] TM1 WITH (NOLOCK) INNER JOIN [TIPDOKUMENTA] T2 WITH (NOLOCK) ON T2.[IDTIPDOKUMENTA] = TM1.[IDTIPDOKUMENTA]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString184 + " FROM ([DOKUMENT] TM1 WITH (NOLOCK) INNER JOIN [TIPDOKUMENTA] T2 WITH (NOLOCK) ON T2.[IDTIPDOKUMENTA] = TM1.[IDTIPDOKUMENTA])" + this.m_WhereString + " ORDER BY TM1.[IDDOKUMENT] ";
            }
            this.cmDOKUMENTSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmDOKUMENTSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOKUMENTSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            this.cmDOKUMENTSelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["IDDOKUMENT"]));
            this.DOKUMENTSelect5 = this.cmDOKUMENTSelect5.FetchData();
            this.RcdFound184 = 0;
            this.ScanLoadDokument();
            this.LoadDataDokument(maxRows);
        }

        private void ScanByIDTIPDOKUMENTA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDTIPDOKUMENTA] = @IDTIPDOKUMENTA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString184 + "  FROM ([DOKUMENT] TM1 WITH (NOLOCK) INNER JOIN [TIPDOKUMENTA] T2 WITH (NOLOCK) ON T2.[IDTIPDOKUMENTA] = TM1.[IDTIPDOKUMENTA])" + this.m_WhereString + " ORDER BY TM1.[IDDOKUMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString184, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDDOKUMENT] ) AS DK_PAGENUM   FROM ([DOKUMENT] TM1 WITH (NOLOCK) INNER JOIN [TIPDOKUMENTA] T2 WITH (NOLOCK) ON T2.[IDTIPDOKUMENTA] = TM1.[IDTIPDOKUMENTA]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString184 + " FROM ([DOKUMENT] TM1 WITH (NOLOCK) INNER JOIN [TIPDOKUMENTA] T2 WITH (NOLOCK) ON T2.[IDTIPDOKUMENTA] = TM1.[IDTIPDOKUMENTA])" + this.m_WhereString + " ORDER BY TM1.[IDDOKUMENT] ";
            }
            this.cmDOKUMENTSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmDOKUMENTSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOKUMENTSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPDOKUMENTA", DbType.Int32));
            }
            this.cmDOKUMENTSelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["IDTIPDOKUMENTA"]));
            this.DOKUMENTSelect5 = this.cmDOKUMENTSelect5.FetchData();
            this.RcdFound184 = 0;
            this.ScanLoadDokument();
            this.LoadDataDokument(maxRows);
        }

        private void ScanEndDokument()
        {
            this.DOKUMENTSelect5.Close();
        }

        private void ScanLoadDokument()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDOKUMENTSelect5.HasMoreRows)
            {
                this.RcdFound184 = 1;
                this.rowDOKUMENT["IDDOKUMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DOKUMENTSelect5, 0));
                this.rowDOKUMENT["NAZIVDOKUMENT"] = RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOKUMENTSelect5, 1))));
                this.rowDOKUMENT["NAZIVTIPDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOKUMENTSelect5, 2));
                this.rowDOKUMENT["PS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.DOKUMENTSelect5, 3));
                this.rowDOKUMENT["IDTIPDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DOKUMENTSelect5, 4));
                this.rowDOKUMENT["NAZIVTIPDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DOKUMENTSelect5, 2));
            }
        }

        private void ScanNextDokument()
        {
            this.cmDOKUMENTSelect5.HasMoreRows = this.DOKUMENTSelect5.Read();
            this.RcdFound184 = 0;
            this.ScanLoadDokument();
        }

        private void ScanStartDokument(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString184 + "  FROM ([DOKUMENT] TM1 WITH (NOLOCK) INNER JOIN [TIPDOKUMENTA] T2 WITH (NOLOCK) ON T2.[IDTIPDOKUMENTA] = TM1.[IDTIPDOKUMENTA])" + this.m_WhereString + " ORDER BY TM1.[IDDOKUMENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString184, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDDOKUMENT] ) AS DK_PAGENUM   FROM ([DOKUMENT] TM1 WITH (NOLOCK) INNER JOIN [TIPDOKUMENTA] T2 WITH (NOLOCK) ON T2.[IDTIPDOKUMENTA] = TM1.[IDTIPDOKUMENTA]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString184 + " FROM ([DOKUMENT] TM1 WITH (NOLOCK) INNER JOIN [TIPDOKUMENTA] T2 WITH (NOLOCK) ON T2.[IDTIPDOKUMENTA] = TM1.[IDTIPDOKUMENTA])" + this.m_WhereString + " ORDER BY TM1.[IDDOKUMENT] ";
            }
            this.cmDOKUMENTSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.DOKUMENTSelect5 = this.cmDOKUMENTSelect5.FetchData();
            this.RcdFound184 = 0;
            this.ScanLoadDokument();
            this.LoadDataDokument(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.DOKUMENTSet = (DOKUMENTDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.DOKUMENTSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.DOKUMENTSet.DOKUMENT.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DOKUMENTDataSet.DOKUMENTRow current = (DOKUMENTDataSet.DOKUMENTRow) enumerator.Current;
                        this.rowDOKUMENT = current;
                        if (Helpers.IsRowChanged(this.rowDOKUMENT))
                        {
                            this.ReadRowDokument();
                            if (this.rowDOKUMENT.RowState == DataRowState.Added)
                            {
                                this.InsertDokument();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateDokument();
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

        private void UpdateDokument()
        {
            this.CheckOptimisticConcurrencyDokument();
            this.CheckExtendedTableDokument();
            this.AfterConfirmDokument();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DOKUMENT] SET [NAZIVDOKUMENT]=@NAZIVDOKUMENT, [PS]=@PS, [IDTIPDOKUMENTA]=@IDTIPDOKUMENTA  WHERE [IDDOKUMENT] = @IDDOKUMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVDOKUMENT", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PS", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPDOKUMENTA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["NAZIVDOKUMENT"]))));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["PS"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["IDTIPDOKUMENTA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowDOKUMENT["IDDOKUMENT"]));
            command.ExecuteStmt();
            this.OnDOKUMENTUpdated(new DOKUMENTEventArgs(this.rowDOKUMENT, StatementType.Update));
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
        public class DOKUMENTDataChangedException : DataChangedException
        {
            public DOKUMENTDataChangedException()
            {
            }

            public DOKUMENTDataChangedException(string message) : base(message)
            {
            }

            protected DOKUMENTDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOKUMENTDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DOKUMENTDataLockedException : DataLockedException
        {
            public DOKUMENTDataLockedException()
            {
            }

            public DOKUMENTDataLockedException(string message) : base(message)
            {
            }

            protected DOKUMENTDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOKUMENTDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DOKUMENTDuplicateKeyException : DuplicateKeyException
        {
            public DOKUMENTDuplicateKeyException()
            {
            }

            public DOKUMENTDuplicateKeyException(string message) : base(message)
            {
            }

            protected DOKUMENTDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOKUMENTDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DOKUMENTEventArgs : EventArgs
        {
            private DOKUMENTDataSet.DOKUMENTRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public DOKUMENTEventArgs(DOKUMENTDataSet.DOKUMENTRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DOKUMENTDataSet.DOKUMENTRow Row
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
        public class DOKUMENTNotFoundException : DataNotFoundException
        {
            public DOKUMENTNotFoundException()
            {
            }

            public DOKUMENTNotFoundException(string message) : base(message)
            {
            }

            protected DOKUMENTNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DOKUMENTNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void DOKUMENTUpdateEventHandler(object sender, DOKUMENTDataAdapter.DOKUMENTEventArgs e);

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
        public class IRAInvalidDeleteException : InvalidDeleteException
        {
            public IRAInvalidDeleteException()
            {
            }

            public IRAInvalidDeleteException(string message) : base(message)
            {
            }

            protected IRAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IRAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SHEMAIRAInvalidDeleteException : InvalidDeleteException
        {
            public SHEMAIRAInvalidDeleteException()
            {
            }

            public SHEMAIRAInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMAIRAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMAIRAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPDOKUMENTAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public TIPDOKUMENTAForeignKeyNotFoundException()
            {
            }

            public TIPDOKUMENTAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected TIPDOKUMENTAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPDOKUMENTAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class URAInvalidDeleteException : InvalidDeleteException
        {
            public URAInvalidDeleteException()
            {
            }

            public URAInvalidDeleteException(string message) : base(message)
            {
            }

            protected URAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public URAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

