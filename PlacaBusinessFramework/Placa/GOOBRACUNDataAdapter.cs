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

    public class GOOBRACUNDataAdapter : IDataAdapter, IGOOBRACUNDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmGOOBRACUNSelect1;
        private ReadWriteCommand cmGOOBRACUNSelect2;
        private ReadWriteCommand cmGOOBRACUNSelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private IDataReader GOOBRACUNSelect1;
        private IDataReader GOOBRACUNSelect2;
        private IDataReader GOOBRACUNSelect5;
        private GOOBRACUNDataSet GOOBRACUNSet;
        private StatementType Gx_mode;
        private object m__IDRADNIKOriginal;
        private object m__ODBICIISKORISTIVOOriginal;
        private object m__OLAKSICEISKORISTIVOOriginal;
        private readonly string m_SelectString257 = "TM1.[IDGOOBRACUN], T2.[PREZIME], T2.[IME], T2.[AKTIVAN], TM1.[OLAKSICEISKORISTIVO], TM1.[ODBICIISKORISTIVO], TM1.[IDRADNIK]";
        private string m_WhereString;
        private short RcdFound257;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private GOOBRACUNDataSet.GOOBRACUNRow rowGOOBRACUN;
        private string scmdbuf;
        private StatementType sMode257;

        public event GOOBRACUNUpdateEventHandler GOOBRACUNUpdated;

        public event GOOBRACUNUpdateEventHandler GOOBRACUNUpdating;

        private void AddRowGoobracun()
        {
            this.GOOBRACUNSet.GOOBRACUN.AddGOOBRACUNRow(this.rowGOOBRACUN);
        }

        private void AfterConfirmGoobracun()
        {
            this.OnGOOBRACUNUpdating(new GOOBRACUNEventArgs(this.rowGOOBRACUN, this.Gx_mode));
        }

        private void CheckExtendedTableGoobracun()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [PREZIME], [IME], [AKTIVAN] FROM [RADNIK] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["IDRADNIK"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new RADNIKForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RADNIK") }));
            }
            this.rowGOOBRACUN["PREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            this.rowGOOBRACUN["IME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
            this.rowGOOBRACUN["AKTIVAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 2));
            reader.Close();
        }

        private void CheckOptimisticConcurrencyGoobracun()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDGOOBRACUN], [OLAKSICEISKORISTIVO], [ODBICIISKORISTIVO], [IDRADNIK] FROM [GOOBRACUN] WITH (UPDLOCK) WHERE [IDGOOBRACUN] = @IDGOOBRACUN ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGOOBRACUN", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["IDGOOBRACUN"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new GOOBRACUNDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("GOOBRACUN") }));
                }
                if ((!command.HasMoreRows || !this.m__OLAKSICEISKORISTIVOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1)))) || (!this.m__ODBICIISKORISTIVOOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))) || !this.m__IDRADNIKOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 3)))))
                {
                    reader.Close();
                    throw new GOOBRACUNDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("GOOBRACUN") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowGoobracun()
        {
            this.rowGOOBRACUN = this.GOOBRACUNSet.GOOBRACUN.NewGOOBRACUNRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyGoobracun();
            this.OnDeleteControlsGoobracun();
            this.AfterConfirmGoobracun();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [GOOBRACUN]  WHERE [IDGOOBRACUN] = @IDGOOBRACUN", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGOOBRACUN", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["IDGOOBRACUN"]));
            command.ExecuteStmt();
            this.OnGOOBRACUNUpdated(new GOOBRACUNEventArgs(this.rowGOOBRACUN, StatementType.Delete));
            this.rowGOOBRACUN.Delete();
            this.sMode257 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode257;
        }

 
        public virtual int Fill(GOOBRACUNDataSet dataSet)
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
                    this.GOOBRACUNSet = dataSet;
                    this.LoadChildGoobracun(0, -1);
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
            this.GOOBRACUNSet = (GOOBRACUNDataSet) dataSet;
            if (this.GOOBRACUNSet != null)
            {
                return this.Fill(this.GOOBRACUNSet);
            }
            this.GOOBRACUNSet = new GOOBRACUNDataSet();
            this.Fill(this.GOOBRACUNSet);
            dataSet.Merge(this.GOOBRACUNSet);
            return 0;
        }

        public virtual int Fill(GOOBRACUNDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDGOOBRACUN"]));
        }

        public virtual int Fill(GOOBRACUNDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDGOOBRACUN"]));
        }

        public virtual int Fill(GOOBRACUNDataSet dataSet, int iDGOOBRACUN)
        {
            if (!this.FillByIDGOOBRACUN(dataSet, iDGOOBRACUN))
            {
                throw new GOOBRACUNNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("GOOBRACUN") }));
            }
            return 0;
        }

        public virtual bool FillByIDGOOBRACUN(GOOBRACUNDataSet dataSet, int iDGOOBRACUN)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GOOBRACUNSet = dataSet;
            this.rowGOOBRACUN = this.GOOBRACUNSet.GOOBRACUN.NewGOOBRACUNRow();
            this.rowGOOBRACUN.IDGOOBRACUN = iDGOOBRACUN;
            try
            {
                this.LoadByIDGOOBRACUN(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound257 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByIDRADNIK(GOOBRACUNDataSet dataSet, int iDRADNIK)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GOOBRACUNSet = dataSet;
            this.rowGOOBRACUN = this.GOOBRACUNSet.GOOBRACUN.NewGOOBRACUNRow();
            this.rowGOOBRACUN.IDRADNIK = iDRADNIK;
            try
            {
                this.LoadByIDRADNIK(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(GOOBRACUNDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GOOBRACUNSet = dataSet;
            try
            {
                this.LoadChildGoobracun(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByIDRADNIK(GOOBRACUNDataSet dataSet, int iDRADNIK, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GOOBRACUNSet = dataSet;
            this.rowGOOBRACUN = this.GOOBRACUNSet.GOOBRACUN.NewGOOBRACUNRow();
            this.rowGOOBRACUN.IDRADNIK = iDRADNIK;
            try
            {
                this.LoadByIDRADNIK(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDGOOBRACUN], [OLAKSICEISKORISTIVO], [ODBICIISKORISTIVO], [IDRADNIK] FROM [GOOBRACUN] WITH (NOLOCK) WHERE [IDGOOBRACUN] = @IDGOOBRACUN ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGOOBRACUN", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["IDGOOBRACUN"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound257 = 1;
                this.rowGOOBRACUN["IDGOOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowGOOBRACUN["OLAKSICEISKORISTIVO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 1));
                this.rowGOOBRACUN["ODBICIISKORISTIVO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
                this.rowGOOBRACUN["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 3));
                this.sMode257 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadGoobracun();
                this.Gx_mode = this.sMode257;
            }
            else
            {
                this.RcdFound257 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDGOOBRACUN";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGOOBRACUNSelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [GOOBRACUN] WITH (NOLOCK) ", false);
            this.GOOBRACUNSelect2 = this.cmGOOBRACUNSelect2.FetchData();
            if (this.GOOBRACUNSelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.GOOBRACUNSelect2.GetInt32(0);
            }
            this.GOOBRACUNSelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByIDRADNIK(int iDRADNIK)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGOOBRACUNSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [GOOBRACUN] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (this.cmGOOBRACUNSelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmGOOBRACUNSelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmGOOBRACUNSelect1.SetParameter(0, iDRADNIK);
            this.GOOBRACUNSelect1 = this.cmGOOBRACUNSelect1.FetchData();
            if (this.GOOBRACUNSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.GOOBRACUNSelect1.GetInt32(0);
            }
            this.GOOBRACUNSelect1.Close();
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

        public virtual int GetRecordCountByIDRADNIK(int iDRADNIK)
        {
            int internalRecordCountByIDRADNIK;
            try
            {
                this.InitializeMembers();
                internalRecordCountByIDRADNIK = this.GetInternalRecordCountByIDRADNIK(iDRADNIK);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByIDRADNIK;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound257 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__OLAKSICEISKORISTIVOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ODBICIISKORISTIVOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IDRADNIKOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.GOOBRACUNSet = new GOOBRACUNDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertGoobracun()
        {
            this.CheckOptimisticConcurrencyGoobracun();
            this.CheckExtendedTableGoobracun();
            this.AfterConfirmGoobracun();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [GOOBRACUN] ([OLAKSICEISKORISTIVO], [ODBICIISKORISTIVO], [IDRADNIK]) VALUES (@OLAKSICEISKORISTIVO, @ODBICIISKORISTIVO, @IDRADNIK); SELECT SCOPE_IDENTITY()", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OLAKSICEISKORISTIVO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODBICIISKORISTIVO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["OLAKSICEISKORISTIVO"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["ODBICIISKORISTIVO"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["IDRADNIK"]));
            IDataReader reader = command.FetchData();
            this.rowGOOBRACUN.IDGOOBRACUN = Convert.ToInt32(reader.GetDecimal(0));
            reader.Close();
            this.OnGOOBRACUNUpdated(new GOOBRACUNEventArgs(this.rowGOOBRACUN, StatementType.Insert));
        }

        private void LoadByIDGOOBRACUN(int startRow, int maxRows)
        {
            bool enforceConstraints = this.GOOBRACUNSet.EnforceConstraints;
            this.GOOBRACUNSet.GOOBRACUN.BeginLoadData();
            this.ScanByIDGOOBRACUN(startRow, maxRows);
            this.GOOBRACUNSet.GOOBRACUN.EndLoadData();
            this.GOOBRACUNSet.EnforceConstraints = enforceConstraints;
            if (this.GOOBRACUNSet.GOOBRACUN.Count > 0)
            {
                this.rowGOOBRACUN = this.GOOBRACUNSet.GOOBRACUN[this.GOOBRACUNSet.GOOBRACUN.Count - 1];
            }
        }

        private void LoadByIDRADNIK(int startRow, int maxRows)
        {
            bool enforceConstraints = this.GOOBRACUNSet.EnforceConstraints;
            this.GOOBRACUNSet.GOOBRACUN.BeginLoadData();
            this.ScanByIDRADNIK(startRow, maxRows);
            this.GOOBRACUNSet.GOOBRACUN.EndLoadData();
            this.GOOBRACUNSet.EnforceConstraints = enforceConstraints;
            if (this.GOOBRACUNSet.GOOBRACUN.Count > 0)
            {
                this.rowGOOBRACUN = this.GOOBRACUNSet.GOOBRACUN[this.GOOBRACUNSet.GOOBRACUN.Count - 1];
            }
        }

        private void LoadChildGoobracun(int startRow, int maxRows)
        {
            this.CreateNewRowGoobracun();
            bool enforceConstraints = this.GOOBRACUNSet.EnforceConstraints;
            this.GOOBRACUNSet.GOOBRACUN.BeginLoadData();
            this.ScanStartGoobracun(startRow, maxRows);
            this.GOOBRACUNSet.GOOBRACUN.EndLoadData();
            this.GOOBRACUNSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataGoobracun(int maxRows)
        {
            int num = 0;
            if (this.RcdFound257 != 0)
            {
                this.ScanLoadGoobracun();
                while ((this.RcdFound257 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowGoobracun();
                    this.CreateNewRowGoobracun();
                    this.ScanNextGoobracun();
                }
            }
            if (num > 0)
            {
                this.RcdFound257 = 1;
            }
            this.ScanEndGoobracun();
            if (this.GOOBRACUNSet.GOOBRACUN.Count > 0)
            {
                this.rowGOOBRACUN = this.GOOBRACUNSet.GOOBRACUN[this.GOOBRACUNSet.GOOBRACUN.Count - 1];
            }
        }

        private void LoadGoobracun()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [PREZIME], [IME], [AKTIVAN] FROM [RADNIK] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["IDRADNIK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowGOOBRACUN["PREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowGOOBRACUN["IME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowGOOBRACUN["AKTIVAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 2));
            }
            reader.Close();
        }

        private void LoadRowGoobracun()
        {
            this.AddRowGoobracun();
        }

        private void OnDeleteControlsGoobracun()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [PREZIME], [IME], [AKTIVAN] FROM [RADNIK] WITH (NOLOCK) WHERE [IDRADNIK] = @IDRADNIK ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["IDRADNIK"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowGOOBRACUN["PREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
                this.rowGOOBRACUN["IME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowGOOBRACUN["AKTIVAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 2));
            }
            reader.Close();
        }

        private void OnGOOBRACUNUpdated(GOOBRACUNEventArgs e)
        {
            if (this.GOOBRACUNUpdated != null)
            {
                GOOBRACUNUpdateEventHandler gOOBRACUNUpdatedEvent = this.GOOBRACUNUpdated;
                if (gOOBRACUNUpdatedEvent != null)
                {
                    gOOBRACUNUpdatedEvent(this, e);
                }
            }
        }

        private void OnGOOBRACUNUpdating(GOOBRACUNEventArgs e)
        {
            if (this.GOOBRACUNUpdating != null)
            {
                GOOBRACUNUpdateEventHandler gOOBRACUNUpdatingEvent = this.GOOBRACUNUpdating;
                if (gOOBRACUNUpdatingEvent != null)
                {
                    gOOBRACUNUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowGoobracun()
        {
            this.Gx_mode = Mode.FromRowState(this.rowGOOBRACUN.RowState);
            if (this.rowGOOBRACUN.RowState != DataRowState.Added)
            {
                this.m__OLAKSICEISKORISTIVOOriginal = RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["OLAKSICEISKORISTIVO", DataRowVersion.Original]);
                this.m__ODBICIISKORISTIVOOriginal = RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["ODBICIISKORISTIVO", DataRowVersion.Original]);
                this.m__IDRADNIKOriginal = RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["IDRADNIK", DataRowVersion.Original]);
            }
            else
            {
                this.m__OLAKSICEISKORISTIVOOriginal = RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["OLAKSICEISKORISTIVO"]);
                this.m__ODBICIISKORISTIVOOriginal = RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["ODBICIISKORISTIVO"]);
                this.m__IDRADNIKOriginal = RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["IDRADNIK"]);
            }
            this._Gxremove = this.rowGOOBRACUN.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowGOOBRACUN = (GOOBRACUNDataSet.GOOBRACUNRow) DataSetUtil.CloneOriginalDataRow(this.rowGOOBRACUN);
            }
        }

        private void ScanByIDGOOBRACUN(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDGOOBRACUN] = @IDGOOBRACUN";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString257 + "  FROM ([GOOBRACUN] TM1 WITH (NOLOCK) INNER JOIN [RADNIK] T2 WITH (NOLOCK) ON T2.[IDRADNIK] = TM1.[IDRADNIK])" + this.m_WhereString + " ORDER BY TM1.[IDGOOBRACUN]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString257, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGOOBRACUN] ) AS DK_PAGENUM   FROM ([GOOBRACUN] TM1 WITH (NOLOCK) INNER JOIN [RADNIK] T2 WITH (NOLOCK) ON T2.[IDRADNIK] = TM1.[IDRADNIK]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString257 + " FROM ([GOOBRACUN] TM1 WITH (NOLOCK) INNER JOIN [RADNIK] T2 WITH (NOLOCK) ON T2.[IDRADNIK] = TM1.[IDRADNIK])" + this.m_WhereString + " ORDER BY TM1.[IDGOOBRACUN] ";
            }
            this.cmGOOBRACUNSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmGOOBRACUNSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmGOOBRACUNSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGOOBRACUN", DbType.Int32));
            }
            this.cmGOOBRACUNSelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["IDGOOBRACUN"]));
            this.GOOBRACUNSelect5 = this.cmGOOBRACUNSelect5.FetchData();
            this.RcdFound257 = 0;
            this.ScanLoadGoobracun();
            this.LoadDataGoobracun(maxRows);
        }

        private void ScanByIDRADNIK(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDRADNIK] = @IDRADNIK";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString257 + "  FROM ([GOOBRACUN] TM1 WITH (NOLOCK) INNER JOIN [RADNIK] T2 WITH (NOLOCK) ON T2.[IDRADNIK] = TM1.[IDRADNIK])" + this.m_WhereString + " ORDER BY TM1.[IDGOOBRACUN]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString257, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGOOBRACUN] ) AS DK_PAGENUM   FROM ([GOOBRACUN] TM1 WITH (NOLOCK) INNER JOIN [RADNIK] T2 WITH (NOLOCK) ON T2.[IDRADNIK] = TM1.[IDRADNIK]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString257 + " FROM ([GOOBRACUN] TM1 WITH (NOLOCK) INNER JOIN [RADNIK] T2 WITH (NOLOCK) ON T2.[IDRADNIK] = TM1.[IDRADNIK])" + this.m_WhereString + " ORDER BY TM1.[IDGOOBRACUN] ";
            }
            this.cmGOOBRACUNSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmGOOBRACUNSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmGOOBRACUNSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmGOOBRACUNSelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["IDRADNIK"]));
            this.GOOBRACUNSelect5 = this.cmGOOBRACUNSelect5.FetchData();
            this.RcdFound257 = 0;
            this.ScanLoadGoobracun();
            this.LoadDataGoobracun(maxRows);
        }

        private void ScanEndGoobracun()
        {
            this.GOOBRACUNSelect5.Close();
        }

        private void ScanLoadGoobracun()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmGOOBRACUNSelect5.HasMoreRows)
            {
                this.RcdFound257 = 1;
                this.rowGOOBRACUN["IDGOOBRACUN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.GOOBRACUNSelect5, 0));
                this.rowGOOBRACUN["PREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GOOBRACUNSelect5, 1));
                this.rowGOOBRACUN["IME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GOOBRACUNSelect5, 2));
                this.rowGOOBRACUN["AKTIVAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.GOOBRACUNSelect5, 3));
                this.rowGOOBRACUN["OLAKSICEISKORISTIVO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.GOOBRACUNSelect5, 4));
                this.rowGOOBRACUN["ODBICIISKORISTIVO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.GOOBRACUNSelect5, 5));
                this.rowGOOBRACUN["IDRADNIK"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.GOOBRACUNSelect5, 6));
                this.rowGOOBRACUN["PREZIME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GOOBRACUNSelect5, 1));
                this.rowGOOBRACUN["IME"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.GOOBRACUNSelect5, 2));
                this.rowGOOBRACUN["AKTIVAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.GOOBRACUNSelect5, 3));
            }
        }

        private void ScanNextGoobracun()
        {
            this.cmGOOBRACUNSelect5.HasMoreRows = this.GOOBRACUNSelect5.Read();
            this.RcdFound257 = 0;
            this.ScanLoadGoobracun();
        }

        private void ScanStartGoobracun(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString257 + "  FROM ([GOOBRACUN] TM1 WITH (NOLOCK) INNER JOIN [RADNIK] T2 WITH (NOLOCK) ON T2.[IDRADNIK] = TM1.[IDRADNIK])" + this.m_WhereString + " ORDER BY TM1.[IDGOOBRACUN]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString257, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGOOBRACUN] ) AS DK_PAGENUM   FROM ([GOOBRACUN] TM1 WITH (NOLOCK) INNER JOIN [RADNIK] T2 WITH (NOLOCK) ON T2.[IDRADNIK] = TM1.[IDRADNIK]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString257 + " FROM ([GOOBRACUN] TM1 WITH (NOLOCK) INNER JOIN [RADNIK] T2 WITH (NOLOCK) ON T2.[IDRADNIK] = TM1.[IDRADNIK])" + this.m_WhereString + " ORDER BY TM1.[IDGOOBRACUN] ";
            }
            this.cmGOOBRACUNSelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.GOOBRACUNSelect5 = this.cmGOOBRACUNSelect5.FetchData();
            this.RcdFound257 = 0;
            this.ScanLoadGoobracun();
            this.LoadDataGoobracun(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.GOOBRACUNSet = (GOOBRACUNDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.GOOBRACUNSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.GOOBRACUNSet.GOOBRACUN.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        GOOBRACUNDataSet.GOOBRACUNRow current = (GOOBRACUNDataSet.GOOBRACUNRow) enumerator.Current;
                        this.rowGOOBRACUN = current;
                        if (Helpers.IsRowChanged(this.rowGOOBRACUN))
                        {
                            this.ReadRowGoobracun();
                            if (this.rowGOOBRACUN.RowState == DataRowState.Added)
                            {
                                this.InsertGoobracun();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateGoobracun();
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

        private void UpdateGoobracun()
        {
            this.CheckOptimisticConcurrencyGoobracun();
            this.CheckExtendedTableGoobracun();
            this.AfterConfirmGoobracun();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [GOOBRACUN] SET [OLAKSICEISKORISTIVO]=@OLAKSICEISKORISTIVO, [ODBICIISKORISTIVO]=@ODBICIISKORISTIVO, [IDRADNIK]=@IDRADNIK  WHERE [IDGOOBRACUN] = @IDGOOBRACUN", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OLAKSICEISKORISTIVO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ODBICIISKORISTIVO", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGOOBRACUN", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["OLAKSICEISKORISTIVO"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["ODBICIISKORISTIVO"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["IDRADNIK"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowGOOBRACUN["IDGOOBRACUN"]));
            command.ExecuteStmt();
            this.OnGOOBRACUNUpdated(new GOOBRACUNEventArgs(this.rowGOOBRACUN, StatementType.Update));
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
        public class GOOBRACUNDataChangedException : DataChangedException
        {
            public GOOBRACUNDataChangedException()
            {
            }

            public GOOBRACUNDataChangedException(string message) : base(message)
            {
            }

            protected GOOBRACUNDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GOOBRACUNDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GOOBRACUNDataLockedException : DataLockedException
        {
            public GOOBRACUNDataLockedException()
            {
            }

            public GOOBRACUNDataLockedException(string message) : base(message)
            {
            }

            protected GOOBRACUNDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GOOBRACUNDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class GOOBRACUNEventArgs : EventArgs
        {
            private GOOBRACUNDataSet.GOOBRACUNRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public GOOBRACUNEventArgs(GOOBRACUNDataSet.GOOBRACUNRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public GOOBRACUNDataSet.GOOBRACUNRow Row
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
        public class GOOBRACUNNotFoundException : DataNotFoundException
        {
            public GOOBRACUNNotFoundException()
            {
            }

            public GOOBRACUNNotFoundException(string message) : base(message)
            {
            }

            protected GOOBRACUNNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GOOBRACUNNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void GOOBRACUNUpdateEventHandler(object sender, GOOBRACUNDataAdapter.GOOBRACUNEventArgs e);

        [Serializable]
        public class RADNIKForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public RADNIKForeignKeyNotFoundException()
            {
            }

            public RADNIKForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected RADNIKForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

