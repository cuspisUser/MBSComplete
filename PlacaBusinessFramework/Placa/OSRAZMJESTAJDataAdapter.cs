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

    public class OSRAZMJESTAJDataAdapter : IDataAdapter, IOSRAZMJESTAJDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmOSRAZMJESTAJSelect1;
        private ReadWriteCommand cmOSRAZMJESTAJSelect2;
        private ReadWriteCommand cmOSRAZMJESTAJSelect3;
        private ReadWriteCommand cmOSRAZMJESTAJSelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__IDLOKACIJEOriginal;
        private object m__INVBROJOriginal;
        private object m__KOLICINARASHODAOriginal;
        private object m__KOLICINAULAZAOriginal;
        private readonly string m_SelectString279 = "TM1.[IDOSRAZMJESTAJ], TM1.[KOLICINAULAZA], TM1.[KOLICINARASHODA], TM1.[IDLOKACIJE], TM1.[INVBROJ]";
        private string m_WhereString;
        private IDataReader OSRAZMJESTAJSelect1;
        private IDataReader OSRAZMJESTAJSelect2;
        private IDataReader OSRAZMJESTAJSelect3;
        private IDataReader OSRAZMJESTAJSelect6;
        private OSRAZMJESTAJDataSet OSRAZMJESTAJSet;
        private short RcdFound279;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private OSRAZMJESTAJDataSet.OSRAZMJESTAJRow rowOSRAZMJESTAJ;
        private string scmdbuf;
        private StatementType sMode279;

        public event OSRAZMJESTAJUpdateEventHandler OSRAZMJESTAJUpdated;

        public event OSRAZMJESTAJUpdateEventHandler OSRAZMJESTAJUpdating;

        private void AddRowOsrazmjestaj()
        {
            this.OSRAZMJESTAJSet.OSRAZMJESTAJ.AddOSRAZMJESTAJRow(this.rowOSRAZMJESTAJ);
        }

        private void AfterConfirmOsrazmjestaj()
        {
            this.OnOSRAZMJESTAJUpdating(new OSRAZMJESTAJEventArgs(this.rowOSRAZMJESTAJ, this.Gx_mode));
        }

        private void CheckIntegrityErrorsOsrazmjestaj()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDLOKACIJE] FROM [LOKACIJE] WITH (NOLOCK) WHERE [IDLOKACIJE] = @IDLOKACIJE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDLOKACIJE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["IDLOKACIJE"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new LOKACIJEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("LOKACIJE") }));
            }
            reader.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT [INVBROJ] FROM [OS] WITH (NOLOCK) WHERE [INVBROJ] = @INVBROJ ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["INVBROJ"]));
            IDataReader reader2 = command2.FetchData();
            if (!command2.HasMoreRows)
            {
                reader2.Close();
                throw new OSForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OS") }));
            }
            reader2.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyOsrazmjestaj()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOSRAZMJESTAJ], [KOLICINAULAZA], [KOLICINARASHODA], [IDLOKACIJE], [INVBROJ] FROM [OSRAZMJESTAJ] WITH (UPDLOCK) WHERE [IDOSRAZMJESTAJ] = @IDOSRAZMJESTAJ ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSRAZMJESTAJ", DbType.Guid));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["IDOSRAZMJESTAJ"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new OSRAZMJESTAJDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("OSRAZMJESTAJ") }));
                }
                if ((!command.HasMoreRows || !this.m__KOLICINAULAZAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1)))) || ((!this.m__KOLICINARASHODAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))) || !this.m__IDLOKACIJEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 3)))) || !this.m__INVBROJOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt64(reader, 4)))))
                {
                    reader.Close();
                    throw new OSRAZMJESTAJDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("OSRAZMJESTAJ") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowOsrazmjestaj()
        {
            this.rowOSRAZMJESTAJ = this.OSRAZMJESTAJSet.OSRAZMJESTAJ.NewOSRAZMJESTAJRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyOsrazmjestaj();
            this.AfterConfirmOsrazmjestaj();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [OSRAZMJESTAJ]  WHERE [IDOSRAZMJESTAJ] = @IDOSRAZMJESTAJ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSRAZMJESTAJ", DbType.Guid));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["IDOSRAZMJESTAJ"]));
            command.ExecuteStmt();
            this.OnOSRAZMJESTAJUpdated(new OSRAZMJESTAJEventArgs(this.rowOSRAZMJESTAJ, StatementType.Delete));
            this.rowOSRAZMJESTAJ.Delete();
            this.sMode279 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode279;
        }

        public virtual int Fill(OSRAZMJESTAJDataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                Guid iDOSRAZMJESTAJ = new Guid(this.fillDataParameters[0].Value.ToString());
                this.Fill(dataSet, iDOSRAZMJESTAJ);
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.OSRAZMJESTAJSet = dataSet;
                    this.LoadChildOsrazmjestaj(0, -1);
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
            this.OSRAZMJESTAJSet = (OSRAZMJESTAJDataSet) dataSet;
            if (this.OSRAZMJESTAJSet != null)
            {
                return this.Fill(this.OSRAZMJESTAJSet);
            }
            this.OSRAZMJESTAJSet = new OSRAZMJESTAJDataSet();
            this.Fill(this.OSRAZMJESTAJSet);
            dataSet.Merge(this.OSRAZMJESTAJSet);
            return 0;
        }

        public virtual int Fill(OSRAZMJESTAJDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, (Guid) dataRecord["IDOSRAZMJESTAJ"]);
        }

        public virtual int Fill(OSRAZMJESTAJDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, (Guid) dataRecord["IDOSRAZMJESTAJ"]);
        }

        public virtual int Fill(OSRAZMJESTAJDataSet dataSet, Guid iDOSRAZMJESTAJ)
        {
            if (!this.FillByIDOSRAZMJESTAJ(dataSet, iDOSRAZMJESTAJ))
            {
                throw new OSRAZMJESTAJNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OSRAZMJESTAJ") }));
            }
            return 0;
        }

        public virtual int FillByIDLOKACIJE(OSRAZMJESTAJDataSet dataSet, int iDLOKACIJE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSRAZMJESTAJSet = dataSet;
            this.rowOSRAZMJESTAJ = this.OSRAZMJESTAJSet.OSRAZMJESTAJ.NewOSRAZMJESTAJRow();
            this.rowOSRAZMJESTAJ.IDLOKACIJE = iDLOKACIJE;
            try
            {
                this.LoadByIDLOKACIJE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual bool FillByIDOSRAZMJESTAJ(OSRAZMJESTAJDataSet dataSet, Guid iDOSRAZMJESTAJ)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSRAZMJESTAJSet = dataSet;
            this.rowOSRAZMJESTAJ = this.OSRAZMJESTAJSet.OSRAZMJESTAJ.NewOSRAZMJESTAJRow();
            this.rowOSRAZMJESTAJ.IDOSRAZMJESTAJ = iDOSRAZMJESTAJ;
            try
            {
                this.LoadByIDOSRAZMJESTAJ(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound279 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByINVBROJ(OSRAZMJESTAJDataSet dataSet, long iNVBROJ)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSRAZMJESTAJSet = dataSet;
            this.rowOSRAZMJESTAJ = this.OSRAZMJESTAJSet.OSRAZMJESTAJ.NewOSRAZMJESTAJRow();
            this.rowOSRAZMJESTAJ.INVBROJ = iNVBROJ;
            try
            {
                this.LoadByINVBROJ(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(OSRAZMJESTAJDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSRAZMJESTAJSet = dataSet;
            try
            {
                this.LoadChildOsrazmjestaj(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDLOKACIJE(OSRAZMJESTAJDataSet dataSet, int iDLOKACIJE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSRAZMJESTAJSet = dataSet;
            this.rowOSRAZMJESTAJ = this.OSRAZMJESTAJSet.OSRAZMJESTAJ.NewOSRAZMJESTAJRow();
            this.rowOSRAZMJESTAJ.IDLOKACIJE = iDLOKACIJE;
            try
            {
                this.LoadByIDLOKACIJE(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByINVBROJ(OSRAZMJESTAJDataSet dataSet, long iNVBROJ, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSRAZMJESTAJSet = dataSet;
            this.rowOSRAZMJESTAJ = this.OSRAZMJESTAJSet.OSRAZMJESTAJ.NewOSRAZMJESTAJRow();
            this.rowOSRAZMJESTAJ.INVBROJ = iNVBROJ;
            try
            {
                this.LoadByINVBROJ(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOSRAZMJESTAJ], [KOLICINAULAZA], [KOLICINARASHODA], [IDLOKACIJE], [INVBROJ] FROM [OSRAZMJESTAJ] WITH (NOLOCK) WHERE [IDOSRAZMJESTAJ] = @IDOSRAZMJESTAJ ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSRAZMJESTAJ", DbType.Guid));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["IDOSRAZMJESTAJ"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound279 = 1;
                this.rowOSRAZMJESTAJ["IDOSRAZMJESTAJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetGuid(reader, 0));
                this.rowOSRAZMJESTAJ["KOLICINAULAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
                this.rowOSRAZMJESTAJ["KOLICINARASHODA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
                this.rowOSRAZMJESTAJ["IDLOKACIJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 3));
                this.rowOSRAZMJESTAJ["INVBROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt64(reader, 4));
                this.sMode279 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode279;
            }
            else
            {
                this.RcdFound279 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDOSRAZMJESTAJ";
                parameter.DbType = DbType.Guid;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSRAZMJESTAJSelect3 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OSRAZMJESTAJ] WITH (NOLOCK) ", false);
            this.OSRAZMJESTAJSelect3 = this.cmOSRAZMJESTAJSelect3.FetchData();
            if (this.OSRAZMJESTAJSelect3.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OSRAZMJESTAJSelect3.GetInt32(0);
            }
            this.OSRAZMJESTAJSelect3.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDLOKACIJE(int iDLOKACIJE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSRAZMJESTAJSelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OSRAZMJESTAJ] WITH (NOLOCK) WHERE [IDLOKACIJE] = @IDLOKACIJE ", false);
            if (this.cmOSRAZMJESTAJSelect2.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSRAZMJESTAJSelect2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDLOKACIJE", DbType.Int32));
            }
            this.cmOSRAZMJESTAJSelect2.SetParameter(0, iDLOKACIJE);
            this.OSRAZMJESTAJSelect2 = this.cmOSRAZMJESTAJSelect2.FetchData();
            if (this.OSRAZMJESTAJSelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OSRAZMJESTAJSelect2.GetInt32(0);
            }
            this.OSRAZMJESTAJSelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByINVBROJ(long iNVBROJ)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSRAZMJESTAJSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OSRAZMJESTAJ] WITH (NOLOCK) WHERE [INVBROJ] = @INVBROJ ", false);
            if (this.cmOSRAZMJESTAJSelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSRAZMJESTAJSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
            }
            this.cmOSRAZMJESTAJSelect1.SetParameter(0, iNVBROJ);
            this.OSRAZMJESTAJSelect1 = this.cmOSRAZMJESTAJSelect1.FetchData();
            if (this.OSRAZMJESTAJSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OSRAZMJESTAJSelect1.GetInt32(0);
            }
            this.OSRAZMJESTAJSelect1.Close();
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

        public virtual int GetRecordCountByIDLOKACIJE(int iDLOKACIJE)
        {
            int internalRecordCountByIDLOKACIJE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDLOKACIJE = this.GetInternalRecordCountByIDLOKACIJE(iDLOKACIJE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDLOKACIJE;
        }

        public virtual int GetRecordCountByINVBROJ(long iNVBROJ)
        {
            int internalRecordCountByINVBROJ;
            try
            {
                this.InitializeMembers();
                internalRecordCountByINVBROJ = this.GetInternalRecordCountByINVBROJ(iNVBROJ);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByINVBROJ;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound279 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__KOLICINAULAZAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KOLICINARASHODAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDLOKACIJEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__INVBROJOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.OSRAZMJESTAJSet = new OSRAZMJESTAJDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertOsrazmjestaj()
        {
            this.CheckOptimisticConcurrencyOsrazmjestaj();
            this.AfterConfirmOsrazmjestaj();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [OSRAZMJESTAJ] ([IDOSRAZMJESTAJ], [KOLICINAULAZA], [KOLICINARASHODA], [IDLOKACIJE], [INVBROJ]) VALUES (@IDOSRAZMJESTAJ, @KOLICINAULAZA, @KOLICINARASHODA, @IDLOKACIJE, @INVBROJ)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSRAZMJESTAJ", DbType.Guid));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KOLICINAULAZA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KOLICINARASHODA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDLOKACIJE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["IDOSRAZMJESTAJ"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["KOLICINAULAZA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["KOLICINARASHODA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["IDLOKACIJE"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["INVBROJ"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new OSRAZMJESTAJDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsOsrazmjestaj();
            }
            this.OnOSRAZMJESTAJUpdated(new OSRAZMJESTAJEventArgs(this.rowOSRAZMJESTAJ, StatementType.Insert));
        }

        private void LoadByIDLOKACIJE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OSRAZMJESTAJSet.EnforceConstraints;
            this.OSRAZMJESTAJSet.OSRAZMJESTAJ.BeginLoadData();
            this.ScanByIDLOKACIJE(startRow, maxRows);
            this.OSRAZMJESTAJSet.OSRAZMJESTAJ.EndLoadData();
            this.OSRAZMJESTAJSet.EnforceConstraints = enforceConstraints;
            if (this.OSRAZMJESTAJSet.OSRAZMJESTAJ.Count > 0)
            {
                this.rowOSRAZMJESTAJ = this.OSRAZMJESTAJSet.OSRAZMJESTAJ[this.OSRAZMJESTAJSet.OSRAZMJESTAJ.Count - 1];
            }
        }

        private void LoadByIDOSRAZMJESTAJ(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OSRAZMJESTAJSet.EnforceConstraints;
            this.OSRAZMJESTAJSet.OSRAZMJESTAJ.BeginLoadData();
            this.ScanByIDOSRAZMJESTAJ(startRow, maxRows);
            this.OSRAZMJESTAJSet.OSRAZMJESTAJ.EndLoadData();
            this.OSRAZMJESTAJSet.EnforceConstraints = enforceConstraints;
            if (this.OSRAZMJESTAJSet.OSRAZMJESTAJ.Count > 0)
            {
                this.rowOSRAZMJESTAJ = this.OSRAZMJESTAJSet.OSRAZMJESTAJ[this.OSRAZMJESTAJSet.OSRAZMJESTAJ.Count - 1];
            }
        }

        private void LoadByINVBROJ(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OSRAZMJESTAJSet.EnforceConstraints;
            this.OSRAZMJESTAJSet.OSRAZMJESTAJ.BeginLoadData();
            this.ScanByINVBROJ(startRow, maxRows);
            this.OSRAZMJESTAJSet.OSRAZMJESTAJ.EndLoadData();
            this.OSRAZMJESTAJSet.EnforceConstraints = enforceConstraints;
            if (this.OSRAZMJESTAJSet.OSRAZMJESTAJ.Count > 0)
            {
                this.rowOSRAZMJESTAJ = this.OSRAZMJESTAJSet.OSRAZMJESTAJ[this.OSRAZMJESTAJSet.OSRAZMJESTAJ.Count - 1];
            }
        }

        private void LoadChildOsrazmjestaj(int startRow, int maxRows)
        {
            this.CreateNewRowOsrazmjestaj();
            bool enforceConstraints = this.OSRAZMJESTAJSet.EnforceConstraints;
            this.OSRAZMJESTAJSet.OSRAZMJESTAJ.BeginLoadData();
            this.ScanStartOsrazmjestaj(startRow, maxRows);
            this.OSRAZMJESTAJSet.OSRAZMJESTAJ.EndLoadData();
            this.OSRAZMJESTAJSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataOsrazmjestaj(int maxRows)
        {
            int num = 0;
            if (this.RcdFound279 != 0)
            {
                this.ScanLoadOsrazmjestaj();
                while ((this.RcdFound279 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowOsrazmjestaj();
                    this.CreateNewRowOsrazmjestaj();
                    this.ScanNextOsrazmjestaj();
                }
            }
            if (num > 0)
            {
                this.RcdFound279 = 1;
            }
            this.ScanEndOsrazmjestaj();
            if (this.OSRAZMJESTAJSet.OSRAZMJESTAJ.Count > 0)
            {
                this.rowOSRAZMJESTAJ = this.OSRAZMJESTAJSet.OSRAZMJESTAJ[this.OSRAZMJESTAJSet.OSRAZMJESTAJ.Count - 1];
            }
        }

        private void LoadRowOsrazmjestaj()
        {
            this.AddRowOsrazmjestaj();
        }

        private void OnOSRAZMJESTAJUpdated(OSRAZMJESTAJEventArgs e)
        {
            if (this.OSRAZMJESTAJUpdated != null)
            {
                OSRAZMJESTAJUpdateEventHandler oSRAZMJESTAJUpdatedEvent = this.OSRAZMJESTAJUpdated;
                if (oSRAZMJESTAJUpdatedEvent != null)
                {
                    oSRAZMJESTAJUpdatedEvent(this, e);
                }
            }
        }

        private void OnOSRAZMJESTAJUpdating(OSRAZMJESTAJEventArgs e)
        {
            if (this.OSRAZMJESTAJUpdating != null)
            {
                OSRAZMJESTAJUpdateEventHandler oSRAZMJESTAJUpdatingEvent = this.OSRAZMJESTAJUpdating;
                if (oSRAZMJESTAJUpdatingEvent != null)
                {
                    oSRAZMJESTAJUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowOsrazmjestaj()
        {
            this.Gx_mode = Mode.FromRowState(this.rowOSRAZMJESTAJ.RowState);
            if (this.rowOSRAZMJESTAJ.RowState != DataRowState.Added)
            {
                this.m__KOLICINAULAZAOriginal = RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["KOLICINAULAZA", DataRowVersion.Original]);
                this.m__KOLICINARASHODAOriginal = RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["KOLICINARASHODA", DataRowVersion.Original]);
                this.m__IDLOKACIJEOriginal = RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["IDLOKACIJE", DataRowVersion.Original]);
                this.m__INVBROJOriginal = RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["INVBROJ", DataRowVersion.Original]);
            }
            else
            {
                this.m__KOLICINAULAZAOriginal = RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["KOLICINAULAZA"]);
                this.m__KOLICINARASHODAOriginal = RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["KOLICINARASHODA"]);
                this.m__IDLOKACIJEOriginal = RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["IDLOKACIJE"]);
                this.m__INVBROJOriginal = RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["INVBROJ"]);
            }
            this._Gxremove = this.rowOSRAZMJESTAJ.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowOSRAZMJESTAJ = (OSRAZMJESTAJDataSet.OSRAZMJESTAJRow) DataSetUtil.CloneOriginalDataRow(this.rowOSRAZMJESTAJ);
            }
        }

        private void ScanByIDLOKACIJE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDLOKACIJE] = @IDLOKACIJE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString279 + "  FROM [OSRAZMJESTAJ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSRAZMJESTAJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString279, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOSRAZMJESTAJ] ) AS DK_PAGENUM   FROM [OSRAZMJESTAJ] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString279 + " FROM [OSRAZMJESTAJ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSRAZMJESTAJ] ";
            }
            this.cmOSRAZMJESTAJSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOSRAZMJESTAJSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSRAZMJESTAJSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDLOKACIJE", DbType.Int32));
            }
            this.cmOSRAZMJESTAJSelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["IDLOKACIJE"]));
            this.OSRAZMJESTAJSelect6 = this.cmOSRAZMJESTAJSelect6.FetchData();
            this.RcdFound279 = 0;
            this.ScanLoadOsrazmjestaj();
            this.LoadDataOsrazmjestaj(maxRows);
        }

        private void ScanByIDOSRAZMJESTAJ(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDOSRAZMJESTAJ] = @IDOSRAZMJESTAJ";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString279 + "  FROM [OSRAZMJESTAJ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSRAZMJESTAJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString279, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOSRAZMJESTAJ] ) AS DK_PAGENUM   FROM [OSRAZMJESTAJ] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString279 + " FROM [OSRAZMJESTAJ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSRAZMJESTAJ] ";
            }
            this.cmOSRAZMJESTAJSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOSRAZMJESTAJSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSRAZMJESTAJSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSRAZMJESTAJ", DbType.Guid));
            }
            this.cmOSRAZMJESTAJSelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["IDOSRAZMJESTAJ"]));
            this.OSRAZMJESTAJSelect6 = this.cmOSRAZMJESTAJSelect6.FetchData();
            this.RcdFound279 = 0;
            this.ScanLoadOsrazmjestaj();
            this.LoadDataOsrazmjestaj(maxRows);
        }

        private void ScanByINVBROJ(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[INVBROJ] = @INVBROJ";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString279 + "  FROM [OSRAZMJESTAJ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSRAZMJESTAJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString279, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOSRAZMJESTAJ] ) AS DK_PAGENUM   FROM [OSRAZMJESTAJ] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString279 + " FROM [OSRAZMJESTAJ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSRAZMJESTAJ] ";
            }
            this.cmOSRAZMJESTAJSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOSRAZMJESTAJSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSRAZMJESTAJSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
            }
            this.cmOSRAZMJESTAJSelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["INVBROJ"]));
            this.OSRAZMJESTAJSelect6 = this.cmOSRAZMJESTAJSelect6.FetchData();
            this.RcdFound279 = 0;
            this.ScanLoadOsrazmjestaj();
            this.LoadDataOsrazmjestaj(maxRows);
        }

        private void ScanEndOsrazmjestaj()
        {
            this.OSRAZMJESTAJSelect6.Close();
        }

        private void ScanLoadOsrazmjestaj()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmOSRAZMJESTAJSelect6.HasMoreRows)
            {
                this.RcdFound279 = 1;
                this.rowOSRAZMJESTAJ["IDOSRAZMJESTAJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetGuid(this.OSRAZMJESTAJSelect6, 0));
                this.rowOSRAZMJESTAJ["KOLICINAULAZA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OSRAZMJESTAJSelect6, 1));
                this.rowOSRAZMJESTAJ["KOLICINARASHODA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.OSRAZMJESTAJSelect6, 2));
                this.rowOSRAZMJESTAJ["IDLOKACIJE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OSRAZMJESTAJSelect6, 3));
                this.rowOSRAZMJESTAJ["INVBROJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt64(this.OSRAZMJESTAJSelect6, 4));
            }
        }

        private void ScanNextOsrazmjestaj()
        {
            this.cmOSRAZMJESTAJSelect6.HasMoreRows = this.OSRAZMJESTAJSelect6.Read();
            this.RcdFound279 = 0;
            this.ScanLoadOsrazmjestaj();
        }

        private void ScanStartOsrazmjestaj(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString279 + "  FROM [OSRAZMJESTAJ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSRAZMJESTAJ]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString279, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOSRAZMJESTAJ] ) AS DK_PAGENUM   FROM [OSRAZMJESTAJ] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString279 + " FROM [OSRAZMJESTAJ] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSRAZMJESTAJ] ";
            }
            this.cmOSRAZMJESTAJSelect6 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.OSRAZMJESTAJSelect6 = this.cmOSRAZMJESTAJSelect6.FetchData();
            this.RcdFound279 = 0;
            this.ScanLoadOsrazmjestaj();
            this.LoadDataOsrazmjestaj(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.OSRAZMJESTAJSet = (OSRAZMJESTAJDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.OSRAZMJESTAJSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.OSRAZMJESTAJSet.OSRAZMJESTAJ.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        OSRAZMJESTAJDataSet.OSRAZMJESTAJRow current = (OSRAZMJESTAJDataSet.OSRAZMJESTAJRow) enumerator.Current;
                        this.rowOSRAZMJESTAJ = current;
                        if (Helpers.IsRowChanged(this.rowOSRAZMJESTAJ))
                        {
                            this.ReadRowOsrazmjestaj();
                            if (this.rowOSRAZMJESTAJ.RowState == DataRowState.Added)
                            {
                                this.InsertOsrazmjestaj();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateOsrazmjestaj();
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

        private void UpdateOsrazmjestaj()
        {
            this.CheckOptimisticConcurrencyOsrazmjestaj();
            this.AfterConfirmOsrazmjestaj();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [OSRAZMJESTAJ] SET [KOLICINAULAZA]=@KOLICINAULAZA, [KOLICINARASHODA]=@KOLICINARASHODA, [IDLOKACIJE]=@IDLOKACIJE, [INVBROJ]=@INVBROJ  WHERE [IDOSRAZMJESTAJ] = @IDOSRAZMJESTAJ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KOLICINAULAZA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KOLICINARASHODA", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDLOKACIJE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSRAZMJESTAJ", DbType.Guid));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["KOLICINAULAZA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["KOLICINARASHODA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["IDLOKACIJE"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["INVBROJ"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOSRAZMJESTAJ["IDOSRAZMJESTAJ"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsOsrazmjestaj();
            }
            this.OnOSRAZMJESTAJUpdated(new OSRAZMJESTAJEventArgs(this.rowOSRAZMJESTAJ, StatementType.Update));
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
        public class ForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public ForeignKeyNotFoundException()
            {
            }

            public ForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected ForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class LOKACIJEForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public LOKACIJEForeignKeyNotFoundException()
            {
            }

            public LOKACIJEForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected LOKACIJEForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public LOKACIJEForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public OSForeignKeyNotFoundException()
            {
            }

            public OSForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected OSForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSRAZMJESTAJDataChangedException : DataChangedException
        {
            public OSRAZMJESTAJDataChangedException()
            {
            }

            public OSRAZMJESTAJDataChangedException(string message) : base(message)
            {
            }

            protected OSRAZMJESTAJDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSRAZMJESTAJDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSRAZMJESTAJDataLockedException : DataLockedException
        {
            public OSRAZMJESTAJDataLockedException()
            {
            }

            public OSRAZMJESTAJDataLockedException(string message) : base(message)
            {
            }

            protected OSRAZMJESTAJDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSRAZMJESTAJDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSRAZMJESTAJDuplicateKeyException : DuplicateKeyException
        {
            public OSRAZMJESTAJDuplicateKeyException()
            {
            }

            public OSRAZMJESTAJDuplicateKeyException(string message) : base(message)
            {
            }

            protected OSRAZMJESTAJDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSRAZMJESTAJDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class OSRAZMJESTAJEventArgs : EventArgs
        {
            private OSRAZMJESTAJDataSet.OSRAZMJESTAJRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public OSRAZMJESTAJEventArgs(OSRAZMJESTAJDataSet.OSRAZMJESTAJRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OSRAZMJESTAJDataSet.OSRAZMJESTAJRow Row
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
        public class OSRAZMJESTAJNotFoundException : DataNotFoundException
        {
            public OSRAZMJESTAJNotFoundException()
            {
            }

            public OSRAZMJESTAJNotFoundException(string message) : base(message)
            {
            }

            protected OSRAZMJESTAJNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSRAZMJESTAJNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void OSRAZMJESTAJUpdateEventHandler(object sender, OSRAZMJESTAJDataAdapter.OSRAZMJESTAJEventArgs e);
    }
}

