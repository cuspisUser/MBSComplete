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

    public class GRUPEKOEFDataAdapter : IDataAdapter, IGRUPEKOEFDataAdapter
    {
        private bool _Gxremove;
        private bool _Gxremove15;
        private ReadWriteCommand cmGRUPEKOEFLevel1Select2;
        private ReadWriteCommand cmGRUPEKOEFSelect1;
        private ReadWriteCommand cmGRUPEKOEFSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private IDataReader GRUPEKOEFLevel1Select2;
        private IDataReader GRUPEKOEFSelect1;
        private IDataReader GRUPEKOEFSelect4;
        private GRUPEKOEFDataSet GRUPEKOEFSet;
        private StatementType Gx_mode;
        private object m__IDMZOSTABLICEOriginal;
        private object m__NAZIVGRUPEKOEFOriginal;
        private readonly string m_SelectString95 = "TM1.[IDGRUPEKOEF], TM1.[NAZIVGRUPEKOEF]";
        private string m_SubSelTopString96;
        private string m_WhereString;
        private short RcdFound95;
        private short RcdFound96;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private GRUPEKOEFDataSet.GRUPEKOEFRow rowGRUPEKOEF;
        private GRUPEKOEFDataSet.GRUPEKOEFLevel1Row rowGRUPEKOEFLevel1;
        private string scmdbuf;
        private StatementType sMode95;
        private StatementType sMode96;

        public event GRUPEKOEFLevel1UpdateEventHandler GRUPEKOEFLevel1Updated;

        public event GRUPEKOEFLevel1UpdateEventHandler GRUPEKOEFLevel1Updating;

        public event GRUPEKOEFUpdateEventHandler GRUPEKOEFUpdated;

        public event GRUPEKOEFUpdateEventHandler GRUPEKOEFUpdating;

        private void AddRowGrupekoef()
        {
            this.GRUPEKOEFSet.GRUPEKOEF.AddGRUPEKOEFRow(this.rowGRUPEKOEF);
        }

        private void AddRowGrupekoeflevel1()
        {
            this.GRUPEKOEFSet.GRUPEKOEFLevel1.AddGRUPEKOEFLevel1Row(this.rowGRUPEKOEFLevel1);
        }

        private void AfterConfirmGrupekoef()
        {
            this.OnGRUPEKOEFUpdating(new GRUPEKOEFEventArgs(this.rowGRUPEKOEF, this.Gx_mode));
        }

        private void AfterConfirmGrupekoeflevel1()
        {
            this.OnGRUPEKOEFLevel1Updating(new GRUPEKOEFLevel1EventArgs(this.rowGRUPEKOEFLevel1, this.Gx_mode));
        }

        private void CheckDeleteErrorsGrupekoef()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK], [IDGRUPEKOEF] FROM [RADNIKLevel7] WITH (NOLOCK) WHERE [IDGRUPEKOEF] = @IDGRUPEKOEF ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEF["IDGRUPEKOEF"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RADNIKLevel7InvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Level7" }));
            }
            reader.Close();
        }

        private void CheckExtendedTableGrupekoeflevel1()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVELEMENT] FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEFLevel1["IDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new ELEMENTForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ELEMENT") }));
            }
            this.rowGRUPEKOEFLevel1["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            reader.Close();
        }

        private void CheckIntegrityErrorsGrupekoeflevel1()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDMZOSTABLICE] FROM [MZOSTABLICE] WITH (NOLOCK) WHERE [IDMZOSTABLICE] = @IDMZOSTABLICE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMZOSTABLICE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEFLevel1["IDMZOSTABLICE"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new MZOSTABLICEForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("MZOSTABLICE") }));
            }
            reader.Close();
            throw new ForeignKeyNotFoundException(this.resourceManager.GetString("refinterror"));
        }

        private void CheckOptimisticConcurrencyGrupekoef()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDGRUPEKOEF], [NAZIVGRUPEKOEF] FROM [GRUPEKOEF] WITH (UPDLOCK) WHERE [IDGRUPEKOEF] = @IDGRUPEKOEF ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEF["IDGRUPEKOEF"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new GRUPEKOEFDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("GRUPEKOEF") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVGRUPEKOEFOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new GRUPEKOEFDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("GRUPEKOEF") }));
                }
                reader.Close();
            }
        }

        private void CheckOptimisticConcurrencyGrupekoeflevel1()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDGRUPEKOEF], [IDELEMENT], [IDMZOSTABLICE] FROM [GRUPEKOEFLevel1] WITH (UPDLOCK) WHERE [IDGRUPEKOEF] = @IDGRUPEKOEF AND [IDELEMENT] = @IDELEMENT ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEFLevel1["IDGRUPEKOEF"]));
                command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEFLevel1["IDELEMENT"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new GRUPEKOEFLevel1DataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("GRUPEKOEFLevel1") }));
                }
                if (!command.HasMoreRows || !this.m__IDMZOSTABLICEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 2))))
                {
                    reader.Close();
                    throw new GRUPEKOEFLevel1DataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("GRUPEKOEFLevel1") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowGrupekoef()
        {
            this.rowGRUPEKOEF = this.GRUPEKOEFSet.GRUPEKOEF.NewGRUPEKOEFRow();
        }

        private void CreateNewRowGrupekoeflevel1()
        {
            this.rowGRUPEKOEFLevel1 = this.GRUPEKOEFSet.GRUPEKOEFLevel1.NewGRUPEKOEFLevel1Row();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyGrupekoef();
            this.ProcessNestedLevelGrupekoeflevel1();
            this.AfterConfirmGrupekoef();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [GRUPEKOEF]  WHERE [IDGRUPEKOEF] = @IDGRUPEKOEF", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEF["IDGRUPEKOEF"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsGrupekoef();
            }
            this.OnGRUPEKOEFUpdated(new GRUPEKOEFEventArgs(this.rowGRUPEKOEF, StatementType.Delete));
            this.rowGRUPEKOEF.Delete();
            this.sMode95 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode95;
        }

        private void DeleteGrupekoeflevel1()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyGrupekoeflevel1();
            this.OnDeleteControlsGrupekoeflevel1();
            this.AfterConfirmGrupekoeflevel1();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [GRUPEKOEFLevel1]  WHERE [IDGRUPEKOEF] = @IDGRUPEKOEF AND [IDELEMENT] = @IDELEMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEFLevel1["IDGRUPEKOEF"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEFLevel1["IDELEMENT"]));
            command.ExecuteStmt();
            this.OnGRUPEKOEFLevel1Updated(new GRUPEKOEFLevel1EventArgs(this.rowGRUPEKOEFLevel1, StatementType.Delete));
            this.rowGRUPEKOEFLevel1.Delete();
            this.sMode96 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode96;
        }

        public virtual int Fill(GRUPEKOEFDataSet dataSet)
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
                    this.GRUPEKOEFSet = dataSet;
                    this.LoadChildGrupekoef(0, -1);
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
            this.GRUPEKOEFSet = (GRUPEKOEFDataSet) dataSet;
            if (this.GRUPEKOEFSet != null)
            {
                return this.Fill(this.GRUPEKOEFSet);
            }
            this.GRUPEKOEFSet = new GRUPEKOEFDataSet();
            this.Fill(this.GRUPEKOEFSet);
            dataSet.Merge(this.GRUPEKOEFSet);
            return 0;
        }

        public virtual int Fill(GRUPEKOEFDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDGRUPEKOEF"]));
        }

        public virtual int Fill(GRUPEKOEFDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDGRUPEKOEF"]));
        }

        public virtual int Fill(GRUPEKOEFDataSet dataSet, int iDGRUPEKOEF)
        {
            if (!this.FillByIDGRUPEKOEF(dataSet, iDGRUPEKOEF))
            {
                throw new GRUPEKOEFNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("GRUPEKOEF") }));
            }
            return 0;
        }

        public virtual bool FillByIDGRUPEKOEF(GRUPEKOEFDataSet dataSet, int iDGRUPEKOEF)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GRUPEKOEFSet = dataSet;
            this.rowGRUPEKOEF = this.GRUPEKOEFSet.GRUPEKOEF.NewGRUPEKOEFRow();
            this.rowGRUPEKOEF.IDGRUPEKOEF = iDGRUPEKOEF;
            try
            {
                this.LoadByIDGRUPEKOEF(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound95 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(GRUPEKOEFDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GRUPEKOEFSet = dataSet;
            try
            {
                this.LoadChildGrupekoef(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDGRUPEKOEF], [NAZIVGRUPEKOEF] FROM [GRUPEKOEF] WITH (NOLOCK) WHERE [IDGRUPEKOEF] = @IDGRUPEKOEF ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEF["IDGRUPEKOEF"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound95 = 1;
                this.rowGRUPEKOEF["IDGRUPEKOEF"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowGRUPEKOEF["NAZIVGRUPEKOEF"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode95 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode95;
            }
            else
            {
                this.RcdFound95 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDGRUPEKOEF";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGRUPEKOEFSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [GRUPEKOEF] WITH (NOLOCK) ", false);
            this.GRUPEKOEFSelect1 = this.cmGRUPEKOEFSelect1.FetchData();
            if (this.GRUPEKOEFSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.GRUPEKOEFSelect1.GetInt32(0);
            }
            this.GRUPEKOEFSelect1.Close();
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

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound95 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__IDMZOSTABLICEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Gxremove15 = false;
            this.RcdFound96 = 0;
            this.m_SubSelTopString96 = "";
            this.m__NAZIVGRUPEKOEFOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.GRUPEKOEFSet = new GRUPEKOEFDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertGrupekoef()
        {
            this.CheckOptimisticConcurrencyGrupekoef();
            this.AfterConfirmGrupekoef();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [GRUPEKOEF] ([IDGRUPEKOEF], [NAZIVGRUPEKOEF]) VALUES (@IDGRUPEKOEF, @NAZIVGRUPEKOEF)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVGRUPEKOEF", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEF["IDGRUPEKOEF"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEF["NAZIVGRUPEKOEF"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new GRUPEKOEFDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnGRUPEKOEFUpdated(new GRUPEKOEFEventArgs(this.rowGRUPEKOEF, StatementType.Insert));
            this.ProcessLevelGrupekoef();
        }

        private void InsertGrupekoeflevel1()
        {
            this.CheckOptimisticConcurrencyGrupekoeflevel1();
            this.CheckExtendedTableGrupekoeflevel1();
            this.AfterConfirmGrupekoeflevel1();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [GRUPEKOEFLevel1] ([IDGRUPEKOEF], [IDELEMENT], [IDMZOSTABLICE]) VALUES (@IDGRUPEKOEF, @IDELEMENT, @IDMZOSTABLICE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMZOSTABLICE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEFLevel1["IDGRUPEKOEF"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEFLevel1["IDELEMENT"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEFLevel1["IDMZOSTABLICE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new GRUPEKOEFLevel1DuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsGrupekoeflevel1();
            }
            this.OnGRUPEKOEFLevel1Updated(new GRUPEKOEFLevel1EventArgs(this.rowGRUPEKOEFLevel1, StatementType.Insert));
        }

        private void LoadByIDGRUPEKOEF(int startRow, int maxRows)
        {
            bool enforceConstraints = this.GRUPEKOEFSet.EnforceConstraints;
            this.GRUPEKOEFSet.GRUPEKOEFLevel1.BeginLoadData();
            this.GRUPEKOEFSet.GRUPEKOEF.BeginLoadData();
            this.ScanByIDGRUPEKOEF(startRow, maxRows);
            this.GRUPEKOEFSet.GRUPEKOEFLevel1.EndLoadData();
            this.GRUPEKOEFSet.GRUPEKOEF.EndLoadData();
            this.GRUPEKOEFSet.EnforceConstraints = enforceConstraints;
            if (this.GRUPEKOEFSet.GRUPEKOEF.Count > 0)
            {
                this.rowGRUPEKOEF = this.GRUPEKOEFSet.GRUPEKOEF[this.GRUPEKOEFSet.GRUPEKOEF.Count - 1];
            }
        }

        private void LoadChildGrupekoef(int startRow, int maxRows)
        {
            this.CreateNewRowGrupekoef();
            bool enforceConstraints = this.GRUPEKOEFSet.EnforceConstraints;
            this.GRUPEKOEFSet.GRUPEKOEFLevel1.BeginLoadData();
            this.GRUPEKOEFSet.GRUPEKOEF.BeginLoadData();
            this.ScanStartGrupekoef(startRow, maxRows);
            this.GRUPEKOEFSet.GRUPEKOEFLevel1.EndLoadData();
            this.GRUPEKOEFSet.GRUPEKOEF.EndLoadData();
            this.GRUPEKOEFSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadChildGrupekoeflevel1()
        {
            this.CreateNewRowGrupekoeflevel1();
            this.ScanStartGrupekoeflevel1();
        }

        private void LoadDataGrupekoef(int maxRows)
        {
            int num = 0;
            if (this.RcdFound95 != 0)
            {
                this.ScanLoadGrupekoef();
                while ((this.RcdFound95 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowGrupekoef();
                    this.CreateNewRowGrupekoef();
                    this.ScanNextGrupekoef();
                }
            }
            if (num > 0)
            {
                this.RcdFound95 = 1;
            }
            this.ScanEndGrupekoef();
            if (this.GRUPEKOEFSet.GRUPEKOEF.Count > 0)
            {
                this.rowGRUPEKOEF = this.GRUPEKOEFSet.GRUPEKOEF[this.GRUPEKOEFSet.GRUPEKOEF.Count - 1];
            }
        }

        private void LoadDataGrupekoeflevel1()
        {
            while (this.RcdFound96 != 0)
            {
                this.LoadRowGrupekoeflevel1();
                this.CreateNewRowGrupekoeflevel1();
                this.ScanNextGrupekoeflevel1();
            }
            this.ScanEndGrupekoeflevel1();
        }

        private void LoadRowGrupekoef()
        {
            this.AddRowGrupekoef();
        }

        private void LoadRowGrupekoeflevel1()
        {
            this.AddRowGrupekoeflevel1();
        }

        private void OnDeleteControlsGrupekoeflevel1()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVELEMENT] FROM [ELEMENT] WITH (NOLOCK) WHERE [IDELEMENT] = @IDELEMENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEFLevel1["IDELEMENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowGRUPEKOEFLevel1["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void OnGRUPEKOEFLevel1Updated(GRUPEKOEFLevel1EventArgs e)
        {
            if (this.GRUPEKOEFLevel1Updated != null)
            {
                GRUPEKOEFLevel1UpdateEventHandler handler = this.GRUPEKOEFLevel1Updated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnGRUPEKOEFLevel1Updating(GRUPEKOEFLevel1EventArgs e)
        {
            if (this.GRUPEKOEFLevel1Updating != null)
            {
                GRUPEKOEFLevel1UpdateEventHandler handler = this.GRUPEKOEFLevel1Updating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnGRUPEKOEFUpdated(GRUPEKOEFEventArgs e)
        {
            if (this.GRUPEKOEFUpdated != null)
            {
                GRUPEKOEFUpdateEventHandler gRUPEKOEFUpdatedEvent = this.GRUPEKOEFUpdated;
                if (gRUPEKOEFUpdatedEvent != null)
                {
                    gRUPEKOEFUpdatedEvent(this, e);
                }
            }
        }

        private void OnGRUPEKOEFUpdating(GRUPEKOEFEventArgs e)
        {
            if (this.GRUPEKOEFUpdating != null)
            {
                GRUPEKOEFUpdateEventHandler gRUPEKOEFUpdatingEvent = this.GRUPEKOEFUpdating;
                if (gRUPEKOEFUpdatingEvent != null)
                {
                    gRUPEKOEFUpdatingEvent(this, e);
                }
            }
        }

        private void ProcessLevelGrupekoef()
        {
            this.sMode95 = this.Gx_mode;
            this.ProcessNestedLevelGrupekoeflevel1();
            this.Gx_mode = this.sMode95;
        }

        private void ProcessNestedLevelGrupekoeflevel1()
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.GRUPEKOEFSet.GRUPEKOEFLevel1.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    this.rowGRUPEKOEFLevel1 = (GRUPEKOEFDataSet.GRUPEKOEFLevel1Row) current;
                    if (Helpers.IsRowChanged(this.rowGRUPEKOEFLevel1))
                    {
                        bool flag = false;
                        if (this.rowGRUPEKOEFLevel1.RowState != DataRowState.Deleted)
                        {
                            flag = this.rowGRUPEKOEFLevel1.IDGRUPEKOEF == this.rowGRUPEKOEF.IDGRUPEKOEF;
                        }
                        else
                        {
                            flag = this.rowGRUPEKOEFLevel1["IDGRUPEKOEF", DataRowVersion.Original].Equals(this.rowGRUPEKOEF.IDGRUPEKOEF);
                        }
                        if (flag)
                        {
                            this.ReadRowGrupekoeflevel1();
                            if (this.rowGRUPEKOEFLevel1.RowState == DataRowState.Added)
                            {
                                this.Gx_mode = StatementType.Insert;
                                this.InsertGrupekoeflevel1();
                            }
                            else
                            {
                                if (this._Gxremove15)
                                {
                                    this.Gx_mode = StatementType.Delete;
                                    this.DeleteGrupekoeflevel1();
                                    continue;
                                }
                                this.Gx_mode = StatementType.Update;
                                this.UpdateGrupekoeflevel1();
                            }
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
        }

        private void ReadRowGrupekoef()
        {
            this.Gx_mode = Mode.FromRowState(this.rowGRUPEKOEF.RowState);
            if (this.rowGRUPEKOEF.RowState != DataRowState.Added)
            {
                this.m__NAZIVGRUPEKOEFOriginal = RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEF["NAZIVGRUPEKOEF", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVGRUPEKOEFOriginal = RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEF["NAZIVGRUPEKOEF"]);
            }
            this._Gxremove = this.rowGRUPEKOEF.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowGRUPEKOEF = (GRUPEKOEFDataSet.GRUPEKOEFRow) DataSetUtil.CloneOriginalDataRow(this.rowGRUPEKOEF);
            }
        }

        private void ReadRowGrupekoeflevel1()
        {
            this.Gx_mode = Mode.FromRowState(this.rowGRUPEKOEFLevel1.RowState);
            if (this.rowGRUPEKOEFLevel1.RowState != DataRowState.Added)
            {
                this.m__IDMZOSTABLICEOriginal = RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEFLevel1["IDMZOSTABLICE", DataRowVersion.Original]);
            }
            else
            {
                this.m__IDMZOSTABLICEOriginal = RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEFLevel1["IDMZOSTABLICE"]);
            }
            this._Gxremove15 = this.rowGRUPEKOEFLevel1.RowState == DataRowState.Deleted;
            if (this._Gxremove15)
            {
                this.rowGRUPEKOEFLevel1 = (GRUPEKOEFDataSet.GRUPEKOEFLevel1Row) DataSetUtil.CloneOriginalDataRow(this.rowGRUPEKOEFLevel1);
            }
        }

        private void ScanByIDGRUPEKOEF(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDGRUPEKOEF] = @IDGRUPEKOEF";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString95 + "  FROM [GRUPEKOEF] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDGRUPEKOEF]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString95, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGRUPEKOEF] ) AS DK_PAGENUM   FROM [GRUPEKOEF] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString95 + " FROM [GRUPEKOEF] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDGRUPEKOEF] ";
            }
            this.cmGRUPEKOEFSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmGRUPEKOEFSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmGRUPEKOEFSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
            }
            this.cmGRUPEKOEFSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEF["IDGRUPEKOEF"]));
            this.GRUPEKOEFSelect4 = this.cmGRUPEKOEFSelect4.FetchData();
            this.RcdFound95 = 0;
            this.ScanLoadGrupekoef();
            this.LoadDataGrupekoef(maxRows);
            if (this.RcdFound95 > 0)
            {
                this.SubLvlScanStartGrupekoeflevel1(this.m_WhereString, startRow, maxRows);
                this.SetParametersIDGRUPEKOEFGrupekoef(this.cmGRUPEKOEFLevel1Select2);
                this.SubLvlFetchGrupekoeflevel1();
                this.SubLoadDataGrupekoeflevel1();
            }
        }

        private void ScanEndGrupekoef()
        {
            this.GRUPEKOEFSelect4.Close();
        }

        private void ScanEndGrupekoeflevel1()
        {
            this.GRUPEKOEFLevel1Select2.Close();
        }

        private void ScanLoadGrupekoef()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmGRUPEKOEFSelect4.HasMoreRows)
            {
                this.RcdFound95 = 1;
                this.rowGRUPEKOEF["IDGRUPEKOEF"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.GRUPEKOEFSelect4, 0));
                this.rowGRUPEKOEF["NAZIVGRUPEKOEF"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GRUPEKOEFSelect4, 1));
            }
        }

        private void ScanLoadGrupekoeflevel1()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmGRUPEKOEFLevel1Select2.HasMoreRows)
            {
                this.RcdFound96 = 1;
                this.rowGRUPEKOEFLevel1["IDGRUPEKOEF"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.GRUPEKOEFLevel1Select2, 0));
                this.rowGRUPEKOEFLevel1["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GRUPEKOEFLevel1Select2, 1));
                this.rowGRUPEKOEFLevel1["IDELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.GRUPEKOEFLevel1Select2, 2));
                this.rowGRUPEKOEFLevel1["IDMZOSTABLICE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.GRUPEKOEFLevel1Select2, 3));
                this.rowGRUPEKOEFLevel1["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GRUPEKOEFLevel1Select2, 1));
            }
        }

        private void ScanNextGrupekoef()
        {
            this.cmGRUPEKOEFSelect4.HasMoreRows = this.GRUPEKOEFSelect4.Read();
            this.RcdFound95 = 0;
            this.ScanLoadGrupekoef();
        }

        private void ScanNextGrupekoeflevel1()
        {
            this.cmGRUPEKOEFLevel1Select2.HasMoreRows = this.GRUPEKOEFLevel1Select2.Read();
            this.RcdFound96 = 0;
            this.ScanLoadGrupekoeflevel1();
        }

        private void ScanStartGrupekoef(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString95 + "  FROM [GRUPEKOEF] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDGRUPEKOEF]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString95, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGRUPEKOEF] ) AS DK_PAGENUM   FROM [GRUPEKOEF] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString95 + " FROM [GRUPEKOEF] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDGRUPEKOEF] ";
            }
            this.cmGRUPEKOEFSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.GRUPEKOEFSelect4 = this.cmGRUPEKOEFSelect4.FetchData();
            this.RcdFound95 = 0;
            this.ScanLoadGrupekoef();
            this.LoadDataGrupekoef(maxRows);
            if (this.RcdFound95 > 0)
            {
                this.SubLvlScanStartGrupekoeflevel1(this.m_WhereString, startRow, maxRows);
                this.SetParametersGrupekoefGrupekoef(this.cmGRUPEKOEFLevel1Select2);
                this.SubLvlFetchGrupekoeflevel1();
                this.SubLoadDataGrupekoeflevel1();
            }
        }

        private void ScanStartGrupekoeflevel1()
        {
            this.cmGRUPEKOEFLevel1Select2 = this.connDefault.GetCommand("SELECT T1.[IDGRUPEKOEF], T2.[NAZIVELEMENT], T1.[IDELEMENT], T1.[IDMZOSTABLICE] FROM ([GRUPEKOEFLevel1] T1 WITH (NOLOCK) INNER JOIN [ELEMENT] T2 WITH (NOLOCK) ON T2.[IDELEMENT] = T1.[IDELEMENT]) WHERE T1.[IDGRUPEKOEF] = @IDGRUPEKOEF ORDER BY T1.[IDGRUPEKOEF], T1.[IDELEMENT] ", false);
            if (this.cmGRUPEKOEFLevel1Select2.IDbCommand.Parameters.Count == 0)
            {
                this.cmGRUPEKOEFLevel1Select2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
            }
            this.cmGRUPEKOEFLevel1Select2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEFLevel1["IDGRUPEKOEF"]));
            this.GRUPEKOEFLevel1Select2 = this.cmGRUPEKOEFLevel1Select2.FetchData();
            this.RcdFound96 = 0;
            this.ScanLoadGrupekoeflevel1();
        }

        private void SetParametersGrupekoefGrupekoef(ReadWriteCommand m_Command)
        {
        }

        private void SetParametersIDGRUPEKOEFGrupekoef(ReadWriteCommand m_Command)
        {
            if (m_Command.IDbCommand.Parameters.Count == 0)
            {
                m_Command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
            }
            m_Command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEF["IDGRUPEKOEF"]));
        }

        private void SkipNextGrupekoeflevel1()
        {
            this.cmGRUPEKOEFLevel1Select2.HasMoreRows = this.GRUPEKOEFLevel1Select2.Read();
            this.RcdFound96 = 0;
            if (this.cmGRUPEKOEFLevel1Select2.HasMoreRows)
            {
                this.RcdFound96 = 1;
            }
        }

        private void SubLoadDataGrupekoeflevel1()
        {
            while (this.RcdFound96 != 0)
            {
                this.LoadRowGrupekoeflevel1();
                this.CreateNewRowGrupekoeflevel1();
                this.ScanNextGrupekoeflevel1();
            }
            this.ScanEndGrupekoeflevel1();
        }

        private void SubLvlFetchGrupekoeflevel1()
        {
            this.CreateNewRowGrupekoeflevel1();
            this.GRUPEKOEFLevel1Select2 = this.cmGRUPEKOEFLevel1Select2.FetchData();
            this.RcdFound96 = 0;
            this.ScanLoadGrupekoeflevel1();
        }

        private void SubLvlScanStartGrupekoeflevel1(string sCondition, int startRow, int maxRows)
        {
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.m_WhereString = sCondition;
                    this.m_SubSelTopString96 = "(SELECT TOP " + maxRows.ToString() + " TM1.[IDGRUPEKOEF]  FROM [GRUPEKOEF]  TM1 " + this.m_WhereString + " ORDER BY TM1.[IDGRUPEKOEF] )";
                    this.scmdbuf = "SELECT T1.[IDGRUPEKOEF], T3.[NAZIVELEMENT], T1.[IDELEMENT], T1.[IDMZOSTABLICE] FROM (([GRUPEKOEFLevel1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString96 + "  TMX ON TMX.[IDGRUPEKOEF] = T1.[IDGRUPEKOEF]) INNER JOIN [ELEMENT] T3 WITH (NOLOCK) ON T3.[IDELEMENT] = T1.[IDELEMENT]) ORDER BY T1.[IDGRUPEKOEF], T1.[IDELEMENT]";
                }
                else
                {
                    this.m_WhereString = sCondition;
                    string[] strArray = new string[] { "( SELECT * FROM ( SELECT TM1.[IDGRUPEKOEF], ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGRUPEKOEF]  ) AS DK_PAGENUM   FROM [GRUPEKOEF]  TM1  ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString(), ")" };
                    this.m_SubSelTopString96 = string.Concat(strArray);
                    this.scmdbuf = "SELECT T1.[IDGRUPEKOEF], T3.[NAZIVELEMENT], T1.[IDELEMENT], T1.[IDMZOSTABLICE] FROM (([GRUPEKOEFLevel1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString96 + "  TMX ON TMX.[IDGRUPEKOEF] = T1.[IDGRUPEKOEF]) INNER JOIN [ELEMENT] T3 WITH (NOLOCK) ON T3.[IDELEMENT] = T1.[IDELEMENT]) ORDER BY T1.[IDGRUPEKOEF], T1.[IDELEMENT]";
                }
            }
            else
            {
                this.m_WhereString = sCondition;
                this.m_SubSelTopString96 = "[GRUPEKOEF]";
                this.scmdbuf = "SELECT T1.[IDGRUPEKOEF], T3.[NAZIVELEMENT], T1.[IDELEMENT], T1.[IDMZOSTABLICE] FROM (([GRUPEKOEFLevel1] T1 WITH (NOLOCK) INNER JOIN  " + this.m_SubSelTopString96 + "  TM1 WITH (NOLOCK) ON TM1.[IDGRUPEKOEF] = T1.[IDGRUPEKOEF]) INNER JOIN [ELEMENT] T3 WITH (NOLOCK) ON T3.[IDELEMENT] = T1.[IDELEMENT])" + this.m_WhereString + " ORDER BY T1.[IDGRUPEKOEF], T1.[IDELEMENT] ";
            }
            this.cmGRUPEKOEFLevel1Select2 = this.connDefault.GetCommand(this.scmdbuf, false);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.GRUPEKOEFSet = (GRUPEKOEFDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.GRUPEKOEFSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.GRUPEKOEFSet.GRUPEKOEF.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        GRUPEKOEFDataSet.GRUPEKOEFRow current = (GRUPEKOEFDataSet.GRUPEKOEFRow) enumerator.Current;
                        this.rowGRUPEKOEF = current;
                        if (Helpers.IsRowChanged(this.rowGRUPEKOEF))
                        {
                            this.ReadRowGrupekoef();
                            if (this.rowGRUPEKOEF.RowState == DataRowState.Added)
                            {
                                this.InsertGrupekoef();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateGrupekoef();
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

        private void UpdateGrupekoef()
        {
            this.CheckOptimisticConcurrencyGrupekoef();
            this.AfterConfirmGrupekoef();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [GRUPEKOEF] SET [NAZIVGRUPEKOEF]=@NAZIVGRUPEKOEF  WHERE [IDGRUPEKOEF] = @IDGRUPEKOEF", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVGRUPEKOEF", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEF["NAZIVGRUPEKOEF"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEF["IDGRUPEKOEF"]));
            command.ExecuteStmt();
            this.OnGRUPEKOEFUpdated(new GRUPEKOEFEventArgs(this.rowGRUPEKOEF, StatementType.Update));
            this.ProcessLevelGrupekoef();
        }

        private void UpdateGrupekoeflevel1()
        {
            this.CheckOptimisticConcurrencyGrupekoeflevel1();
            this.CheckExtendedTableGrupekoeflevel1();
            this.AfterConfirmGrupekoeflevel1();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [GRUPEKOEFLevel1] SET [IDMZOSTABLICE]=@IDMZOSTABLICE  WHERE [IDGRUPEKOEF] = @IDGRUPEKOEF AND [IDELEMENT] = @IDELEMENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDMZOSTABLICE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGRUPEKOEF", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEFLevel1["IDMZOSTABLICE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEFLevel1["IDGRUPEKOEF"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowGRUPEKOEFLevel1["IDELEMENT"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckIntegrityErrorsGrupekoeflevel1();
            }
            this.OnGRUPEKOEFLevel1Updated(new GRUPEKOEFLevel1EventArgs(this.rowGRUPEKOEFLevel1, StatementType.Update));
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
        public class ELEMENTForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public ELEMENTForeignKeyNotFoundException()
            {
            }

            public ELEMENTForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected ELEMENTForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ELEMENTForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
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
        public class GRUPEKOEFDataChangedException : DataChangedException
        {
            public GRUPEKOEFDataChangedException()
            {
            }

            public GRUPEKOEFDataChangedException(string message) : base(message)
            {
            }

            protected GRUPEKOEFDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GRUPEKOEFDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GRUPEKOEFDataLockedException : DataLockedException
        {
            public GRUPEKOEFDataLockedException()
            {
            }

            public GRUPEKOEFDataLockedException(string message) : base(message)
            {
            }

            protected GRUPEKOEFDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GRUPEKOEFDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GRUPEKOEFDuplicateKeyException : DuplicateKeyException
        {
            public GRUPEKOEFDuplicateKeyException()
            {
            }

            public GRUPEKOEFDuplicateKeyException(string message) : base(message)
            {
            }

            protected GRUPEKOEFDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GRUPEKOEFDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class GRUPEKOEFEventArgs : EventArgs
        {
            private GRUPEKOEFDataSet.GRUPEKOEFRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public GRUPEKOEFEventArgs(GRUPEKOEFDataSet.GRUPEKOEFRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public GRUPEKOEFDataSet.GRUPEKOEFRow Row
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
        public class GRUPEKOEFLevel1DataChangedException : DataChangedException
        {
            public GRUPEKOEFLevel1DataChangedException()
            {
            }

            public GRUPEKOEFLevel1DataChangedException(string message) : base(message)
            {
            }

            protected GRUPEKOEFLevel1DataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GRUPEKOEFLevel1DataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GRUPEKOEFLevel1DataLockedException : DataLockedException
        {
            public GRUPEKOEFLevel1DataLockedException()
            {
            }

            public GRUPEKOEFLevel1DataLockedException(string message) : base(message)
            {
            }

            protected GRUPEKOEFLevel1DataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GRUPEKOEFLevel1DataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GRUPEKOEFLevel1DuplicateKeyException : DuplicateKeyException
        {
            public GRUPEKOEFLevel1DuplicateKeyException()
            {
            }

            public GRUPEKOEFLevel1DuplicateKeyException(string message) : base(message)
            {
            }

            protected GRUPEKOEFLevel1DuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GRUPEKOEFLevel1DuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class GRUPEKOEFLevel1EventArgs : EventArgs
        {
            private GRUPEKOEFDataSet.GRUPEKOEFLevel1Row m_dataRow;
            private System.Data.StatementType m_statementType;

            public GRUPEKOEFLevel1EventArgs(GRUPEKOEFDataSet.GRUPEKOEFLevel1Row row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public GRUPEKOEFDataSet.GRUPEKOEFLevel1Row Row
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

        public delegate void GRUPEKOEFLevel1UpdateEventHandler(object sender, GRUPEKOEFDataAdapter.GRUPEKOEFLevel1EventArgs e);

        [Serializable]
        public class GRUPEKOEFNotFoundException : DataNotFoundException
        {
            public GRUPEKOEFNotFoundException()
            {
            }

            public GRUPEKOEFNotFoundException(string message) : base(message)
            {
            }

            protected GRUPEKOEFNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GRUPEKOEFNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void GRUPEKOEFUpdateEventHandler(object sender, GRUPEKOEFDataAdapter.GRUPEKOEFEventArgs e);

        [Serializable]
        public class MZOSTABLICEForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public MZOSTABLICEForeignKeyNotFoundException()
            {
            }

            public MZOSTABLICEForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected MZOSTABLICEForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public MZOSTABLICEForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKLevel7InvalidDeleteException : InvalidDeleteException
        {
            public RADNIKLevel7InvalidDeleteException()
            {
            }

            public RADNIKLevel7InvalidDeleteException(string message) : base(message)
            {
            }

            protected RADNIKLevel7InvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKLevel7InvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

