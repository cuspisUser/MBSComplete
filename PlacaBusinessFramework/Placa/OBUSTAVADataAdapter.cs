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

    public class OBUSTAVADataAdapter : IDataAdapter, IOBUSTAVADataAdapter
    {
        private bool _Condition;
        private bool _Gxremove;
        private ReadWriteCommand cmOBUSTAVASelect1;
        private ReadWriteCommand cmOBUSTAVASelect2;
        private ReadWriteCommand cmOBUSTAVASelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__MOOBUSTAVAOriginal;
        private object m__MZOBUSTAVAOriginal;
        private object m__NAZIVOBUSTAVAOriginal;
        private object m__OPISPLACANJAOBUSTAVAOriginal;
        private object m__POOBUSTAVAOriginal;
        private object m__PRIMATELJOBUSTAVA1Original;
        private object m__PRIMATELJOBUSTAVA2Original;
        private object m__PRIMATELJOBUSTAVA3Original;
        private object m__PZOBUSTAVAOriginal;
        private object m__SIFRAOPISAPLACANJAOBUSTAVAOriginal;
        private object m__VBDIOBUSTAVAOriginal;
        private object m__VRSTAOBUSTAVEOriginal;
        private object m__ZRNOBUSTAVAOriginal;
        private readonly string m_SelectString14 = "TM1.[IDOBUSTAVA], TM1.[NAZIVOBUSTAVA], TM1.[MOOBUSTAVA], TM1.[POOBUSTAVA], TM1.[MZOBUSTAVA], TM1.[PZOBUSTAVA], TM1.[VBDIOBUSTAVA], TM1.[ZRNOBUSTAVA], TM1.[PRIMATELJOBUSTAVA1], TM1.[PRIMATELJOBUSTAVA2], TM1.[PRIMATELJOBUSTAVA3], TM1.[SIFRAOPISAPLACANJAOBUSTAVA], TM1.[OPISPLACANJAOBUSTAVA], T2.[NAZIVVRSTAOBUSTAVE], TM1.[VRSTAOBUSTAVE]";
        private string m_WhereString;
        private IDataReader OBUSTAVASelect1;
        private IDataReader OBUSTAVASelect2;
        private IDataReader OBUSTAVASelect5;
        private OBUSTAVADataSet OBUSTAVASet;
        private short RcdFound14;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private OBUSTAVADataSet.OBUSTAVARow rowOBUSTAVA;
        private string scmdbuf;
        private StatementType sMode14;

        public event OBUSTAVAUpdateEventHandler OBUSTAVAUpdated;

        public event OBUSTAVAUpdateEventHandler OBUSTAVAUpdating;

        private void AddRowObustava()
        {
            this.OBUSTAVASet.OBUSTAVA.AddOBUSTAVARow(this.rowOBUSTAVA);
        }

        private void AfterConfirmObustava()
        {
            this.OnOBUSTAVAUpdating(new OBUSTAVAEventArgs(this.rowOBUSTAVA, this.Gx_mode));
        }

        private void CheckDeleteErrorsObustava()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK], [ZADOBUSTAVAIDOBUSTAVA] FROM [RADNIKObustava] WITH (NOLOCK) WHERE [ZADOBUSTAVAIDOBUSTAVA] = @IDOBUSTAVA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBUSTAVA", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["IDOBUSTAVA"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new RADNIKObustavaInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Level6" }));
            }
            reader2.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDOBRACUN], [IDRADNIK], [IDOBUSTAVA] FROM [OBRACUNObustave] WITH (NOLOCK) WHERE [IDOBUSTAVA] = @IDOBUSTAVA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBUSTAVA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["IDOBUSTAVA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new OBRACUNObustaveInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Level11" }));
            }
            reader.Close();
        }

        private void CheckExtendedTableObustava()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVVRSTAOBUSTAVE] FROM [VRSTEOBUSTAVA] WITH (NOLOCK) WHERE [VRSTAOBUSTAVE] = @VRSTAOBUSTAVE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["VRSTAOBUSTAVE"]));
            IDataReader reader = command.FetchData();
            if (!command.HasMoreRows)
            {
                reader.Close();
                throw new VRSTEOBUSTAVAForeignKeyNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("VRSTEOBUSTAVA") }));
            }
            this.rowOBUSTAVA["NAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            reader.Close();
            if (((this.rowOBUSTAVA.VRSTAOBUSTAVE != 0) && (this.rowOBUSTAVA.VRSTAOBUSTAVE != 1)) && (this.rowOBUSTAVA.VRSTAOBUSTAVE != 2))
            {
                throw new VRSTAOBUSTAVEOutOfRangeException("Field Vrsta obustave is out of range");
            }
        }

        private void CheckOptimisticConcurrencyObustava()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOBUSTAVA], [NAZIVOBUSTAVA], [MOOBUSTAVA], [POOBUSTAVA], [MZOBUSTAVA], [PZOBUSTAVA], [VBDIOBUSTAVA], [ZRNOBUSTAVA], [PRIMATELJOBUSTAVA1], [PRIMATELJOBUSTAVA2], [PRIMATELJOBUSTAVA3], [SIFRAOPISAPLACANJAOBUSTAVA], [OPISPLACANJAOBUSTAVA], [VRSTAOBUSTAVE] FROM [OBUSTAVA] WITH (UPDLOCK) WHERE [IDOBUSTAVA] = @IDOBUSTAVA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBUSTAVA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["IDOBUSTAVA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new OBUSTAVADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("OBUSTAVA") }));
                }
                this._Condition = false;
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVOBUSTAVAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MOOBUSTAVAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__POOBUSTAVAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__MZOBUSTAVAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PZOBUSTAVAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__VBDIOBUSTAVAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ZRNOBUSTAVAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7))) || ((!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRIMATELJOBUSTAVA1Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRIMATELJOBUSTAVA2Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9)))) || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__PRIMATELJOBUSTAVA3Original), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10))))))
                {
                    this._Condition = true;
                }
                if ((this._Condition || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__SIFRAOPISAPLACANJAOBUSTAVAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11)))) || (!StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPISPLACANJAOBUSTAVAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12))) || !this.m__VRSTAOBUSTAVEOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 13)))))
                {
                    reader.Close();
                    throw new OBUSTAVADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("OBUSTAVA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowObustava()
        {
            this.rowOBUSTAVA = this.OBUSTAVASet.OBUSTAVA.NewOBUSTAVARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyObustava();
            this.OnDeleteControlsObustava();
            this.AfterConfirmObustava();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [OBUSTAVA]  WHERE [IDOBUSTAVA] = @IDOBUSTAVA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBUSTAVA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["IDOBUSTAVA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsObustava();
            }
            this.OnOBUSTAVAUpdated(new OBUSTAVAEventArgs(this.rowOBUSTAVA, StatementType.Delete));
            this.rowOBUSTAVA.Delete();
            this.sMode14 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode14;
        }

        public virtual int Fill(OBUSTAVADataSet dataSet)
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
                    this.OBUSTAVASet = dataSet;
                    this.LoadChildObustava(0, -1);
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
            this.OBUSTAVASet = (OBUSTAVADataSet) dataSet;
            if (this.OBUSTAVASet != null)
            {
                return this.Fill(this.OBUSTAVASet);
            }
            this.OBUSTAVASet = new OBUSTAVADataSet();
            this.Fill(this.OBUSTAVASet);
            dataSet.Merge(this.OBUSTAVASet);
            return 0;
        }

        public virtual int Fill(OBUSTAVADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDOBUSTAVA"]));
        }

        public virtual int Fill(OBUSTAVADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDOBUSTAVA"]));
        }

        public virtual int Fill(OBUSTAVADataSet dataSet, int iDOBUSTAVA)
        {
            if (!this.FillByIDOBUSTAVA(dataSet, iDOBUSTAVA))
            {
                throw new OBUSTAVANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OBUSTAVA") }));
            }
            return 0;
        }

        public virtual bool FillByIDOBUSTAVA(OBUSTAVADataSet dataSet, int iDOBUSTAVA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OBUSTAVASet = dataSet;
            this.rowOBUSTAVA = this.OBUSTAVASet.OBUSTAVA.NewOBUSTAVARow();
            this.rowOBUSTAVA.IDOBUSTAVA = iDOBUSTAVA;
            try
            {
                this.LoadByIDOBUSTAVA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound14 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillByVRSTAOBUSTAVE(OBUSTAVADataSet dataSet, short vRSTAOBUSTAVE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OBUSTAVASet = dataSet;
            this.rowOBUSTAVA = this.OBUSTAVASet.OBUSTAVA.NewOBUSTAVARow();
            this.rowOBUSTAVA.VRSTAOBUSTAVE = vRSTAOBUSTAVE;
            try
            {
                this.LoadByVRSTAOBUSTAVE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(OBUSTAVADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OBUSTAVASet = dataSet;
            try
            {
                this.LoadChildObustava(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageByVRSTAOBUSTAVE(OBUSTAVADataSet dataSet, short vRSTAOBUSTAVE, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OBUSTAVASet = dataSet;
            this.rowOBUSTAVA = this.OBUSTAVASet.OBUSTAVA.NewOBUSTAVARow();
            this.rowOBUSTAVA.VRSTAOBUSTAVE = vRSTAOBUSTAVE;
            try
            {
                this.LoadByVRSTAOBUSTAVE(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOBUSTAVA], [NAZIVOBUSTAVA], [MOOBUSTAVA], [POOBUSTAVA], [MZOBUSTAVA], [PZOBUSTAVA], [VBDIOBUSTAVA], [ZRNOBUSTAVA], [PRIMATELJOBUSTAVA1], [PRIMATELJOBUSTAVA2], [PRIMATELJOBUSTAVA3], [SIFRAOPISAPLACANJAOBUSTAVA], [OPISPLACANJAOBUSTAVA], [VRSTAOBUSTAVE] FROM [OBUSTAVA] WITH (NOLOCK) WHERE [IDOBUSTAVA] = @IDOBUSTAVA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBUSTAVA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["IDOBUSTAVA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound14 = 1;
                this.rowOBUSTAVA["IDOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowOBUSTAVA["NAZIVOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowOBUSTAVA["MOOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowOBUSTAVA["POOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowOBUSTAVA["MZOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowOBUSTAVA["PZOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowOBUSTAVA["VBDIOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowOBUSTAVA["ZRNOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowOBUSTAVA["PRIMATELJOBUSTAVA1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowOBUSTAVA["PRIMATELJOBUSTAVA2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowOBUSTAVA["PRIMATELJOBUSTAVA3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
                this.rowOBUSTAVA["SIFRAOPISAPLACANJAOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
                this.rowOBUSTAVA["OPISPLACANJAOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12));
                this.rowOBUSTAVA["VRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 13));
                this.sMode14 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadObustava();
                this.Gx_mode = this.sMode14;
            }
            else
            {
                this.RcdFound14 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDOBUSTAVA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOBUSTAVASelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OBUSTAVA] WITH (NOLOCK) ", false);
            this.OBUSTAVASelect2 = this.cmOBUSTAVASelect2.FetchData();
            if (this.OBUSTAVASelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OBUSTAVASelect2.GetInt32(0);
            }
            this.OBUSTAVASelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountByVRSTAOBUSTAVE(short vRSTAOBUSTAVE)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOBUSTAVASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OBUSTAVA] WITH (NOLOCK) WHERE [VRSTAOBUSTAVE] = @VRSTAOBUSTAVE ", false);
            if (this.cmOBUSTAVASelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmOBUSTAVASelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
            }
            this.cmOBUSTAVASelect1.SetParameter(0, vRSTAOBUSTAVE);
            this.OBUSTAVASelect1 = this.cmOBUSTAVASelect1.FetchData();
            if (this.OBUSTAVASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OBUSTAVASelect1.GetInt32(0);
            }
            this.OBUSTAVASelect1.Close();
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

        public virtual int GetRecordCountByVRSTAOBUSTAVE(short vRSTAOBUSTAVE)
        {
            int internalRecordCountByVRSTAOBUSTAVE;
            try
            {
                this.InitializeMembers();
                internalRecordCountByVRSTAOBUSTAVE = this.GetInternalRecordCountByVRSTAOBUSTAVE(vRSTAOBUSTAVE);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountByVRSTAOBUSTAVE;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound14 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MOOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MZOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PZOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__VBDIOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__ZRNOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIMATELJOBUSTAVA1Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIMATELJOBUSTAVA2Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRIMATELJOBUSTAVA3Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__SIFRAOPISAPLACANJAOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OPISPLACANJAOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__VRSTAOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this._Condition = false;
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.OBUSTAVASet = new OBUSTAVADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertObustava()
        {
            this.CheckOptimisticConcurrencyObustava();
            this.CheckExtendedTableObustava();
            this.AfterConfirmObustava();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [OBUSTAVA] ([IDOBUSTAVA], [NAZIVOBUSTAVA], [MOOBUSTAVA], [POOBUSTAVA], [MZOBUSTAVA], [PZOBUSTAVA], [VBDIOBUSTAVA], [ZRNOBUSTAVA], [PRIMATELJOBUSTAVA1], [PRIMATELJOBUSTAVA2], [PRIMATELJOBUSTAVA3], [SIFRAOPISAPLACANJAOBUSTAVA], [OPISPLACANJAOBUSTAVA], [VRSTAOBUSTAVE]) VALUES (@IDOBUSTAVA, @NAZIVOBUSTAVA, @MOOBUSTAVA, @POOBUSTAVA, @MZOBUSTAVA, @PZOBUSTAVA, @VBDIOBUSTAVA, @ZRNOBUSTAVA, @PRIMATELJOBUSTAVA1, @PRIMATELJOBUSTAVA2, @PRIMATELJOBUSTAVA3, @SIFRAOPISAPLACANJAOBUSTAVA, @OPISPLACANJAOBUSTAVA, @VRSTAOBUSTAVE)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBUSTAVA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOBUSTAVA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOOBUSTAVA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POOBUSTAVA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZOBUSTAVA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZOBUSTAVA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIOBUSTAVA", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNOBUSTAVA", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOBUSTAVA1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOBUSTAVA2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOBUSTAVA3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAOBUSTAVA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAOBUSTAVA", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["IDOBUSTAVA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["NAZIVOBUSTAVA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["MOOBUSTAVA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["POOBUSTAVA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["MZOBUSTAVA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["PZOBUSTAVA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["VBDIOBUSTAVA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["ZRNOBUSTAVA"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["PRIMATELJOBUSTAVA1"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["PRIMATELJOBUSTAVA2"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["PRIMATELJOBUSTAVA3"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["SIFRAOPISAPLACANJAOBUSTAVA"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["OPISPLACANJAOBUSTAVA"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["VRSTAOBUSTAVE"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new OBUSTAVADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnOBUSTAVAUpdated(new OBUSTAVAEventArgs(this.rowOBUSTAVA, StatementType.Insert));
        }

        private void LoadByIDOBUSTAVA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OBUSTAVASet.EnforceConstraints;
            this.OBUSTAVASet.OBUSTAVA.BeginLoadData();
            this.ScanByIDOBUSTAVA(startRow, maxRows);
            this.OBUSTAVASet.OBUSTAVA.EndLoadData();
            this.OBUSTAVASet.EnforceConstraints = enforceConstraints;
            if (this.OBUSTAVASet.OBUSTAVA.Count > 0)
            {
                this.rowOBUSTAVA = this.OBUSTAVASet.OBUSTAVA[this.OBUSTAVASet.OBUSTAVA.Count - 1];
            }
        }

        private void LoadByVRSTAOBUSTAVE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OBUSTAVASet.EnforceConstraints;
            this.OBUSTAVASet.OBUSTAVA.BeginLoadData();
            this.ScanByVRSTAOBUSTAVE(startRow, maxRows);
            this.OBUSTAVASet.OBUSTAVA.EndLoadData();
            this.OBUSTAVASet.EnforceConstraints = enforceConstraints;
            if (this.OBUSTAVASet.OBUSTAVA.Count > 0)
            {
                this.rowOBUSTAVA = this.OBUSTAVASet.OBUSTAVA[this.OBUSTAVASet.OBUSTAVA.Count - 1];
            }
        }

        private void LoadChildObustava(int startRow, int maxRows)
        {
            this.CreateNewRowObustava();
            bool enforceConstraints = this.OBUSTAVASet.EnforceConstraints;
            this.OBUSTAVASet.OBUSTAVA.BeginLoadData();
            this.ScanStartObustava(startRow, maxRows);
            this.OBUSTAVASet.OBUSTAVA.EndLoadData();
            this.OBUSTAVASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataObustava(int maxRows)
        {
            int num = 0;
            if (this.RcdFound14 != 0)
            {
                this.ScanLoadObustava();
                while ((this.RcdFound14 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowObustava();
                    this.CreateNewRowObustava();
                    this.ScanNextObustava();
                }
            }
            if (num > 0)
            {
                this.RcdFound14 = 1;
            }
            this.ScanEndObustava();
            if (this.OBUSTAVASet.OBUSTAVA.Count > 0)
            {
                this.rowOBUSTAVA = this.OBUSTAVASet.OBUSTAVA[this.OBUSTAVASet.OBUSTAVA.Count - 1];
            }
        }

        private void LoadObustava()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVVRSTAOBUSTAVE] FROM [VRSTEOBUSTAVA] WITH (NOLOCK) WHERE [VRSTAOBUSTAVE] = @VRSTAOBUSTAVE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["VRSTAOBUSTAVE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowOBUSTAVA["NAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void LoadRowObustava()
        {
            this.AddRowObustava();
        }

        private void OnDeleteControlsObustava()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [NAZIVVRSTAOBUSTAVE] FROM [VRSTEOBUSTAVA] WITH (NOLOCK) WHERE [VRSTAOBUSTAVE] = @VRSTAOBUSTAVE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["VRSTAOBUSTAVE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.rowOBUSTAVA["NAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0));
            }
            reader.Close();
        }

        private void OnOBUSTAVAUpdated(OBUSTAVAEventArgs e)
        {
            if (this.OBUSTAVAUpdated != null)
            {
                OBUSTAVAUpdateEventHandler oBUSTAVAUpdatedEvent = this.OBUSTAVAUpdated;
                if (oBUSTAVAUpdatedEvent != null)
                {
                    oBUSTAVAUpdatedEvent(this, e);
                }
            }
        }

        private void OnOBUSTAVAUpdating(OBUSTAVAEventArgs e)
        {
            if (this.OBUSTAVAUpdating != null)
            {
                OBUSTAVAUpdateEventHandler oBUSTAVAUpdatingEvent = this.OBUSTAVAUpdating;
                if (oBUSTAVAUpdatingEvent != null)
                {
                    oBUSTAVAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowObustava()
        {
            this.Gx_mode = Mode.FromRowState(this.rowOBUSTAVA.RowState);
            if (this.rowOBUSTAVA.RowState != DataRowState.Added)
            {
                this.m__NAZIVOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["NAZIVOBUSTAVA", DataRowVersion.Original]);
                this.m__MOOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["MOOBUSTAVA", DataRowVersion.Original]);
                this.m__POOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["POOBUSTAVA", DataRowVersion.Original]);
                this.m__MZOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["MZOBUSTAVA", DataRowVersion.Original]);
                this.m__PZOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["PZOBUSTAVA", DataRowVersion.Original]);
                this.m__VBDIOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["VBDIOBUSTAVA", DataRowVersion.Original]);
                this.m__ZRNOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["ZRNOBUSTAVA", DataRowVersion.Original]);
                this.m__PRIMATELJOBUSTAVA1Original = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["PRIMATELJOBUSTAVA1", DataRowVersion.Original]);
                this.m__PRIMATELJOBUSTAVA2Original = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["PRIMATELJOBUSTAVA2", DataRowVersion.Original]);
                this.m__PRIMATELJOBUSTAVA3Original = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["PRIMATELJOBUSTAVA3", DataRowVersion.Original]);
                this.m__SIFRAOPISAPLACANJAOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["SIFRAOPISAPLACANJAOBUSTAVA", DataRowVersion.Original]);
                this.m__OPISPLACANJAOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["OPISPLACANJAOBUSTAVA", DataRowVersion.Original]);
                this.m__VRSTAOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["VRSTAOBUSTAVE", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["NAZIVOBUSTAVA"]);
                this.m__MOOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["MOOBUSTAVA"]);
                this.m__POOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["POOBUSTAVA"]);
                this.m__MZOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["MZOBUSTAVA"]);
                this.m__PZOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["PZOBUSTAVA"]);
                this.m__VBDIOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["VBDIOBUSTAVA"]);
                this.m__ZRNOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["ZRNOBUSTAVA"]);
                this.m__PRIMATELJOBUSTAVA1Original = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["PRIMATELJOBUSTAVA1"]);
                this.m__PRIMATELJOBUSTAVA2Original = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["PRIMATELJOBUSTAVA2"]);
                this.m__PRIMATELJOBUSTAVA3Original = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["PRIMATELJOBUSTAVA3"]);
                this.m__SIFRAOPISAPLACANJAOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["SIFRAOPISAPLACANJAOBUSTAVA"]);
                this.m__OPISPLACANJAOBUSTAVAOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["OPISPLACANJAOBUSTAVA"]);
                this.m__VRSTAOBUSTAVEOriginal = RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["VRSTAOBUSTAVE"]);
            }
            this._Gxremove = this.rowOBUSTAVA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowOBUSTAVA = (OBUSTAVADataSet.OBUSTAVARow) DataSetUtil.CloneOriginalDataRow(this.rowOBUSTAVA);
            }
        }

        private void ScanByIDOBUSTAVA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDOBUSTAVA] = @IDOBUSTAVA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString14 + "  FROM ([OBUSTAVA] TM1 WITH (NOLOCK) INNER JOIN [VRSTEOBUSTAVA] T2 WITH (NOLOCK) ON T2.[VRSTAOBUSTAVE] = TM1.[VRSTAOBUSTAVE])" + this.m_WhereString + " ORDER BY TM1.[IDOBUSTAVA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString14, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOBUSTAVA] ) AS DK_PAGENUM   FROM ([OBUSTAVA] TM1 WITH (NOLOCK) INNER JOIN [VRSTEOBUSTAVA] T2 WITH (NOLOCK) ON T2.[VRSTAOBUSTAVE] = TM1.[VRSTAOBUSTAVE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString14 + " FROM ([OBUSTAVA] TM1 WITH (NOLOCK) INNER JOIN [VRSTEOBUSTAVA] T2 WITH (NOLOCK) ON T2.[VRSTAOBUSTAVE] = TM1.[VRSTAOBUSTAVE])" + this.m_WhereString + " ORDER BY TM1.[IDOBUSTAVA] ";
            }
            this.cmOBUSTAVASelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOBUSTAVASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmOBUSTAVASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBUSTAVA", DbType.Int32));
            }
            this.cmOBUSTAVASelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["IDOBUSTAVA"]));
            this.OBUSTAVASelect5 = this.cmOBUSTAVASelect5.FetchData();
            this.RcdFound14 = 0;
            this.ScanLoadObustava();
            this.LoadDataObustava(maxRows);
        }

        private void ScanByVRSTAOBUSTAVE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[VRSTAOBUSTAVE] = @VRSTAOBUSTAVE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString14 + "  FROM ([OBUSTAVA] TM1 WITH (NOLOCK) INNER JOIN [VRSTEOBUSTAVA] T2 WITH (NOLOCK) ON T2.[VRSTAOBUSTAVE] = TM1.[VRSTAOBUSTAVE])" + this.m_WhereString + " ORDER BY TM1.[IDOBUSTAVA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString14, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOBUSTAVA] ) AS DK_PAGENUM   FROM ([OBUSTAVA] TM1 WITH (NOLOCK) INNER JOIN [VRSTEOBUSTAVA] T2 WITH (NOLOCK) ON T2.[VRSTAOBUSTAVE] = TM1.[VRSTAOBUSTAVE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString14 + " FROM ([OBUSTAVA] TM1 WITH (NOLOCK) INNER JOIN [VRSTEOBUSTAVA] T2 WITH (NOLOCK) ON T2.[VRSTAOBUSTAVE] = TM1.[VRSTAOBUSTAVE])" + this.m_WhereString + " ORDER BY TM1.[IDOBUSTAVA] ";
            }
            this.cmOBUSTAVASelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOBUSTAVASelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmOBUSTAVASelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
            }
            this.cmOBUSTAVASelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["VRSTAOBUSTAVE"]));
            this.OBUSTAVASelect5 = this.cmOBUSTAVASelect5.FetchData();
            this.RcdFound14 = 0;
            this.ScanLoadObustava();
            this.LoadDataObustava(maxRows);
        }

        private void ScanEndObustava()
        {
            this.OBUSTAVASelect5.Close();
        }

        private void ScanLoadObustava()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmOBUSTAVASelect5.HasMoreRows)
            {
                this.RcdFound14 = 1;
                this.rowOBUSTAVA["IDOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OBUSTAVASelect5, 0));
                this.rowOBUSTAVA["NAZIVOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBUSTAVASelect5, 1));
                this.rowOBUSTAVA["MOOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBUSTAVASelect5, 2));
                this.rowOBUSTAVA["POOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBUSTAVASelect5, 3));
                this.rowOBUSTAVA["MZOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBUSTAVASelect5, 4));
                this.rowOBUSTAVA["PZOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBUSTAVASelect5, 5));
                this.rowOBUSTAVA["VBDIOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBUSTAVASelect5, 6));
                this.rowOBUSTAVA["ZRNOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBUSTAVASelect5, 7));
                this.rowOBUSTAVA["PRIMATELJOBUSTAVA1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBUSTAVASelect5, 8));
                this.rowOBUSTAVA["PRIMATELJOBUSTAVA2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBUSTAVASelect5, 9));
                this.rowOBUSTAVA["PRIMATELJOBUSTAVA3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBUSTAVASelect5, 10));
                this.rowOBUSTAVA["SIFRAOPISAPLACANJAOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBUSTAVASelect5, 11));
                this.rowOBUSTAVA["OPISPLACANJAOBUSTAVA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBUSTAVASelect5, 12));
                this.rowOBUSTAVA["NAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBUSTAVASelect5, 13));
                this.rowOBUSTAVA["VRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.OBUSTAVASelect5, 14));
                this.rowOBUSTAVA["NAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OBUSTAVASelect5, 13));
            }
        }

        private void ScanNextObustava()
        {
            this.cmOBUSTAVASelect5.HasMoreRows = this.OBUSTAVASelect5.Read();
            this.RcdFound14 = 0;
            this.ScanLoadObustava();
        }

        private void ScanStartObustava(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString14 + "  FROM ([OBUSTAVA] TM1 WITH (NOLOCK) INNER JOIN [VRSTEOBUSTAVA] T2 WITH (NOLOCK) ON T2.[VRSTAOBUSTAVE] = TM1.[VRSTAOBUSTAVE])" + this.m_WhereString + " ORDER BY TM1.[IDOBUSTAVA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString14, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOBUSTAVA] ) AS DK_PAGENUM   FROM ([OBUSTAVA] TM1 WITH (NOLOCK) INNER JOIN [VRSTEOBUSTAVA] T2 WITH (NOLOCK) ON T2.[VRSTAOBUSTAVE] = TM1.[VRSTAOBUSTAVE]) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString14 + " FROM ([OBUSTAVA] TM1 WITH (NOLOCK) INNER JOIN [VRSTEOBUSTAVA] T2 WITH (NOLOCK) ON T2.[VRSTAOBUSTAVE] = TM1.[VRSTAOBUSTAVE])" + this.m_WhereString + " ORDER BY TM1.[IDOBUSTAVA] ";
            }
            this.cmOBUSTAVASelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.OBUSTAVASelect5 = this.cmOBUSTAVASelect5.FetchData();
            this.RcdFound14 = 0;
            this.ScanLoadObustava();
            this.LoadDataObustava(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.OBUSTAVASet = (OBUSTAVADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.OBUSTAVASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.OBUSTAVASet.OBUSTAVA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        OBUSTAVADataSet.OBUSTAVARow current = (OBUSTAVADataSet.OBUSTAVARow) enumerator.Current;
                        this.rowOBUSTAVA = current;
                        if (Helpers.IsRowChanged(this.rowOBUSTAVA))
                        {
                            this.ReadRowObustava();
                            if (this.rowOBUSTAVA.RowState == DataRowState.Added)
                            {
                                this.InsertObustava();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateObustava();
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

        private void UpdateObustava()
        {
            this.CheckOptimisticConcurrencyObustava();
            this.CheckExtendedTableObustava();
            this.AfterConfirmObustava();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [OBUSTAVA] SET [NAZIVOBUSTAVA]=@NAZIVOBUSTAVA, [MOOBUSTAVA]=@MOOBUSTAVA, [POOBUSTAVA]=@POOBUSTAVA, [MZOBUSTAVA]=@MZOBUSTAVA, [PZOBUSTAVA]=@PZOBUSTAVA, [VBDIOBUSTAVA]=@VBDIOBUSTAVA, [ZRNOBUSTAVA]=@ZRNOBUSTAVA, [PRIMATELJOBUSTAVA1]=@PRIMATELJOBUSTAVA1, [PRIMATELJOBUSTAVA2]=@PRIMATELJOBUSTAVA2, [PRIMATELJOBUSTAVA3]=@PRIMATELJOBUSTAVA3, [SIFRAOPISAPLACANJAOBUSTAVA]=@SIFRAOPISAPLACANJAOBUSTAVA, [OPISPLACANJAOBUSTAVA]=@OPISPLACANJAOBUSTAVA, [VRSTAOBUSTAVE]=@VRSTAOBUSTAVE  WHERE [IDOBUSTAVA] = @IDOBUSTAVA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVOBUSTAVA", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MOOBUSTAVA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POOBUSTAVA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MZOBUSTAVA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PZOBUSTAVA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VBDIOBUSTAVA", DbType.String, 7));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZRNOBUSTAVA", DbType.String, 10));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOBUSTAVA1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOBUSTAVA2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRIMATELJOBUSTAVA3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAOBUSTAVA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAOBUSTAVA", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBUSTAVA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["NAZIVOBUSTAVA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["MOOBUSTAVA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["POOBUSTAVA"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["MZOBUSTAVA"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["PZOBUSTAVA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["VBDIOBUSTAVA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["ZRNOBUSTAVA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["PRIMATELJOBUSTAVA1"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["PRIMATELJOBUSTAVA2"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["PRIMATELJOBUSTAVA3"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["SIFRAOPISAPLACANJAOBUSTAVA"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["OPISPLACANJAOBUSTAVA"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["VRSTAOBUSTAVE"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowOBUSTAVA["IDOBUSTAVA"]));
            command.ExecuteStmt();
            new obustavaupdateredundancy(ref this.dsDefault).execute(this.rowOBUSTAVA.IDOBUSTAVA);
            this.OnOBUSTAVAUpdated(new OBUSTAVAEventArgs(this.rowOBUSTAVA, StatementType.Update));
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
        public class OBRACUNObustaveInvalidDeleteException : InvalidDeleteException
        {
            public OBRACUNObustaveInvalidDeleteException()
            {
            }

            public OBRACUNObustaveInvalidDeleteException(string message) : base(message)
            {
            }

            protected OBRACUNObustaveInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBRACUNObustaveInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OBUSTAVADataChangedException : DataChangedException
        {
            public OBUSTAVADataChangedException()
            {
            }

            public OBUSTAVADataChangedException(string message) : base(message)
            {
            }

            protected OBUSTAVADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBUSTAVADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OBUSTAVADataLockedException : DataLockedException
        {
            public OBUSTAVADataLockedException()
            {
            }

            public OBUSTAVADataLockedException(string message) : base(message)
            {
            }

            protected OBUSTAVADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBUSTAVADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OBUSTAVADuplicateKeyException : DuplicateKeyException
        {
            public OBUSTAVADuplicateKeyException()
            {
            }

            public OBUSTAVADuplicateKeyException(string message) : base(message)
            {
            }

            protected OBUSTAVADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBUSTAVADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class OBUSTAVAEventArgs : EventArgs
        {
            private OBUSTAVADataSet.OBUSTAVARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public OBUSTAVAEventArgs(OBUSTAVADataSet.OBUSTAVARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OBUSTAVADataSet.OBUSTAVARow Row
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
        public class OBUSTAVANotFoundException : DataNotFoundException
        {
            public OBUSTAVANotFoundException()
            {
            }

            public OBUSTAVANotFoundException(string message) : base(message)
            {
            }

            protected OBUSTAVANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OBUSTAVANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void OBUSTAVAUpdateEventHandler(object sender, OBUSTAVADataAdapter.OBUSTAVAEventArgs e);

        [Serializable]
        public class RADNIKObustavaInvalidDeleteException : InvalidDeleteException
        {
            public RADNIKObustavaInvalidDeleteException()
            {
            }

            public RADNIKObustavaInvalidDeleteException(string message) : base(message)
            {
            }

            protected RADNIKObustavaInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKObustavaInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VRSTAOBUSTAVEOutOfRangeException : UserException
        {
            public VRSTAOBUSTAVEOutOfRangeException()
            {
            }

            public VRSTAOBUSTAVEOutOfRangeException(string message) : base(message)
            {
            }

            protected VRSTAOBUSTAVEOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTAOBUSTAVEOutOfRangeException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VRSTEOBUSTAVAForeignKeyNotFoundException : Deklarit.ForeignKeyNotFoundException
        {
            public VRSTEOBUSTAVAForeignKeyNotFoundException()
            {
            }

            public VRSTEOBUSTAVAForeignKeyNotFoundException(string message) : base(message)
            {
            }

            protected VRSTEOBUSTAVAForeignKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VRSTEOBUSTAVAForeignKeyNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

