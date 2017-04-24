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

    public class BANKEDataAdapter : IDataAdapter, IBANKEDataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private IDataReader BANKESelect1;
        private IDataReader BANKESelect4;
        private BANKEDataSet BANKESet;
        private ReadWriteCommand cmBANKESelect1;
        private ReadWriteCommand cmBANKESelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__MOBANKAOriginal;
        private object m__MZBANKAOriginal;
        private object m__NAZIVBANKE1Original;
        private object m__NAZIVBANKE2Original;
        private object m__NAZIVBANKE3Original;
        private object m__OPISPLACANJABANKEOriginal;
        private object m__POBANKAOriginal;
        private object m__PZBANKAOriginal;
        private object m__SIFRAOPISPLACANJABANKEOriginal;
        private object m__VBDIBANKEOriginal;
        private object m__ZRNBANKEOriginal;
        private readonly string m_SelectString1 = "TM1.[IDBANKE], TM1.[NAZIVBANKE1], TM1.[NAZIVBANKE2], TM1.[NAZIVBANKE3], TM1.[MOBANKA], TM1.[POBANKA], TM1.[MZBANKA], TM1.[PZBANKA], TM1.[SIFRAOPISPLACANJABANKE], TM1.[OPISPLACANJABANKE], TM1.[VBDIBANKE], TM1.[ZRNBANKE]";
        private string m_WhereString;
        private short RcdFound1;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private BANKEDataSet.BANKERow rowBANKE;
        private string scmdbuf;
        private StatementType sMode1;

        public event BANKEUpdateEventHandler BANKEUpdated;

        public event BANKEUpdateEventHandler BANKEUpdating;

        private void AddRowBanke()
        {
            this.BANKESet.BANKE.AddBANKERow(this.rowBANKE);
        }

        private void AfterConfirmBanke()
        {
            this.OnBANKEUpdating(new BANKEEventArgs(this.rowBANKE, this.Gx_mode));
        }

        private void CheckDeleteErrorsBanke()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK], [BANKAZASTICENOIDBANKE] FROM [RADNIKIzuzeceOdOvrhe] WITH (NOLOCK) WHERE [BANKAZASTICENOIDBANKE] = @IDBANKE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBANKE["IDBANKE"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new RADNIKIzuzeceOdOvrheInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "IzuzeceOdOvrhe" }));
            }
            reader2.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [DDIDRADNIK] FROM [DDRADNIK] WITH (NOLOCK) WHERE [IDBANKE] = @IDBANKE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBANKE["IDBANKE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new DDRADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "DDRADNIK" }));
            }
            reader.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK] FROM [RADNIK] WITH (NOLOCK) WHERE [IDBANKE] = @IDBANKE ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBANKE["IDBANKE"]));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                reader3.Close();
                throw new RADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIK" }));
            }
            reader3.Close();
        }

        private void CheckOptimisticConcurrencyBanke()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDBANKE], [NAZIVBANKE1], [NAZIVBANKE2], [NAZIVBANKE3], [MOBANKA], [POBANKA], [MZBANKA], [PZBANKA], [SIFRAOPISPLACANJABANKE], [OPISPLACANJABANKE], [VBDIBANKE], [ZRNBANKE] FROM [BANKE] WITH (UPDLOCK) WHERE [IDBANKE] = @IDBANKE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBANKE["IDBANKE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new BANKEDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("BANKE") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVBANKE1Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVBANKE2Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVBANKE3Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MOBANKAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__POBANKAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MZBANKAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PZBANKAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__SIFRAOPISPLACANJABANKEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPISPLACANJABANKEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__VBDIBANKEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10))))))
                {
                    this._Condition = true;
                }
                if (this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZRNBANKEOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11))))
                {
                    reader.Close();
                    throw new BANKEDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("BANKE") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowBanke()
        {
            this.rowBANKE = this.BANKESet.BANKE.NewBANKERow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyBanke();
            this.AfterConfirmBanke();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [BANKE]  WHERE [IDBANKE] = @IDBANKE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBANKE["IDBANKE"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsBanke();
            }
            this.OnBANKEUpdated(new BANKEEventArgs(this.rowBANKE, StatementType.Delete));
            this.rowBANKE.Delete();
            this.sMode1 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode1;
        }

        public virtual int Fill(BANKEDataSet dataSet)
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
                    this.BANKESet = dataSet;
                    this.LoadChildBanke(0, -1);
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
            this.BANKESet = (BANKEDataSet) dataSet;
            if (this.BANKESet != null)
            {
                return this.Fill(this.BANKESet);
            }
            this.BANKESet = new BANKEDataSet();
            this.Fill(this.BANKESet);
            dataSet.Merge(this.BANKESet);
            return 0;
        }

        public virtual int Fill(BANKEDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDBANKE"]));
        }

        public virtual int Fill(BANKEDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDBANKE"]));
        }

        public virtual int Fill(BANKEDataSet dataSet, int iDBANKE)
        {
            if (!this.FillByIDBANKE(dataSet, iDBANKE))
            {
                throw new BANKENotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("BANKE") }));
            }
            return 0;
        }

        public virtual bool FillByIDBANKE(BANKEDataSet dataSet, int iDBANKE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.BANKESet = dataSet;
            this.rowBANKE = this.BANKESet.BANKE.NewBANKERow();
            this.rowBANKE.IDBANKE = iDBANKE;
            try
            {
                this.LoadByIDBANKE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound1 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(BANKEDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.BANKESet = dataSet;
            try
            {
                this.LoadChildBanke(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDBANKE], [NAZIVBANKE1], [NAZIVBANKE2], [NAZIVBANKE3], [MOBANKA], [POBANKA], [MZBANKA], [PZBANKA], [SIFRAOPISPLACANJABANKE], [OPISPLACANJABANKE], [VBDIBANKE], [ZRNBANKE] FROM [BANKE] WITH (NOLOCK) WHERE [IDBANKE] = @IDBANKE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBANKE["IDBANKE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound1 = 1;
                this.rowBANKE["IDBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowBANKE["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowBANKE["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowBANKE["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowBANKE["MOBANKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowBANKE["POBANKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowBANKE["MZBANKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowBANKE["PZBANKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowBANKE["SIFRAOPISPLACANJABANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowBANKE["OPISPLACANJABANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowBANKE["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
                this.rowBANKE["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
                this.sMode1 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode1;
            }
            else
            {
                this.RcdFound1 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDBANKE";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmBANKESelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [BANKE] WITH (NOLOCK) ", false);
            this.BANKESelect1 = this.cmBANKESelect1.FetchData();
            if (this.BANKESelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.BANKESelect1.GetInt32(0);
            }
            this.BANKESelect1.Close();
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
            this.RcdFound1 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVBANKE1Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__NAZIVBANKE2Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__NAZIVBANKE3Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__MOBANKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POBANKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MZBANKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PZBANKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SIFRAOPISPLACANJABANKEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OPISPLACANJABANKEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__VBDIBANKEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZRNBANKEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Condition = false;
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.BANKESet = new BANKEDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertBanke()
        {
            this.CheckOptimisticConcurrencyBanke();
            this.AfterConfirmBanke();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [BANKE] ([IDBANKE], [NAZIVBANKE1], [NAZIVBANKE2], [NAZIVBANKE3], [MOBANKA], [POBANKA], [MZBANKA], [PZBANKA], [SIFRAOPISPLACANJABANKE], [OPISPLACANJABANKE], [VBDIBANKE], [ZRNBANKE]) VALUES (@IDBANKE, @NAZIVBANKE1, @NAZIVBANKE2, @NAZIVBANKE3, @MOBANKA, @POBANKA, @MZBANKA, @PZBANKA, @SIFRAOPISPLACANJABANKE, @OPISPLACANJABANKE, @VBDIBANKE, @ZRNBANKE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVBANKE1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVBANKE2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVBANKE3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOBANKA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POBANKA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZBANKA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZBANKA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISPLACANJABANKE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJABANKE", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIBANKE", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNBANKE", DbType.String, 10));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBANKE["IDBANKE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBANKE["NAZIVBANKE1"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowBANKE["NAZIVBANKE2"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowBANKE["NAZIVBANKE3"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowBANKE["MOBANKA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowBANKE["POBANKA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowBANKE["MZBANKA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowBANKE["PZBANKA"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowBANKE["SIFRAOPISPLACANJABANKE"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowBANKE["OPISPLACANJABANKE"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowBANKE["VBDIBANKE"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowBANKE["ZRNBANKE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new BANKEDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnBANKEUpdated(new BANKEEventArgs(this.rowBANKE, StatementType.Insert));
        }

        private void LoadByIDBANKE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.BANKESet.EnforceConstraints;
            this.BANKESet.BANKE.BeginLoadData();
            this.ScanByIDBANKE(startRow, maxRows);
            this.BANKESet.BANKE.EndLoadData();
            this.BANKESet.EnforceConstraints = enforceConstraints;
            if (this.BANKESet.BANKE.Count > 0)
            {
                this.rowBANKE = this.BANKESet.BANKE[this.BANKESet.BANKE.Count - 1];
            }
        }

        private void LoadChildBanke(int startRow, int maxRows)
        {
            this.CreateNewRowBanke();
            bool enforceConstraints = this.BANKESet.EnforceConstraints;
            this.BANKESet.BANKE.BeginLoadData();
            this.ScanStartBanke(startRow, maxRows);
            this.BANKESet.BANKE.EndLoadData();
            this.BANKESet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataBanke(int maxRows)
        {
            int num = 0;
            if (this.RcdFound1 != 0)
            {
                this.ScanLoadBanke();
                while ((this.RcdFound1 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowBanke();
                    this.CreateNewRowBanke();
                    this.ScanNextBanke();
                }
            }
            if (num > 0)
            {
                this.RcdFound1 = 1;
            }
            this.ScanEndBanke();
            if (this.BANKESet.BANKE.Count > 0)
            {
                this.rowBANKE = this.BANKESet.BANKE[this.BANKESet.BANKE.Count - 1];
            }
        }

        private void LoadRowBanke()
        {
            this.AddRowBanke();
        }

        private void OnBANKEUpdated(BANKEEventArgs e)
        {
            if (this.BANKEUpdated != null)
            {
                BANKEUpdateEventHandler bANKEUpdatedEvent = this.BANKEUpdated;
                if (bANKEUpdatedEvent != null)
                {
                    bANKEUpdatedEvent(this, e);
                }
            }
        }

        private void OnBANKEUpdating(BANKEEventArgs e)
        {
            if (this.BANKEUpdating != null)
            {
                BANKEUpdateEventHandler bANKEUpdatingEvent = this.BANKEUpdating;
                if (bANKEUpdatingEvent != null)
                {
                    bANKEUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowBanke()
        {
            this.Gx_mode = Mode.FromRowState(this.rowBANKE.RowState);
            if (this.rowBANKE.RowState != DataRowState.Added)
            {
                this.m__NAZIVBANKE1Original = RuntimeHelpers.GetObjectValue(this.rowBANKE["NAZIVBANKE1", DataRowVersion.Original]);
                this.m__NAZIVBANKE2Original = RuntimeHelpers.GetObjectValue(this.rowBANKE["NAZIVBANKE2", DataRowVersion.Original]);
                this.m__NAZIVBANKE3Original = RuntimeHelpers.GetObjectValue(this.rowBANKE["NAZIVBANKE3", DataRowVersion.Original]);
                this.m__MOBANKAOriginal = RuntimeHelpers.GetObjectValue(this.rowBANKE["MOBANKA", DataRowVersion.Original]);
                this.m__POBANKAOriginal = RuntimeHelpers.GetObjectValue(this.rowBANKE["POBANKA", DataRowVersion.Original]);
                this.m__MZBANKAOriginal = RuntimeHelpers.GetObjectValue(this.rowBANKE["MZBANKA", DataRowVersion.Original]);
                this.m__PZBANKAOriginal = RuntimeHelpers.GetObjectValue(this.rowBANKE["PZBANKA", DataRowVersion.Original]);
                this.m__SIFRAOPISPLACANJABANKEOriginal = RuntimeHelpers.GetObjectValue(this.rowBANKE["SIFRAOPISPLACANJABANKE", DataRowVersion.Original]);
                this.m__OPISPLACANJABANKEOriginal = RuntimeHelpers.GetObjectValue(this.rowBANKE["OPISPLACANJABANKE", DataRowVersion.Original]);
                this.m__VBDIBANKEOriginal = RuntimeHelpers.GetObjectValue(this.rowBANKE["VBDIBANKE", DataRowVersion.Original]);
                this.m__ZRNBANKEOriginal = RuntimeHelpers.GetObjectValue(this.rowBANKE["ZRNBANKE", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVBANKE1Original = RuntimeHelpers.GetObjectValue(this.rowBANKE["NAZIVBANKE1"]);
                this.m__NAZIVBANKE2Original = RuntimeHelpers.GetObjectValue(this.rowBANKE["NAZIVBANKE2"]);
                this.m__NAZIVBANKE3Original = RuntimeHelpers.GetObjectValue(this.rowBANKE["NAZIVBANKE3"]);
                this.m__MOBANKAOriginal = RuntimeHelpers.GetObjectValue(this.rowBANKE["MOBANKA"]);
                this.m__POBANKAOriginal = RuntimeHelpers.GetObjectValue(this.rowBANKE["POBANKA"]);
                this.m__MZBANKAOriginal = RuntimeHelpers.GetObjectValue(this.rowBANKE["MZBANKA"]);
                this.m__PZBANKAOriginal = RuntimeHelpers.GetObjectValue(this.rowBANKE["PZBANKA"]);
                this.m__SIFRAOPISPLACANJABANKEOriginal = RuntimeHelpers.GetObjectValue(this.rowBANKE["SIFRAOPISPLACANJABANKE"]);
                this.m__OPISPLACANJABANKEOriginal = RuntimeHelpers.GetObjectValue(this.rowBANKE["OPISPLACANJABANKE"]);
                this.m__VBDIBANKEOriginal = RuntimeHelpers.GetObjectValue(this.rowBANKE["VBDIBANKE"]);
                this.m__ZRNBANKEOriginal = RuntimeHelpers.GetObjectValue(this.rowBANKE["ZRNBANKE"]);
            }
            this._Gxremove = this.rowBANKE.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowBANKE = (BANKEDataSet.BANKERow) DataSetUtil.CloneOriginalDataRow(this.rowBANKE);
            }
        }

        private void ScanByIDBANKE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDBANKE] = @IDBANKE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString1 + "  FROM [BANKE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDBANKE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString1, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDBANKE] ) AS DK_PAGENUM   FROM [BANKE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString1 + " FROM [BANKE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDBANKE] ";
            }
            this.cmBANKESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmBANKESelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmBANKESelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            this.cmBANKESelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBANKE["IDBANKE"]));
            this.BANKESelect4 = this.cmBANKESelect4.FetchData();
            this.RcdFound1 = 0;
            this.ScanLoadBanke();
            this.LoadDataBanke(maxRows);
        }

        private void ScanEndBanke()
        {
            this.BANKESelect4.Close();
        }

        private void ScanLoadBanke()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmBANKESelect4.HasMoreRows)
            {
                this.RcdFound1 = 1;
                this.rowBANKE["IDBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.BANKESelect4, 0));
                this.rowBANKE["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BANKESelect4, 1));
                this.rowBANKE["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BANKESelect4, 2));
                this.rowBANKE["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BANKESelect4, 3));
                this.rowBANKE["MOBANKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BANKESelect4, 4));
                this.rowBANKE["POBANKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BANKESelect4, 5));
                this.rowBANKE["MZBANKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BANKESelect4, 6));
                this.rowBANKE["PZBANKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BANKESelect4, 7));
                this.rowBANKE["SIFRAOPISPLACANJABANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BANKESelect4, 8));
                this.rowBANKE["OPISPLACANJABANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BANKESelect4, 9));
                this.rowBANKE["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BANKESelect4, 10));
                this.rowBANKE["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.BANKESelect4, 11));
            }
        }

        private void ScanNextBanke()
        {
            this.cmBANKESelect4.HasMoreRows = this.BANKESelect4.Read();
            this.RcdFound1 = 0;
            this.ScanLoadBanke();
        }

        private void ScanStartBanke(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString1 + "  FROM [BANKE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDBANKE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString1, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDBANKE] ) AS DK_PAGENUM   FROM [BANKE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString1 + " FROM [BANKE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDBANKE] ";
            }
            this.cmBANKESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.BANKESelect4 = this.cmBANKESelect4.FetchData();
            this.RcdFound1 = 0;
            this.ScanLoadBanke();
            this.LoadDataBanke(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.BANKESet = (BANKEDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.BANKESet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.BANKESet.BANKE.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        BANKEDataSet.BANKERow current = (BANKEDataSet.BANKERow) enumerator.Current;
                        this.rowBANKE = current;
                        if (Helpers.IsRowChanged(this.rowBANKE))
                        {
                            this.ReadRowBanke();
                            if (this.rowBANKE.RowState == DataRowState.Added)
                            {
                                this.InsertBanke();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateBanke();
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

        private void UpdateBanke()
        {
            this.CheckOptimisticConcurrencyBanke();
            this.AfterConfirmBanke();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [BANKE] SET [NAZIVBANKE1]=@NAZIVBANKE1, [NAZIVBANKE2]=@NAZIVBANKE2, [NAZIVBANKE3]=@NAZIVBANKE3, [MOBANKA]=@MOBANKA, [POBANKA]=@POBANKA, [MZBANKA]=@MZBANKA, [PZBANKA]=@PZBANKA, [SIFRAOPISPLACANJABANKE]=@SIFRAOPISPLACANJABANKE, [OPISPLACANJABANKE]=@OPISPLACANJABANKE, [VBDIBANKE]=@VBDIBANKE, [ZRNBANKE]=@ZRNBANKE  WHERE [IDBANKE] = @IDBANKE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVBANKE1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVBANKE2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVBANKE3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOBANKA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POBANKA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZBANKA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZBANKA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISPLACANJABANKE", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJABANKE", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIBANKE", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNBANKE", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowBANKE["NAZIVBANKE1"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowBANKE["NAZIVBANKE2"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowBANKE["NAZIVBANKE3"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowBANKE["MOBANKA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowBANKE["POBANKA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowBANKE["MZBANKA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowBANKE["PZBANKA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowBANKE["SIFRAOPISPLACANJABANKE"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowBANKE["OPISPLACANJABANKE"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowBANKE["VBDIBANKE"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowBANKE["ZRNBANKE"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowBANKE["IDBANKE"]));
            command.ExecuteStmt();
            this.OnBANKEUpdated(new BANKEEventArgs(this.rowBANKE, StatementType.Update));
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
        public class BANKEDataChangedException : DataChangedException
        {
            public BANKEDataChangedException()
            {
            }

            public BANKEDataChangedException(string message) : base(message)
            {
            }

            protected BANKEDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BANKEDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BANKEDataLockedException : DataLockedException
        {
            public BANKEDataLockedException()
            {
            }

            public BANKEDataLockedException(string message) : base(message)
            {
            }

            protected BANKEDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BANKEDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class BANKEDuplicateKeyException : DuplicateKeyException
        {
            public BANKEDuplicateKeyException()
            {
            }

            public BANKEDuplicateKeyException(string message) : base(message)
            {
            }

            protected BANKEDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BANKEDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class BANKEEventArgs : EventArgs
        {
            private BANKEDataSet.BANKERow m_dataRow;
            private System.Data.StatementType m_statementType;

            public BANKEEventArgs(BANKEDataSet.BANKERow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public BANKEDataSet.BANKERow Row
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
        public class BANKENotFoundException : DataNotFoundException
        {
            public BANKENotFoundException()
            {
            }

            public BANKENotFoundException(string message) : base(message)
            {
            }

            protected BANKENotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BANKENotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void BANKEUpdateEventHandler(object sender, BANKEDataAdapter.BANKEEventArgs e);

        [Serializable]
        public class DDRADNIKInvalidDeleteException : InvalidDeleteException
        {
            public DDRADNIKInvalidDeleteException()
            {
            }

            public DDRADNIKInvalidDeleteException(string message) : base(message)
            {
            }

            protected DDRADNIKInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDRADNIKInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKInvalidDeleteException : InvalidDeleteException
        {
            public RADNIKInvalidDeleteException()
            {
            }

            public RADNIKInvalidDeleteException(string message) : base(message)
            {
            }

            protected RADNIKInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RADNIKIzuzeceOdOvrheInvalidDeleteException : InvalidDeleteException
        {
            public RADNIKIzuzeceOdOvrheInvalidDeleteException()
            {
            }

            public RADNIKIzuzeceOdOvrheInvalidDeleteException(string message) : base(message)
            {
            }

            protected RADNIKIzuzeceOdOvrheInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKIzuzeceOdOvrheInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

